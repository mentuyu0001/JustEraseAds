using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class PenaltyText : MonoBehaviour
{
    // ペナルティ時に3秒間待たせるスクリプト

    // ペナルティ時のテキストの取得
    [SerializeField] private TextMeshProUGUI penaltyText;

    // 広告削除ボタンの取得
    [SerializeField] private GameObject eliminateButton;

    // テキストの背景の取得
    [SerializeField] private GameObject textBackGround;

    // ペナルティ時のカウントダウン
    private async UniTask PenaltyCountDown()
    {
        // 5秒後にキャンセル
        var token = new CancellationTokenSource(TimeSpan.FromSeconds(5f)).Token;

        try
        {
            // 削除ボタンを非アクティブにする
            eliminateButton.SetActive(false);

            // ペナルティ時のカウントダウン
            // 1秒毎にテキストを変更させる
            penaltyText.text = "3";
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            penaltyText.text = "2";
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            penaltyText.text = "1";
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            penaltyText.text = "";
            textBackGround.SetActive(false);

            eliminateButton.SetActive(true);
        } catch (OperationCanceledException)
        {
            Debug.Log("キャンセルされた");
        }
    }

    // ペナルティ時のカウントダウンの関数
    public async void PenaltyCountSrat()
    {
        this.gameObject.SetActive(true);
        textBackGround.SetActive(true);
        await PenaltyCountDown();
    }
}
