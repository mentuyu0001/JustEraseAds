using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cysharp.Threading.Tasks;  // UniTaskを使うための名前空間
using TMPro;

public class CountEliminateAdv : MonoBehaviour
{
    // <summary>
    // 消された広告をカウントし、次の処理に移行する
    // 具体的にはスコアの表示など
    // </summary>

    // 音声スクリプトの定義
    private Sounds sounds;

    // ValueHolderの定義
    [SerializeField] private ValueHolder holder;

    // Timerの定義
    [SerializeField] private TimerCountUp timer;

    // リザルトゲームオブジェクトの定義と取得
    [SerializeField] private GameObject result;

    // リザルト時のタイムの定義と取得
    [SerializeField] private TextMeshProUGUI resultTime;

    // プレイ画面に表示されるタイマーの定義と取得
    [SerializeField] private GameObject playTimer;

    // タイマーの背景の定義と取得
    [SerializeField] private GameObject timerBackGround;

    // 消す広告のノルマの定義
    int taskAdv;

    // 広告の初期値
    int countAdv = 0;

    private void Start()
    {
        // 音声スクリプトの取得
        sounds = GameObject.Find("/Sounds").GetComponent<Sounds>();

        // 消す広告の数の取得
        taskAdv = holder.get_ADV_NUM();
    }

    // 消された広告のカウントをする関数
    public void add_countAdv()
    {
        countAdv++;
        if (countAdv == taskAdv)
        {
            clear();
        }
    }

    // クリア時の処理
    private void clear()
    {
        // BGMの停止
        sounds.StopBGM();
        // リザルト時のSEの再生
        sounds.PlaySE(2);
        // タイマーの停止
        timer.StopStopwatch();
        // リザルト画面が表示されるときは、ゲーム画面右上のタイマー等の表示を消す
        playTimer.SetActive(false);
        timerBackGround.SetActive(false);
        // リザルト画面のタイムの書き換え
        resultTime.text = timer.DisplayTime();
        // リザルト画面の表示
        result.SetActive(true);
    }
}
