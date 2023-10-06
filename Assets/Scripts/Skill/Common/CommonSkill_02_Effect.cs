using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSkill_02_Effect : SkillEffrct
{
    CommonSkill_02 commonSkill_02;
    void Start()
    {
        commonSkill_02 = GameObject.FindObjectOfType<CommonSkill_02>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
