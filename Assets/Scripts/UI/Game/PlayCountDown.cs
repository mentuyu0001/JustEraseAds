using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using TMPro;

public class PlayCountDown : MonoBehaviour
{
    // <summary>
    // �Q�[���J�n�O�̃J�E���g�_�E��������X�N���v�g
    // </summary>

    // SE�̏�����
    private Sounds sounds;

    // TitleBGM�̏�����
    private TitleBGM titleBGM;

    // �J�E���g�_�E�����s���e�L�X�g
    [SerializeField] private TextMeshProUGUI countDown;

    // �Q�[���J�n���ɋN������^�C�}�[�̎擾
    [SerializeField] private TimerCountUp timer;

    // �Q�[���J�n���ɋN������L���������s���X�N���v�g�̎擾
    [SerializeField] private GenerateAdv generater;

    // �v���C���O�̃J�E���g�_�E�����s�����q
    private async UniTask CountDown()
    {
        // 5�b��ɃL�����Z��
        var token = new CancellationTokenSource(TimeSpan.FromSeconds(5f)).Token;

        try
        {
            // �Q�[���̃J�E���g�_�E��
            // 1�b���Ƀe�L�X�g��ύX������
            // �I�u�W�F�N�g�����邩�ǂ����̊m�F
            if (GameObject.Find("/TitleBGM") != null)
            {
                titleBGM.DestroyGameObject(); // TItleBGM�I�u�W�F�N�g�̔j��
            }
            
            sounds.StopBGM(); // BGM�̒�~
            sounds.PlaySE(3); // �J�E���g�_�E����SE
            countDown.text = "�R";
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            countDown.text = "�Q";
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            countDown.text = "�P";
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            countDown.text = "";
            sounds.PlayBGM(1);


            // �^�C�}�[�̋N��
            timer.StartStopwatch().Forget();

            // �L���̐���
            generater.GenerateAdvs();

        } catch (OperationCanceledException)
        {
            Debug.Log("�L�����Z�����ꂽ");
        }
    }

    private async void Start()
    {
        // �����X�N���v�g�̎擾
        sounds = GameObject.Find("/Sounds").GetComponent<Sounds>();

        // TitleBGM�̎擾
        // �I�u�W�F�N�g�����邩�ǂ����̊m�F
        if (GameObject.Find("/TitleBGM") != null)
        {
            titleBGM = GameObject.Find("/TitleBGM").GetComponent<TitleBGM>();
        }

        await CountDown();
    }
}