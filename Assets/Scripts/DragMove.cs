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
    }
    public void OnDrag(PointerEventData eventData)
    {
        //if (trackingMousePosition.MapisActive == true) 
        if (trackingMousePosition.moveType == TrackingMousePosition.MoveType.Map)
        {
            //if(_rectTransform.)
            //Debug.Log(eventData);
            Vector2 vec = eventData.delta;            
            // 移動量を表すベクター
            Vector2 Movement = vec * _speed;
            
            if (_rectTransform.anchoredPosition.x + Movement.x >= 27900)
            {
                Movement = new Vector2(0f, Movement.y);
                _rectTransform.anchoredPosition = new Vector2(27899, _rectTransform.anchoredPosition.y);
            }
            else if (_rectTransform.anchoredPosition.x + Movement.x <= -27900)
            {
                Movement = new Vector2(0f, Movement.y);
                _rectTransform.anchoredPosition = new Vector2(-27899, _rectTransform.anchoredPosition.y);
            }

            if (_rectTransform.anchoredPosition.y + Movement.y >= 19585)
            {
                Movement = new Vector2(Movement.x, 0f);
                _rectTransform.anchoredPosition = new Vector2(_rectTransform.anchoredPosition.x, 19584);
            }
            else if (_rectTransform.anchoredPosition.y + Movement.y <= -19585)
            {
                Movement = new Vector2(Movement.x, 0f);
                _rectTransform.anchoredPosition = new Vector2(_rectTransform.anchoredPosition.x, -19584);
            }
            _rectTransform.anchoredPosition += Movement;
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
