using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SkillParameter 
{//�ĺ���, ��ų�̸�, �⺻��ġ, ��Ÿ��, ���ӽð�, ����, ��Ÿ�� ������, ���� ���ӽð�, ����
 //Ÿ�ټ�, ����Ƚ��


  
    //[Serializable]
    public class SkilParams : MonoBehaviour
    {
        [Serializable]
        public enum SkillType { PASSIVE, ACTIVE, ULTIMATE }

        public SkillType skillType;
        public float fId;//�ĺ���
        public string strName;//�̸�        
        public float fSkillLevel = 1f;//��ų����
        public string strDiscription;//��ų ����
        public string strFilepath;//��ų������ ���
        public float fSkillRequireExp;//��ų ������ �ʿ����ġ
        public float fSkillExp;//��ų����ġ
        public float fUnlockLevel;//��ų�ر� �ʿ�ĳ���ͷ���
        public float fUnlockHidenLevel;//��ų �߰�Ư������ ����
        public float fTimer;//��ųŸ�̸�
        public float fCoolTime;//��ų ��Ÿ��
        public float fDuration;//��ų ���ӽð�        
        public float fSkillCoolReduce;//��ų ��Ÿ�Ӱ���
        public float fBuffDuration;//������ų ���ӽð�
        public float fRange;//��ų����        
        public float fValue;//��ų �⺻������
        public float fHidenValue;//�رݵ� ��ųȿ�� ����
        public float fMagnification;//��ų����
        public float fTargetCount;//��ų Ÿ�ټ�
        public float fAttackCount;//��ųŸ��Ƚ��        
        public float fBulletCount;//�߻�ü ����
        public bool bisUnlockSkill = false;//��ų �ر�
        public bool bisCanUse = false;//��ų�� ��밡������
        public bool bisActtivate = false;//��ų �ߵ�����
        public bool bisUnlockHiden = false;//��ų �߰���� �ر�
        public float plusval = 10f;
        public float pulsmag = 10f;
        public float plusattackcount = 0;
        public float plustargetcount = 0;

        public float checkLevel;
    }
    

}
