using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseUIPanel : MonoBehaviour
{
    public Canvas canvas;

    void Start()
    {
        if (canvas == null)
        {
            Debug.LogError("Canvas reference not set in the inspector!");
        }
    }

    public void CloseCanvas()
    {
        canvas.gameObject.SetActive(false);
    }
}
