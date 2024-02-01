using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpSelect : MonoBehaviour
{
    [SerializeField]
    PopUpMg _popUpMg;
    [SerializeField]
    private int Select;
    [SerializeField]
    private GameObject _gameObject;
    public void PopUpSelectClick()
    {
        SoundManager.instance.PlayAudioSorce(SoundManager.AudioOfType.SYSTEMSE, 0);
        _gameObject.SetActive(true);
        _popUpMg.PopUpImageChange(Select);
    }
}