using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor.PackageManager;
#endif

public class PenaltyAdvImg : MonoBehaviour
{
    // <summary>
    // �y�i���e�B���ɐ��������L���̃T�C�Y����
    // </summary>

    // �J�����̎擾
    private Camera mainCamera;

    private void Start()
    {
        // �y�i���e�B�[�L���̃\�[�g�l�̒�`
        this.GetComponent<SpriteRenderer>().sortingLayerName = "PenaltyAdv";
        this.GetComponent<SpriteRenderer>().sortingOrder = 1;

        // �J�����̎擾
        mainCamera = Camera.main;

        // �J�����̃r���[�|�[�g�̎l���̃��[���h���W���擾
        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

        // �I�u�W�F�N�g�̃T�C�Y���擾
        Vector2 objectSize = this.GetComponent<SpriteRenderer>().bounds.size;

        // �I�u�W�F�N�g�̈ʒu�ƃT�C�Y�𒲐�
        // �ʒu�̏C��
        this.transform.position = Vector3.zero;

        // �T�C�Y�̏C��
        // �J�����̕��ƍ����̎擾
        float width = topRight.x - bottomLeft.x;
        float height = topRight.y - bottomLeft.y;

        // ���̃I�u�W�F�N�g�T�C�Y�̒�`
        Vector2 preObjectSize;
        preObjectSize.x = width;
        preObjectSize.y = objectSize.y * width / objectSize.x;

        // �T�C�Y������Ȃ�������t�̕������t�ōĒ�`
        if (preObjectSize.y > height)
        {
            preObjectSize.x = objectSize.x * height / objectSize.y;
            preObjectSize.y = height;
        }

        // objectSize�ɖ߂�
        objectSize = preObjectSize;

        // ���[�J���T�C�Y�ɒ������đ������
        // ���݂�SpriteRenderer�̃T�C�Y���擾
        Vector2 spriteSize = this.GetComponent<SpriteRenderer>().bounds.size;
        // �X�P�[���W�����v�Z���ēK�p
        Vector3 scaleFactor = new Vector3(objectSize.x / spriteSize.x, objectSize.y / spriteSize.y, 1);
        Vector2 nowScale = transform.localScale;
        scaleFactor.x *= nowScale.x;
        scaleFactor.y *= nowScale.y;
        transform.localScale = scaleFactor;
    }
}
