using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAr_Active_01_Effect : SkillEffrct
{
    CharAr_Active_01 charAr_Active_01;
    void Start()
    {
        charAr_Active_01 = GameObject.FindObjectOfType<CharAr_Active_01>();
        myFactory(GameManager.instance.objectFactory.CharARActive01EffectFactory);
        fAttackCount = charAr_Active_01.fAttackCount;
        fSpeed = charAr_Active_01.fSpeed;
        fTargetCount = charAr_Active_01.fTargetCount;
    }
    
    // Update is called once per frame
    void Update()
    {
        CheckDistance(Firepiont, charAr_Active_01.fRange);   
    }
    
}
