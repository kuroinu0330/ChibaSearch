using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookBack : MonoBehaviour
{
    [SerializeField]
    private GameObject _BookBack;
    public void _BookBackClick()
    {
        if (_BookBack == null)
        {

        }
        else
        {
            _BookBack.SetActive(false);
        }
    }
}
