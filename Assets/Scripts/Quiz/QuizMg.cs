using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static MapGemPlacement;

public class QuizMg: MonoBehaviour
{
    [SerializeField]
    public int num;
    [SerializeField]
    private int numBook;
    public int QuizScore;
    [SerializeField]
    private GameObject _gameObject;
    [SerializeField]
    private Text _TrueText;
    [SerializeField]
    private Text _FalseText;
    [SerializeField]
    private Text _questiontext;
    public static QuizMg instance;

    //Quizcreate quizcreate;

    public List<GameObject> badge = new List<GameObject>();
    public List<GameObject> Bookbadge = new List<GameObject>();

    public void Awake()
    {
        if (instance == null)
        {
            // シングルトン処理
            instance = this;
        }
    }

    public void TrueClick()
    {

        Debug.Log("aaaa");
        QuizScore = 1;
    }
    public void FalseClick()
    {

        Debug.Log("bbbb");
        QuizScore = 2;
    }

    private void Update()
    {
        TrueFalse();
    }
    public void TrueFalse()
    {
        switch (QuizScore)
        {
            //正解
            case 1:
                _gameObject.SetActive(false);
                //Destroy(_gameObject, 2);
                QuizMg.instance.badge[num].SetActive(false);
                QuizMg.instance.Bookbadge[numBook].SetActive(true);
                CatholineCompass.instance.JewelGameObjectRemove(QuizMg.instance.badge[num]);
                QuizScore = 0;
                break;
            //不正
            case 2:
                _gameObject.SetActive(false);
                //Destroy(_gameObject, 2);
                Debug.Log("不正解");
                QuizScore = 0;
                break;
        }
    }
    public void Setquestion(_Quiz quiz)
    {
        _questiontext.text = quiz.question;
        _TrueText.text = quiz.correct;
        _FalseText.text = quiz.incorrect;
        Debug.Log("問題文:" + quiz.correct + "\n" + "正解:" + quiz.incorrect + "\n" + "不正解:" + quiz.question);
    }
    public void badgedelet(int num2)
    {
        num = num2;
    }
}
