using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManager;

public class badgeEffect : MonoBehaviour
{
    [SerializeField, Header("スケールを変えたいオブジェクト")]
    GameObject targetObject;
    //スケールを変える速度
    private Vector3 speed = new Vector3(2, 2, 0);
    [SerializeField]
    private bool flag = false;
    [SerializeField]
    private bool flagTo = false;
    private int _completeCount;
    // Update is called once per frame
    void Update()
    {
        if (targetObject.transform.localScale.x > 1)
        {
            targetObject.transform.localScale -= speed * Time.deltaTime;
        }
        else if(!flagTo)
        {
            flag = true;
        }
        badgeSE();
        if (_completeCount == 50)
        {
            Debug.Log("complete");
        }
    }
    private void badgeSE()
    {
        if (flag)
        {
            SoundManager.instance.PlayAudioSorce(AudioOfType.SYSTEMSE, 5);  
            _completeCount++;
            flagTo = true;
            flag = false;
        }
    }
}
