using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using ItemParameter;

public class UiCellView : MonoBehaviour
{
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
    void Start()
    {
        
    }
    public void SetUp(ProfessionalData professionalData)
    {
        
        professionalParams.fId                  = professionalData.fId;
        professionalParams.strName              = professionalData.strName;
        professionalParams.strDiscription       = professionalData.strDiscription;
        professionalParams.strImage             = professionalData.strImage;
        professionalParams.fDropRate            = professionalData.fDropRate;
        professionalParams.fPassiveSkillValue   = professionalData.fPassiveSkillValue;
        professionalParams.fDamage              = professionalData.fDamage;
        professionalParams.fDefense             = professionalData.fDefense;
        professionalParams.fSpeed               = professionalData.fSpeed;
        professionalParams.fCrtical             = professionalData.fCrtical;
        professionalParams.fCriticalDamage      = professionalData.fCriticalDamage;
        //이미지 넣는 함수
        SetImage(professionalData.strImage);
        Debug.Log("프로");
        
    }
    public void SetUp(EquipData equipData)
    {
        
        equipParams.fId             = equipData.fId;
        equipParams.strName         = equipData.strName;
        equipParams.strDiscription  = equipData.strDiscription;
        equipParams.strImage        = equipData.strImage;
        equipParams.fDropRate       = equipData.fDropRate;
        equipParams.fDamage         = equipData.fDamage;
        equipParams.fDefense        = equipData.fDefense;
        equipParams.fSpeed          = equipData.fSpeed;
        equipParams.fCrtical        = equipData.fCrtical;
        equipParams.fCriticalDamage = equipData.fCriticalDamage;
        SetImage(equipData.strImage);
        Debug.Log(equipData.strImage);

    }
    public void SetUp(GemStoneData gemStoneData)
    {
        
        gemstoneParams.fId            = gemStoneData.fId;
        gemstoneParams.strName        = gemStoneData.strName;
        gemstoneParams.strDiscription = gemStoneData.strDiscription;
        gemstoneParams.strImage       = gemStoneData.strImage;
        gemstoneParams.fDropRate      = gemStoneData.fDropRate;
        gemstoneParams.fUpDamage      = gemStoneData.fUpDamage;
        gemstoneParams.fNumber        = gemStoneData.fNumber;
        SetImage(gemStoneData.strImage);
        Debug.Log("돌");
    }
    public void SetUp(MaterialData materialData)
    {
        
        materialParams.fId              = materialData.fId;
        materialParams.strName          = materialData.strName;
        materialParams.strDiscription   = materialData.strDiscription;
        materialParams.strImage         = materialData.strImage;
        materialParams.fDropRate        = materialData.fDropRate;
        materialParams.fExp             = materialData.fExp;
        materialParams.fNumber          = materialData.fNumber;
        SetImage(materialData.strImage);
        Debug.Log("마테");
    }
    Sprite SetImage(string imagePath)//보고 따라함
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