using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragMove : MonoBehaviour,IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    [SerializeField]
    private Image _image;
    private float _speed = 15;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta * _speed /**  Time.deltaTime*/;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<Button>().enabled = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.GetComponent<Button>().enabled = false;
    }
}
