using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Ÿ�Ӷ���
/* 20230821
 * �� ��ư Ŭ�� �� �г� Ȱ��ȭ ����
 */
#endregion
public class SettingUIManager : MonoBehaviour
{
    public GameObject gSettingPanel;
    public GameObject gSoundPanel;
    public GameObject gGraphicPanel;
    public GameObject gAccountPanel;
    public GameObject gGamePanel;


    void OnEnable()
    {
        Init();
    }
    private void Init()
    {
        gSettingPanel.SetActive(false);
        gSoundPanel.SetActive(true);
        gGraphicPanel.SetActive(false);
        gAccountPanel.SetActive(false);
        gGamePanel.SetActive(false);
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
    }public void ButtonExit()
    {
        gSettingPanel.SetActive(false);
        gSoundPanel.SetActive(true);
        gGraphicPanel.SetActive(false);
        gAccountPanel.SetActive(false);
        gGamePanel.SetActive(false);
    }

}
