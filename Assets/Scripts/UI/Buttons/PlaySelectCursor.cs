using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySelectCursor : MonoBehaviour
{
    // カーソル選択時の音を鳴らすスクリプト

    // SEの初期化
    private Sounds sounds;

    private void Start()
    {
        // 音声スクリプトの取得
        sounds = GameObject.Find("/Sounds").GetComponent<Sounds>();
    }

    // カーソル選択時の音を鳴らす
    public void PlaySE()
    {
        sounds.PlaySE(0);
    }
}
