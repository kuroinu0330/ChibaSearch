using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz1 : MonoBehaviour
{
    [SerializeField]
    private int num;
    [SerializeField]
    private int numBook;
    public int QuizScore;
    [SerializeField]
    private GameObject _gameObject;
    [SerializeField]
    private GameObject _TrueText;
    [SerializeField]
    private GameObject _FalseText;
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
            case 1:
                Destroy(_gameObject,2);
                QuizMg.instance.badge[num].SetActive(false);
                QuizMg.instance.Bookbadge[numBook].SetActive(true);
                CatholineCompass.instance.JewelGameObjectRemove(QuizMg.instance.badge[num]);
                if (_TrueText == null) {}
                else
                {
                    _TrueText.SetActive(true);
                }
                Debug.Log("ê≥â");
                break;
            case 2:
                Destroy(_gameObject,2);
                if (_FalseText == null){}
                else
                {
                    _FalseText.SetActive(true);
                }
                Debug.Log("ïsê≥â");
                break;
        }
    }
}
