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
    void Start()
    {
        
    }
    public void SetUp(ProfessionalData professionalData)
    {
        ItemParameter.ProfessionalEquipParams professionalParams = new ProfessionalEquipParams();        
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
        Debug.Log(professionalData.strImage);
    }
    public void SetUp(EquipData equipData)
    {
        ItemParameter.EquipParams equipParams = new EquipParams();
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
    }
    public void SetUp(GemStoneData gemStoneData)
    {
        ItemParameter.GemstoneParams gemstoneParams = new GemstoneParams();
        gemstoneParams.fId            = gemStoneData.fId;
        gemstoneParams.strName        = gemStoneData.strName;
        gemstoneParams.strDiscription = gemStoneData.strDiscription;
        gemstoneParams.strImage       = gemStoneData.strImage;
        gemstoneParams.fDropRate      = gemStoneData.fDropRate;
        gemstoneParams.fUpDamage      = gemStoneData.fUpDamage;
        gemstoneParams.fNumber        = gemStoneData.fNumber;
        SetImage(gemStoneData.strImage);
    }
    public void SetUp(MaterialData materialData)
    {
        ItemParameter.MaterialParams materialParams = new MaterialParams();
        materialParams.fId              = materialData.fId;
        materialParams.strName          = materialData.strName;
        materialParams.strDiscription   = materialData.strDiscription;
        materialParams.strImage         = materialData.strImage;
        materialParams.fDropRate        = materialData.fDropRate;
        materialParams.fExp             = materialData.fExp;
        materialParams.fNumber          = materialData.fNumber;
        SetImage(materialData.strImage);
    }
    Sprite SetImage(string imagePath)//보고 따라함
    {

        string path = Path.Combine(imagePath);
        if (File.Exists(path))
        {
            byte[] imageByte = File.ReadAllBytes(path);
            Texture2D Image = new Texture2D(20, 20);
            return Sprite.Create(Image, new Rect(0, 0, Image.width, Image.height), new Vector2(0.5f, 0.5f));
            //if (texture.LoadImage(imageByte))
            //{
            //    return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            //}
            //else
            //{
            //    Debug.LogError("파일 불러오기실패");
            //    return null;
            //}
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