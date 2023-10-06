using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSkill_03_Effect : SkillEffrct
{

    void Start()
    {
        myFactory(GameManager.instance.objectFactory.Common03EffectFactory);
    }

}
