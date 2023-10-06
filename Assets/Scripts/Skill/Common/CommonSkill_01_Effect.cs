using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSkill_01_Effect : SkillEffrct
{
    CommonSkill_01 commonSkill_01;
    void Start()
    {
        commonSkill_01 = GameObject.FindObjectOfType<CommonSkill_01>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
