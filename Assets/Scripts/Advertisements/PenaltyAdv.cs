using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenaltyAdv : MonoBehaviour
{
    // <summary>
    // 広告をミスた時のペナルティ処理の移行と消す広告のレイヤーを変更する処理
    // </summary>

    // ValueHolderの定義
    ValueHolder holder;

    // EliminatePenaltyの定義
    EliminatePenalty elimPenalty;

    // PenaltyBackGroundの定義
    GameObject penaltyBackGround;

    // ChangePenaltyBackGroundの定義
    GameObject changePenaltyBackGround;

    // ペナルティ時に使用する、スクリプトの定義
    PenaltyText penaltyCountDown;

    private void Start()
    {
        // ChangePenaltyBackGroundの取得
        changePenaltyBackGround = GameObject.Find("/ChangePenaltyBackGround");

        // penaltyCountDownの取得
        penaltyCountDown = changePenaltyBackGround.transform.Find("PenaltyBackGround/PenaltyCountDown").GetComponent<PenaltyText>();

        // EliminatePenaltyの取得
        elimPenalty = changePenaltyBackGround.transform.Find("PenaltyBackGround/PenaltyElim").GetComponent<EliminatePenalty>();

        // PenaltyBackGroundの取得
        penaltyBackGround = changePenaltyBackGround.transform.Find("PenaltyBackGround").gameObject;

        // 広告のレイヤーを変更する処理
        // ValueHolderの取得
        holder = GameObject.Find("/ValueHolder").GetComponent<ValueHolder>();

        // レイヤー定義
        // レイヤーが0～31までしか定義できないので、20を超えた段階でsorting layerを変化させる
        if (holder.get_createAdv() < 10)
        {
            this.GetComponent<SpriteRenderer>().sortingLayerName = "advtisements1-10";
            this.GetComponent<SpriteRenderer>().sortingOrder = holder.get_createAdv() * 2;
        } else
        {
            this.GetComponent<SpriteRenderer>().sortingLayerName = "advtisements11-20";
            this.GetComponent<SpriteRenderer>().sortingOrder = (holder.get_createAdv() % 10) * 2;
        }
        holder.add_createAdv();
    }

    // ペナルティ処理
    public void penaltyAdv()
    {
        // 送付する名前の変数
        string sendName = "";

        // クローンの名前を取得する処理
        for (int i = 0; i < this.name.Length; i++)
        {
            if (this.name[i] == '(')
            {
                break;
            } else
            {
                sendName += this.name[i];
            }
        }

        // ミスったときの処理の移行
        // Resourcesフォルダーのオブジェクトのロードと生成
        GameObject penaltyAdvObj = Resources.Load<GameObject>("Advertisements/Prefab/p"+sendName);
        Instantiate(penaltyAdvObj, Vector3.zero, Quaternion.identity);
        penaltyCountDown.PenaltyCountSrat();
        // EliminatePenaltyにペナルティ広告の名前を送る
        elimPenalty.setPimg(sendName);
        penaltyBackGround.SetActive(true);
    }
}
