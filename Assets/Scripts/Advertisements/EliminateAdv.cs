using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminateAdv : MonoBehaviour
{
    // �L���J�E���g���s���X�N���v�g�̒�`
    CountEliminateAdv countAdv;

    // �e�I�u�W�F�N�g�i�L���S�̂̃I�u�W�F�N�g�j�̒�`
    GameObject advertisement;


    public void Start()
    {
        // �e�I�u�W�F�N�g�̎擾
        advertisement = transform.parent.gameObject;

        // �q�I�u�W�F�N�g�̃��C���[��e�I�u�W�F�N�g�����ɕҏW����
        this.GetComponent<SpriteRenderer>().sortingLayerName = advertisement.GetComponent<SpriteRenderer>().sortingLayerName;
        this.GetComponent<SpriteRenderer>().sortingOrder = advertisement.GetComponent<SpriteRenderer>().sortingOrder + 1;

        // �L���J�E���g�X�N���v�g�̎擾
        countAdv = GameObject.Find("CountEliminateAdv").GetComponent<CountEliminateAdv>();
    }


    // �����ꂽ�L�����J�E���g���鏈���ƍL������������
    public void eliminateAdv()
    {
        countAdv.add_countAdv();
        Destroy(advertisement);
    }
}
