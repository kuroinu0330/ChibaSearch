using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class MapGemPlacement : MonoBehaviour
{
    //csvファイルを読み込むための変数
    [SerializeField]
    private TextAsset mapCSV;

    //シングルトン化
    public static MapGemPlacement instance;

    // 配列
    [SerializeField]
    private List<_Quiz> quizList = new List<_Quiz>();

    public _Quiz _quiz(int num)
    {
        return quizList[num];
    }

    /// <summary>
    /// 構造体
    /// </summary>
    [Serializable]
    public struct _Quiz
    {
        //問題
        public string question;
        //正解
        public string correct;
        //不正解
        public string incorrect;
    }

    /// <summary>
    /// CSV読み込み
    /// </summary>
    private void Quiz_Lead_csv()
    {
        //CSVファイルをStringReaderに変換
        StringReader reader = new StringReader(mapCSV.text);

        //先頭の解説行をスキップする
        reader.ReadLine();

        //CSVファイルの全文を読み込む
        string csv = reader.ReadToEnd();

        //読み込んだ全文を一行に切り分ける(要素数が縦列の総数)
        string[] line = csv.Split('\n');

        // 
        for (int i = 0; i < line.Length - 1; i++)
        {
            _Quiz quiz = new _Quiz();
            string[] values = line[i].Split(",");
            quiz.question   = values[0];
            quiz.correct    = values[1];
            quiz.incorrect  = values[2];


            quizList.Add(quiz);

            //Debug.Log("問題文:" + quiz.correct + "\n" + "正解:" + quiz.incorrect + "\n" + "不正解:" + quiz.question);
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        // シングルトン化
        if(instance == null)
        {
            instance = this;
            Quiz_Lead_csv();
        }
    }
}
