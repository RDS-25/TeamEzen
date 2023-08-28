using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ItemParameter
{//   - �ĺ���(ID),��·�(��ų ���),������ �⺻ ��ġ(ĳ���� �Ķ���� ���)
    [Serializable]
    public enum ItemType { EQUIPMENT,GEMSTONE,PROFESSIONAL,MATERIAL}
   [Serializable]
    public class ProfessionalEquipParams
    {//���� ��� �÷��ټ� �ִ� ĳ������ �Ķ���Ͱ�
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
    }
    [Serializable]
    public class GemstoneParams
    {//�������� �ش� ��ų�� ���� ���
        public float fId;//���� ������ȣ
        public string strName;//���� �̸�
        public string strDiscription;//��� ����
        public string strImage;//������ �̹��� �ּ�
        public float fDropRate;//���� �����
        public float fUpDamage;//������ �÷��ִ� ��ų ���������
        public float fNumber;//����
        
    }
    [Serializable]
    public class EquipParams
    {
        public float fId=1;
        public string strName;//��� �̸�
        public string strDiscription;//��� ����
        public string strImage;//������ �̹��� �ּ�
        public float fDropRate;
        public float fDamage;
        public float fDefense;
        public float fSpeed;
        public float fCrtical;
        public float fCriticalDamage;

    }
    [Serializable]
    public class MaterialParams
    {
        public float fId;
        public string strName;
        public string strDiscription;
        public string strImage;//������ �̹��� �ּ�
        public float fDropRate;
        public float fExp;
        public float fNumber;//����
        
    }
}
