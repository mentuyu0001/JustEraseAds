using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // �V�[���J�ڂ̊֐��ꗗ

    // �^�C�g���J��
    public void Title()
    {
        SceneManager.LoadScene("Title");
    }

    // �v���C��ʑJ��
    public void Game()
    {
        SceneManager.LoadScene("Game");
    }

    // �X�|���T�[��ʑJ��
    public void Sponsor()
    {
        SceneManager.LoadScene("Sponsor");
    }

    // �����L���O�J��
    public void Ranking()
    {
        SceneManager.LoadScene("Ranking");
    }

    // �Q�[�������
    public void Exit()
    {
        Application.Quit();
    }
}
