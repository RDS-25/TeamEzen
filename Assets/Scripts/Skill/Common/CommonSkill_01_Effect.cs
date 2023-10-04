using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSkill_01_Effect : SkillEffrct
{
    CommonSkill_01 commonSkill_01;
    void Start()
    {
        commonSkill_01 = GameObject.FindObjectOfType<CommonSkill_01>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);
        fAttackCount = commonSkill_01.fAttackCount;
        fSpeed = commonSkill_01.fSpeed;
        fTargetCount = commonSkill_01.fTargetCount;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance(Firepiont, commonSkill_01.fRange);
    }
}
