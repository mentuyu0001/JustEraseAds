using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using System.Text;
#if UNITY_EDITOR
using UnityEditor.PackageManager;
#endif
using UnityEngine;
#if UNITY_WSA
using UnityEngine.WSA;
#endif

public class RankingUpload : MonoBehaviour
{
    // <summry>
    // ランキング更新
    // カスタムIDの生成等も行う
    // <summry>

    //アカウントを作成するか
    private bool _shouldCreateAccount;

    //ログイン時に使うID
    private string _customID;

    //IDを保存する時のKEY
    private static readonly string CUSTOM_ID_SAVE_KEY = "JustToGetRIdOfAdsID";
    private static readonly string PLAYERNUM_SAVE_KEY = "JustToGetRIdOfAdsNUM";

    //=================================================================================
    //ログイン処理
    //=================================================================================

    // スコアの更新
    public void Upload(int playerScore)
    {
        _customID = LoadCustomID();

        // 工学展だけの処理
        // _customIDの後ろに番号を追加して、毎回違うユーザーとして扱う様にする
        // ここから
        int playerNum = PlayerPrefs.GetInt(PLAYERNUM_SAVE_KEY, 0);
        
        string loginID = _customID + playerNum.ToString();
        playerNum++;
        PlayerPrefs.SetInt(PLAYERNUM_SAVE_KEY, playerNum);
        // ここまでが特殊な処理、製品版では修正する


        var request = new LoginWithCustomIDRequest { CustomId = loginID, CreateAccount = true }; // ここのCreateAccountもtrueから_shouldCreateAccountに変えるようにする（製品版の時）
        PlayFabClientAPI.LoginWithCustomID(request, result => UploadSuccess(result, playerScore), UploadFailure);
    }

    // Uploadのログインに成功したときの処理
    private void UploadSuccess(LoginResult result, int playerScore)
    {
        //アカウントを作成しようとしたのに、IDが既に使われていて、出来なかった場合
        if (_shouldCreateAccount && !result.NewlyCreated)
        {
            Upload(playerScore);//ログインしなおし
            return;
        }

        //アカウント作成時にIDを保存
        if (result.NewlyCreated)
        {
            SaveCustomID();
        }

        // スコアの送信
        SubmitScore(playerScore);

        Debug.Log($"PlayFabのログインに成功\nPlayFabId : {result.PlayFabId}, CustomId : {_customID}\nアカウントを作成したか : {result.NewlyCreated}");

        Debug.Log("ログインに成功しました");
    }

    // Uploadのログインに失敗したときの処理
    private void UploadFailure(PlayFabError error)
    {
        Debug.Log("ログインに失敗しました");
    }

    //=================================================================================
    //カスタムIDの取得
    //=================================================================================

    //IDを取得
    private string LoadCustomID()
    {
        //IDを取得
        string id = PlayerPrefs.GetString(CUSTOM_ID_SAVE_KEY);

        //保存されていなければ新規生成
        _shouldCreateAccount = string.IsNullOrEmpty(id);
        return _shouldCreateAccount ? GenerateCustomID() : id;
    }

    //IDの保存
    private void SaveCustomID()
    {
        PlayerPrefs.SetString(CUSTOM_ID_SAVE_KEY, _customID);
    }

    //=================================================================================
    //カスタムIDの生成
    //=================================================================================

    //IDに使用する文字
    private static readonly string ID_CHARACTERS = "abcdefghijklmnopqrstuvwxyz";

    //IDを生成する
    private string GenerateCustomID()
    {
        int idLength = 8;//IDの長さ
        StringBuilder stringBuilder = new StringBuilder(idLength);
        var random = new System.Random();

        //ランダムにIDを生成
        for (int i = 0; i < idLength; i++)
        {
            stringBuilder.Append(ID_CHARACTERS[random.Next(ID_CHARACTERS.Length)]);
        }

        return stringBuilder.ToString();
    }

    //=================================================================================
    //スコアの送信
    //=================================================================================
    
    // スコア送信の関数
    private void SubmitScore(int playerScore)
    {
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "TimeAtackRanking",
                    Value = playerScore
                }
            }
        }, result =>
        {
            Debug.Log($"スコア {playerScore} 送信完了！");
        }, error =>
        {
            Debug.Log("スコア送信に失敗しました");
        });
    }

}
