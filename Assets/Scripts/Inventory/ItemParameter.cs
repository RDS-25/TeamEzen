using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ItemParameter
{//   - 식별자(ID),상승량(스킬 계수),장비들의 기본 수치(캐릭터 파라미터 상승)
    public enum ItemType { EQUIPMENT,GEMSTONE}
   [Serializable]
    public class OnlyCharaterEquipParams
    {//전용 장비가 올려줄수 있는 캐릭터의 파라미터값
        public float fId;//장비 고유번호
        public float fSkillValue;//장비가 올려주는 패시브 스킬값
        public float fDropRate;//장비 드랍율
        //상승시켜줄 캐릭터 스텟들
    }
    [Serializable]
    public class GemstoneParams
    {//보석마다 해당 스킬의 배율 상승
        public float fId;//보석 고유번호
        public float fUpMagnification;//보석이 올려주는 스킬 대미지비율
        public float fDropRate;//보석 드랍율
    }

}
