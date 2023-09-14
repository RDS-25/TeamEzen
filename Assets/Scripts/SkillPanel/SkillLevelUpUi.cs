using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SkillLevelUpUi : MonoBehaviour
{
    public TMP_Text currentLevel;
    public TMP_Text nextLevel;
    public Image skillImamge;
    public TMP_Text skillName;
    public TMP_Text skillDescription;
    //public Image imgFirstMaterial;
    //public Image imgSecondMaterial;
    //public Image imgThirdMaterial;


    public List<Button> listButtons = new();
    public SkillPanelUi skillPanelUi;
    Dictionary<string, string> dictSelectedSkillParams = new();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < listButtons.Count; i++)
        {
            int buttonIndex = i;
            listButtons[i].onClick.AddListener(() => OnClickButton(buttonIndex));
        }
    }

    void OnClickButton(int index)
    {
        switch (index)
        {
            case 0:
                SetDictSkillParams(skillPanelUi.dictCurPassive);
                ShowSkillData();
                break;
            case 1:
                SetDictSkillParams(skillPanelUi.dictCurBasic);
                ShowSkillData();
                break;
            case 2:
                SetDictSkillParams(skillPanelUi.dictCurActive);
                ShowSkillData();
                break;
            case 3:
                SetDictSkillParams(skillPanelUi.dictCurUlt);
                ShowSkillData();
                break;
            default:
                break;
        }

    }
    void SetDictSkillParams(Dictionary<string,string> dictTemp)
    {
        dictSelectedSkillParams = dictTemp;
    }
    void ShowSkillData()
    {
        currentLevel.text = "Lv. " + dictSelectedSkillParams[SkillID.LEVEL];
        nextLevel.text = "Lv. " + (float.Parse(dictSelectedSkillParams[SkillID.LEVEL]) + 1);
        skillImamge.sprite = GameManager.instance.LoadAndSetSprite(dictSelectedSkillParams[SkillID.ICON_PATH]);
        skillName.text = dictSelectedSkillParams[SkillID.NAME];
        skillDescription.text = dictSelectedSkillParams[SkillID.DESCRIPT];

    }
}
