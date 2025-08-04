using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Button�N���X
public abstract class Button : MonoBehaviour
{
    // �V�[���J��
    public abstract void SceneTransition();

    // �}�E�X������Ă���ԁA�{�^�����Â�����
    // �}�E�X��������Ƃ��̃��\�b�h
    public void OnMouseEnterHandler()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(0.75f, 0.75f, 0.75f, 1);
    }
    // �}�E�X�����ꂽ���̃��\�b�h
    public void OnMouseExitHandler()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}
