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
        // _bookButton.transform.position = new Vector3(1800, 150, 0);
        // _plusButton.transform.position = new Vector3(1800, 600, 0);
        // _minusButton.transform.position = new Vector3(1800, 430, 0);
        _bookButton.transform.localPosition = new Vector3(_bookButton.transform.localPosition.x * -1f,
            _bookButton.transform.localPosition.y, _bookButton.transform.localPosition.z);
        _plusButton.transform.localPosition = new Vector3(_plusButton.transform.localPosition.x * -1f,
            _plusButton.transform.localPosition.y, _plusButton.transform.localPosition.z);
        _minusButton.transform.localPosition = new Vector3(_minusButton.transform.localPosition.x * -1f,
            _minusButton.transform.localPosition.y, _minusButton.transform.localPosition.z);
        //trackingMousePosition.LRKey = TrackingMousePosition.LeftRightKey.Right;
        _RightButton.SetActive(false);
        _LeftButton.SetActive(true);
        _bookButton.GetComponent<Image>().sprite = spriteMae;
    }
}
