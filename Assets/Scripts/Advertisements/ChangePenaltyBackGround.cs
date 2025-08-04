using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePenaltyBackGround : MonoBehaviour
{
    // PenaltyBackGroundのアクティブor非アクティブを操作するためのスクリプト
    // 初期状態が非アクティブ状態なため、代わりのスクリプトを用意した
    // 広告にこのオブジェクトをFindで見つけさせて、操作する


    // PenaltyBackGroundの取得
    [SerializeField] GameObject penaltyBackGround;

    public void setActive()
    {
        penaltyBackGround.SetActive(true);
    }

    public void setFalse()
    {
        penaltyBackGround.SetActive(false);
    }
}
