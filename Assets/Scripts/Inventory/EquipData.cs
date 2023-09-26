using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipData_", menuName = "Item / EquipData")]

public class EquipData : ScriptableObject
{
    [SerializeField]
    ItemParameter.ItemType itemType = ItemParameter.ItemType.EQUIPMENT;
    public float fId;
    public string strName;//��� �̸�
    public string strDiscription;//��� ����
    public string strImage;//������ �̹��� �ּ�
    public float fDropRate;
    public float fDamage;
    public float fDefense;
    public float fSpeed;
    public float fCrtical;
    public float fCriticalDamage;
    public float fCount;
}
