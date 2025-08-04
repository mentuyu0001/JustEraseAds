using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class PenaltyText : MonoBehaviour
{
    // �y�i���e�B����3�b�ԑ҂�����X�N���v�g

    // �y�i���e�B���̃e�L�X�g�̎擾
    [SerializeField] private TextMeshProUGUI penaltyText;

    // �L���폜�{�^���̎擾
    [SerializeField] private GameObject eliminateButton;

    // �e�L�X�g�̔w�i�̎擾
    [SerializeField] private GameObject textBackGround;

    // �y�i���e�B���̃J�E���g�_�E��
    private async UniTask PenaltyCountDown()
    {
        // 5�b��ɃL�����Z��
        var token = new CancellationTokenSource(TimeSpan.FromSeconds(5f)).Token;

        try
        {
            // �폜�{�^�����A�N�e�B�u�ɂ���
            eliminateButton.SetActive(false);

            // �y�i���e�B���̃J�E���g�_�E��
            // 1�b���Ƀe�L�X�g��ύX������
            penaltyText.text = "3";
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            penaltyText.text = "2";
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            penaltyText.text = "1";
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            penaltyText.text = "";
            textBackGround.SetActive(false);

            eliminateButton.SetActive(true);
        } catch (OperationCanceledException)
        {
            Debug.Log("�L�����Z�����ꂽ");
        }
    }

    // �y�i���e�B���̃J�E���g�_�E���̊֐�
    public async void PenaltyCountSrat()
    {
        this.gameObject.SetActive(true);
        textBackGround.SetActive(true);
        await PenaltyCountDown();
    }
}
