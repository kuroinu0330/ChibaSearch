using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchM : MonoBehaviour
{
    private GameObject _gameObject;
    private GameObject _nearObj;
    private float _serchTime;
    // Start is called before the first frame update
    void Start()
    {
        _nearObj = serchTag(gameObject, "Badge");
    }

    // Update is called once per frame
    void Update()
    {
        BreadSearch();
    }
    public void BreadSearch()
    {
        _serchTime += Time.deltaTime;
        if (_serchTime >= 0)
        {
            _gameObject = serchTag(gameObject, "Badge");
            _nearObj = _gameObject;
            _serchTime = 0;
            //対象の位置の方向を向く
            transform.LookAt(_nearObj.transform);
            if (_gameObject == null) { return; }

            Vector3 distance = _gameObject.transform.position - this.transform.position;

            Vector3 diff = (this.gameObject.transform.position - _nearObj.transform.position);

            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, -diff);

            //移動のメソッド
        }
    }
    public GameObject serchTag(GameObject nowObj, string tagName)
    {

        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        GameObject targetObj = null;
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
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
}
