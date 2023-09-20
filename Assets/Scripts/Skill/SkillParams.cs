using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Params 
{//식별자, 스킬이름, 기본수치, 쿨타임, 지속시간, 배율, 쿨타임 감소율, 버프 지속시간, 범위
 //타겟수, 공격횟수


  
    //[Serializable]
    public class SkillParams : MonoBehaviour
    {
        public GameObject gMySkillGameObject;

        [Serializable]
        public enum SkillType { BASIC, PASSIVE, ACTIVE, ULTIMATE }
        public enum SkillDetailType { ATTACK, HEAL, BUFF}

        public SkillType enumSkillType;
        public SkillDetailType enumSkillDetail;
        public string skillType;//저장용
        public string skillDetail;//저장용 

        public float fCharToUse;
        public float fId;//식별자
        public string strName;//이름        
        public float fSkillLevel = 1f;//스킬레벨
        public string strDiscription;//스킬 설명
        public string strIconName;//스킬아이콘 경로
        public string strSkillFolderPath;//폴더경로
        public string strSkillParamsName;//파일경로
        public string strEffectPath;//이펙트경로
        public string strEffectName;//이펙트 이름                                    
        public float fSkillRequireExp;//스킬 레벨업 필요경험치
        public float fSkillExp;//스킬경험치
        public float fUnlockLevel;//스킬해금 필요캐릭터레벨
        public float fUnlockHidenLevel;//스킬 추가특성해제 스킬레벨
        public float fTimer;//스킬타이머
        public float fCoolTime;//스킬 쿨타임
        public float fDuration;//스킬 지속시간        
        public float fSkillCoolReduce;//스킬 쿨타임감소
        public float fBuffDuration;//버프스킬 지속시간
        public float fRange;//스킬사거리
        public float fMaxRange;//스킬범위                       
        public float fValue;//스킬 기본데미지
        public float fHidenValue;//해금된 스킬효과 배율
        public float fMagnification;//스킬배율
        public float fTargetCount;//스킬 타겟수
        public float fAttackCount;//스킬타격횟수        
        public float fBulletCount;//발사체 갯수
        public bool bisUnlockSkill = false;//스킬 해금
        public bool bisCanUse = false;//스킬이 사용가능한지
        public bool bisActtivate = false;//스킬 발동여부
        public bool bisUnlockHiden = false;//스킬 추가기능 해금
        public float plusval = 10f;//레벨업시 증가밸류
        public float pulsmag = 10f;//레벨업시 증가배율
        public float plusattackcount = 0;//레벨업시 증가공격횟수
        public float plustargetcount = 0;//레벨업시 증가타겟수

        public float checkLevel;
    }
    

}
