using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz1 : MonoBehaviour
{
    public int QuizScore;
    [SerializeField]
    private GameObject _gameObject;
    [SerializeField]
    private GameObject _badgeobj;
    // Start is called before the first frame update
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
                Destroy(_badgeobj);
                Debug.Log("ê≥â");
                break;
            case 2:
                Destroy(_gameObject,2);
                Debug.Log("ïsê≥â");
                break;
        }
    }
}
