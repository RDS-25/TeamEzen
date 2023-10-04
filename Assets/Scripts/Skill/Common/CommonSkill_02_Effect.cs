using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSkill_02_Effect : SkillEffrct
{
    CommonSkill_02 commonSkill_02;
    void Start()
    {
        commonSkill_02 = GameObject.FindObjectOfType<CommonSkill_02>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);
        fAttackCount = commonSkill_02.fAttackCount;
        fSpeed = commonSkill_02.fSpeed;
        fTargetCount = commonSkill_02.fTargetCount;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance(Firepiont, commonSkill_02.fRange);
    }
}
