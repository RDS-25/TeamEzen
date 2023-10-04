using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSg_Ulti_Effect : SkillEffrct
{
    CharSg_Ulti charSg_Ulti;
    void Start()
    {
        charSg_Ulti = GameObject.FindObjectOfType<CharSg_Ulti>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);
        fAttackCount = charSg_Ulti.fAttackCount;
        fSpeed = charSg_Ulti.fSpeed;
        fTargetCount = charSg_Ulti.fTargetCount;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance(Firepiont, charSg_Ulti.fRange);
    }
}
