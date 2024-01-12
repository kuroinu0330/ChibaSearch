using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LeftButton : MonoBehaviour
{
    [SerializeField]
    private GameObject _bookButton;
    [SerializeField]
    private GameObject _plusButton;
    [SerializeField]
    private GameObject _minusButton;
    [SerializeField]
    TrackingMousePosition trackingMousePosition;
    [SerializeField]
    private GameObject _LeftButton;
    [SerializeField]
    private GameObject _RightButton;
    [SerializeField]
    public Sprite spriteMae;
    [SerializeField]
    public Sprite spriteAto;
    // Update is called once per frame
    public void LeftUi()
    {
        _bookButton.transform.position = new Vector3(130,160,0);
        _plusButton.transform.position = new Vector3(125,620,0);
        _minusButton.transform.position = new Vector3(125,445,0);
        //trackingMousePosition.LRKey = TrackingMousePosition.LeftRightKey.Left;
        _RightButton.SetActive(true);
        _LeftButton.SetActive(false);
        _bookButton.GetComponent<Image>().sprite = spriteAto;
    }
}
