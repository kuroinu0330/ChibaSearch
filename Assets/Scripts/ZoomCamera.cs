using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static SoundManager;

public class ZoomCamera : MonoBehaviour
{
    [SerializeField, Header("変化があったときの効果音")]
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

    [SerializeField]
    private GameObject _mushimeganeRoot;

    private RandomFlash[] _listFlashStars = null;
    private Quizcreate[] _listQuizCreates = null;

    private void Start()
    {
        _listFlashStars = _badge.GetComponentsInChildren<RandomFlash>();
        _listQuizCreates = _badge.GetComponentsInChildren<Quizcreate>();

        // 準備　まずはStarを虫眼鏡カメラに表示、Buttonを非表示
        SetEffectActive(true);
        SetQuizBadgeActive(false);
    }

    private void SetEffectActive(bool onoff)
    {
        for (int i = 0; i < _listFlashStars.Length; i++)
        {
            if (_listFlashStars[i] == null) continue;

            if (onoff)
            {
                _listFlashStars[i].gameObject.layer = 7;
                _listFlashStars[i].gameObject.GetComponent<RawImage>().enabled = true;
                
            }
            else
            {
                _listFlashStars[i].gameObject.layer = 6;
                _listFlashStars[i].gameObject.GetComponent<RawImage>().enabled = false;
            }
            
        }
    }

    private void SetQuizBadgeActive(bool onoff)
    {
        for (int i = 0; i < _listQuizCreates.Length; i++)
        {
            if (_listQuizCreates[i] == null) continue;

            if (onoff)
            {
                _listQuizCreates[i].gameObject.layer = 7;
                _listQuizCreates[i].gameObject.GetComponent<Image>().enabled = true;
                _listQuizCreates[i].gameObject.GetComponent<Button>().interactable = true;
            }
            else
            {
                _listQuizCreates[i].gameObject.layer = 6;
                _listQuizCreates[i].gameObject.GetComponent<Image>().enabled = false;
                _listQuizCreates[i].gameObject.GetComponent<Button>().interactable = false;
            }
        }
    }

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
                _Camera.orthographicSize = 19.0f;
                _mushimeganeRoot.transform.localScale = new Vector3(65, 65, 1);
                SetQuizBadgeActive(false);
                SetEffectActive(true);
                Debug.Log("縮小");
                break;
            case 2:
                _Camera.orthographicSize = 7.0f;
                _mushimeganeRoot.transform.localScale = new Vector3(55, 55, 1);
                SetQuizBadgeActive(true);
                SetEffectActive(false);
                Debug.Log("拡大");
                break;
        }
    }
}
