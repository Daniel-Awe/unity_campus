using UnityEngine;
using System.Collections;
using System.Collections.Generic;
// 我的添加
using UnityEngine.UI;

public class EQ : MonoBehaviour
{
	public static EQ thisC;
	//震动级别
	public float level = 0f;
	//水平力
	public float xPower = 0f;
	//垂直力
	public float yPower = 0f;
	//检查值是否发生变化
	private float symbolLevel;
	private float symbolPower;
	//缓存动态
	[HideInInspector]
	public List<EQDynamic> listDynamicC;
	//缓存整体
	[HideInInspector]
	public List<EQFixed> listFixedC;
	//缓存附着
	[HideInInspector]
	public List<EQAttach> listAttachC;
	private void Awake()
	{

		thisC = this;
		symbolLevel = level;
		symbolPower = xPower + yPower;
		foreach (EQDynamic loopDynamicC in this.transform.GetComponentsInChildren<EQDynamic>(true))
		{
			listDynamicC.Add(loopDynamicC);
		}
		foreach (EQFixed loopFixedC in this.transform.GetComponentsInChildren<EQFixed>(true))
		{
			listFixedC.Add(loopFixedC);
		}
		foreach (EQAttach loopAttachC in this.transform.GetComponentsInChildren<EQAttach>(true))
		{
			listAttachC.Add(loopAttachC);
		}

	}
	private void Update()
	{
		//限制值不为负数
		if (level <= 0f)
		{
			level = 0f;
		}
		if (xPower <= 0f)
		{
			xPower = 0f;
		}
		if (yPower <= 0f)
		{
			yPower = 0f;
		}
		//当等级发生变化，xyPower重新分配
		if (symbolLevel != level)
		{
			symbolLevel = level;
			//重新分配
			xPower = level;
			yPower = level;
			symbolPower = xPower + yPower;
		}
		//当Pwoer发生变化，level重新分配
		if (symbolPower != xPower + yPower)
		{
			symbolPower = xPower + yPower;
			//重新分配
			level = symbolPower / 2f;
			symbolLevel = level;
		}
		//获取随机的力
		float tempRandomXPower = Random.Range(-xPower, xPower);
		float tempRandomYPower = Random.Range(-yPower, yPower);
		//遍历物体并施加力
		foreach (EQDynamic loopDynamicC in listDynamicC)
		{
			//偏移量
			Vector3 tempOffsetPos = new Vector3(tempRandomXPower, tempRandomYPower, tempRandomXPower) / (10f * loopDynamicC.mass);
			//加上loopDynamicC.rigidbody.velocity的话可以继承上一次的速度值，不加的话会约束便宜量
			Vector3 tempNewPos = loopDynamicC.GetComponent<Rigidbody>().velocity + tempOffsetPos;
			loopDynamicC.GetComponent<Rigidbody>().velocity = tempNewPos;
		}
		foreach (EQFixed loopFixedC in listFixedC)
		{
			//偏移量
			Vector3 tempOffsetPos = new Vector3(tempRandomXPower, tempRandomYPower, tempRandomXPower) / 140f;
			//加上basePos可以限制偏移量
			Vector3 tempNewPos = loopFixedC.basePos + tempOffsetPos;
			loopFixedC.transform.position = tempNewPos;
		}
		foreach (EQAttach loopAttachC in listAttachC)
		{
			//偏移量
			Vector3 tempOffsetPos = new Vector3(tempRandomXPower, tempRandomYPower, tempRandomXPower) / 140f;
			//加上basePos可以限制偏移量
			Vector3 tempNewPos = loopAttachC.basePos + tempOffsetPos;
			loopAttachC.transform.position = tempNewPos;
			//检查抵消值和偏移量
			float tempOffsetValue = tempRandomXPower + tempRandomYPower + tempRandomXPower;
			tempOffsetValue -= loopAttachC.counteract;
			if (tempOffsetValue >= 0f)
			{
				//耐久度减去多出的偏移量
				loopAttachC.hp -= tempOffsetValue;
			}
		}
	}
	[ContextMenu("Add")]
	private void Add()
	{
		//快速给动态刚体附加Dynamic标记
		Rigidbody[] tempRigidbodys = this.transform.GetComponentsInChildren<Rigidbody>(true);
		foreach (Rigidbody loopRigidbody in tempRigidbodys)
		{
			if (loopRigidbody.GetComponent<EQDynamic>() == null)
			{
				loopRigidbody.gameObject.AddComponent<EQDynamic>();
			}
		}
		//快速给固定整体附加Fixed标记
		Transform tempTra = this.transform.Find("Fixed");
		if (tempTra.GetComponent<EQFixed>() == null)
		{
			tempTra.gameObject.AddComponent<EQFixed>();
		}
		//快速给固定整体附加Attach标记
		tempTra = this.transform.Find("Attach");
		foreach (Transform loopTra in tempTra)
		{
			if (loopTra.GetComponent<EQAttach>() == null)
			{
				loopTra.gameObject.AddComponent<EQAttach>();
			}
		}
	}
	[ContextMenu("Remove")]
	private void Remove()
	{
		//快速清除所有标记
		EQDynamic[] tempDynamicCs = this.transform.GetComponentsInChildren<EQDynamic>(true);
		foreach (EQDynamic loopDynamicC in tempDynamicCs)
		{
			//即时销毁
			DestroyImmediate(loopDynamicC);
		}
		EQFixed[] tempFixedCs = this.transform.GetComponentsInChildren<EQFixed>(true);
		foreach (EQFixed loopFixedC in tempFixedCs)
		{
			//即时销毁
			DestroyImmediate(loopFixedC);
		}
		EQAttach[] tempAttachCs = this.transform.GetComponentsInChildren<EQAttach>(true);
		foreach (EQAttach loopAttachC in tempAttachCs)
		{
			//即时销毁
			DestroyImmediate(loopAttachC);
		}
	}

	// 添加一个方法来关闭Canvas
	public void SetLevelFromSlider(float sliderValue)
	{
		level = sliderValue;
	}
}
