using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections;

public class PlayFabAuth : MonoBehaviour
{
    public InputField emailInput;
    public InputField passwordInput;
    public InputField usernameInput;
    public Text feedbackText;
    public Canvas canvas;

    public void Register()
    {
        if (string.IsNullOrEmpty(emailInput.text) || string.IsNullOrEmpty(passwordInput.text))
        {
            Debug.LogError("邮箱地址和密码不能为空");
            return;
        }

        var request = new RegisterPlayFabUserRequest
        {
            Username = usernameInput.text,
            Email = emailInput.text,
            Password = passwordInput.text
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnFail);
    }

    // 登录用户
    public void Login()
    {
        if (string.IsNullOrEmpty(emailInput.text) || string.IsNullOrEmpty(passwordInput.text))
        {
            Debug.LogError("邮箱地址和密码不能为空");
            return;
        }

        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text
        };

        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnFail);
    }

    // 注册成功的回调
    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("注册成功");
        ShowFeedbackText("注册成功！", 5f);
    }

    // 登录成功的回调
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("登录成功");
        ShowFeedbackText("登录成功！", 3f);
    }

    // 失败的回调
    private void OnFail(PlayFabError error)
    {
        //Debug.LogError(error.GenerateErrorReport());
        feedbackText.text = "操作错误：" + error.ErrorMessage;
    }

    // 显示反馈文本
    private void ShowFeedbackText(string message, float delayInSeconds)
    {
        feedbackText.text = message + " (关闭倒计时: " + delayInSeconds.ToString("F0") + "秒)";
        StartCoroutine(HideFeedbackTextAfterDelay(delayInSeconds));
    }

    // 隐藏反馈文本并关闭 Canvas
    private IEnumerator HideFeedbackTextAfterDelay(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);

        feedbackText.text = "";
        canvas.gameObject.SetActive(false);
    }
}
