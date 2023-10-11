using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatholineCompass : MonoBehaviour
{
    // 虫眼鏡のゲームオブジェクトを保持する変数
    [SerializeField] private GameObject _glassesObject;

    // シーン上に配置してある全ての宝石を保持する配列
    [SerializeField] private List<GameObject> _jewelryObjects;

    // シングルトン化
    public static CatholineCompass instance;
    
    private void Awake()
    {
        // インスタンスが設定されていない場合以下の処理を実行する
        if (instance == null)
        {
            // シングルトン処理
            instance = this;
        }
    }
    
    private void FixedUpdate()
    {
        // 配列を虫眼鏡から近い順にソートする
        JewelArraySort();

        // カソリーヌを一番近い宝石の方向を向かせる
        CatholineNavigation();
    }

    /// <summary>
    /// 配列のソート処理
    /// </summary>
    private void JewelArraySort()
    {
        // 配列の本ソート処理
        _jewelryObjects.Sort((a, b) => MathF
            .Abs(Vector3.Distance(_glassesObject.transform.position, a.transform.position))
            .CompareTo(MathF.Abs(Vector3.Distance(_glassesObject.transform.position, b.transform.position))));
    }

    /// <summary>
    /// カソリーヌを一番近い宝石の方を向くようにする
    /// </summary>
    private void CatholineNavigation()
    {
        // 配列に最低でも一つの要素が内包されている時に以下の処理を実行する
        if (_jewelryObjects[0] != null)
        {
            // 単位ベクトルを求めるVector型配列
            Vector2 dis =
                (Vector2)(_glassesObject.gameObject.transform.position +
                          _jewelryObjects[0].transform.position);
            dis = dis.normalized;

            // Z軸の回転量を保持する変数
            float RotateZ = 0.0f;

            // 単位ベクトルのY軸がマイナスだった場合以下の処理を実行する
            if (dis.y < 0)
            {
                RotateZ = dis.x * 90 - 180f;
            }
            // 単位ベクトルのY軸がプラスだった場合以下の処理を実行する
            else
            {
                RotateZ = dis.x * -90;
            }

            // カソリーヌの回転処理を実行する
            this.transform.rotation = Quaternion.Euler(0, 0, RotateZ);
        }
    }

    /// <summary>
    /// 「_jewelryObjects」から使用済みのオブジェクトを排除する関数 
    /// </summary>
    /// <param name="obj">獲得済みの宝石オブジェクト</param>
    public void JewelGameObjectRemove(GameObject obj)
    {
        // 配列から使用済みの宝石オブジェクトをリムーブする
        _jewelryObjects.Remove(obj);
    }

}
