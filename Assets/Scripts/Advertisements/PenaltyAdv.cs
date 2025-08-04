using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenaltyAdv : MonoBehaviour
{
    // <summary>
    // �L�����~�X�����̃y�i���e�B�����̈ڍs�Ə����L���̃��C���[��ύX���鏈��
    // </summary>

    // ValueHolder�̒�`
    ValueHolder holder;

    // EliminatePenalty�̒�`
    EliminatePenalty elimPenalty;

    // PenaltyBackGround�̒�`
    GameObject penaltyBackGround;

    // ChangePenaltyBackGround�̒�`
    GameObject changePenaltyBackGround;

    // �y�i���e�B���Ɏg�p����A�X�N���v�g�̒�`
    PenaltyText penaltyCountDown;

    private void Start()
    {
        // ChangePenaltyBackGround�̎擾
        changePenaltyBackGround = GameObject.Find("/ChangePenaltyBackGround");

        // penaltyCountDown�̎擾
        penaltyCountDown = changePenaltyBackGround.transform.Find("PenaltyBackGround/PenaltyCountDown").GetComponent<PenaltyText>();

        // EliminatePenalty�̎擾
        elimPenalty = changePenaltyBackGround.transform.Find("PenaltyBackGround/PenaltyElim").GetComponent<EliminatePenalty>();

        // PenaltyBackGround�̎擾
        penaltyBackGround = changePenaltyBackGround.transform.Find("PenaltyBackGround").gameObject;

        // �L���̃��C���[��ύX���鏈��
        // ValueHolder�̎擾
        holder = GameObject.Find("/ValueHolder").GetComponent<ValueHolder>();

        // ���C���[��`
        // ���C���[��0�`31�܂ł�����`�ł��Ȃ��̂ŁA20�𒴂����i�K��sorting layer��ω�������
        if (holder.get_createAdv() < 10)
        {
            this.GetComponent<SpriteRenderer>().sortingLayerName = "advtisements1-10";
            this.GetComponent<SpriteRenderer>().sortingOrder = holder.get_createAdv() * 2;
        } else
        {
            this.GetComponent<SpriteRenderer>().sortingLayerName = "advtisements11-20";
            this.GetComponent<SpriteRenderer>().sortingOrder = (holder.get_createAdv() % 10) * 2;
        }
        holder.add_createAdv();
    }

    // �y�i���e�B����
    public void penaltyAdv()
    {
        // ���t���閼�O�̕ϐ�
        string sendName = "";

        // �N���[���̖��O���擾���鏈��
        for (int i = 0; i < this.name.Length; i++)
        {
            if (this.name[i] == '(')
            {
                break;
            } else
            {
                sendName += this.name[i];
            }
        }

        // �~�X�����Ƃ��̏����̈ڍs
        // Resources�t�H���_�[�̃I�u�W�F�N�g�̃��[�h�Ɛ���
        GameObject penaltyAdvObj = Resources.Load<GameObject>("Advertisements/Prefab/p"+sendName);
        Instantiate(penaltyAdvObj, Vector3.zero, Quaternion.identity);
        penaltyCountDown.PenaltyCountSrat();
        // EliminatePenalty�Ƀy�i���e�B�L���̖��O�𑗂�
        elimPenalty.setPimg(sendName);
        penaltyBackGround.SetActive(true);
    }
}
