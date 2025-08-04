using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using TMPro;

public class PlayCountDown : MonoBehaviour
{
    // <summary>
    // ゲーム開始前のカウントダウンをするスクリプト
    // </summary>

    // SEの初期化
    private Sounds sounds;

    // TitleBGMの初期化
    private TitleBGM titleBGM;

    // カウントダウンを行うテキスト
    [SerializeField] private TextMeshProUGUI countDown;

    // ゲーム開始時に起動するタイマーの取得
    [SerializeField] private TimerCountUp timer;

    // ゲーム開始時に起動する広告生成を行うスクリプトの取得
    [SerializeField] private GenerateAdv generater;

    // プレイ直前のカウントダウンを行う巻子
    private async UniTask CountDown()
    {
        // 5秒後にキャンセル
        var token = new CancellationTokenSource(TimeSpan.FromSeconds(5f)).Token;

        try
        {
            // ゲームのカウントダウン
            // 1秒毎にテキストを変更させる
            // オブジェクトがあるかどうかの確認
            if (GameObject.Find("/TitleBGM") != null)
            {
                titleBGM.DestroyGameObject(); // TItleBGMオブジェクトの破壊
            }
            
            sounds.StopBGM(); // BGMの停止
            sounds.PlaySE(3); // カウントダウンのSE
            countDown.text = "３";
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            countDown.text = "２";
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            countDown.text = "１";
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            countDown.text = "";
            sounds.PlayBGM(1);


            // タイマーの起動
            timer.StartStopwatch().Forget();

            // 広告の生成
            generater.GenerateAdvs();

        } catch (OperationCanceledException)
        {
            Debug.Log("キャンセルされた");
        }
    }

    private async void Start()
    {
        // 音声スクリプトの取得
        sounds = GameObject.Find("/Sounds").GetComponent<Sounds>();

        // TitleBGMの取得
        // オブジェクトがあるかどうかの確認
        if (GameObject.Find("/TitleBGM") != null)
        {
            titleBGM = GameObject.Find("/TitleBGM").GetComponent<TitleBGM>();
        }

        await CountDown();
    }
}