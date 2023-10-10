using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Params;
public class BuffType : Skill
{
    float stat1;
    float stat2;
    public override void SetType()
    {
        skillDetail = "BUFF";//딕셔너리 저장용 변수
        enumSkillDetail = SkillDetailType.BUFF;
    }

    public override void SkillUnlock()
    {//버프 공통이면 여기서 따로면 더 내려가서 아니면 지우기
        base.SkillUnlock();
        //추가기능
    }
    public override void SkillHidenUnlock()
    {
        base.SkillHidenUnlock();
        //추가기능 구현

    }
    public override void SkillTriger(Vector3 playerposition)
    {
        base.SkillTriger(playerposition);
        CharaterStatUp();

    }
    public virtual void CharaterStatUp()//ref float stat1, ref float stat2)//ref는 주는 쪽에도 영향을 줌 변수의 얕은 복사
    {
        stat1= stat1 * fMagnification + fValue;

        
        if (bisUnlockHiden)
        {
            stat2 = stat2 * fHidenValue;
            
        }
    }
}
