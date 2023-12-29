using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragMove : MonoBehaviour,IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private float _speed = 15;
    [SerializeField]
    TrackingMousePosition trackingMousePosition;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log(eventData);
        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (trackingMousePosition.MapisActive == true) {
            //if(_rectTransform.)
            //Debug.Log(eventData);
            Vector2 vec = eventData.delta;

            if (_rectTransform.anchoredPosition.x >= 27900)
            {
                vec = new Vector2(-1f, vec.y);
            }
            else if (_rectTransform.anchoredPosition.x <= -27900)
            {
                vec = new Vector2(1f, vec.y);
            }

            if (_rectTransform.anchoredPosition.y >= 19590)
            {
                vec = new Vector2(vec.x, -1f);

            }
            else if (_rectTransform.anchoredPosition.y <= -19590)
            {
                vec = new Vector2(vec.x, 1f);
            }

            _rectTransform.anchoredPosition += vec * _speed;
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log(eventData);
    }

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        //_image = GetComponent<Image>();
    }

}
