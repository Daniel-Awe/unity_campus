using UnityEngine;
using System.Collections;

public class EQAttach : MonoBehaviour {
	[HideInInspector]
	public Vector3 basePos;
	public float mass=1f;
	public float counteract=1f;
	public float hp=100f;
	private void Awake(){
		basePos=this.transform.position;
	}
	private void Update(){
		if(mass<=0f){
			mass=0.01f;
		}
		if(hp<=0f){
			//附加Dynamic类并继承质量
			EQDynamic tempDynamicC=this.gameObject.AddComponent<EQDynamic>();
			tempDynamicC.mass=mass;
			tempDynamicC.gameObject.AddComponent<Rigidbody>();
			//对EQ的地震列表进行处理
			EQ.thisC.listAttachC.Remove(this);
			EQ.thisC.listDynamicC.Add(tempDynamicC);
			//销毁Attach类
			Destroy(this);
		}
	}
}
