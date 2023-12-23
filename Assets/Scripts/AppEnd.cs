using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManager;

public class AppEnd : MonoBehaviour
{
    [SerializeField, Header("�`�����l��")]
    private int _Channel;
    public void EndClick()
    {
        SoundManager.instance.PlayAudioSorce(AudioOfType.SYSTEMSE, _Channel);
        Application.Quit();
    }
}
