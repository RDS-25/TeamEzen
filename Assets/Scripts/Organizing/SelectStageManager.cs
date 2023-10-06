using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Params;
public class SelectStageManager : MonoBehaviour
{
    int nStageNum;
    public Transform gSlots;
    public GameObject gOrganizingPanel;
    public GameObject SelectStagePanel;
    public Button[] StageButtons;
    private void OnEnable()
    {
        StageButtons = gSlots.GetComponentsInChildren<Button>();
        for (int i = 0; i < StageButtons.Length; i++)
        {
            int buttonIndex = i;
            StageButtons[i].onClick.AddListener(() => OnClickButton(buttonIndex));
        }
    }

    public void ButtonExit()
    {
        SelectStagePanel.SetActive(false);
    }
    void OnClickButton(int index)
    {
        Debug.Log("스테이지 버튼 " + index);
        nStageNum = index;
        GameManager.instance.stageType = (StageParams.STAGE_TYPE)nStageNum;
        gOrganizingPanel.SetActive(true);
    }

}
