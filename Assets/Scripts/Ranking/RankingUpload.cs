using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using System.Text;
#if UNITY_EDITOR
using UnityEditor.PackageManager;
#endif
using UnityEngine;
#if UNITY_WSA
using UnityEngine.WSA;
#endif

public class RankingUpload : MonoBehaviour
{
    // <summry>
    // �����L���O�X�V
    // �J�X�^��ID�̐��������s��
    // <summry>

    //�A�J�E���g���쐬���邩
    private bool _shouldCreateAccount;

    //���O�C�����Ɏg��ID
    private string _customID;

    //ID��ۑ����鎞��KEY
    private static readonly string CUSTOM_ID_SAVE_KEY = "JustToGetRIdOfAdsID";
    private static readonly string PLAYERNUM_SAVE_KEY = "JustToGetRIdOfAdsNUM";

    //=================================================================================
    //���O�C������
    //=================================================================================

    // �X�R�A�̍X�V
    public void Upload(int playerScore)
    {
        _customID = LoadCustomID();

        // �H�w�W�����̏���
        // _customID�̌��ɔԍ���ǉ����āA����Ⴄ���[�U�[�Ƃ��Ĉ����l�ɂ���
        // ��������
        int playerNum = PlayerPrefs.GetInt(PLAYERNUM_SAVE_KEY, 0);
        
        string loginID = _customID + playerNum.ToString();
        playerNum++;
        PlayerPrefs.SetInt(PLAYERNUM_SAVE_KEY, playerNum);
        // �����܂ł�����ȏ����A���i�łł͏C������


        var request = new LoginWithCustomIDRequest { CustomId = loginID, CreateAccount = true }; // ������CreateAccount��true����_shouldCreateAccount�ɕς���悤�ɂ���i���i�ł̎��j
        PlayFabClientAPI.LoginWithCustomID(request, result => UploadSuccess(result, playerScore), UploadFailure);
    }

    // Upload�̃��O�C���ɐ��������Ƃ��̏���
    private void UploadSuccess(LoginResult result, int playerScore)
    {
        //�A�J�E���g���쐬���悤�Ƃ����̂ɁAID�����Ɏg���Ă��āA�o���Ȃ������ꍇ
        if (_shouldCreateAccount && !result.NewlyCreated)
        {
            Upload(playerScore);//���O�C�����Ȃ���
            return;
        }

        //�A�J�E���g�쐬����ID��ۑ�
        if (result.NewlyCreated)
        {
            SaveCustomID();
        }

        // �X�R�A�̑��M
        SubmitScore(playerScore);

        Debug.Log($"PlayFab�̃��O�C���ɐ���\nPlayFabId : {result.PlayFabId}, CustomId : {_customID}\n�A�J�E���g���쐬������ : {result.NewlyCreated}");

        Debug.Log("���O�C���ɐ������܂���");
    }

    // Upload�̃��O�C���Ɏ��s�����Ƃ��̏���
    private void UploadFailure(PlayFabError error)
    {
        Debug.Log("���O�C���Ɏ��s���܂���");
    }

    //=================================================================================
    //�J�X�^��ID�̎擾
    //=================================================================================

    //ID���擾
    private string LoadCustomID()
    {
        //ID���擾
        string id = PlayerPrefs.GetString(CUSTOM_ID_SAVE_KEY);

        //�ۑ�����Ă��Ȃ���ΐV�K����
        _shouldCreateAccount = string.IsNullOrEmpty(id);
        return _shouldCreateAccount ? GenerateCustomID() : id;
    }

    //ID�̕ۑ�
    private void SaveCustomID()
    {
        PlayerPrefs.SetString(CUSTOM_ID_SAVE_KEY, _customID);
    }

    //=================================================================================
    //�J�X�^��ID�̐���
    //=================================================================================

    //ID�Ɏg�p���镶��
    private static readonly string ID_CHARACTERS = "abcdefghijklmnopqrstuvwxyz";

    //ID�𐶐�����
    private string GenerateCustomID()
    {
        int idLength = 8;//ID�̒���
        StringBuilder stringBuilder = new StringBuilder(idLength);
        var random = new System.Random();

        //�����_����ID�𐶐�
        for (int i = 0; i < idLength; i++)
        {
            stringBuilder.Append(ID_CHARACTERS[random.Next(ID_CHARACTERS.Length)]);
        }

        return stringBuilder.ToString();
    }

    //=================================================================================
    //�X�R�A�̑��M
    //=================================================================================
    
    // �X�R�A���M�̊֐�
    private void SubmitScore(int playerScore)
    {
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "TimeAtackRanking",
                    Value = playerScore
                }
            }
        }, result =>
        {
            Debug.Log($"�X�R�A {playerScore} ���M�����I");
        }, error =>
        {
            Debug.Log("�X�R�A���M�Ɏ��s���܂���");
        });
    }

}
