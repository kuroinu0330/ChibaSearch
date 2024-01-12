using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManager;

public class BookBack : MonoBehaviour
{
    [SerializeField, Header("�`�����l��")]
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
            // 移動可能フラグを有効化
            TrackingMousePosition.instace.UIButtomExit();
        }
    }
}
