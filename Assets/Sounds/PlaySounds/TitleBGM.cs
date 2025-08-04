using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBGM : MonoBehaviour
{
    // ���̃I�u�W�F�N�g���̂̏�����
    private static TitleBGM instance;

    // �����X�N���v�g�̒�`
    private Sounds sounds;

    private void Awake()
    {
        // �I�u�W�F�N�g�����ɂ���m�F����
        CheckInstance();
    }

    void Start()
    {
        // �����X�N���v�g�̎擾
        sounds = GameObject.Find("/Sounds").GetComponent<Sounds>();

        // BGM���Đ�����
        sounds.StopBGM();
        sounds.PlayBGM(0);
    }

    // �I�u�W�F�N�g�����݂��邩�m�F����
    private void CheckInstance()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
