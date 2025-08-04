using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EliminatePenalty : MonoBehaviour
{
    // �y�i���e�B�w�i�̎擾
    [SerializeField] private GameObject background;


    // �y�i���e�B�摜�̖��O�̎擾
    private string Pimg = "";

    // �y�i���e�B�p�L�������������̏���
    public void eliminatePenaltyAdv()
    {
        // �w�i������
        background.SetActive(false);

        // �j������L�����擾����
        GameObject adv = GameObject.Find("/"+Pimg + "(Clone)");

        // �j��
        Destroy(adv);
    }

    public void setPimg(string name)
    {
        Pimg = "p" + name;
    }
}
