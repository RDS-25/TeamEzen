using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSkill_03_Effect : SkillEffrct
{
    CommonSkill_03 commonSkill_03;
    void Start()
    {
        commonSkill_03 = GameObject.FindObjectOfType<CommonSkill_03>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
