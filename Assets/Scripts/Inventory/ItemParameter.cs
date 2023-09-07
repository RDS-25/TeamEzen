using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ItemParameter
{//   - 식별자(ID),상승량(스킬 계수),장비들의 기본 수치(캐릭터 파라미터 상승)
    [Serializable]
    public enum ItemType { PROFESSIONAL,EQUIPMENT, GEMSTONE,MATERIAL}
   [Serializable]
    public class ProfessionalEquipParams
    {//전용 장비가 올려줄수 있는 캐릭터의 파라미터값
        public ItemType ItemType = ItemType.PROFESSIONAL;
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
    }
    [Serializable]
    public class EquipParams
    {
        public ItemType ItemType = ItemType.EQUIPMENT;
        public float fId = 1;
        public string strName;//장비 이름
        public string strDiscription;//장비 설명
        public string strImage;//아이템 이미지 주소
        public float fDropRate;
        public float fDamage;
        public float fDefense;
        public float fSpeed;
        public float fCrtical;
        public float fCriticalDamage;

    }
    [Serializable]
    public class GemstoneParams
    {//보석마다 해당 스킬의 배율 상승
        public ItemType ItemType = ItemType.GEMSTONE;
        public float fId;//보석 고유번호
        public string strName;//보석 이름
        public string strDiscription;//장비 설명
        public string strImage;//아이템 이미지 주소
        public float fDropRate;//보석 드랍율
        public float fUpDamage;//보석이 올려주는 스킬 대미지비율
        public float fNumber;//갯수
        
    }
    
    [Serializable]
    public class MaterialParams
    {
        public ItemType ItemType = ItemType.MATERIAL;
        public float fId;
        public string strName;
        public string strDiscription;
        public string strImage;//아이템 이미지 주소
        public float fDropRate;
        public float fExp;
        public float fNumber;//갯수
        
    }
}
