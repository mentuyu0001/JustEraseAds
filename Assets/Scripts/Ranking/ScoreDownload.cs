using PlayFab.ClientModels;
using PlayFab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDownload : MonoBehaviour
{
    // 編集するテキストの取得
    [SerializeField] private TextMeshProUGUI rankingText;
    [SerializeField] private TextMeshProUGUI loadText;

    private void Start()
    {
        LoginAndDownLoad();
    }

    // ログイン処理
    private void LoginAndDownLoad()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = "JustToGetRidOfAdvsRankingLoader",
            CreateAccount = true
        };

        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, DownloadFailure);
    }

    // ログインに成功したときの処理
    private void OnLoginSuccess(LoginResult result)
    {
        Download();  // ログインが完了したらダウンロードを開始
    }

    // スコアの読み込み
    private void Download()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "TimeAtackRanking", // 統計情報名を指定
            StartPosition = 0, // 何位以降のランキングを取得するか指定
            MaxResultsCount = 10 // ランキングデータを何件取得するか指定
        };

        PlayFabClientAPI.GetLeaderboard(request, DownloadSuccess, DownloadFailure);
    }

    // Downloadのログインに成功したときの処理
    private void DownloadSuccess(GetLeaderboardResult leaderboardResult)
    {
        loadText.text = "";

        // 実際は良い感じのランキングを表示するコードにします。
        foreach (var item in leaderboardResult.Leaderboard)
        {
            // 表示するタイムの文字列と数値の定義
            int intScore = 5999999 - item.StatValue; // 5999999はスコアの最大値
            string textScore = "";
            textScore += (intScore / 1000 / 60).ToString("00") + ":" +
                ((intScore / 1000) % 60).ToString("00") + ":" +
                (intScore % 1000).ToString("000");

            // 順位の表示（5999999はスコアの最大値）
            Debug.Log($"{item.Position + 1}位: {item.DisplayName} - {5999999 - item.StatValue}s");
            if (item.Position < 9)
            {
                rankingText.text += "　";
            }
            // テキストの変換
            rankingText.text += ConvertToFullWidth((item.Position + 1).ToString());
            rankingText.text += "位：";
            rankingText.text += ConvertToFullWidth(textScore);
            if (item.Position < 9)
            {
                rankingText.text += "\n";
            }
        }
    }

    // Downloadのログインに失敗したときの処理
    private void DownloadFailure(PlayFabError error)
    {
        loadText.text = "取得に失敗しました\n時間をおいて\nやり直して下さい";
    }

    //=======================================================================
    //半角を全角、全角を半角に変換する関数
    //=======================================================================
    const int ConvertionConstant = 65248;

    static public string ConvertToFullWidth(string halfWidthStr)
    {
        string fullWidthStr = null;

        for (int i = 0; i < halfWidthStr.Length; i++)
        {
            fullWidthStr += (char)(halfWidthStr[i] + ConvertionConstant);
        }

        return fullWidthStr;
    }

    static public string ConvertToHalfWidth(string fullWidthStr)
    {
        string halfWidthStr = null;

        for (int i = 0; i < fullWidthStr.Length; i++)
        {
            halfWidthStr += (char)(fullWidthStr[i] - ConvertionConstant);
        }

        return halfWidthStr;
    }
}
