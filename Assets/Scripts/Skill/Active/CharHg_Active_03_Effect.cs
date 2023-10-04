using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharHg_Active_03_Effect : SkillEffrct
{
    CharHg_Active_03 charHg_Active_03;
    void Start()
    {
        charHg_Active_03 = GameObject.FindObjectOfType<CharHg_Active_03>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);
        fAttackCount = charHg_Active_03.fAttackCount;
        fSpeed = charHg_Active_03.fSpeed;
        fTargetCount = charHg_Active_03.fTargetCount;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance(Firepiont, charHg_Active_03.fRange);
    }
}
