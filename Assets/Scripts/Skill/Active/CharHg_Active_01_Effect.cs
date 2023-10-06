using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharHg_Active_01_Effect : SkillEffrct
{
    
    void Start()
    {
        
        myFactory(GameManager.instance.objectFactory.CharHGActive01EffectFactory);

    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
