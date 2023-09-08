using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GemStoneData_", menuName = "Item / GemStoneData")]

public class GemStoneData : ScriptableObject
{
    [SerializeField]
    ItemParameter.ItemType itemType = ItemParameter.ItemType.GEMSTONE;
    public float fId;//���� ������ȣ
    public string strName;//���� �̸�
    public string strDiscription;//��� ����
    public string strImage;//������ �̹��� �ּ�
    public float fDropRate;//���� �����
    public float fUpDamage;//������ �÷��ִ� ��ų ���������
    public float fCount;//����
}
