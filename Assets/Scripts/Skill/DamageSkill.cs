using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageSkill : ActiveSkill
{
    protected float plusval=10f;
    protected float pulsmag = 10f;
    protected float plusattackcount = 0;
    protected float plustargetcount = 0;
     
    float a;
    public override void SetParams()
    {
        base.SetParams();
    }
    public void SkillDamage()
    {//스킬로 데미지를 줘야하는 순간 동작
     //사용해야할 캐릭터 스텟 받아오기

    }


}
