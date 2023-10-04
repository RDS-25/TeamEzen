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
    // Start is called before the first frame update
    private void OnEnable()
    {
        dictItemCount = GameManager.instance.DataRead(FolderPath.PARAMS_ITEM_COUNT + FileName.STR_JSON_INVEN_SAVE);

        for (int i = 0; i < listMatButtons.Count; i++)
        {
            if (!dictMatExp.ContainsKey(i + 300))
                dictMatExp.Add(i + 300, 0);
            listMatButtons[i].transform.GetChild(1).GetComponent<TMP_Text>().text
                = dictMatExp[i + 300] + "/" + dictItemCount[(i + 300).ToString()];
        }
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
            if(uiCellView.ID == fNum + 300)
            {
                listMatButtons[fNum].GetComponent<Image>().sprite
                    = GameManager.instance.LoadAndSetSprite
                    (FolderPath.SPRITE_ITEM_ICON + uiCellView.IMAGE_PATH);
            }
        }
    }
    void Update()
    {
        // dictMatExp 여기에 들어있는 id 값을 가진 머테리얼 표시해주기
    }

    void OnClickMatExpButton(int index)
    {
        // 선택한 재료 딕셔너리에 개수 저장
        index += 300;
        if(dictItemCount[index.ToString()] == "0")
        {
            return;
        }
        listMatButtons[index].transform.GetChild(1).GetComponent<TMP_Text>().text
                = dictMatExp[index] + "/" + dictItemCount[index.ToString()];
        dictMatExp[index] += 1;
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
            // 재료 선택한 딕셔너리 초기화해주고 itemcount 빼주기 만들기
            dictItemCount[MatExpPair.Key.ToString()]
                = (int.Parse(dictItemCount[MatExpPair.Key.ToString()]) - MatExpPair.Value).ToString();
        }
        return fSumExp;
    }
}
