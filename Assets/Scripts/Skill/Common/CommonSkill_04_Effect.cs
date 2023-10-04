using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSkill_04_Effect : SkillEffrct
{
    CommonSkill_04 commonSkill_04;
    void Start()
    {
        commonSkill_04 = GameObject.FindObjectOfType<CommonSkill_04>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);
        fAttackCount = commonSkill_04.fAttackCount;
        fSpeed = commonSkill_04.fSpeed;
        fTargetCount = commonSkill_04.fTargetCount;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance(Firepiont, commonSkill_04.fRange);
    }
}
