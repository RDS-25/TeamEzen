using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyUIManager : MonoBehaviour
{
    // ���� �κ� UI ��ư
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
    // ���� ��ư
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
    // �κ��丮 ��ư
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
    // �������� ��ư
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
    // ĳ���� ��ư
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
    // ��ų ��ư
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
