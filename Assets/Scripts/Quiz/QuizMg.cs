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
    [SerializeField]
    private ButtonController _buttonControllerA;
    public ButtonController ButtonControllerA => _buttonControllerA;
    [SerializeField]
    private ButtonController _buttonControllerB;
    public ButtonController ButtonControllerB => _buttonControllerB;

    private int ClickSECount;

    public List<GameObject> badge = new List<GameObject>();
    public List<GameObject> Bookbadge = new List<GameObject>();
    public List<GameObject> Getbadge = new List<GameObject>();

    [SerializeField]
    private GameObject _musimegane;
    [SerializeField]
    private Camera _mainCamera;
    [SerializeField]
    ZoomCamera _zoomCamera;
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
        SoundManager.instance.PlayAudioSorce(AudioOfType.BGM,1);
    }

    public void FalseClick()
    {
        SoundManager.instance.PlayAudioSorce(AudioOfType.SYSTEMSE, 2);
        Debug.Log("bbbb");
        QuizScore = 2;
        SoundManager.instance.PlayAudioSorce(AudioOfType.BGM, 1);
        _musimegane.transform.position = new Vector3(_mainCamera.transform.position.x, 
                                                     _mainCamera.transform.position.y,
                                                     _musimegane.transform.position.z);
        _zoomCamera._count = 1;
        _zoomCamera.ZoomCount();
        //_zoomCamera._count--;
        //Debug.Log(_musimegane.transform.position)
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
                //SoundManager.instance.PlayAudioSorce(AudioOfType.BGM, _Channel);
                Invoke(nameof(quizFalse), 1f);
                badge[num].SetActive(false);
                BadgeAlbumManager.instance.GetBadgeThis(num);
                //Bookbadge[numBook].SetActive(true);
                Getbadge[numGet].SetActive(true);
                Debug.Log(numGet);
                CatholineCompass.instance.JewelGameObjectRemove(QuizMg.instance.badge[num]);
                Invoke(nameof(badgeGet), 1f);
                QuizScore = 0;
                // 移動可能フラグを有効化
                TrackingMousePosition.Instance.UIButtomExit();
                break;
            //�s��
            case 2:
                //SoundManager.instance.PlayAudioSorce(AudioOfType.BGM, _Channel);
                _gameObject.SetActive(false);
                //Destroy(_gameObject, 2);
                //Debug.Log("�s����");
                QuizScore = 0;
                // 移動可能フラグを有効化
                TrackingMousePosition.Instance.UIButtomExit();
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
