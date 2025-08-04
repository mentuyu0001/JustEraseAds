using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Button�N���X�̌p��
public class ToRanking : Button
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

    // �����L���O��ʂɑJ�ڂ���
    public override void SceneTransition()
    {
        sounds.PlaySE(1);
        sceneController.Ranking();
    }
}
