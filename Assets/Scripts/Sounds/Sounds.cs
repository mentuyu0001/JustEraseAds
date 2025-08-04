using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    // このオブジェクト自体の初期化
    private static Sounds instance;

    // 音声の初期化と取得
    [SerializeField] private AudioSource[] bgm;
    [SerializeField] private AudioSource[] se;



    private void Awake()
    {
        // オブジェクトが既にある確認する
        CheckInstance();
    }

    private void Start()
    {
        // 画面遷移してもオブジェクトが壊れないようにする
        DontDestroyOnLoad(this.gameObject);
    }

    // オブジェクトが存在するか確認する
    private void CheckInstance()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    // BGMの再生
    public void PlayBGM(int bgmToPlay)
    {
        if (bgmToPlay < bgm.Length)
        {
            bgm[bgmToPlay].Play();
        }
    }

    // BGMの停止
    public void StopBGM() 
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }
    }

    // SEの再生
    public void PlaySE(int soundToPlay)
    {
        if (soundToPlay < se.Length)
        {
            se[soundToPlay].Play();
        }
    }
}
