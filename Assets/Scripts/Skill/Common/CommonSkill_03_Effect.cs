using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSkill_03_Effect : SkillEffrct
{
    CommonSkill_03 commonSkill_03;
    void Start()
    {
        commonSkill_03 = GameObject.FindObjectOfType<CommonSkill_03>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);
        fAttackCount = commonSkill_03.fAttackCount;
        fSpeed = commonSkill_03.fSpeed;
        fTargetCount = commonSkill_03.fTargetCount;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance(Firepiont, commonSkill_03.fRange);
    }
}
