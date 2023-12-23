using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kasoMove : MonoBehaviour
{

    [SerializeField] private List<GameObject> _targetObject;
    //最も近いオブジェクト

    private GameObject _nearObj;
    private float _serchTime;
    // Start is called before the first frame updSate
    void Start()
    { 
        //最も近いオブジェクトを取得
        //_nearObj = serchTag(gameObject, "RiceBaby");
        if (_targetObject.Count != 0)
        {
            _nearObj = _targetObject[0];
        }
        else
        {
            _nearObj = null;
        }
    }

    public bool TargetIsNull()
    {
        if (_targetObject.Count == 0)
        {
            return true;
        }

        return false;
    }


    ///<summary>
    /// 近くにいる米Objの方向に向いて追従する。
    /// </summary>
    void Update()
    {
        _serchTime += Time.deltaTime;
        if (_serchTime >= 0)
        {
            if (_targetObject.Count != 0)
            {
                _gameObject = _targetObject[0];
            }
            else if (_targetObject.Count == 0)
            {
                _gameObject = null;
            }

            _nearObj = _gameObject;
            _serchTime = 0;
            //対象の位置の方向を向く
            transform.LookAt(_nearObj.transform);
            if (_gameObject == null) { return; }

            Vector3 distance = _gameObject.transform.position - this.transform.position;

            Vector3 diff = (this.gameObject.transform.position - _nearObj.transform.position);

            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, -diff);




            //自分自身の位置から相対的に移動する(_speedとdeltaTimeの間に速度倍率を挟んだけどこれは前のやつと同じ内容だよ : 外島)
            //transform.Translate(Vector3.forward * 0.1f);
            //transform.position = Vector3.MoveTowards(
            //transform.position,
            //_nearObj.transform.position,
            //_speed * _sppedRetio * Time.deltaTime);

        }
        //ScoreText.text = _HighScore.ToString();
    }

    private void FixedUpdate()
    {
        //今世紀最大の気持ち悪コード
        /*_targetObject.Sort((a, b) => MathF.Abs(Vector3.Distance(this.transform.position, a.transform.position))
            .CompareTo(MathF.Abs(Vector3.Distance(this.transform.position, b.transform.position))));*/
    }

    public void GameObjectAdd(GameObject obj)
    {
        _targetObject.Add(obj);
    }

    public void GameObjectRemove(GameObject obj)
    {
        _targetObject.Remove(obj);
    }

  
 

    //一秒間米を獲得できなかったらスコアを0にする。
    bool _Clear = false;
    private GameObject _gameObject;

    /// <summary>
    /// 3秒間米を獲得できなかったらスコアと速度を初期化にする。([番外]ここも速度倍率に変えたよ)
    /// </summary>
    /// <returns></returns>
    public void ChallengeClear()
    {
        _Clear = true;
    }

    /// <summary>
    /// 米とおにぎりの距離を計算して近くにある米objに追従する
    /// </summary>
    /// <param name="nowObj">自分自身</param>
    /// <param name="tagName">米を探知</param>
    /// <returns></returns>
    #region 探知系
    public GameObject serchTag(GameObject nowObj, string tagName)
    {

        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        GameObject targetObj = null;
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            /*メモ
             * boolでfalseとtrueを使って画面内に要るときはtrueいないときはfalse
             *Vector2.DistanceではなくsqrMagnitudeを使った方が処理が軽い
             */
            //自身と取得したオブジェクトの距離を取得

            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

            //Debug.Log(nearDis);
        }
        //最も近かったオブジェクトを返す
        //return GameObject.Find(nearObjName);
        return targetObj;
    }
    #endregion

}
