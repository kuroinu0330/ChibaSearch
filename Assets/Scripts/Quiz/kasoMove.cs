using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kasoMove : MonoBehaviour
{

    [SerializeField] private List<GameObject> _targetObject;
    //�ł��߂��I�u�W�F�N�g

    private GameObject _nearObj;
    private float _serchTime;
    // Start is called before the first frame updSate
    void Start()
    { 
        //�ł��߂��I�u�W�F�N�g���擾
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
    /// �߂��ɂ����Obj�̕����Ɍ����ĒǏ]����B
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
            //�Ώۂ̈ʒu�̕���������
            transform.LookAt(_nearObj.transform);
            if (_gameObject == null) { return; }

            Vector3 distance = _gameObject.transform.position - this.transform.position;

            Vector3 diff = (this.gameObject.transform.position - _nearObj.transform.position);

            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, -diff);




            //�������g�̈ʒu���瑊�ΓI�Ɉړ�����(_speed��deltaTime�̊Ԃɑ��x�{�������񂾂��ǂ���͑O�̂�Ɠ������e���� : �O��)
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
        //�����I�ő�̋C�������R�[�h
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

  
 

    //��b�ԕĂ��l���ł��Ȃ�������X�R�A��0�ɂ���B
    bool _Clear = false;
    private GameObject _gameObject;

    /// <summary>
    /// 3�b�ԕĂ��l���ł��Ȃ�������X�R�A�Ƒ��x���������ɂ���B([�ԊO]���������x�{���ɕς�����)
    /// </summary>
    /// <returns></returns>
    public void ChallengeClear()
    {
        _Clear = true;
    }

    /// <summary>
    /// �ĂƂ��ɂ���̋������v�Z���ċ߂��ɂ����obj�ɒǏ]����
    /// </summary>
    /// <param name="nowObj">�������g</param>
    /// <param name="tagName">�Ă�T�m</param>
    /// <returns></returns>
    #region �T�m�n
    public GameObject serchTag(GameObject nowObj, string tagName)
    {

        float tmpDis = 0;           //�����p�ꎞ�ϐ�
        float nearDis = 0;          //�ł��߂��I�u�W�F�N�g�̋���
        GameObject targetObj = null;
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            /*����
             * bool��false��true���g���ĉ�ʓ��ɗv��Ƃ���true���Ȃ��Ƃ���false
             *Vector2.Distance�ł͂Ȃ�sqrMagnitude���g���������������y��
             */
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
    #endregion

}
