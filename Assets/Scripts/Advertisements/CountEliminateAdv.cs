using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cysharp.Threading.Tasks;  // UniTask���g�����߂̖��O���
using TMPro;

public class CountEliminateAdv : MonoBehaviour
{
    // <summary>
    // �����ꂽ�L�����J�E���g���A���̏����Ɉڍs����
    // ��̓I�ɂ̓X�R�A�̕\���Ȃ�
    // </summary>

    // �����X�N���v�g�̒�`
    private Sounds sounds;

    // ValueHolder�̒�`
    [SerializeField] private ValueHolder holder;

    // Timer�̒�`
    [SerializeField] private TimerCountUp timer;

    // ���U���g�Q�[���I�u�W�F�N�g�̒�`�Ǝ擾
    [SerializeField] private GameObject result;

    // ���U���g���̃^�C���̒�`�Ǝ擾
    [SerializeField] private TextMeshProUGUI resultTime;

    // �v���C��ʂɕ\�������^�C�}�[�̒�`�Ǝ擾
    [SerializeField] private GameObject playTimer;

    // �^�C�}�[�̔w�i�̒�`�Ǝ擾
    [SerializeField] private GameObject timerBackGround;

    // �����L���̃m���}�̒�`
    int taskAdv;

    // �L���̏����l
    int countAdv = 0;

    private void Start()
    {
        // �����X�N���v�g�̎擾
        sounds = GameObject.Find("/Sounds").GetComponent<Sounds>();

        // �����L���̐��̎擾
        taskAdv = holder.get_ADV_NUM();
    }

    // �����ꂽ�L���̃J�E���g������֐�
    public void add_countAdv()
    {
        countAdv++;
        if (countAdv == taskAdv)
        {
            clear();
        }
    }

    // �N���A���̏���
    private void clear()
    {
        // BGM�̒�~
        sounds.StopBGM();
        // ���U���g����SE�̍Đ�
        sounds.PlaySE(2);
        // �^�C�}�[�̒�~
        timer.StopStopwatch();
        // ���U���g��ʂ��\�������Ƃ��́A�Q�[����ʉE��̃^�C�}�[���̕\��������
        playTimer.SetActive(false);
        timerBackGround.SetActive(false);
        // ���U���g��ʂ̃^�C���̏�������
        resultTime.text = timer.DisplayTime();
        // ���U���g��ʂ̕\��
        result.SetActive(true);
    }
}
