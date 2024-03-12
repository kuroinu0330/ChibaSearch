using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backScript : MonoBehaviour
{
    [SerializeField]
    public GameObject _image;
    public void BackImage()
    {
        _image.SetActive(false);
        // 移動可能フラグを有効化
        TrackingMousePosition.Instance.UIButtomExit();
        SoundManager.instance.PlayAudioSorce(SoundManager.AudioOfType.SYSTEMSE, 0);
    }
}
