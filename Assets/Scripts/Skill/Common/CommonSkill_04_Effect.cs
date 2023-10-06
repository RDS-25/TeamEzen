using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSkill_04_Effect : SkillEffrct
{
    CommonSkill_04 commonSkill_04;
    void Start()
    {
        commonSkill_04 = GameObject.FindObjectOfType<CommonSkill_04>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
