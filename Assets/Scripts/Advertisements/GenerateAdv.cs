using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateAdv : MonoBehaviour
{
    // <summary>
    // 広告オブジェクトの生成
    // </summary>

    // 音声スクリプトの定義
    private Sounds sounds;

    // ValueHolderの定義
    [SerializeField] private ValueHolder holder;

    // 生成するオブジェクトの数
    int numAdv;

    // 広告の種類の数
    int kindAdv;

    // オブジェクトの初期化
    private GameObject adv;
    private Camera mainCamera;

    private void Start()
    {
        // 音声スクリプトの取得
        sounds = GameObject.Find("/Sounds").GetComponent<Sounds>();
    }

    // オブジェクトをランダムに取得し、生成する関数
    void SpawnObject(int AdNum)
    {
        // カメラのビューポートの四隅のワールド座標を取得
        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

        // 広告オブジェクトの取得
        adv = Resources.Load<GameObject>("Advertisements/Prefab/" + AdNum.ToString());

        // オブジェクトのサイズを取得
        Vector2 objectSize = adv.GetComponent<SpriteRenderer>().bounds.size;

        // オブジェクトの生成位置をランダムに決定（ただしカメラ内に収まるように調整）
        float spawnX = Random.Range(bottomLeft.x + objectSize.x / 2, topRight.x - objectSize.x / 2);
        float spawnY = Random.Range(bottomLeft.y + objectSize.y / 2, topRight.y - objectSize.y / 2 - 0.7f);

        // オブジェクトを生成とレイヤーの設定
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);
        Instantiate(adv, spawnPosition, Quaternion.identity);
        
    }

    // 広告を生成する関数
    public void GenerateAdvs()
    {
        // カメラの取得
        mainCamera = Camera.main;

        // 生成するオブジェクトの数の取得
        numAdv = holder.get_ADV_NUM();

        // 広告の種類の数取得
        kindAdv = holder.get_ADV_KIND();

        // 生成する広告をランダムで選出する
        List<int> allNumbers = new List<int>();
        for (int i = 0; i < kindAdv; i++)
        {
            allNumbers.Add(i);
        }
        int[] generateArray = new int[numAdv];
        for (int i = 0; i < numAdv; i++)
        {
            int randomIndex = Random.Range(0, allNumbers.Count);
            generateArray[i] = allNumbers[randomIndex];
            allNumbers.RemoveAt(randomIndex); // 選ばれた数をリストから削除
        }

        

        // オブジェクトの生成
        for (int i = 0; i < numAdv; i++)
        {
            Debug.Log(generateArray[i]);
            SpawnObject(generateArray[i]);
        }
    }
}
