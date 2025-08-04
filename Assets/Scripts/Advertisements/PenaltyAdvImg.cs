using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor.PackageManager;
#endif

public class PenaltyAdvImg : MonoBehaviour
{
    // <summary>
    // ペナルティ時に生成される広告のサイズ調整
    // </summary>

    // カメラの取得
    private Camera mainCamera;

    private void Start()
    {
        // ペナルティー広告のソート値の定義
        this.GetComponent<SpriteRenderer>().sortingLayerName = "PenaltyAdv";
        this.GetComponent<SpriteRenderer>().sortingOrder = 1;

        // カメラの取得
        mainCamera = Camera.main;

        // カメラのビューポートの四隅のワールド座標を取得
        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

        // オブジェクトのサイズを取得
        Vector2 objectSize = this.GetComponent<SpriteRenderer>().bounds.size;

        // オブジェクトの位置とサイズを調整
        // 位置の修正
        this.transform.position = Vector3.zero;

        // サイズの修正
        // カメラの幅と高さの取得
        float width = topRight.x - bottomLeft.x;
        float height = topRight.y - bottomLeft.y;

        // 仮のオブジェクトサイズの定義
        Vector2 preObjectSize;
        preObjectSize.x = width;
        preObjectSize.y = objectSize.y * width / objectSize.x;

        // サイズが合わなかったら逆の幅高さ逆で再定義
        if (preObjectSize.y > height)
        {
            preObjectSize.x = objectSize.x * height / objectSize.y;
            preObjectSize.y = height;
        }

        // objectSizeに戻す
        objectSize = preObjectSize;

        // ローカルサイズに調整して代入する
        // 現在のSpriteRendererのサイズを取得
        Vector2 spriteSize = this.GetComponent<SpriteRenderer>().bounds.size;
        // スケール係数を計算して適用
        Vector3 scaleFactor = new Vector3(objectSize.x / spriteSize.x, objectSize.y / spriteSize.y, 1);
        Vector2 nowScale = transform.localScale;
        scaleFactor.x *= nowScale.x;
        scaleFactor.y *= nowScale.y;
        transform.localScale = scaleFactor;
    }
}
