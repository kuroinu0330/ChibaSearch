using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorialimage : MonoBehaviour
{
    [SerializeField]
    private GameObject _TutorialWin;
    [SerializeField]
    private GameObject _TutorialWeb;
    private void Start()
    {
        #if UNITY_WEBGL
            _TutorialWeb.SetActive(true);
        #endif

        #if UNITY_STANDALONE_WIN
            _TutorialWin.SetActive(true);
        #endif
    }
}
