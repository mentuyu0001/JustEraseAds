using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySelectCursor : MonoBehaviour
{
    // �J�[�\���I�����̉���炷�X�N���v�g

    // SE�̏�����
    private Sounds sounds;

    private void Start()
    {
        // �����X�N���v�g�̎擾
        sounds = GameObject.Find("/Sounds").GetComponent<Sounds>();
    }

    // �J�[�\���I�����̉���炷
    public void PlaySE()
    {
        sounds.PlaySE(0);
    }
}
