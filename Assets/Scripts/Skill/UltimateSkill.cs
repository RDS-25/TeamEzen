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
    {//�ñر� ������ �� �������� ��밡��
        
    }
    public virtual void PlayAnimation()
    {

    }
    public virtual void PlaySound()
    {

    }
}
