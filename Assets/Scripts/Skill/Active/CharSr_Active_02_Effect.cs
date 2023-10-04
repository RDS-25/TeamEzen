using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSr_Active_02_Effect : SkillEffrct
{
    CharSr_Active_02 charSr_Active_02;
    void Start()
    {
        charSr_Active_02 = GameObject.FindObjectOfType<CharSr_Active_02>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);
        fAttackCount = charSr_Active_02.fAttackCount;
        fSpeed = charSr_Active_02.fSpeed;
        fTargetCount = charSr_Active_02.fTargetCount;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance(Firepiont, charSr_Active_02.fRange);
    }
}
