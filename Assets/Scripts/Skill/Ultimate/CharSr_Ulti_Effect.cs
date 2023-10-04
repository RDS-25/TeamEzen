using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSr_Ulti_Effect : SkillEffrct
{
    CharSr_Ulti charSr_Ulti;
    void Start()
    {
        charSr_Ulti = GameObject.FindObjectOfType<CharSr_Ulti>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);
        fAttackCount = charSr_Ulti.fAttackCount;
        fSpeed = charSr_Ulti.fSpeed;
        fTargetCount = charSr_Ulti.fTargetCount;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance(Firepiont, charSr_Ulti.fRange);
    }
}
