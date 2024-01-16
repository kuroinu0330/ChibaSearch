using UnityEngine;
using static SoundManager;

public class ZoomCamera : MonoBehaviour
{
    [SerializeField, Header("�`�����l��")]
    private int _Channel;
    [SerializeField]
    private Camera _Camera;
    [Range(_countMin, _countMax)]
    [SerializeField]
    public int _count = 1;

    const int _countMax = 2;
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
            SoundManager.instance.PlayAudioSorce(AudioOfType.SYSTEMSE, _Channel);
            ZoomCount();
        }
    }
    public void MinusOnClick()
    {
        if (_count > _countMin)
        {
            _count--;
            SoundManager.instance.PlayAudioSorce(AudioOfType.SYSTEMSE, _Channel);
            ZoomCount();
        }
    }
    void ZoomCount()
    {
        switch (_count)
        {
            case 1:
                _Camera.orthographicSize = 13.0f;
                if (_badge != null)
                {
                    _badge.SetActive(false);
                }
                Debug.Log("�g��Q");
                break;
            case 2:
                _Camera.orthographicSize = 7.0f;
                if (_badge != null)
                {
                    _badge.SetActive(true);
                }
                Debug.Log("�g��3");
                break;
        }
    }
}
