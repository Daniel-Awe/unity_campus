using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasClose : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas canvas; // 引用Canvas组件

    void Start()
    {
        // 获取Canvas组件，确保在Inspector中将Canvas分配给这个变量
        if (canvas == null)
        {
            Debug.LogError("Canvas reference not set in the inspector!");
        }
    }

    // 由按钮调用的方法，用于关闭Canvas
    public void CloseCanvas()
    {
        canvas.gameObject.SetActive(false); // 关闭Canvas
    }
}
