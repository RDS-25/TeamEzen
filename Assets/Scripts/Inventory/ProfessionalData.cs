using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProfessionalData_", menuName = "Item / ProfessionalData")]
public class ProfessionalData : ScriptableObject
{
    [SerializeField]
    ItemParameter.ItemType ItemType = ItemParameter.ItemType.PROFESSIONAL;
    public float fId;//��� ������ȣ
    public string strName;//��� �̸�
    public string strDiscription;//��� ����
    public string strImage;//������ �̹��� �ּ�
    public float fDropRate;//��� �����
    public float fPassiveSkillValue;//��� �÷��ִ� �нú� ��ų��        
    public float fDamage;
    public float fDefense;
    public float fSpeed;
    public float fCrtical;
    public float fCriticalDamage;
    public float fCount;
}
