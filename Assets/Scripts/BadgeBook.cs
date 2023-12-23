using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SoundManager;

public class BadgeBook : MonoBehaviour
{
    [SerializeField]
    private GameObject _Book;
    public void BadgeClick()
    {
        if (_Book == null)
        {

        }
        else
        {
            SoundManager.instance.PlayAudioSorce(AudioOfType.SYSTEMSE, 8);
            _Book.SetActive(true);
        }
    }
}
