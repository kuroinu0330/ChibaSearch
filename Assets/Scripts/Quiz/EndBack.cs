using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBack : MonoBehaviour
{
    [SerializeField]
    public GameObject endBackimage;
    public void EndClick()
    {
        endBackimage.SetActive(true);
        SoundManager.instance.PlayAudioSorce(SoundManager.AudioOfType.SYSTEMSE, 0);
    }
}
