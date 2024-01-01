using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SliderControll : MonoBehaviour
{

    public Slider eqSlider;  // 引用Slider组件
    public GameObject House1;  // 引用House1物体

    private EQ eqComponent;  // 用于保存House1上的EQ组件

    void Start()
    {
        eqComponent = House1.GetComponent<EQ>();  // 获取House1上的EQ组件
        eqSlider.onValueChanged.AddListener(UpdateEQLevel);  // 添加滑动条值改变的监听器
        Debug.Log("onValueChanged event added to Slider." + eqComponent.level);
    }


    // 当Slider值改变时调用的方法
    void UpdateEQLevel(float value)
    {
        eqComponent.level = value;  // 更新EQ组件中的Level值
        Debug.Log("EQ Level: " + eqComponent.level);  // 输出到控制台
    }
}
