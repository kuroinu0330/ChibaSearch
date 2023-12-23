using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManager;

public class AppEnd : MonoBehaviour
{
    [SerializeField, Header("ƒ`ƒƒƒ“ƒlƒ‹")]
    private int _Channel;
    public void EndClick()
    {
        SoundManager.instance.PlayAudioSorce(AudioOfType.SYSTEMSE, _Channel);
        Application.Quit();
    }
}
