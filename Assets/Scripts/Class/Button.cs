using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Buttonクラス
public abstract class Button : MonoBehaviour
{
    // シーン遷移
    public abstract void SceneTransition();

    // マウスが乗っている間、ボタンを暗くする
    // マウスが乗ったときのメソッド
    public void OnMouseEnterHandler()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(0.75f, 0.75f, 0.75f, 1);
    }
    // マウスが離れた時のメソッド
    public void OnMouseExitHandler()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}
