using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SliderControll : MonoBehaviour
{

    public Slider eqSlider;
    public GameObject House1;
    public GameObject House2;
    public GameObject House3;
    public GameObject House4;

    private void Start()
    {
        eqSlider.onValueChanged.AddListener(UpdateEQLevel);
        Debug.Log("onValueChanged event added to Slider. Initial EQ Level: " + House1.GetComponent<EQ>().level);
    }

    void UpdateEQLevel(float value)
    {
        SetEQLevel(House1, value);
        SetEQLevel(House2, value);
        SetEQLevel(House3, value);
        SetEQLevel(House4, value);
        Debug.Log("EQ Level: " + House1.GetComponent<EQ>().level);
    }

    void SetEQLevel(GameObject house, float value)
    {
        EQ eqComponent = house.GetComponent<EQ>();
        if (eqComponent != null)
        {
            eqComponent.level = value;
        }
    }
}
