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
            //�Ώۂ̈ʒu�̕���������
            transform.LookAt(_nearObj.transform);
            if (_gameObject == null) { return; }

            Vector3 distance = _gameObject.transform.position - this.transform.position;

            Vector3 diff = (this.gameObject.transform.position - _nearObj.transform.position);

            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, -diff);

            //�ړ��̃��\�b�h
        }
    }
    public GameObject serchTag(GameObject nowObj, string tagName)
    {

        float tmpDis = 0;           //�����p�ꎞ�ϐ�
        float nearDis = 0;          //�ł��߂��I�u�W�F�N�g�̋���
        GameObject targetObj = null;
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //���g�Ǝ擾�����I�u�W�F�N�g�̋������擾

            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //�I�u�W�F�N�g�̋������߂����A����0�ł���΃I�u�W�F�N�g�����擾
            //�ꎞ�ϐ��ɋ������i�[
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

            //Debug.Log(nearDis);
        }
        //�ł��߂������I�u�W�F�N�g��Ԃ�
        //return GameObject.Find(nearObjName);
        return targetObj;
    }
}
