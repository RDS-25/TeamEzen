using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipData_", menuName = "Item / EquipData")]

public class EquipData : ScriptableObject
{
    [SerializeField]
    ItemParameter.ItemType itemType = ItemParameter.ItemType.EQUIPMENT;
    public float fId;
    public string strName;//장비 이름
    public string strDiscription;//장비 설명
    public string strImage;//아이템 이미지 주소
    public float fDropRate;
    public float fDamage;
    public float fDefense;
    public float fSpeed;
    public float fCrtical;
    public float fCriticalDamage;
    public float fCount;
}
