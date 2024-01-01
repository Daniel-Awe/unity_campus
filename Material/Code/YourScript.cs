using UnityEngine;

public class YourScript : MonoBehaviour
{
    private void YourMethod()
    {
        // 获取名为 "House1" 的物体上的 EQ 组件
        EQ eqScript = GameObject.Find("House1").GetComponent<EQ>();

        // 检查是否成功获取 EQ 组件
        if (eqScript != null)
        {
            // 访问 EQ 组件中的 Level 属性
            float levelValue = eqScript.level;

            // 使用 levelValue 进行其他操作
        }
        else
        {
            Debug.LogError("Cannot find EQ script on the object named 'House1'. Make sure the object exists and has the EQ script.");
        }
    }
}
