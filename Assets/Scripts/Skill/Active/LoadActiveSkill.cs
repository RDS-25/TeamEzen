using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadActiveSkill : AttackType
{
    string ActiveSkillPath;
    string ActiveParams;
    //public character character;ĳ����
    Dictionary<string, string> DicActiveSkillparam;

    void Start()
    {
        
    }
    public override void InitParams()
    {//ĳ���Ͱ� �������ִ� ��ųid���̶� ��ġ
        
        
            if (GameManager.instance.CheckExist(ActiveSkillPath, ActiveParams))
            {

            }
        
        
    }

    void Update()
    {
        
    }
}
