using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SoundManager;

public class RandMark : MonoBehaviour
{
    [SerializeField, Header("�����̖���")]
    private GameObject _randMarkTest;
    // �{�^�����������Ƃ��̏���
    public void OnButtonDown()
    {
        Debug.Log("Down");
        _randMarkTest.SetActive(true);
    }
    // �{�^���𗣂����Ƃ��̏���
    public void OnButtonUp()
    {
        Debug.Log("Up");
        _randMarkTest.SetActive(false);
    }
}
