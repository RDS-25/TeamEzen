using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSkill_04_Effect : SkillEffrct
{
    CommonSkill_04 commonSkill_04;
    void Start()
    {
        myFactory(GameManager.instance.objectFactory.Common04EffectFactory);
    }

}
