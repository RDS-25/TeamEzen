using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadActiveSkill : ActiveSkill
{
    string ActiveSkillPath;
    string ActiveParams;
    //public character character;캐릭터
    Dictionary<string, string> DicActiveSkillparam;
    public Transform FirePoint;
    const float PLUS_VAL = 10f;
    const float PLUS_MAG = 10f;
    const float PLUS_TARGET_COUNT = 0f;
    const float PLUS_ATTACK_COUNT = 0f;
    void Start()
    {
        
    }
    public override void InitParams()
    {//캐릭터가 가지고있는 스킬id값이랑 매치
        
        
            if (GameManager.instance.CheckExist(ActiveSkillPath, ActiveParams))
            {

            }
        
        
    }

    void Update()
    {
        
    }
}
