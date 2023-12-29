using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManager;

public class BookBack : MonoBehaviour
{
    [SerializeField, Header("ƒ`ƒƒƒ“ƒlƒ‹")]
    private int _Channel;
    [SerializeField]
    private GameObject _BookBack;
    public void _BookBackClick()
    {
        if (_BookBack == null)
        {

        }
        else
        {
            SoundManager.instance.PlayAudioSorce(AudioOfType.SYSTEMSE, _Channel);
            _BookBack.SetActive(false);
        }
    }
}
