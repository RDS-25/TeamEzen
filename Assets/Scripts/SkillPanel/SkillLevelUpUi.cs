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
    public Dictionary<float, float> dictMatExp = new();
    Dictionary<string, string> dictItemCount = new();

    public List<Button> listButtons = new();
    public List<Button> listMatButtons = new();
    public SkillPanelUi skillPanelUi;
    Dictionary<string, string> dictSelectedSkillParams = new();
    // Start is called before the first frame update
    void Start()
    {
        dictItemCount = GameManager.instance.DataRead(FolderPath.PARAMS_ITEM_COUNT);

        for (int i = 0; i < listButtons.Count; i++)
        {
            int buttonIndex = i;
            listButtons[i].onClick.AddListener(() => OnClickButton(buttonIndex));
        }
        for (int i = 0; i < listButtons.Count; i++)
        {
            int buttonIndex = i;
            listButtons[i].onClick.AddListener(() => OnClickMatExpButton(buttonIndex));
        }
    }
    void Update()
    {
        // dictMatExp ���⿡ ����ִ� id ���� ���� ���׸��� ǥ�����ֱ�
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
    void OnClickMatExpButton(int index)
    {
        // ������ ��� ��ųʸ��� ���� ����
        index += 300;
        if (!dictMatExp.ContainsKey(index))
            dictMatExp.Add(index, 0);
        dictMatExp[index] += 1;
    }

    void SetDictSkillParams(Dictionary<string,string> dictTemp)
    {
        dictSelectedSkillParams = dictTemp;
    }
    void ShowSkillData()
    {
        currentLevel.text = "Lv. " + dictSelectedSkillParams[SkillID.LEVEL];
        nextLevel.text = "Lv. " + (float.Parse(dictSelectedSkillParams[SkillID.LEVEL]) + 1);
        skillImamge.sprite = GameManager.instance.LoadAndSetSprite
            (FolderPath.SPRITE_SKILL_ICON + dictSelectedSkillParams[SkillID.ICON_NAME]);
        skillName.text = dictSelectedSkillParams[SkillID.NAME];
        skillDescription.text = dictSelectedSkillParams[SkillID.DESCRIPT];
    }

    public void LevelUpSkill()
    {
        foreach(GameObject skills in GameManager.instance.objectFactory.AllSkill.listPool)
        {
            if(skills.GetComponent<Skill>().fId.ToString() == dictSelectedSkillParams[SkillID.ID])
            {
                var skillScript = skills.GetComponent<Skill>();
                if(skillScript.fSkillLevel < 10)
                {
                    skillScript.SkillActivationInit(ref skillPanelUi.curCharStat);
                    skillScript.SkillExpUp(SelectMaterialToExpUp());
                    ShowSkillData();
                    skillPanelUi.ShowSkill();
                    if(skillScript.fSkillLevel == 10)
                        nextLevel.text = "Max";
                }
                break;
            }
        }
    }
    float SelectMaterialToExpUp()
    {
        float fSumExp = 0;
        foreach (KeyValuePair<float, float> MatExpPair in dictMatExp)
        {
            fSumExp = MatExpPair.Key * MatExpPair.Value;
            // ��� ������ ��ųʸ� �ʱ�ȭ���ְ� itemcount ���ֱ� �����
            dictItemCount[MatExpPair.Key.ToString()]
                = (int.Parse(dictItemCount[MatExpPair.Key.ToString()]) - MatExpPair.Value).ToString();
        }
        return fSumExp;
    }
}
