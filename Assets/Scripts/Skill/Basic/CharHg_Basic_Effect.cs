using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharHg_Basic_Effect : SkillEffrct
{
    CharHg_Basic charHg_Basic;
    void Start()
    {
        charHg_Basic = GameObject.FindObjectOfType<CharHg_Basic>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);

    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
