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
        SoundManager.instance.PlayAudioSorce(SoundManager.AudioOfType.SYSTEMSE, 0);
        _bookButton.transform.localPosition = new Vector3(_bookButton.transform.localPosition.x * -1f,
            _bookButton.transform.localPosition.y, _bookButton.transform.localPosition.z);
        _plusButton.transform.localPosition = new Vector3(_plusButton.transform.localPosition.x * -1f,
            _plusButton.transform.localPosition.y, _plusButton.transform.localPosition.z);
        _minusButton.transform.localPosition = new Vector3(_minusButton.transform.localPosition.x * -1f,
            _minusButton.transform.localPosition.y, _minusButton.transform.localPosition.z);
        _RightButton.SetActive(true);
        _LeftButton.SetActive(false);
        _bookButton.GetComponent<Image>().sprite = spriteAto;
    }
}
