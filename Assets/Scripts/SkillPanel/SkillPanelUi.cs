using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
public class SkillPanelUi : MonoBehaviour
{
    public SelectCharactorUIManager charactorUIManager;
    Stat curCharStat;
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

    private const string _STR_ID = "fId";
    private const string _STR_IMAGE_URL = "strFilepath";
    private const string _STR_LEVEL = "fSkillLevel";
    private const string _STR_NAME = "strName";
    private const string _STR_DESCRIPT = "strDiscription";
    void Start()
    {
        charactorUIManager = GameObject.Find("CharManager").GetComponent<SelectCharactorUIManager>();
        curCharStat = charactorUIManager.OwnChar[charactorUIManager.curCharID].GetComponent<Stat>();

        fPassiveSkillId = curCharStat.PassiveSkill;
        fActiveSkillId = curCharStat.ActiveSkill;
        fBasicSkillId = curCharStat.BasicSkill;
        fUltimateSkillId = curCharStat.UltimateSkill;
        dictPassive = GameManager.instance.DataReadAll(FolderPath.PARAMS_PASSIVE_SKILL);
        dictActive = GameManager.instance.DataReadAll(FolderPath.PARAMS_ACTIVE_SKILL);
        dictBasic = GameManager.instance.DataReadAll(FolderPath.PARAMS_ACTIVE_SKILL);
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
            if (mySkill[_STR_ID] == skillId.ToString())
            {
                imageIcon.sprite = LoadAndSetSprite(mySkill[_STR_IMAGE_URL]);
                textLevel.text = mySkill[_STR_LEVEL];
                textName.text = "Lv. " + mySkill[_STR_NAME];
                textDescription.text = mySkill[_STR_DESCRIPT];
                break;
            }
        }
    }


    private Sprite LoadAndSetSprite(string imagePath)
    {
        string path = Path.Combine(imagePath);

        Debug.Log("°æ·Î´Â" + path);
        if (File.Exists(path))
        {
            byte[] imageBytes = File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(2, 2);
            if (texture.LoadImage(imageBytes))
            {
                return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            }
            else
            {
                Debug.LogError("Failed to load image: " + imagePath);
                return null;
            }
        }
        else
        {
            Debug.LogError("Image file not found: " + path);
            return null;
        }
    }
}
