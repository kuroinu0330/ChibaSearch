using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SoundManager;

public class Quizcreate : MonoBehaviour
{
    [SerializeField]
    private Transform[] _ButtonTop;
    [SerializeField]
    private Transform[] _ButtonBottom;

    [SerializeField, Header("チャンネル")]
    private int _Channel;

    [SerializeField]
    private GameObject QuizPrefab;

    [SerializeField]
    QuizMg quizMg;

    [SerializeField]
    public int num;

    [SerializeField]
    GameObject canvas;

    //TrackingMousePosition trackingMousePosition;
    public void Quizcreate1()
    {
        SoundManager.instance.PlayAudioSorce(AudioOfType.BGM, _Channel);
        if (QuizPrefab == null)
        {
            
        }
        else
        {
            QuizMg.instance.ButtonControllerA.InteractiveOn();
            QuizMg.instance.ButtonControllerB.InteractiveOn();
            QuizMg.instance.badgedelet(num);
            QuizMg.instance.Setquestion(MapGemPlacement.instance._quiz(num));
            QuizPrefab.SetActive(true);
            //TrackingMousePosition.instace.isActiveflag = false;
            Debug.Log("問題");
            if (Random.Range(0,2) == 0)
            {
                Vector3 sw = _ButtonTop[0].position;
                foreach (Transform t in _ButtonTop)
                {
                    t.position = _ButtonBottom[0].position;
                }
                foreach (Transform t in _ButtonBottom)
                {
                    t.position = sw;
                }
            }
        }
    }
}
