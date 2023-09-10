using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProfessionalData_", menuName = "Item / ProfessionalData")]
public class ProfessionalData : ScriptableObject
{
    [SerializeField]
    ItemParameter.ItemType ItemType = ItemParameter.ItemType.PROFESSIONAL;
    public float fId;//장비 고유번호
    public string strName;//장비 이름
    public string strDiscription;//장비 설명
    public string strImage;//아이템 이미지 주소
    public float fDropRate;//장비 드랍율
    public float fPassiveSkillValue;//장비가 올려주는 패시브 스킬값        
    public float fDamage;
    public float fDefense;
    public float fSpeed;
    public float fCrtical;
    public float fCriticalDamage;
    public float fCount;
}
