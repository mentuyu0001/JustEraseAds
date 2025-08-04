using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBGM : MonoBehaviour
{
    // このオブジェクト自体の初期化
    private static TitleBGM instance;

    // 音声スクリプトの定義
    private Sounds sounds;

    private void Awake()
    {
        // オブジェクトが既にある確認する
        CheckInstance();
    }

    void Start()
    {
        // 音声スクリプトの取得
        sounds = GameObject.Find("/Sounds").GetComponent<Sounds>();

        // BGMを再生する
        sounds.StopBGM();
        sounds.PlayBGM(0);
    }

    // オブジェクトが存在するか確認する
    private void CheckInstance()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
