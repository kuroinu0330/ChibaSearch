using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManager;

public class RandMark : MonoBehaviour
{
    [SerializeField, Header("�����̖���")]
    private GameObject _RandMarkTest;
    [SerializeField,Tooltip("�J�E���g")]
    private int _Count;
    [SerializeField, Tooltip("�J�E���g")]
    private float _Time;
    // Start is called before the first frame update
    private void Update()
    {
        //Debug.Log(_Time);
    }
    public void OnTextClick()
    {
        SoundManager.instance.PlayAudioSorce(AudioOfType.SYSTEMSE, 0);
        _Count++;
        if (_Count == 1)
        {
            _RandMarkTest.SetActive(true);
            Invoke(nameof(TextTime), _Time);
        }
        if (_Count == 2)
        {
            _RandMarkTest.SetActive(false);
            _Count = 0;
        }
    }
    private void TextTime()
    {
        _RandMarkTest.SetActive(false);
        _Count = 0;
    }
}
