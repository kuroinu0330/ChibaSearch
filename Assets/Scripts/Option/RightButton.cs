using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightButton : MonoBehaviour
{
    [SerializeField]
    private GameObject _bookButton;
    [SerializeField]
    private GameObject _plusButton;
    [SerializeField]
    TrackingMousePosition trackingMousePosition;
    [SerializeField]
    private GameObject _minusButton;
    [SerializeField]
    private GameObject _LeftButton;
    [SerializeField]
    private GameObject _RightButton;
    [SerializeField]
    public Sprite spriteMae;
    [SerializeField]
    public Sprite spriteAto;
    public void LightUi()
    {
        _bookButton.transform.position = new Vector3(1800, 150, 0);
        _plusButton.transform.position = new Vector3(1800, 600, 0);
        _minusButton.transform.position = new Vector3(1800, 430, 0);
        trackingMousePosition.LRKey = TrackingMousePosition.LeftRightKey.Right;
        _RightButton.SetActive(false);
        _LeftButton.SetActive(true);
        _bookButton.GetComponent<Image>().sprite = spriteMae;
    }
}
