using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // シーン遷移の関数一覧

    // タイトル遷移
    public void Title()
    {
        SceneManager.LoadScene("Title");
    }

    // プレイ画面遷移
    public void Game()
    {
        SceneManager.LoadScene("Game");
    }

    // スポンサー画面遷移
    public void Sponsor()
    {
        SceneManager.LoadScene("Sponsor");
    }

    // ランキング遷移
    public void Ranking()
    {
        SceneManager.LoadScene("Ranking");
    }

    // ゲームを閉じる
    public void Exit()
    {
        Application.Quit();
    }
}
