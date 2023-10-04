using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAr_Active_03_Effect : SkillEffrct
{
    CharAr_Active_03 charAr_Active_03;
    void Start()
    {
        charAr_Active_03 = GameObject.FindObjectOfType<CharAr_Active_03>();
        myFactory(GameManager.instance.objectFactory.CharARActive03EffectFactory);
        fAttackCount = charAr_Active_03.fAttackCount;
        fSpeed = charAr_Active_03.fSpeed;
        fTargetCount = charAr_Active_03.fTargetCount;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance(Firepiont, charAr_Active_03.fRange);
    }
}
