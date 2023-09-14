using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadActiveSkill : AttackType
{
    string ActiveSkillPath;
    string ActiveParams;
    //public character character;캐릭터
    Dictionary<string, string> DicActiveSkillparam;

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
