using UnityEngine;
using System;
using UnityEditor;
using UnityEngine.UI;

public class TrackingMousePosition : MonoBehaviour
{
    public static TrackingMousePosition instace;
    /// <summary>
    /// マウスポインターを投影するCanvasコンポーネントの参照
    /// </summary>
    [SerializeField] private Canvas _canvas;

    /// <summary>
    /// マウスポインターを投影するCanvasのRectTransformコンポーネントの参照
    /// </summary>
    [SerializeField] private RectTransform _mapCanvas;

    /// <summary>
    /// マウスポインターのRectTransformコンポーネントの参照
    /// </summary>
    [SerializeField] private RectTransform _cursorTransform;

    [SerializeField] private Camera _camera;
    [SerializeField] private Camera _Maincamera;

    [SerializeField] private RectTransform _cursorAllTrans;

    [SerializeField] public bool MapisActive = true;
    public bool isActiveflag = false;
    private int flagCount;
    //public Text TextFrame;
    [SerializeField]
    private GameObject CoCo;
    
    //レンズの半径を保持
    [SerializeField]
    private float lensRadius = 100;
    //レンズの中心座標を保持
    [SerializeField] 
    private Transform lensPosition;

        [SerializeField] 
    private Touch touch;
    void Update()
    {
        /*
       // if (Application.isEditor)
        if (Input.touchCount > 0)
        {
            if (Input.touchCount == 1)
            {
                touch = Input.GetTouch(0);

                MapisActive = false;
                Vector3 mousePosition = touch.position;
                if (mousePosition.x < 0.90f * Screen.width && mousePosition.y > 0.10f * Screen.height && outLens((Vector2)mousePosition))
                {
                    Vector3 target = _camera.ScreenToWorldPoint(mousePosition);
                    target.z = _cursorAllTrans.position.z;
                    _cursorAllTrans.position = target;
                }
            }
            else if (Input.touchCount == 2)
            {
                touch = Input.GetTouch(0);

                MapisActive = true;
                Vector3 mousePosition = touch.position;
            }
        }
        else
        {
            if (isActiveflag)
            {
                // CanvasのRectTransform内にあるマウスの座標をローカル座標に変換する
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    _mapCanvas,
                    Input.mousePosition,
                    _canvas.worldCamera,
                    out var mousePosition);

                // ポインターをマウスの座標に移動する
                _cursorTransform.anchoredPosition = new Vector2(mousePosition.x, mousePosition.y);
            }
            if (Input.GetMouseButton(0))
            {
                MapisActive = false;
                Vector3 mousePosition = Input.mousePosition;
                //Debug.Log(mousePosition.x + ":" + mousePosition.y);
                if (mousePosition.x < 0.85f * Screen.width && mousePosition.y > 0.15f * Screen.height && outLens((Vector2)mousePosition))
                {
                    Vector3 target = _camera.ScreenToWorldPoint(mousePosition);
                    target.z = _cursorAllTrans.position.z;
                    _cursorAllTrans.position = target;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                //_cursorAllTrans.transform.SetParent(_mapCanvas);
                MapisActive = true;
            }
        }*/
        // if (Application.isEditor)
        if (Input.touchCount > 0)
        {
            if (Input.touchCount == 1)
            {
                touch = Input.GetTouch(0);

                MapisActive = false;
                Vector3 mousePosition = touch.position;
                    Vector3 target = _camera.ScreenToWorldPoint(mousePosition);
                    target.z = _cursorAllTrans.position.z;
                    _cursorAllTrans.position = target;
                
            }
            else if (Input.touchCount == 2)
            {
                touch = Input.GetTouch(0);

                MapisActive = true;
                Vector3 mousePosition = touch.position;
            }
        }
        else
        {
            if (isActiveflag)
            {
                // CanvasのRectTransform内にあるマウスの座標をローカル座標に変換する
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    _mapCanvas,
                    Input.mousePosition,
                    _canvas.worldCamera,
                    out var mousePosition);

                // ポインターをマウスの座標に移動する
                _cursorTransform.anchoredPosition = new Vector2(mousePosition.x, mousePosition.y);
            }
            if (Input.GetMouseButton(0))
            {
                MapisActive = false;
                Vector3 mousePosition = Input.mousePosition;
                //Debug.Log(mousePosition.x + ":" + mousePosition.y);
                if (mousePosition.x < 0.90f * Screen.width && mousePosition.y > 0.15f * Screen.height && outLens((Vector2)mousePosition))
                {
                    Vector3 target = _camera.ScreenToWorldPoint(mousePosition);
                    target.z = _cursorAllTrans.position.z;
                    _cursorAllTrans.position = target;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                //_cursorAllTrans.transform.SetParent(_mapCanvas);
                MapisActive = true;
            }
        }
    }
    private bool outLens(Vector3 pos)
    {
        Vector2 dis = (Vector2)lensPosition.position - (Vector2)_camera.ScreenToWorldPoint(pos);

        //Debug.Log("レンズの中心座標 : " + (Vector2)lensPosition.position);
        //Debug.Log("マウスの中心座標 : " + (Vector2)_camera.ScreenToWorldPoint(pos));
        //Debug.Log("距離 : " + dis.magnitude);
        
        if (Mathf.Abs(dis.magnitude) >= lensRadius)
        {
            return true;
        }

        return false;
    }
}
