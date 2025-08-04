using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    // ���̃I�u�W�F�N�g���̂̏�����
    private static Sounds instance;

    // �����̏������Ǝ擾
    [SerializeField] private AudioSource[] bgm;
    [SerializeField] private AudioSource[] se;



    private void Awake()
    {
        // �I�u�W�F�N�g�����ɂ���m�F����
        CheckInstance();
    }

    private void Start()
    {
        // ��ʑJ�ڂ��Ă��I�u�W�F�N�g�����Ȃ��悤�ɂ���
        DontDestroyOnLoad(this.gameObject);
    }

    // �I�u�W�F�N�g�����݂��邩�m�F����
    private void CheckInstance()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    // BGM�̍Đ�
    public void PlayBGM(int bgmToPlay)
    {
        if (bgmToPlay < bgm.Length)
        {
            bgm[bgmToPlay].Play();
        }
    }

    // BGM�̒�~
    public void StopBGM() 
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }
    }

    // SE�̍Đ�
    public void PlaySE(int soundToPlay)
    {
        if (soundToPlay < se.Length)
        {
            se[soundToPlay].Play();
        }
    }
}
