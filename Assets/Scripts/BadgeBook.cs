using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadgeBook : MonoBehaviour
{
    [SerializeField]
    private GameObject _Book;
    public void BadgeClick()
    {
        if (_Book == null)
        {

        }
        else
        {
            _Book.SetActive(true);
        }
    }
}
