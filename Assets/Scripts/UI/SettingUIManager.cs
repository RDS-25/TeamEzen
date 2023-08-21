using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUIManager : MonoBehaviour
{
    public GameObject gSettingPanel;
    public GameObject gSoundPanel;
    public GameObject gGraphicPanel;
    public GameObject gAccountPanel;
    public GameObject gGamePanel;

    private void Init()
    {
        gSoundPanel.SetActive(true);
        gGraphicPanel.SetActive(false);
        gAccountPanel.SetActive(false);
        gGamePanel.SetActive(false);
    }
    public void ButtonExit()
    {
        Init();
        gSettingPanel.SetActive(false);
    }
    public void ButtonSound()
    {
        gSoundPanel.SetActive(true);
        gGraphicPanel.SetActive(false);
        gAccountPanel.SetActive(false);
        gGamePanel.SetActive(false);
    }
    public void ButtonGraphic()
    {
        gSoundPanel.SetActive(false);
        gGraphicPanel.SetActive(true);
        gAccountPanel.SetActive(false);
        gGamePanel.SetActive(false);
    }
    public void ButtonAccount()
    {
        gSoundPanel.SetActive(false);
        gGraphicPanel.SetActive(false);
        gAccountPanel.SetActive(true);
        gGamePanel.SetActive(false);
    }
    public void ButtonGame()
    {
        gSoundPanel.SetActive(false);
        gGraphicPanel.SetActive(false);
        gAccountPanel.SetActive(false);
        gGamePanel.SetActive(true);
    }

}
