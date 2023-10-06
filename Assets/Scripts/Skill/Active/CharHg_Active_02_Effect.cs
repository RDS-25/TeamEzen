using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharHg_Active_02_Effect : SkillEffrct
{
    
    void Start()
    {
        
        myFactory(GameManager.instance.objectFactory.CharHGActive02EffectFactory);

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
