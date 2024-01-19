using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    [SerializeField]
    private Camera _Camera;
    [Range(_countMin, _countMax)][SerializeField]
    private int _count = 1;

    const int _countMax = 3;
    const int _countMin = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WheelTest();
    }
    void WheelTest()
    {
        float wheel = Input.GetAxisRaw("Mouse ScrollWheel");
        if(wheel > 0)
        {
            if (_count < _countMax)
            {
                _count++;
                ZoomCount();
            }
        }
        else if (wheel < 0 )
        {
            if (_count > _countMin)
            {
                _count--;
                ZoomCount();
            }
        }
        
    }
    void ZoomCount()
    {
        switch (_count)
        {
            case 1:
                _Camera.orthographicSize = 15.0f;
                Debug.Log("Šg‘å");
                break;
            case 2:
                _Camera.orthographicSize = 10.0f;
                Debug.Log("Šg‘å‚Q");
                break;
            case 3:
                _Camera.orthographicSize = 5.0f;
                Debug.Log("Šg‘å3");
                break;
        }
    }
}
