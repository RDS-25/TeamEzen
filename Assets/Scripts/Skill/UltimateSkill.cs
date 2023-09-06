using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateSkill : Skill
{
    public override void SetType()
    {
        skillType = SkillType.ULTIMATE;
    }
    public override void SkillTriger()
    {//궁극기 게이지 다 차있을시 사용가능
        
    }
    public virtual void PlayAnimation()
    {

    }
    public virtual void PlaySound()
    {

    }
}
