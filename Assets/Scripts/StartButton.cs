using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartClick()
    {
        SceneManager.LoadScene("MainScene");
        SoundManager.instance.PlayAudioSorce(SoundManager.AudioOfType.BGM, 1);
    }
}
