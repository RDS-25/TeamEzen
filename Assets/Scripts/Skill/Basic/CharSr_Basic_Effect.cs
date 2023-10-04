using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSr_Basic_Effect : SkillEffrct
{
    CharSr_Basic charSr_Basic;
    void Start()
    {
        charSr_Basic = GameObject.FindObjectOfType<CharSr_Basic>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);
        fAttackCount = charSr_Basic.fAttackCount;
        fSpeed = charSr_Basic.fSpeed;
        fTargetCount = charSr_Basic.fTargetCount;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance(Firepiont, charSr_Basic.fRange);
    }
}
