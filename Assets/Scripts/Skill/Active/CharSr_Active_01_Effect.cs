using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSr_Active_01_Effect : SkillEffrct
{
    CharSr_Active_01 charSr_Active_01;
    void Start()
    {
        charSr_Active_01 = GameObject.FindObjectOfType<CharSr_Active_01>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);
        fAttackCount = charSr_Active_01.fAttackCount;
        fSpeed = charSr_Active_01.fSpeed;
        fTargetCount = charSr_Active_01.fTargetCount;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance(Firepiont, charSr_Active_01.fRange);
    }
}
