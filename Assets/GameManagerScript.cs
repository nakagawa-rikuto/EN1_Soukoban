using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    // �N���X�̒��A���\�b�h�̊O�ɏ������Ƃɒ���
    void PrintArray()
    {
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";
        }
        Debug.Log(debugText);
    }

    int GetPlayeIndex()
    {
        for (int i = 0; i < map.Length; i++)
        {

            if (map[i] == 1)
            {
                return i;
            }
        }
        return -1;
    }

    bool MoveNumber(int number, int moveFrom, int moveTo)
    {
        // �ړ��悪�͈͊O�Ȃ�ړ��s��
        if (moveTo < 0 || moveTo >= map.Length) { return false; }

        // �ړ����2(��)��������
        if (map[moveTo] == 2)
        {

            //�ǂ̕����ֈړ����邩���Z�o
            int velocity = moveTo - moveFrom;

            /* �v���C���[�̈ړ��悩��A����ɐ��2(��)���ړ�������B
               ���̈ړ������AMoveNumber���\�b�h����MoveNumber���\�b�h��\���A
               �������ċN���Ă���B�ړ��s��bool�ŋL�^*/
            bool success = MoveNumber(2, moveTo, moveTo + velocity);

            // ���������������s������A�v���C���[�̈ړ������s
            if (!success) { return false; }
        }
        // �v���C���[�E���ւ�炸�̈ړ�����
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }

    //�@�z��̐錾
    int[] map;

    // Start is called before the first frame update
    void Start()
    {

        // �z��̎��Ԃ̍쐬�Ə�����
        map = new int[] { 0, 2, 0, 1, 0, 2, 0, 2, 0 };

        PrintArray();
    }

    // Update is called once per frame
    void Update()
    {

        //�E�L�[�̏���
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            // ������Ȃ��������̂��߂�-1�ŏ�����
            int playerIndex = GetPlayeIndex();

            MoveNumber(1, playerIndex, playerIndex + 1);

            PrintArray();
        }

        //���L�[�̏���
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            int playerIndex = GetPlayeIndex();

            MoveNumber(1, playerIndex, playerIndex - 1);


            PrintArray();
        }

    }
}
