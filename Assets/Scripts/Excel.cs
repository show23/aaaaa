//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.IO;

//public class Excel : MonoBehaviour
//{
//    TextAsset csvFile; // CSV�t�@�C��
//    List<List<string>> csvDatas = new List<List<string>>(); // CSV�̒��g�����郊�X�g;

//    void Start()
//    {
//        csvFile = Resources.Load("Book1") as TextAsset; // ���\�[�X�t�H���_����CSV�t�@�C����ǂݍ���
//        StringReader reader = new StringReader(csvFile.text);

//        // , �ŕ�������s���ǂݍ���
//        // ���X�g�ɒǉ����Ă���
//        while (reader.Peek() != -1) // reader.Peek��-1�ɂȂ�܂�
//        {
//            string line = reader.ReadLine(); // ��s���ǂݍ���
//            string[] values = line.Split(','); // , ��؂�Ńf�[�^�𕪊�
//            List<string> row = new List<string>(values);
//            csvDatas.Add(row); // ���X�g�ɒǉ�
//        }

//        // Unity�̕ϐ���CSV����ǂݍ��񂾃f�[�^���������
//        if (csvDatas.Count > 1 && csvDatas[1].Count > 1)
//        {
//            float moveSpeedFromCSV = float.Parse(csvDatas[1][1]); // ��: CSV��2��ڂ̒l��float�ɕϊ�
//            PlayerMove.instance.moveSpeed = moveSpeedFromCSV;
//        }

//        if (csvDatas.Count > 2 && csvDatas[2].Count > 1)
//        {
//            float dashSpeedFromCSV = float.Parse(csvDatas[2][1]); // ��: CSV��2��ڂ̒l��float�ɕϊ�
//            PlayerMove.instance.dashSpeed = dashSpeedFromCSV;
//        }

//        if (csvDatas.Count > 5 && csvDatas[5].Count > 1)
//        {
//            float hikiyoseFromCSV = float.Parse(csvDatas[5][1]);
//            PlayerAttractor.instance.attractionRange = hikiyoseFromCSV;
//        }

//        if (csvDatas.Count > 6 && csvDatas[6].Count > 1)
//        {
//            float hikiyoseForceFromCSV = float.Parse(csvDatas[6][1]);
//            PlayerAttractor.instance.attractionForce = hikiyoseForceFromCSV;
//        }

//        if (csvDatas.Count > 7 && csvDatas[7].Count > 1)
//        {
//            float hikiyoseStopFromCSV = float.Parse(csvDatas[7][1]);
//            PlayerAttractor.instance.stopDistance = hikiyoseStopFromCSV;
//        }

//        if (csvDatas.Count > 8 && csvDatas[8].Count > 1)
//        {
//            float hikiyoseIncreaseFromCSV = float.Parse(csvDatas[8][1]);
//            PlayerAttack.instance.increasedRange = hikiyoseIncreaseFromCSV;
//        }

//        if (csvDatas.Count > 9 && csvDatas[9].Count > 1)
//        {
//            float hikiyoseRangeFromCSV = float.Parse(csvDatas[9][1]);
//            PlayerAttack.instance.maxInteractionRange = hikiyoseRangeFromCSV;
//        }
//        if (csvDatas.Count > 5 && csvDatas[5].Count > 4)
//        {
//            float LineTimeFromCSV = float.Parse(csvDatas[5][4]);
//            Line.instance.buttonPressDuration = LineTimeFromCSV;
//        }
//        if (csvDatas.Count > 6 && csvDatas[5].Count > 4)
//        {
//            float LineDistanceFromCSV = float.Parse(csvDatas[6][4]);
//            Line.instance.maxDistance = LineDistanceFromCSV;
//        }
//    }
//}
