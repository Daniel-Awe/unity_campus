using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoginManager : MonoBehaviour
{
    public Text loginText;
    public Text registerText;

    void Start()
    {
        // 隐藏登录成功文字
        loginText.gameObject.SetActive(false);
        registerText.gameObject.SetActive(false);
    }

    public void OnLoginButtonClick()
    {
        // 在此处添加登录逻辑，成功则显示文本，然后启动计时器
        // 这里简单地使用 Invoke 方法模拟登录成功后的操作

        // 模拟登录成功后显示文本
        ShowLoginText();

        // 5秒后隐藏文本
        Invoke("HideLoginText", 5f);
    }

    void ShowLoginText()
    {
        // 显示登录成功文字
        loginText.gameObject.SetActive(true);
    }

    void HideLoginText()
    {
        // 隐藏登录成功文字
        loginText.gameObject.SetActive(false);
    }
}
