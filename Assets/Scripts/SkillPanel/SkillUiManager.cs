using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillUiManager : MonoBehaviour
{
    public GameObject gMainPanel;
    public GameObject gSkillPanel;
    public GameObject gSkillLevelUpPanel;
    public GameObject gSkillChangePanel;
    public GameObject gCharacterImagePanel;

    void Start()
    {
        Init();
    }

    void Init()
    {
        gSkillPanel.SetActive(true);
        gSkillLevelUpPanel.SetActive(false);
        gSkillChangePanel.SetActive(false);
        gCharacterImagePanel.SetActive(true);
    }
    public void ButtonExit()
    {
        gMainPanel.SetActive(false);
        Init();
    }
    public void ButtonToSkillPanelBack()
    {
        gSkillPanel.SetActive(true);
        gSkillLevelUpPanel.SetActive(false);
        gSkillChangePanel.SetActive(false);
    }
    public void ButtonSkillLevelUpPanel()
    {
        gSkillPanel.SetActive(false);
        gSkillLevelUpPanel.SetActive(true);
        gSkillChangePanel.SetActive(false);
    }
    public void ButtonSkillChange()
    {
        gSkillPanel.SetActive(false);
        gSkillLevelUpPanel.SetActive(false);
        gSkillChangePanel.SetActive(true);
    }
}
