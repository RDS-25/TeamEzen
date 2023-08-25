using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "character", menuName = "Scriptable Object/character", order = int.MaxValue)]
public class CharacterData : ScriptableObject
{
    //�ε���
    public float fId;
    //ĳ���� ����
    public string sImage;
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
    //Ÿ�� (� ������ ĳ������)
    public float fType;
    //�ñر� ������
    public float fUltimateGauge;
    //�����ϰ��ִ��� ������
    public bool bIsOwn;
 
}
