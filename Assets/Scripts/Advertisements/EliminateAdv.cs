using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminateAdv : MonoBehaviour
{
    // 広告カウントを行うスクリプトの定義
    CountEliminateAdv countAdv;

    // 親オブジェクト（広告全体のオブジェクト）の定義
    GameObject advertisement;


    public void Start()
    {
        // 親オブジェクトの取得
        advertisement = transform.parent.gameObject;

        // 子オブジェクトのレイヤーを親オブジェクトを元に編集する
        this.GetComponent<SpriteRenderer>().sortingLayerName = advertisement.GetComponent<SpriteRenderer>().sortingLayerName;
        this.GetComponent<SpriteRenderer>().sortingOrder = advertisement.GetComponent<SpriteRenderer>().sortingOrder + 1;

        // 広告カウントスクリプトの取得
        countAdv = GameObject.Find("CountEliminateAdv").GetComponent<CountEliminateAdv>();
    }


    // 消された広告をカウントする処理と広告を消す処理
    public void eliminateAdv()
    {
        countAdv.add_countAdv();
        Destroy(advertisement);
    }
}
