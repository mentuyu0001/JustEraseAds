using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Button�N���X�̌p��
public class ToExit : Button
{
    // SE�̏�����
    private Sounds sounds;

    // �V�[���R���g���[���[�̓ǂݍ���
    [SerializeField] private SceneController sceneController;

    private void Start()
    {
        // �����X�N���v�g�̎擾
        sounds = GameObject.Find("/Sounds").GetComponent<Sounds>();
    }

    // �Q�[�����I��������
    public override void SceneTransition()
    {
        sounds.PlaySE(1);
        sceneController.Exit();
    }
}
