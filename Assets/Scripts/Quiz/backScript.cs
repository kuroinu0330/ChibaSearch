using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backScript : MonoBehaviour
{
    [SerializeField]
    public GameObject _image;
    public void BackImage()
    {
        _image.SetActive(false);
    }
}
