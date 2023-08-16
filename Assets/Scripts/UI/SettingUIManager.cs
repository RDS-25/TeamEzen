using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUIManager : MonoBehaviour
{
    public GameObject gSettingPanel;
    public GameObject gSoundPanel;
    public GameObject gGraphicPanel;
    public GameObject gAccountPanel;
    
    private void Init()
    {
        gSettingPanel.SetActive(true);
        gGraphicPanel.SetActive(false);
        gAccountPanel.SetActive(false);
    }
    public void ButtonExit()
    {
        Init();
        gSettingPanel.SetActive(false);
    }
    
}
