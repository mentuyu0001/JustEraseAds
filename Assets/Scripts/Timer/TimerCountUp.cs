using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class TimerCountUp : MonoBehaviour
{
    // UIの表示
    [SerializeField] private TextMeshProUGUI timer;

    // キャンセル処理
    private CancellationTokenSource cancellationTokenSource;

    // 経過時間
    float elapsedTime = 0f;

    public async UniTaskVoid StartStopwatch()
    {
        // キャンセル処理
        cancellationTokenSource = new CancellationTokenSource();

        try
        {
            while (true)  // タスクを無限に実行
            {
                await UniTask.Yield(PlayerLoopTiming.Update, cancellationTokenSource.Token);  // キャンセルトークンを使用して待機
                elapsedTime += Time.deltaTime;  // 経過時間を増やす
                timer.text = DisplayTime();  // 経過時間UIを表示
            }
        }
        catch (OperationCanceledException)
        {
            // キャンセル処理
        }
    }

    public void StopStopwatch()
    {
        cancellationTokenSource?.Cancel();  // タスクをキャンセル
    }

    public string DisplayTime()
    {
        string timeText;

        float minutes = Mathf.FloorToInt(elapsedTime / 60);
        float seconds = Mathf.FloorToInt(elapsedTime % 60);
        float milliseconds = (elapsedTime % 1) * 1000 - 0.5f;  // 表示タイムが四捨五入されるので0.5f引く

        // スコアのオーバーフロー対策
        if (minutes > 99)
        {
            minutes = 99;
            seconds = 59;
            milliseconds = 999;

            elapsedTime = 5999.999f;
        }

        timeText = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);  // "MM:SS:MS"形式で表示

        return timeText;
    }

    // タイムを1000倍して、int型にして返す（送信用の関数）
    public int GetIntTime()
    {
        // floatに変換する
        float minutes = Mathf.FloorToInt(elapsedTime / 60);
        float seconds = Mathf.FloorToInt(elapsedTime % 60);
        float milliseconds = (elapsedTime % 1) * 1000;  // ミリ秒も表示する場合
        
        // intに変換する
        int submitTime = (int)(minutes * 1000 * 60 + seconds * 1000 + milliseconds);

        return submitTime;
    }

    void Start()
    {
        // UIの初期化
        timer.text = "00:00:000";
    }
}
