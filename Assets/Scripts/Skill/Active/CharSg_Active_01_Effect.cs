using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSg_Active_01_Effect : SkillEffrct
{
    CharSg_Active_01 charSg_Active_01;
    void Start()
    {
        charSg_Active_01 = GameObject.FindObjectOfType<CharSg_Active_01>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);
        fAttackCount = charSg_Active_01.fAttackCount;
        fSpeed = charSg_Active_01.fSpeed;
        fTargetCount = charSg_Active_01.fTargetCount;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance(Firepiont, charSg_Active_01.fRange);
    }
}
