using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    // クラスの中、メソッドの外に書くことに注意
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
        // 移動先が範囲外なら移動不可
        if (moveTo < 0 || moveTo >= map.Length) { return false; }

        // 移動先に2(箱)が居たら
        if (map[moveTo] == 2)
        {

            //どの方向へ移動するかを算出
            int velocity = moveTo - moveFrom;

            /* プレイヤーの移動先から、さらに先へ2(箱)を移動させる。
               箱の移動処理、MoveNumberメソッド内でMoveNumberメソッドを予備、
               処理が再起している。移動可不可をboolで記録*/
            bool success = MoveNumber(2, moveTo, moveTo + velocity);

            // もし箱買い同失敗したら、プレイヤーの移動も失敗
            if (!success) { return false; }
        }
        // プレイヤー・箱関わらずの移動処理
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }

    //　配列の宣言
    int[] map;

    // Start is called before the first frame update
    void Start()
    {

        // 配列の実態の作成と初期化
        map = new int[] { 0, 2, 0, 1, 0, 2, 0, 2, 0 };

        PrintArray();
    }

    // Update is called once per frame
    void Update()
    {

        //右キーの処理
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            // 見つからなかった時のために-1で初期化
            int playerIndex = GetPlayeIndex();

            MoveNumber(1, playerIndex, playerIndex + 1);

            PrintArray();
        }

        //左キーの処理
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            int playerIndex = GetPlayeIndex();

            MoveNumber(1, playerIndex, playerIndex - 1);


            PrintArray();
        }

    }
}
