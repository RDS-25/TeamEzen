using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharHg_Ulti_Effect : SkillEffrct
{
    CharHg_Ulti charHg_Ulti;
    void Start()
    {
        charHg_Ulti = GameObject.FindObjectOfType<CharHg_Ulti>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);
        fAttackCount = charHg_Ulti.fAttackCount;
        fSpeed = charHg_Ulti.fSpeed;
        fTargetCount = charHg_Ulti.fTargetCount;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance(Firepiont, charHg_Ulti.fRange);
    }
}
