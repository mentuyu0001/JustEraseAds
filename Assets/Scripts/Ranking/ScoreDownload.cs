using PlayFab.ClientModels;
using PlayFab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDownload : MonoBehaviour
{
    // �ҏW����e�L�X�g�̎擾
    [SerializeField] private TextMeshProUGUI rankingText;
    [SerializeField] private TextMeshProUGUI loadText;

    private void Start()
    {
        LoginAndDownLoad();
    }

    // ���O�C������
    private void LoginAndDownLoad()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = "JustToGetRidOfAdvsRankingLoader",
            CreateAccount = true
        };

        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, DownloadFailure);
    }

    // ���O�C���ɐ��������Ƃ��̏���
    private void OnLoginSuccess(LoginResult result)
    {
        Download();  // ���O�C��������������_�E�����[�h���J�n
    }

    // �X�R�A�̓ǂݍ���
    private void Download()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "TimeAtackRanking", // ���v��񖼂��w��
            StartPosition = 0, // ���ʈȍ~�̃����L���O���擾���邩�w��
            MaxResultsCount = 10 // �����L���O�f�[�^�������擾���邩�w��
        };

        PlayFabClientAPI.GetLeaderboard(request, DownloadSuccess, DownloadFailure);
    }

    // Download�̃��O�C���ɐ��������Ƃ��̏���
    private void DownloadSuccess(GetLeaderboardResult leaderboardResult)
    {
        loadText.text = "";

        // ���ۂ͗ǂ������̃����L���O��\������R�[�h�ɂ��܂��B
        foreach (var item in leaderboardResult.Leaderboard)
        {
            // �\������^�C���̕�����Ɛ��l�̒�`
            int intScore = 5999999 - item.StatValue; // 5999999�̓X�R�A�̍ő�l
            string textScore = "";
            textScore += (intScore / 1000 / 60).ToString("00") + ":" +
                ((intScore / 1000) % 60).ToString("00") + ":" +
                (intScore % 1000).ToString("000");

            // ���ʂ̕\���i5999999�̓X�R�A�̍ő�l�j
            Debug.Log($"{item.Position + 1}��: {item.DisplayName} - {5999999 - item.StatValue}s");
            if (item.Position < 9)
            {
                rankingText.text += "�@";
            }
            // �e�L�X�g�̕ϊ�
            rankingText.text += ConvertToFullWidth((item.Position + 1).ToString());
            rankingText.text += "�ʁF";
            rankingText.text += ConvertToFullWidth(textScore);
            if (item.Position < 9)
            {
                rankingText.text += "\n";
            }
        }
    }

    // Download�̃��O�C���Ɏ��s�����Ƃ��̏���
    private void DownloadFailure(PlayFabError error)
    {
        loadText.text = "�擾�Ɏ��s���܂���\n���Ԃ�������\n��蒼���ĉ�����";
    }

    //=======================================================================
    //���p��S�p�A�S�p�𔼊p�ɕϊ�����֐�
    //=======================================================================
    const int ConvertionConstant = 65248;

    static public string ConvertToFullWidth(string halfWidthStr)
    {
        string fullWidthStr = null;

        for (int i = 0; i < halfWidthStr.Length; i++)
        {
            fullWidthStr += (char)(halfWidthStr[i] + ConvertionConstant);
        }

        return fullWidthStr;
    }

    static public string ConvertToHalfWidth(string fullWidthStr)
    {
        string halfWidthStr = null;

        for (int i = 0; i < fullWidthStr.Length; i++)
        {
            halfWidthStr += (char)(fullWidthStr[i] - ConvertionConstant);
        }

        return halfWidthStr;
    }
}
