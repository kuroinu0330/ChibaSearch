using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SoundManager;

public class RandMark : MonoBehaviour
{
    [SerializeField, Header("建物の名所")]
    private GameObject _RandMarkTest;
    [SerializeField,Tooltip("カウント")]
    private int _Count;
    [SerializeField, Tooltip("カウント")]
    private float _Time;
    //[SerializeField]
    //private Button _button;
    [SerializeField]
    TrackingMousePosition _trackingmousePosition;
    // Start is called before the first frame update
    private void Start()
    {
        //_button = GetComponent<Button>();
    }
    private void Update()
    {
        //Debug.Log(_Time);
    }
    /*public void OnTextClick()
    {
        SoundManager.instance.PlayAudioSorce(AudioOfType.SYSTEMSE, 0);
        _Count++;
        switch (_Count)
        {
            case 1:
                StartCoroutine(TextCoroutine());
                break;
            case 2:
                _RandMarkTest.SetActive(false);
                _Count = 0;
                break;
        }
    }
    private IEnumerator TextCoroutine()
    {
        //_button.interactable = false;
        _RandMarkTest.SetActive(true);
        _trackingmousePosition.canMoveFlag = true;
        yield return new WaitForSeconds(_Time);
        _Count = 0;
        _RandMarkTest.SetActive(false);
        //_button.interactable = true;
        yield break;
    }*/
    // ボタンを押したときの処理
    public void OnButtonDown()
    {
        Debug.Log("Down");
        _RandMarkTest.SetActive(true);
    }
    // ボタンを離したときの処理
    public void OnButtonUp()
    {
        Debug.Log("Up");
        _RandMarkTest.SetActive(false);
    }
}
