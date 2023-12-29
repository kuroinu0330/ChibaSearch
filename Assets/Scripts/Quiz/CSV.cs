using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSV : MonoBehaviour
{
    void Start()
    {
        //クイズリストに読み込んだ情報を反映
        quiz = Quiz_Lead_csv();
    }
    public struct _Quiz
    {
        public string question;
        public string correct;
        public string incorrect;
    }
    public static List<_Quiz> quiz = new List<_Quiz>();
    public List<_Quiz> Quiz_Lead_csv()
    {
        //一時入力用で毎回初期化する構造体とリスト
        _Quiz quiz = new _Quiz();
        TextAsset csvFile;

        //ResourcesからCSVを読み込むのに必要
        List<_Quiz> Quiz_List = new List<_Quiz>();

        //読み込んだCSVファイルを格納
        List<string[]> Quizcsv = new List<string[]>();

        //CSVファイルの行数を格納
        int height = 0;

        //for文用。一行目は読み込まない
        int i = 1;

        /* Resouces/CSV下のCSV読み込み */
        csvFile = Resources.Load("CSV/Quiz.csv") as TextAsset;

        //読み込んだテキストをString型にして格納
        StringReader reader = new StringReader(csvFile.text);
        while (reader.Peek() > -1)
        {
            List<string> strings = new List<string>();
            string line = reader.ReadLine();
            // ,で区切ってCSVに格納
            string[] values = line.Split(',');
            // 行数加算
            height++; 
        }
        for (i = 1; i < height; i++)
        {
            quiz.question = Quizcsv[i][0];
            quiz.correct = Quizcsv[i][1];
            quiz.incorrect = Quizcsv[i][2];
            //戻り値のリストに加える
            Quiz_List.Add(quiz);
        }
        return Quiz_List;
    }
}
