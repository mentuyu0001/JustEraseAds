using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Buttonクラスの継承
public class ToExit : Button
{
    // SEの初期化
    private Sounds sounds;

    // シーンコントローラーの読み込み
    [SerializeField] private SceneController sceneController;

    private void Start()
    {
        // 音声スクリプトの取得
        sounds = GameObject.Find("/Sounds").GetComponent<Sounds>();
    }

    // ゲームを終了させる
    public override void SceneTransition()
    {
        sounds.PlaySE(1);
        sceneController.Exit();
    }
}
