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

    public List<Button> listMatButtons = new();
    public SkillPanelUi skillPanelUi;
    Dictionary<string, string> dictSelectedSkillParams = new();

    private const int MAT_INDEX = 300;
    private void OnEnable()
    {
        ShowMatData();
    }
    private void OnDisable()
    {
        dictMatExp.Clear();
    }
    void Start()
    {
        for (int i = 0; i < listMatButtons.Count; i++)
        {
            int buttonIndex = i;
            listMatButtons[i].onClick.AddListener(() => OnClickMatExpButton(buttonIndex));
        }
        int fNum = 0;
        foreach(GameObject items in GameManager.instance.objectFactory.ItemObjectFactory.listPool)
        {
            UiCellView uiCellView = items.GetComponent<UiCellView>();
            if(uiCellView.ID == fNum + MAT_INDEX)
            {
                listMatButtons[fNum].GetComponent<Image>().sprite
                    = GameManager.instance.LoadAndSetSprite
                    (FolderPath.SPRITE_ITEM_ICON + uiCellView.IMAGE_PATH);
                fNum++;
            }
        }
    }
    void Update()
    {
        // dictMatExp 여기에 들어있는 id 값을 가진 머테리얼 표시해주기
    }
    void ShowMatData()
    {
        dictItemCount = GameManager.instance.DataRead(FolderPath.PARAMS_ITEM_COUNT + FileName.STR_JSON_INVEN_SAVE);

        for (int i = 0; i < listMatButtons.Count; i++)
        {
            if (!dictMatExp.ContainsKey(i + MAT_INDEX))
                dictMatExp.Add(i + MAT_INDEX, 0);
            listMatButtons[i].transform.GetChild(1).GetComponent<TMP_Text>().text
                = dictMatExp[i + MAT_INDEX] + "/" + dictItemCount[(i + MAT_INDEX).ToString()];
        }
    }
    void OnClickMatExpButton(int index)
    {
        // 선택한 재료 딕셔너리에 개수 저장
        if(dictItemCount[(index + MAT_INDEX).ToString()] == "0")
        {
            return;
        }
        dictMatExp[index + MAT_INDEX] += 1;
        listMatButtons[index].transform.GetChild(1).GetComponent<TMP_Text>().text
                = dictMatExp[index + MAT_INDEX] + "/" + dictItemCount[(index + MAT_INDEX).ToString()];
    }

    public void SetDictSkillParams(Dictionary<string,string> dictTemp)
    {
        dictSelectedSkillParams = dictTemp;
    }
    public void ShowSkillData()
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
                ShowMatData();
                break;
            }
        }
    }
    float SelectMaterialToExpUp()
    {
        float fSumExp = 0;
        List<GameObject> MatItem = new();
        foreach(GameObject item in GameManager.instance.objectFactory.ItemObjectFactory.listPool)
        {
            if(Mathf.FloorToInt(item.GetComponent<UiCellView>().ID / 100) == 3)
            {
                MatItem.Add(item);
            }
        }
        //foreach (KeyValuePair<float, float> MatExpPair in dictMatExp)
        for(int i = 0; i < dictMatExp.Count; i++)
        {
            fSumExp += MatItem[i].GetComponent<UiCellView>().EXP * dictMatExp[i + MAT_INDEX];
            // 재료 선택한 딕셔너리 초기화해주고 itemcount 빼주기 만들기
            dictItemCount[(i + MAT_INDEX).ToString()]
                = (int.Parse(dictItemCount[(i + MAT_INDEX).ToString()]) - dictMatExp[i + MAT_INDEX]).ToString();
            dictMatExp[i + MAT_INDEX] = 0;
        }
        //foreach (float key in dictMatExp.Keys)
        //{
        //    fSumExp += MatItem[index].GetComponent<UiCellView>().EXP * dictMatExp[key];
        //    // 재료 선택한 딕셔너리 초기화해주고 itemcount 빼주기 만들기
        //    dictItemCount[key.ToString()]
        //        = (int.Parse(dictItemCount[key.ToString()]) - dictMatExp[key]).ToString();
        //    index++;
        //}

        GameManager.instance.DataWrite(FolderPath.PARAMS_ITEM_COUNT + FileName.STR_JSON_INVEN_SAVE, dictItemCount);
        ShowMatData();
        return fSumExp;
    }
}
