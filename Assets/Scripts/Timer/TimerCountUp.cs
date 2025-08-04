using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class TimerCountUp : MonoBehaviour
{
    // UI�̕\��
    [SerializeField] private TextMeshProUGUI timer;

    // �L�����Z������
    private CancellationTokenSource cancellationTokenSource;

    // �o�ߎ���
    float elapsedTime = 0f;

    public async UniTaskVoid StartStopwatch()
    {
        // �L�����Z������
        cancellationTokenSource = new CancellationTokenSource();

        try
        {
            while (true)  // �^�X�N�𖳌��Ɏ��s
            {
                await UniTask.Yield(PlayerLoopTiming.Update, cancellationTokenSource.Token);  // �L�����Z���g�[�N�����g�p���đҋ@
                elapsedTime += Time.deltaTime;  // �o�ߎ��Ԃ𑝂₷
                timer.text = DisplayTime();  // �o�ߎ���UI��\��
            }
        }
        catch (OperationCanceledException)
        {
            // �L�����Z������
        }
    }

    public void StopStopwatch()
    {
        cancellationTokenSource?.Cancel();  // �^�X�N���L�����Z��
    }

    public string DisplayTime()
    {
        string timeText;

        float minutes = Mathf.FloorToInt(elapsedTime / 60);
        float seconds = Mathf.FloorToInt(elapsedTime % 60);
        float milliseconds = (elapsedTime % 1) * 1000 - 0.5f;  // �\���^�C�����l�̌ܓ������̂�0.5f����

        // �X�R�A�̃I�[�o�[�t���[�΍�
        if (minutes > 99)
        {
            minutes = 99;
            seconds = 59;
            milliseconds = 999;

            elapsedTime = 5999.999f;
        }

        timeText = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);  // "MM:SS:MS"�`���ŕ\��

        return timeText;
    }

    // �^�C����1000�{���āAint�^�ɂ��ĕԂ��i���M�p�̊֐��j
    public int GetIntTime()
    {
        // float�ɕϊ�����
        float minutes = Mathf.FloorToInt(elapsedTime / 60);
        float seconds = Mathf.FloorToInt(elapsedTime % 60);
        float milliseconds = (elapsedTime % 1) * 1000;  // �~���b���\������ꍇ
        
        // int�ɕϊ�����
        int submitTime = (int)(minutes * 1000 * 60 + seconds * 1000 + milliseconds);

        return submitTime;
    }

    void Start()
    {
        // UI�̏�����
        timer.text = "00:00:000";
    }
}
