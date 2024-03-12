using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class SoundAtatti : MonoBehaviour
{
    [SerializeField]
    private int num;
    UnityEngine.UI.Slider slider;

    void Start()
    {
        slider = this.GetComponent<UnityEngine.UI.Slider>();
        switch (num)
        {
            case 0:
                {
                    slider.value = SoundManager.instance.BGMVolume;
                    slider.onValueChanged.AddListener(ValueChangeCheck);
                    break;
                }
            case 1:
                {
                    slider.value = SoundManager.instance.SEVolume;
                    slider.onValueChanged.AddListener(ValueChangeCheck);
                    break;
                }
        }
    }

    void ValueChangeCheck(float value)
    {
        switch (num)
        {
            case 0:
                {
                    SoundManager.instance.BGMVolume = value;
                    break;
                }
            case 1:
                {
                    SoundManager.instance.SEVolume = value;
                    break;
                }
        }
    }
}
