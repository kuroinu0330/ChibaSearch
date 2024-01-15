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
    //[SerializeField] private Canvas _canvas;

    /// <summary>
    /// マウスポインターを投影するCanvasのRectTransformコンポーネントの参照
    /// </summary>
    //[SerializeField] private RectTransform _mapCanvas;

    /// <summary>
    /// マウスポインターのRectTransformコンポーネントの参照
    /// </summary>
    [SerializeField] private RectTransform _cursorTransform;

    [SerializeField] private Camera _camera;
    //[SerializeField] private Camera _Maincamera;

    [SerializeField] private RectTransform _cursorAllTrans;

    //[SerializeField] private bool MapisActive = true;
    public bool isActiveflag = false;

    public bool canMoveFlag = true;
    //private int flagCount;
    //public Text TextFrame;
    // [SerializeField]
    // private GameObject CoCo;
    
    //レンズの半径を保持
    [SerializeField]
    private float lensRadius = 100;
    //レンズの中心座標を保持
    [SerializeField] 
    private Transform lensPosition;
    
    private Touch touch;

    [SerializeField]
    public Vector3 mousePosition = Vector3.zero;

    public static TrackingMousePosition instance;

    [SerializeField] 
    public MoveType moveType = MoveType.None;

    public enum MoveType
    {
        None,
        Lenz,
        Map
    }

    private void Awake()
    {
        if (instace == null)
        {
            instace = this;
        }
    }

    // public enum LeftRightKey
    // {
    //     Left,
    //     Right,
    // }
    // [SerializeField]
    // public LeftRightKey LRKey;

    void Update()
    {
        // if (Application.isEditor)
        // switch (LRKey)
        // {
        //     case LeftRightKey.Left:
        //         if (Input.touchCount > 0)
        //         {
        //             if (Input.touchCount == 1)
        //             {
        //                 touch = Input.GetTouch(0);
        //
        //                 MapisActive = false;
        //                 Vector3 mousePosition = touch.position;
        //                 if (mousePosition.x > 0.15f * Screen.width && outLens((Vector2)mousePosition))
        //                 {
        //                     Vector3 target = _camera.ScreenToWorldPoint(mousePosition);
        //                     target.z = _cursorAllTrans.position.z;
        //                     _cursorAllTrans.position = target;
        //                 }
        //             }
        //             else if (Input.touchCount == 2)
        //             {
        //                 touch = Input.GetTouch(0);
        //
        //                 MapisActive = true;
        //                 Vector3 mousePosition = touch.position;
        //             }
        //         }
        //         else
        //         {
        //             if (isActiveflag)
        //             {
        //                 // CanvasのRectTransform内にあるマウスの座標をローカル座標に変換する
        //                 RectTransformUtility.ScreenPointToLocalPointInRectangle(
        //                     _mapCanvas,
        //                     Input.mousePosition,
        //                     _canvas.worldCamera,
        //                     out var mousePosition);
        //
        //                 // ポインターをマウスの座標に移動する
        //                 _cursorTransform.anchoredPosition = new Vector2(mousePosition.x, mousePosition.y);
        //             }
        //             if (Input.GetMouseButton(0))
        //             {
        //                 MapisActive = false;
        //                 Vector3 mousePosition = Input.mousePosition;
        //                 //Debug.Log(mousePosition.x + ":" + mousePosition.y);
        //                 if (mousePosition.x > 0.15f * Screen.width && outLens((Vector2)mousePosition))
        //                 {
        //                     Vector3 target = _camera.ScreenToWorldPoint(mousePosition);
        //                     target.z = _cursorAllTrans.position.z;
        //                     _cursorAllTrans.position = target;
        //                 }
        //             }
        //             else if (Input.GetMouseButtonUp(0))
        //             {
        //                 /*_cursorAllTrans.transform.SetParent(_mapCanvas);*/
        //                 MapisActive = true;
        //             }
        //         }
        //         break;
        //     case LeftRightKey.Right:
        //         if (Input.touchCount > 0)
        //         {
        //             if (Input.touchCount == 1)
        //             {
        //                 touch = Input.GetTouch(0);
        //
        //                 MapisActive = false;
        //                 Vector3 mousePosition = touch.position;
        //                 if (mousePosition.x < 0.85f * Screen.width && outLens((Vector2)mousePosition))
        //                 {
        //                     Vector3 target = _camera.ScreenToWorldPoint(mousePosition);
        //                     target.z = _cursorAllTrans.position.z;
        //                     _cursorAllTrans.position = target;
        //                 }
        //             }
        //             else if (Input.touchCount == 2)
        //             {
        //                 touch = Input.GetTouch(0);
        //
        //                 MapisActive = true;
        //                 Vector3 mousePosition = touch.position;
        //             }
        //         }
        //         else
        //         {
        //             if (isActiveflag)
        //             {
        //                 // CanvasのRectTransform内にあるマウスの座標をローカル座標に変換する
        //                 RectTransformUtility.ScreenPointToLocalPointInRectangle(
        //                     _mapCanvas,
        //                     Input.mousePosition,
        //                     _canvas.worldCamera,
        //                     out var mousePosition);
        //
        //                 // ポインターをマウスの座標に移動する
        //                 _cursorTransform.anchoredPosition = new Vector2(mousePosition.x, mousePosition.y);
        //             }
        //             if (Input.GetMouseButton(0))
        //             {
        //                 MapisActive = false;
        //                 Vector3 mousePosition = Input.mousePosition;
        //                 //Debug.Log(mousePosition.x + ":" + mousePosition.y);
        //                 if (mousePosition.x < 0.85f * Screen.width && outLens((Vector2)mousePosition))
        //                 {
        //                     Vector3 target = _camera.ScreenToWorldPoint(mousePosition);
        //                     target.z = _cursorAllTrans.position.z;
        //                     _cursorAllTrans.position = target;
        //                 }
        //             }
        //             else if (Input.GetMouseButtonUp(0))
        //             {
        //                 /*_cursorAllTrans.transform.SetParent(_mapCanvas);*/
        //                 MapisActive = true;
        //             }
        //         }
        //         break;
        // }
        
        // 画面にタッチされている指が1本以上あり且つ「canMoveFlag」がTrueに場合以下の処理を実行
        if (Input.touchCount > 0 && canMoveFlag)
        {
            // 1本目の指をトラッキング
            touch = Input.GetTouch(0);
            
            // 「mousePosition」に画面上の指のワールド座標を保持
            mousePosition = touch.position;

            // 画面にタッチされている指の本数によって以下の処理を分岐
            switch (Input.touchCount)
            {
                // 1本だった場合以下の処理を実行
                case 1:
                    // 移動モードを「Lenz」に設定
                    moveType = MoveType.Lenz;

                    // 指の座標がレンズの外側だった場合以下の処理を実行
                    if (outLens((Vector2)mousePosition))
                    {
                        // 「mousePosition」をスクリーン上の座標に変換して「target」に代入
                        Vector3 target = _camera.ScreenToWorldPoint(mousePosition);
                        
                        // 「target」をレンズのtransformに代入しても問題ないようにZ座標を同期
                        target.z = _cursorAllTrans.position.z;
                        
                        // 「Lenz」の座標を更新
                        _cursorAllTrans.position = target;
                    }
                    break;
                // 2本だった場合以下の処理を実行
                case 2:
                    // 移動モードを「Map」に設定
                    moveType = MoveType.Map;
                    break;
            }
        }
        // 画面上にタッチされている指が存在しない且つ「canMoveFlag」がTrueに場合以下の処理を実行
        else if(canMoveFlag)
        {
            // 左クリックが押された際に以下の処理を実行
            if (Input.GetMouseButtonDown(0))
            {
                // 移動モードを「Lenz」に設定
                moveType = MoveType.Lenz;
            }
            // 移動モードが「Lenz」の時に左クリックが離された際に以下の処理を実行
            else if (Input.GetMouseButtonUp(0) && moveType == MoveType.Lenz)
            {
                // 移動モードを「None」に設定
                moveType = MoveType.None;
            }
            
            // 右クリックが押された際に以下の処理を実行
            if (Input.GetMouseButtonDown(1))
            {
                // 移動モードを「Map」に設定
                moveType = MoveType.Map;
            }
            // 移動モードが「Map」の時に右クリックが離された際に以下の処理を実行
            else if (Input.GetMouseButtonUp(1) && moveType == MoveType.Map)
            {
                // 移動モードを「None」に設定
                moveType = MoveType.None;
            }

            // 移動モードが「None」以外の時以下の処理を実行
            if (moveType != MoveType.None)
            {
                // マウスの座標を保持
                mousePosition = Input.mousePosition;
                
                // 移動モードによって以下の処理を分岐
                switch (moveType)
                {
                    // 移動モードが「Lenz」の場合以下の処理を実行
                    case MoveType.Lenz:
                        if (outLens((Vector2)mousePosition))
                        {
                            Vector3 target = _camera.ScreenToWorldPoint(mousePosition);
                            target.z = _cursorAllTrans.position.z;
                            _cursorAllTrans.position = target; 
                        }
                        break;
                    // 移動モードが「Map」の場合以下の処理を実行
                    case MoveType.Map:
                        break;
                }
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

    /// <summary>
    /// 移動モードが更新されていない(移動を目的としたクリックではない)場合に実行する関数
    /// </summary>
    public void UIButtomEnter()
    {
        // 現在の移動モードが「None」だった場合以下の処理を実行
        if (moveType == MoveType.None)
        {
            // 「canMoveFlag」をfalseにする
            canMoveFlag = false;
        }
    }

    /// <summary>
    /// 移動モードが更新されていない(移動を目的としたクリックではない)状況が終了した場合に実行する関数 
    /// </summary>
    public void UIButtomExit()
    {
        // 「canMoveFlag」をtrueにする
        canMoveFlag = true;
    }
}
