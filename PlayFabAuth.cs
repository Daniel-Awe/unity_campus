// using UnityEngine;
// using UnityEngine.UI;
// using PlayFab;
// using PlayFab.ClientModels;

// public class PlayFabAuth : MonoBehaviour
// {
//     public InputField emailInput;
//     public InputField passwordInput;
//     public InputField usernameInput;

//     // ע�����û�
//     public void Register()
//     {
//         if (string.IsNullOrEmpty(emailInput.text))
//         {
//             Debug.LogError("�����ʼ���ַ����Ϊ�գ�");
//             return;
//         }
//         if (string.IsNullOrEmpty(passwordInput.text))
//         {
//             Debug.LogError("���벻��Ϊ�գ�");
//             return;
//         }
//         var request = new RegisterPlayFabUserRequest
//         {
//             Username = usernameInput.text,
//             Email = emailInput.text,
//             Password = passwordInput.text
//         };

//         PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnFail);
//     }

//     // ��¼�����û�
//     public void Login()
//     {
//         var request = new LoginWithEmailAddressRequest
//         {
//             Email = emailInput.text,
//             Password = passwordInput.text
//         };

//         PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnFail);
//     }

//     // ע��ɹ��Ļص�
//     private void OnRegisterSuccess(RegisterPlayFabUserResult result)
//     {
//         Debug.Log("ע��ɹ���");
//     }

//     // ��¼�ɹ��Ļص�
//     private void OnLoginSuccess(LoginResult result)
//     {
//         Debug.Log("��¼�ɹ���");
//     }

//     // ����ʧ�ܵĻص�
//     private void OnFail(PlayFabError error)
//     {
//         Debug.LogError(error.GenerateErrorReport());
//     }
// }

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
    public Text feedbackText; // 用于显示反馈信息的 UI Text 元素
    public Canvas canvas; // Canvas 的 CanvasGroup 组件

    // 注册用户
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
        ShowFeedbackText("注册成功！", 5f); // 5秒后隐藏反馈文本
    }

    // 登录成功的回调
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("登录成功");
        ShowFeedbackText("登录成功！", 3f); // 3秒后隐藏反馈文本
    }

    // 失败的回调
    private void OnFail(PlayFabError error)
    {
        //Debug.LogError(error.GenerateErrorReport());
        feedbackText.text = "操作错误：" + error.ErrorMessage; // 5秒后隐藏反馈文本
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
        // 等待指定的时间
        yield return new WaitForSeconds(delayInSeconds);

        // 隐藏反馈文本并关闭 Canvas
        feedbackText.text = "";
        canvas.gameObject.SetActive(false);
    }
}
