using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePenaltyBackGround : MonoBehaviour
{
    // PenaltyBackGround�̃A�N�e�B�uor��A�N�e�B�u�𑀍삷�邽�߂̃X�N���v�g
    // ������Ԃ���A�N�e�B�u��ԂȂ��߁A����̃X�N���v�g��p�ӂ���
    // �L���ɂ��̃I�u�W�F�N�g��Find�Ō��������āA���삷��


    // PenaltyBackGround�̎擾
    [SerializeField] GameObject penaltyBackGround;

    public void setActive()
    {
        penaltyBackGround.SetActive(true);
    }

    public void setFalse()
    {
        penaltyBackGround.SetActive(false);
    }
}
