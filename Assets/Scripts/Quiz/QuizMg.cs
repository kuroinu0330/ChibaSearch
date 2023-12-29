using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static MapGemPlacement;
using static SoundManager;

public class QuizMg: MonoBehaviour
{
    [SerializeField, Header("�`�����l��")]
    private int _Channel;
    [SerializeField]
    public int num;
    [SerializeField]
    private int numBook;
    [SerializeField]
    public int numGet;
    [SerializeField]
    public int numBadge;
    public int QuizScore;
    [SerializeField]
    private GameObject _gameObject;
    [SerializeField]
    private TMP_Text _TrueText;
    [SerializeField]
    private TMP_Text _FalseText;
    [SerializeField]
    private TMP_Text _questiontext;
    public static QuizMg instance;
    [SerializeField]
    public GameObject _badgeGetObj;
    //Quizcreate quizcreate;
    [SerializeField]
    private GameObject TMPText;


    public List<GameObject> badge = new List<GameObject>();
    public List<GameObject> Bookbadge = new List<GameObject>();
    public List<GameObject> Getbadge = new List<GameObject>();

    public void Awake()
    {
        if (instance == null)
        {
            // �V���O���g������
            instance = this;
        }
    }

    public void TrueClick()
    {
        SoundManager.instance.PlayAudioSorce(AudioOfType.SYSTEMSE, 1);
        //SoundManager.instance.SEVolume();
        Debug.Log("aaaa");
        QuizScore = 1;
    }
    public void FalseClick()
    {
        SoundManager.instance.PlayAudioSorce(AudioOfType.SYSTEMSE, 2);
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
            //����
            case 1:
                SoundManager.instance.PlayAudioSorce(AudioOfType.BGM, _Channel);
                Invoke(nameof(quizFalse), 1f);
                badge[num].SetActive(false);
                Bookbadge[numBook].SetActive(true);
                Getbadge[numGet].SetActive(true);
                Debug.Log(numGet);
                CatholineCompass.instance.JewelGameObjectRemove(QuizMg.instance.badge[num]);
                Invoke(nameof(badgeGet), 1f);
                QuizScore = 0;
                
                break;
            //�s��
            case 2:
                SoundManager.instance.PlayAudioSorce(AudioOfType.BGM, _Channel);
                _gameObject.SetActive(false);
                //Destroy(_gameObject, 2);
                Debug.Log("�s����");
                QuizScore = 0;
                break;
        }
    }
    public void Setquestion(_Quiz quiz)
    {
        _questiontext.text = quiz.question;
            _TrueText.text = quiz.correct;
           _FalseText.text = quiz.incorrect;
        Debug.Log("��蕶:" + quiz.correct + "\n" + "����:" + quiz.incorrect + "\n" + "�s����:" + quiz.question);
    }
    public void badgedelet(int num2)
    {
        num = num2;
        numBook = num2;
        numGet = num2;
        numBadge = num2;
    }
    public void badgeGet()
    {
        _badgeGetObj.SetActive(true);
    }
    public void quizFalse()
    {
        _gameObject.SetActive(false);
    }
    private void TextTrue()
    {
        if (num == 19)
        {
            TMPText.SetActive(true);
        }

    }
}
