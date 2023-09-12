using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using ItemParameter;

public class UiCellView : MonoBehaviour
{
    //public ItemDatamanager itemDatamanager;
    public Image imgIcon;
    public TMP_Text textCount;
    [SerializeField]
    ProfessionalEquipParams professionalParams = new ProfessionalEquipParams();
    [SerializeField]
    EquipParams equipParams = new EquipParams();
    [SerializeField]
    GemstoneParams gemstoneParams = new GemstoneParams();
    [SerializeField]
    MaterialParams materialParams = new MaterialParams();
    private ItemType itemType = ItemType.EQUIPMENT;
    string _strInvenItemPath = FolderPath.PARAMS_ITEM_COUNT;
    string SaveItemPath = FileName.STR_JSON_INVEN_SAVE;

    public ItemType TYPE
    {
        get
        {
            if (itemType == ItemType.EQUIPMENT)
                return ItemType.EQUIPMENT;
            else if (itemType == ItemType.GEMSTONE)
                return ItemType.GEMSTONE;
            else if (itemType == ItemType.MATERIAL)
                return ItemType.MATERIAL;

            return ItemType.PROFESSIONAL;
        }
    }
    public float ID
    {
        get
        {
            if (itemType == ItemType.EQUIPMENT)
                return equipParams.fId;
            else if (itemType == ItemType.GEMSTONE)
                return gemstoneParams.fId;
            else if (itemType == ItemType.MATERIAL)
                return materialParams.fId;

            return professionalParams.fId;
        }
    }
    public string NAME
    {
        get
        {
            if (itemType == ItemType.EQUIPMENT)
                return equipParams.strName;
            else if (itemType == ItemType.GEMSTONE)
                return gemstoneParams.strName;
            else if (itemType == ItemType.MATERIAL)
                return materialParams.strName;

            return professionalParams.strName;

        }
    }
    public string DISCRIPTION
    {
        get
        {
            if (itemType == ItemType.EQUIPMENT)
                return equipParams.strDiscription;
            else if (itemType == ItemType.GEMSTONE)
                return gemstoneParams.strDiscription;
            else if (itemType == ItemType.MATERIAL)
                return materialParams.strDiscription;

            return professionalParams.strDiscription;

        }
    }
    public string IMAGE_PATH
    {
        get
        {
            if (itemType == ItemType.EQUIPMENT)
                return equipParams.strImage;
            else if (itemType == ItemType.GEMSTONE)
                return gemstoneParams.strImage;
            else if (itemType == ItemType.MATERIAL)
                return materialParams.strImage;

            return professionalParams.strImage;
        }
    }
    public float DROP_RATE
    {
        get
        {
            if (itemType == ItemType.EQUIPMENT)
                return equipParams.fDropRate;
            else if (itemType == ItemType.GEMSTONE)
                return gemstoneParams.fDropRate;
            else if (itemType == ItemType.MATERIAL)
                return materialParams.fDropRate;

            return professionalParams.fDropRate;
        }

    }
    public float DAMAGE
    {
        get
        {
            if (itemType == ItemType.EQUIPMENT)
                return equipParams.fDamage;
            else
                return professionalParams.fDamage;
        }

    }
    public float DEFENSE
    {
        get
        {
            if (itemType == ItemType.EQUIPMENT)
                return equipParams.fDefense;
            else
                return professionalParams.fDefense;
        }
    }
    public float SPEED
    {
        get
        {
            if (itemType == ItemType.EQUIPMENT)
                return equipParams.fSpeed;
            else
                return professionalParams.fSpeed;
        }
    }
    public float CRITICALPER
    {
        get
        {
            {
                if (itemType == ItemType.EQUIPMENT)
                    return equipParams.fCrticalper;
                else
                    return professionalParams.fCrticalper;
            }
        }
    }
    public float CRITICALDAMAGE
    {
        get
        {
            {
                if (itemType == ItemType.EQUIPMENT)
                    return equipParams.fCriticalDamage;
                else
                    return professionalParams.fCriticalDamage;
            }
        }
    }
    public float COUNT
    {
        get
        {

            if (itemType == ItemType.PROFESSIONAL)
                return professionalParams.fCount;
            else if (itemType == ItemType.EQUIPMENT)
                return equipParams.fCount;
            else if(itemType == ItemType.GEMSTONE)
                return gemstoneParams.fCount;
            else
                return materialParams.fCount;
        }
    }
    public float PASSIVEVALUE
    {
        get
        {
            return professionalParams.fPassiveSkillValue;
        }
    }
    public float UPDAMAGE
    {
        get
        {
           return gemstoneParams.fUpDamage;
        }
    }
    public float EXP
    {
        get
        {
            return materialParams.fExp;
        }
    }
  
   
    public void SetUp(ProfessionalData professionalData)
    {
        itemType = ItemType.PROFESSIONAL;
        professionalParams.fId = professionalData.fId;
        professionalParams.strName = professionalData.strName;
        professionalParams.strDiscription = professionalData.strDiscription;
        professionalParams.strImage = professionalData.strImage;
        professionalParams.fDropRate = professionalData.fDropRate;
        professionalParams.fPassiveSkillValue = professionalData.fPassiveSkillValue;
        professionalParams.fDamage = professionalData.fDamage;
        professionalParams.fDefense = professionalData.fDefense;
        professionalParams.fSpeed = professionalData.fSpeed;
        professionalParams.fCrticalper = professionalData.fCrtical;
        professionalParams.fCriticalDamage = professionalData.fCriticalDamage;
        professionalParams.fCount =float.Parse(GameManager.instance.DataRead(_strInvenItemPath + SaveItemPath)[professionalParams.fId.ToString()]);
    }
    public void SetUp(EquipData equipData, Dictionary<string, string> dictItemCount)
    {
        itemType = ItemType.EQUIPMENT;
        equipParams.fId = equipData.fId;
        equipParams.strName = equipData.strName;
        equipParams.strDiscription = equipData.strDiscription;
        equipParams.strImage = equipData.strImage;
        equipParams.fDropRate = equipData.fDropRate;
        equipParams.fDamage = equipData.fDamage;
        equipParams.fDefense = equipData.fDefense;
        equipParams.fSpeed = equipData.fSpeed;
        equipParams.fCrticalper = equipData.fCrtical;
        equipParams.fCriticalDamage = equipData.fCriticalDamage;
        equipParams.fCount = float.Parse(GameManager.instance.DataRead(_strInvenItemPath + SaveItemPath)[equipParams.fId.ToString()]);

    }
    public void SetUp(GemStoneData gemStoneData, Dictionary<string,string> dictItemCount)
    {
        itemType = ItemType.GEMSTONE;
        gemstoneParams.fId = gemStoneData.fId;
        gemstoneParams.strName = gemStoneData.strName;
        gemstoneParams.strDiscription = gemStoneData.strDiscription;
        gemstoneParams.strImage = gemStoneData.strImage;
        gemstoneParams.fDropRate = gemStoneData.fDropRate;
        gemstoneParams.fUpDamage = gemStoneData.fUpDamage;
        gemstoneParams.fCount = float.Parse(GameManager.instance.DataRead(_strInvenItemPath + SaveItemPath)[gemstoneParams.fId.ToString()]);

    }
    public void SetUp(MaterialData materialData, Dictionary<string, string> dictItemCount)
    {
        itemType = ItemType.MATERIAL;
        materialParams.fId = materialData.fId;
        materialParams.strName = materialData.strName;
        materialParams.strDiscription = materialData.strDiscription;
        materialParams.strImage = materialData.strImage;
        materialParams.fDropRate = materialData.fDropRate;
        materialParams.fExp = materialData.fExp;
        materialParams.fCount = float.Parse(GameManager.instance.DataRead(_strInvenItemPath + SaveItemPath)[materialParams.fId.ToString()]);
    }
    Sprite SetImage(string imagePath)//보고 따라함 안씀
    {
        //https://202psj.tistory.com/1296
        string path = Path.Combine(imagePath);
        if (File.Exists(path))
        {
            byte[] imageByte = File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(20, 20);
            if (texture.LoadImage(imageByte))
            {
                return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            }
            else
            {
                Debug.LogError("파일 불러오기실패");
                return null;
            }
        }
        else
        {
            Debug.LogError("이미지파일 없음");
            return null;
        }

    } 
}
//string path = Path.Combine(imagePath);

//if (File.Exists(path))
//{
//    byte[] imageByte = File.ReadAllBytes(path);
//    Texture2D texture = new Texture2D(100, 100);
//    if (texture.LoadImage(imageByte))
//    {
//        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
//    }
//    else
//    {
//        Debug.LogError("파일 불러오기실패");
//        return null;
//    }
//}
//else
//{
//    Debug.LogError("이미지파일 없음");
//    return null;
//}