using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private Text _TrueText;
    [SerializeField]
    private Text _FalseText;
    [SerializeField]
    private Text text;

    
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
                break;
            case 2:
                Destroy(_gameObject,2);
                Debug.Log("ïsê≥â");
                break;
        }
    }
}
