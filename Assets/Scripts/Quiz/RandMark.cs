using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SoundManager;

public class RandMark : MonoBehaviour
{
    [SerializeField, Header("�����̖���")]
    private GameObject _randMark;
    // �{�^�����������Ƃ��̏���
    public void OnButtonDown()
    {
        Debug.Log("Down");
        _randMark.SetActive(true);
    }
    // �{�^���𗣂����Ƃ��̏���
    public void OnButtonUp()
    {
        Debug.Log("Up");
        _randMark.SetActive(false);
    }
}
