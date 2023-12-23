using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSV : MonoBehaviour
{
    void Start()
    {
        //�N�C�Y���X�g�ɓǂݍ��񂾏��𔽉f
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
        //�ꎞ���͗p�Ŗ��񏉊�������\���̂ƃ��X�g
        _Quiz quiz = new _Quiz();
        TextAsset csvFile;

        //Resources����CSV��ǂݍ��ނ̂ɕK�v
        List<_Quiz> Quiz_List = new List<_Quiz>();

        //�ǂݍ���CSV�t�@�C�����i�[
        List<string[]> Quizcsv = new List<string[]>();

        //CSV�t�@�C���̍s�����i�[
        int height = 0;

        //for���p�B��s�ڂ͓ǂݍ��܂Ȃ�
        int i = 1;

        /* Resouces/CSV����CSV�ǂݍ��� */
        csvFile = Resources.Load("CSV/Quiz.csv") as TextAsset;

        //�ǂݍ��񂾃e�L�X�g��String�^�ɂ��Ċi�[
        StringReader reader = new StringReader(csvFile.text);
        while (reader.Peek() > -1)
        {
            List<string> strings = new List<string>();
            string line = reader.ReadLine();
            // ,�ŋ�؂���CSV�Ɋi�[
            string[] values = line.Split(',');
            // �s�����Z
            height++; 
        }
        for (i = 1; i < height; i++)
        {
            quiz.question = Quizcsv[i][0];
            quiz.correct = Quizcsv[i][1];
            quiz.incorrect = Quizcsv[i][2];
            //�߂�l�̃��X�g�ɉ�����
            Quiz_List.Add(quiz);
        }
        return Quiz_List;
    }
}
