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
    public Button[] StageButtons;
    private void Start()
    {
        StageButtons = gSlots.GetComponentsInChildren<Button>();
        for (int i = 0; i < StageButtons.Length; i++)
        {
            int buttonIndex = i;
            StageButtons[i].onClick.AddListener(() => OnClickButton(buttonIndex));
        }
    }
    void OnClickButton(int index)
    {
        nStageNum = index;
        GameManager.instance.stageType = (StageParams.STAGE_TYPE)nStageNum;
        gOrganizingPanel.SetActive(true);
    }

}
