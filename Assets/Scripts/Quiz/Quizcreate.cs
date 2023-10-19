using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quizcreate : MonoBehaviour
{
    [SerializeField]
    public int num;
    [SerializeField]
    private GameObject QuizPrefab;

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
        if (QuizPrefab == null)
        {

        }
        else
        {
            QuizMg.instance.Setquestion(MapGemPlacement.instance._quiz(num));
            GameObject prefab = (GameObject)Instantiate(QuizPrefab);
            prefab.transform.SetParent(canvas.transform, false);
            //Instantiate(QuizPrefab);
        }
    }
}
