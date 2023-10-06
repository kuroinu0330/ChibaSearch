using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    [SerializeField]
    private Camera _Camera;
    [Range(_countMin, _countMax)]
    [SerializeField]
    private int _count = 1;

    const int _countMax = 3;
    const int _countMin = 1;

    [SerializeField]
    private GameObject _badge;

    // Update is called once per frame
    void Update()
    {
        //WheelTest();
    }
    /*void WheelTest()
    {
        float wheel = Input.GetAxisRaw("Mouse ScrollWheel");
        if (wheel > 0)
        {
            if (_count < _countMax)
            {
                _count++;
                ZoomCount();
            }
        }
        else if (wheel < 0)
        {
            if (_count > _countMin)
            {
                _count--;
                ZoomCount();
            }
        }

    }*/
    public void PlusOnClick()
    {
        if (_count < _countMax)
        {
            _count++;
            ZoomCount();
        }
    }
    public void MinusOnClick()
    {
        if (_count > _countMin)
        {
            _count--;
            ZoomCount();
        }
    }
    void ZoomCount()
    {
        switch (_count)
        {
            case 1:
                _Camera.orthographicSize = 19.0f;
                _badge.SetActive(false);
                Debug.Log("Šg‘å");
                break;
            case 2:
                _Camera.orthographicSize = 10.0f;
                _badge.SetActive(false);
                Debug.Log("Šg‘å‚Q");
                break;
            case 3:
                _Camera.orthographicSize = 5.0f;
                _badge.SetActive(true);
                Debug.Log("Šg‘å3");
                break;
        }
    }
}
