using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/* 20230814
 * ������ Ȱ��ȭ ��ư �Լ� �ۼ�
 */
public class LobbyUIManager : MonoBehaviour
{
    // ���� �κ� UI ��ư
    public GameObject gSettingPanel;

    // ���� ��ư
    public void ButtonSetting()
    {
        gSettingPanel.SetActive(true);
    }
    // �κ��丮 ��ư
    public void ButtonInventory()
    {

    }
    // �������� ��ư
    public void ButtonStage()
    {
        SceneManager.LoadScene("SelectStageScene");
    }
    // ĳ���� ��ư
    public void ButtonCharacter()
    {

    }
    // ��ų ��ư
    public void ButtonSkill()
    {

    }
}
