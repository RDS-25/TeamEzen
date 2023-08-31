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
        //�̹��� �ִ� �Լ�
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
    }
    /*Sprite SetImage(string imagePath)
    {
        string path = Path.Combine(imagePath);
        return;
    }*/
}
