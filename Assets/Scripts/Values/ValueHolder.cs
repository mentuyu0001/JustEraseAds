using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ValueHolder : MonoBehaviour
{
    // �l��ۑ����āA�擾����v���O����

    // �\������L���̐�
    const int ADV_NUM = 19;

    // �L���̎�ނ̑���
    const int ADV_KIND = 19;

    // ���������L���̐�
    int createAdv;

    private void Start()
    {
        createAdv = 0;
    }

    // �S���̍L���̐����擾����֐�
    public int get_ADV_NUM()
    {
        return ADV_NUM;
    }

    // �L���̎�ނ̐����擾����֐�
    public int get_ADV_KIND()
    {
        return ADV_KIND;
    }

    // ���L���𐶐������ۂɋN������֐�
    public void add_createAdv()
    {
        createAdv++;
    }

    // ���������L���̐����擾����֐�
    public int get_createAdv()
    {
        return createAdv;
    }
}
