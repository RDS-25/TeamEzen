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
        Init();
    }
    public void Init()
    {
        gSettingPanel.SetActive(false);
        gInvenPanel.SetActive(false);
        gSelectStagePanel.SetActive(false);
        gSelectCharacterPanel.SetActive(false);
        gSkillPanel.SetActive(false);
        gCharacterDetail.SetActive(false);
    }
    public void ButtonSetting()
    {
        gSettingPanel.SetActive(true);
        gInvenPanel.SetActive(false);
        gSelectStagePanel.SetActive(false);
        gSelectCharacterPanel.SetActive(false);
        gSkillPanel.SetActive(false);
        gCharacterDetail.SetActive(false);
    }
    public void ButtonInventory()
    {
        gSettingPanel.SetActive(false);
        gInvenPanel.SetActive(true);
        gSelectStagePanel.SetActive(false);
        gSelectCharacterPanel.SetActive(false);
        gSkillPanel.SetActive(false);
        gCharacterDetail.SetActive(false);
    }
    public void ButtonSelectStage()
    {
        gSettingPanel.SetActive(false);
        gInvenPanel.SetActive(false);
        gSelectStagePanel.SetActive(true);
        gSelectCharacterPanel.SetActive(false);
        gSkillPanel.SetActive(false);
        gCharacterDetail.SetActive(false);
    }
    public void ButtonCharacter()
    {
        gSettingPanel.SetActive(false);
        gInvenPanel.SetActive(false);
        gSelectStagePanel.SetActive(false);
        gSelectCharacterPanel.SetActive(true);
        gSkillPanel.SetActive(false);
        gCharacterDetail.SetActive(false);
    }
    public void ButtonSkill()
    {
        gSettingPanel.SetActive(false);
        gInvenPanel.SetActive(false);
        gSelectStagePanel.SetActive(false);
        gSelectCharacterPanel.SetActive(false);
        gSkillPanel.SetActive(true);
        bool a = gSkillPanel.activeSelf;
        gCharacterDetail.SetActive(false);
    }
}
