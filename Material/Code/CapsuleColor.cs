using UnityEngine;
using Sirenix.OdinInspector;

public class CapsuleColor : MonoBehaviour
{
    [GUIColor(0.3f, 0.8f, 0.8f, 1f)]
    public int ColoredInt1;

    [ColorPalette("Fall")]
    public Color Color1;

    [Button("ChangeColor", ButtonSizes.Small)]
    private void ChangeColor()
    {
        // 获取Capsule的Renderer组件
        Renderer renderer = GetComponent<Renderer>();

        // 检查是否存在Renderer组件
        if (renderer != null)
        {
            // 随机生成一个颜色
            Color randomColor = Color1;

            // 修改材质颜色
            renderer.material.color = randomColor;

            Debug.Log("Capsule颜色已更改为: " + randomColor);
        }
        else
        {
            Debug.LogError("未找到Renderer组件，请确保Capsule对象上有Renderer组件。");
        }
    }

}
