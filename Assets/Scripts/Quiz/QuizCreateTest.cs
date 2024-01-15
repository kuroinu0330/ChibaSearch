using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManager;

public class QuizCreateTest : MonoBehaviour
{
    [SerializeField]
    private Transform[] _ButtonTop;
    [SerializeField]
    private Transform[] _ButtonBottom;
    [SerializeField]
    public List<GameObject> _QuizPrefab = new List<GameObject>();

    [SerializeField, Header("ƒ`ƒƒƒ“ƒlƒ‹")]
    private int _Channel;

    [SerializeField]
    private GameObject QuizPrefab;

    [SerializeField]
    QuizMg quizMg;

    [SerializeField]
    public int num;

    [SerializeField]
    GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Quizcreate1()
    {
        SoundManager.instance.PlayAudioSorce(AudioOfType.BGM, _Channel);
        if (QuizPrefab == null)
        {

        }
        else
        {
            QuizMg.instance.badgedelet(num);
            QuizMg.instance.Setquestion(MapGemPlacement.instance._quiz(num));
            _QuizPrefab[QuizMg.instance.numBadge].SetActive(true);
            Debug.Log("–â‘è");
            if (Random.Range(0, 2) == 0)
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
