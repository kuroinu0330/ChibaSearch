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

    [SerializeField]
    private Image[] _listBadgeImages; // バッジの当たり判定を移動するためのイメージコンポーネントリスト

    [SerializeField]
    private Image _debugImage;

    private void Start()
    {
        _listFlashStars = _badge.GetComponentsInChildren<RandomFlash>();
        _listQuizCreates = _badge.GetComponentsInChildren<Quizcreate>();

        // 準備　まずはStarを虫眼鏡カメラに表示、Buttonを非表示
        SetEffectActive(true);
        SetQuizBadgeActive(false);

        _listBadgeImages = _badge.GetComponentsInChildren<Image>();
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
    public void ZoomCount()
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

    void Update()
    {
        int i = 0;
        switch (_count)
        {
            case 1:
                foreach (var image in _listBadgeImages)
                {
                    image.raycastPadding = Vector4.zero;
                }
                break;
            case 2:

                foreach (var image in _listBadgeImages)
                {
                    Vector3 diffV3 = image.transform.position - _mushimeganeRoot.transform.position;
                    Vector2 center = diffV3 * 2f;
                    if (i == 0)
                    {
                        _debugImage.rectTransform.localPosition = (Vector3)center;
                        Vector2 targetSized = _debugImage.rectTransform.lossyScale * -0.2f;
                        _debugImage.raycastPadding = new Vector4(targetSized.y, targetSized.x, targetSized.y, targetSized.x);
                        //Debug.Log(center.ToString());
                    }
                    Vector2 targetSize = image.rectTransform.lossyScale * -350f;
                    float placeBakerX = 15.0f;
                    float placeBakerY = 7.0f;
                    image.raycastPadding
                         = new Vector4(targetSize.y + center.x * placeBakerX
                                    , targetSize.x + center.y * placeBakerY
                                    , targetSize.y - center.x * placeBakerX
                                    , targetSize.x - center.y * placeBakerY);

                    i++;
                }
                break;
        }
    }
}
