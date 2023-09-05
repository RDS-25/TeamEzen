using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Params
{
    public class StatParams :MonoBehaviour
    {
        //�ε���
        public float fId;
        //�������
        public string sImagepath;
        //�̸�
        public string strName;
        //����
        public float fLevel;
        //ü��
        public float fHealth;
        //���ݷ�
        public float fAtk;
        //����
        public float fDef;
        //ũ��Ƽ�� Ȯ��%
        public float fCriticalPer;
        //ũ��Ƽ�� ������ %
        public float fCriticalDmg;
        //ȸ��
        public float fMiss;
        //�̵��ӵ�
        public float fMoveSpeed;
        //���ݼӵ�
        public float fAtkSpeed;
        //��Ÿ�� ����
        public float fCoolDownReduction;
        //����ġ
        public float fExp;
        //�� ����
        public float fDefBreak;
        //ũ��Ƽ�� ����
        public float fCriticalResist;
        //������ ����%
        public float fDamageReduction;
        //ü�����
        public float fHealthSteel;
        //IncreasedBuffDuration,��ų ���� ���� �ð� ����
        public float fIBD;
        //HealthRecoveryRate,ü��ȸ�� �ӵ�
        public float fHRR;
        //ȸ����(ȸ���� �� �����϶� ȸ�� ��ġ�� ����)
        public float fRecoveryRate;
        //�þ� ��Ÿ�
        public float fSightRange;
        //�⺻ ��Ÿ�
        public float fDefaultRange;
        //�Ӽ�(��,�� ,����)
        public float fProperty;
        //����
        public string strDescription;
        //���� Ÿ�� (� ������ ĳ������) 
        public float fType;
        //�ñر� ������
        public float fUltimateGauge;
        //�����ϰ��ִ��� ������
        public bool bIsOwn;

        // ��ų ID
        //��ų 1 
        public float PassiveSkill;
        //��ų 2 
        public float BasicSkill;
        //��ų 3
        public float ActiveSkill;
        //��ų 4
        public float UltimateSkill;


        // �⺻ ���
        public float Equip;
        // ���� ���
        public float PersonalEquip;
        // ��ų ���� �� 
        public float Stone;


    }
}
