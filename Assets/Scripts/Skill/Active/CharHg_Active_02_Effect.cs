using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharHg_Active_02_Effect : SkillEffrct
{
    CharHg_Active_02 charHg_Active_02;
    void Start()
    {
        charHg_Active_02 = GameObject.FindObjectOfType<CharHg_Active_02>();
        myFactory(GameManager.instance.objectFactory.CharHGActive02EffectFactory);
        fAttackCount = charHg_Active_02.fAttackCount;
        fSpeed = charHg_Active_02.fSpeed;
        fTargetCount = charHg_Active_02.fTargetCount;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance(Firepiont, charHg_Active_02.fRange);
    }
}
