using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragMove : MonoBehaviour,IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private float _speed = 15;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 vec = eventData.delta;

        if(Mathf.Abs(_rectTransform.anchoredPosition.x) >= 27900)
        {
            Debug.Log("XŽ²‰Â“®ˆæŒÀŠE");
            //vec = new Vector2(0.0f, vec.y);
            vec = new Vector2(-1f, vec.y);
            //_rectTransform.anchoredPosition = new Vector2(27899 * Mathf.Sign(eventData.delta.x), _rectTransform.anchoredPosition.y);
        }

        if (Mathf.Abs(_rectTransform.anchoredPosition.y) >= 19590)
        {
            Debug.Log("YŽ²‰Â“®ˆæŒÀŠE");
            //vec = new Vector2(vec.x, 0.0f);
            vec = new Vector2(vec.x, -1f);
            //_rectTransform.anchoredPosition = new Vector2(_rectTransform.anchoredPosition.x, 19589 * Mathf.Sign(eventData.delta.y));

        }

        _rectTransform.anchoredPosition += vec * _speed /**  Time.deltaTime*/;


    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        //_image = GetComponent<Image>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Badge"))
        {
            other.gameObject.GetComponent<Button>().enabled = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Badge"))
        {
            other.gameObject.GetComponent<Button>().enabled = false;
        }
    }
}
