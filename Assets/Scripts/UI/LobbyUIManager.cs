using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyUIManager : MonoBehaviour
{
    // 메인 로비 UI 버튼
    public GameObject gLobbyPanel;
    public GameObject gSettingPanel;
    public GameObject gInvenPanel;
    public GameObject gSelectStagePanel;
    public GameObject gSelectCharacterPanel;
    public GameObject gSkillPanel;
    public GameObject gCharacterDetail;

    private void Start()
    {
        ButtonLobby();
    }
    // 설정 버튼
    public void ButtonSetting()
    {
        gLobbyPanel.SetActive(false);
        gSettingPanel.SetActive(true);
        gInvenPanel.SetActive(false);
        gSelectStagePanel.SetActive(false);
        gSelectCharacterPanel.SetActive(false);
        gSkillPanel.SetActive(false);
        gCharacterDetail.SetActive(false);
    }
    // 인벤토리 버튼
    public void ButtonInventory()
    {
        gLobbyPanel.SetActive(false);
        gSettingPanel.SetActive(false);
        gInvenPanel.SetActive(true);
        gSelectStagePanel.SetActive(false);
        gSelectCharacterPanel.SetActive(false);
        gSkillPanel.SetActive(false);
        gCharacterDetail.SetActive(false);

    }
    // 스테이지 버튼
    public void ButtonSelectStage()
    {
        gLobbyPanel.SetActive(false);
        gSettingPanel.SetActive(false);
        gInvenPanel.SetActive(false);
        gSelectStagePanel.SetActive(true);
        gSelectCharacterPanel.SetActive(false);
        gSkillPanel.SetActive(false);
        gCharacterDetail.SetActive(false);

    }
    // 캐릭터 버튼
    public void ButtonCharacter()
    {
        gLobbyPanel.SetActive(false);
        gSettingPanel.SetActive(false);
        gInvenPanel.SetActive(false);
        gSelectStagePanel.SetActive(false);
        gSelectCharacterPanel.SetActive(true);
        gSkillPanel.SetActive(false);
        gCharacterDetail.SetActive(false);

    }
    // 스킬 버튼
    public void ButtonSkill()
    {
        gLobbyPanel.SetActive(false);
        gSettingPanel.SetActive(false);
        gInvenPanel.SetActive(false);
        gSelectStagePanel.SetActive(false);
        gSelectCharacterPanel.SetActive(false);
        gSkillPanel.SetActive(true);
        gCharacterDetail.SetActive(false);

    }
    public void ButtonLobby()
    {
        gLobbyPanel.SetActive(true);
        gSettingPanel.SetActive(false);
        gInvenPanel.SetActive(false);
        gSelectStagePanel.SetActive(false);
        gSelectCharacterPanel.SetActive(false);
        gSkillPanel.SetActive(false);
        gCharacterDetail.SetActive(false);
    }
}
