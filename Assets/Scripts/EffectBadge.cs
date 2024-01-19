using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBadge : MonoBehaviour
{
    public List<GameObject> _fieldbadge;
    [SerializeField]
    public GameObject BadgeEffect;
    [SerializeField]
    ZoomCamera _zoomCamera;
    [SerializeField]
    private Transform oya;
    [SerializeField]
    public int Count;

    private void Start()
    {
       // RectTransform rect = BadgeEffect.GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        if (_fieldbadge.Count != 0)
        {
            if (_zoomCamera._count == 2)
            {
                fieldbadgeEffect();
            }
            if(_zoomCamera._count == 1)
            {
                Debug.Log("破壊");
                Destroy(BadgeEffect);
            }
            if (_zoomCamera._count == 3)
            {
                Debug.Log("破壊");
                Destroy(BadgeEffect);
            }
        }
    }
    public void fieldbadgeEffect()
    {
        if (Count == 0)
        {
            //BadgeEffect.transform.localScale = new Vector3(3, 3, 3);
            GameObject obj = Instantiate(BadgeEffect, new Vector3(_fieldbadge[0].transform.position.x, 
                                                                  _fieldbadge[0].transform.position.y,-10),Quaternion.identity);
           
            //obj.transform.rotation = Quaternion.Euler(-90, 0, 0);
            obj.transform.SetParent(oya); 
            //RectTransform rect = BadgeEffect.GetComponent<RectTransform>();
            //rect.anchoredPosition = new Vector2(_fieldbadge[0].transform.position.x, _fieldbadge[0].transform.position.y);
            Count++;
 
        }
        if (Count == 1)
        {
            Debug.Log("上限");
        }
    }
    public void _JewelGameObjectRemove(GameObject obj)
    {
        // 配列から使用済みの宝石オブジェクトをリムーブする
        _fieldbadge.Remove(obj);
    }
}
