using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
public class SkillPanelUi : MonoBehaviour
{
    public SelectCharactorUIManager charactorUIManager;
    public Stat curCharStat;
    public Image imageCharacter;

    public Image imagePassive;
    public Image imageBasic;
    public Image imageActive;
    public Image imageUltimate;

    float fPassiveSkillId;
    float fActiveSkillId;
    float fBasicSkillId;
    float fUltimateSkillId;

    public TMP_Text textPassiveLevel;
    public TMP_Text textBasicLevel;
    public TMP_Text textActiveLevel;
    public TMP_Text textUltimateLevel;

    public TMP_Text textPassiveName;
    public TMP_Text textBasicName;
    public TMP_Text textActiveName;
    public TMP_Text textUltimateName;

    public TMP_Text textPassiveDescript;
    public TMP_Text textBasicDescript;
    public TMP_Text textActiveDescript;
    public TMP_Text textUltimateDescript;

    List<Dictionary<string, string>> dictPassive = new();
    List<Dictionary<string, string>> dictActive = new();
    List<Dictionary<string, string>> dictBasic = new();
    List<Dictionary<string, string>> dictUlt = new();

    public Dictionary<string, string> dictCurPassive = new();
    public Dictionary<string, string> dictCurActive = new();
    public Dictionary<string, string> dictCurBasic = new();
    public Dictionary<string, string> dictCurUlt = new();

    void Start()
    {
        charactorUIManager = GameObject.Find("CharManager").GetComponent<SelectCharactorUIManager>();
        Init();
    }
    void Init()
    {

        dictPassive = GameManager.instance.DataReadAll(FolderPath.PARAMS_PASSIVE_SKILL);
        dictActive = GameManager.instance.DataReadAll(FolderPath.PARAMS_ACTIVE_SKILL);
        dictBasic = GameManager.instance.DataReadAll(FolderPath.PARAMS_ACTIVE_SKILL);
        dictUlt = GameManager.instance.DataReadAll(FolderPath.PARAMS_ULTIMATE_SKILL);
        ShowSkill();

    }
    public void ShowSkill()
    {
        curCharStat = GameManager.instance.objectFactory.ownCharFactory.listPool[charactorUIManager.curCharID].GetComponent<Stat>();


        fPassiveSkillId = curCharStat.fPassiveSkill;
        fActiveSkillId = curCharStat.fActiveSkill;
        fBasicSkillId = curCharStat.fBasicSkill;
        fUltimateSkillId = curCharStat.fUltimateSkill;
        dictPassive = GameManager.instance.DataReadAll(FolderPath.PARAMS_PASSIVE_SKILL);
        dictActive = GameManager.instance.DataReadAll(FolderPath.PARAMS_ACTIVE_SKILL);
        dictBasic = GameManager.instance.DataReadAll(FolderPath.PARAMS_BASIC_SKILL);
        dictUlt = GameManager.instance.DataReadAll(FolderPath.PARAMS_ULTIMATE_SKILL);

        ShowSkill(fPassiveSkillId, imagePassive, textPassiveLevel, textPassiveName, textPassiveDescript, dictPassive);
        ShowSkill(fActiveSkillId, imageActive, textActiveLevel, textActiveName, textActiveDescript, dictActive);
        ShowSkill(fBasicSkillId, imageBasic, textBasicLevel, textBasicName, textBasicDescript, dictBasic);
        ShowSkill(fUltimateSkillId, imageUltimate, textUltimateLevel, textUltimateName, textUltimateDescript, dictUlt);
    }
    void ShowSkill(float skillId, Image imageIcon, TMP_Text textLevel, TMP_Text textName,
        TMP_Text textDescription, List<Dictionary<string,string>> dictTemp)
    {
        foreach (Dictionary<string, string> mySkill in dictTemp)
        {
            if (mySkill[SkillID.ID] == skillId.ToString())
            {
                switch (mySkill[SkillID.TYPE])
                {
                    case "BASIC":
                        dictCurBasic = mySkill;
                        break;
                    case "PASSIVE":
                        dictCurPassive = mySkill;
                        break;
                    case "ACTIVE":
                        dictCurActive = mySkill;
                        break;
                    case "ULTIMATE":
                        dictCurUlt = mySkill;
                        break;
                }
                imageIcon.sprite = GameManager.instance.LoadAndSetSprite
                    (FolderPath.SPRITE_SKILL_ICON + mySkill[SkillID.ICON_NAME]);
                textLevel.text = "Lv. " + mySkill[SkillID.LEVEL];
                textName.text = mySkill[SkillID.NAME];
                textDescription.text = mySkill[SkillID.DESCRIPT];
                break;
            }
        }
    }
}
