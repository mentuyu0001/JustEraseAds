using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdate : MonoBehaviour
{
    // <summry>
    // �X�R�A�̍X�V
    // <summry>

    // �X�R�A�̒�`
    int score;

    // ���U���g�̎擾
    [SerializeField] private TimerCountUp timer;

    // �����L���O�X�N���v�g�̎擾
    [SerializeField] private RankingUpload ranking;

    void Start()
    {
        // �X�R�A�̎擾
        score = timer.GetIntTime();

        score = 5999999 - score; // 5999999�̓X�R�A�̍ő�l

        // �X�R�A�̑��M
        ranking.Upload(score);
    }
}
