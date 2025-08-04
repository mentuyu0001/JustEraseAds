using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdate : MonoBehaviour
{
    // <summry>
    // スコアの更新
    // <summry>

    // スコアの定義
    int score;

    // リザルトの取得
    [SerializeField] private TimerCountUp timer;

    // ランキングスクリプトの取得
    [SerializeField] private RankingUpload ranking;

    void Start()
    {
        // スコアの取得
        score = timer.GetIntTime();

        score = 5999999 - score; // 5999999はスコアの最大値

        // スコアの送信
        ranking.Upload(score);
    }
}
