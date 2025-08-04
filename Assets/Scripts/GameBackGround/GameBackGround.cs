using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameBackGround : MonoBehaviour
{
    // �v���C��ʂ̔w�i�������_���ŕς���X�N���v�g

    // �w�i�̎擾�ƒ�`
    [SerializeField] private GameObject[] bg;

    private void SelectBG(int num)
    {
        for (int i = 0; i < bg.Length; i++)
        {
            bg[i].SetActive(false);
        }

        bg[num].SetActive(true);
    }

    private void Start()
    {
        int selectBGnum = Random.Range(0, bg.Length);

        SelectBG(selectBGnum);
    }
}
