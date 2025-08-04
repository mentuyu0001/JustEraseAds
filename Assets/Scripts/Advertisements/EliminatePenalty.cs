using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EliminatePenalty : MonoBehaviour
{
    // ペナルティ背景の取得
    [SerializeField] private GameObject background;


    // ペナルティ画像の名前の取得
    private string Pimg = "";

    // ペナルティ用広告を消した時の処理
    public void eliminatePenaltyAdv()
    {
        // 背景を消す
        background.SetActive(false);

        // 破棄する広告を取得する
        GameObject adv = GameObject.Find("/"+Pimg + "(Clone)");

        // 破壊
        Destroy(adv);
    }

    public void setPimg(string name)
    {
        Pimg = "p" + name;
    }
}
