using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SoundManager;

public class RandMark : MonoBehaviour
{
    [SerializeField, Header("建物の名所")]
    private GameObject _randMarkTest;
    // ボタンを押したときの処理
    public void OnButtonDown()
    {
        Debug.Log("Down");
        _randMarkTest.SetActive(true);
    }
    // ボタンを離したときの処理
    public void OnButtonUp()
    {
        Debug.Log("Up");
        _randMarkTest.SetActive(false);
    }
}
