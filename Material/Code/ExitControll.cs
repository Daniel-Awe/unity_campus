using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitControll : MonoBehaviour
{
    // 此方法将在按钮被点击时被调用
    public void Exit()
    {
        Debug.Log("退出游戏"); // 这行代码可以根据需要进行调整，用于在编辑器中测试

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
