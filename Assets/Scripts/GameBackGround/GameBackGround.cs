using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameBackGround : MonoBehaviour
{
    // プレイ画面の背景をランダムで変えるスクリプト

    // 背景の取得と定義
    [SerializeField] private GameObject[] bg;

    private void SelectBG(int num)
    {
        for (int i = 0; i < bg.Length; i++)
        {
            bg[i].SetActive(false);
        }

        bg[num].SetActive(true);
    }

    private void Start()
    {
        int selectBGnum = Random.Range(0, bg.Length);

        SelectBG(selectBGnum);
    }
}
