using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadActiveSkill : ActiveSkill
{
    string ActiveSkillPath;
    string ActiveParams;
    //public character character;ĳ����
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
    {//ĳ���Ͱ� �������ִ� ��ųid���̶� ��ġ
        
        
            if (GameManager.instance.CheckExist(ActiveSkillPath, ActiveParams))
            {

            }
        
        
    }

    void Update()
    {
        
    }
}
