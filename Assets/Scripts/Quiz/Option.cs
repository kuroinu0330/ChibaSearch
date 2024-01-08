using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    [SerializeField]
    public GameObject _optionImag;
    public void OptionCreate()
    {
        _optionImag.SetActive(true);
    }
}
