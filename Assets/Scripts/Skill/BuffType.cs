using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Params;
public class BuffType : Skill
{
    float stat1;
    float stat2;
    public override void SetType()
    {
        skillDetail = "BUFF";//��ųʸ� ����� ����
        enumSkillDetail = SkillDetailType.BUFF;
    }

    public override void SkillUnlock()
    {//���� �����̸� ���⼭ ���θ� �� �������� �ƴϸ� �����
        base.SkillUnlock();
        //�߰����
    }
    public override void SkillHidenUnlock()
    {
        base.SkillHidenUnlock();
        //�߰���� ����

    }
    public override void SkillTriger(Vector3 playerposition)
    {
        base.SkillTriger(playerposition);
        CharaterStatUp();

    }
    public virtual void CharaterStatUp()//ref float stat1, ref float stat2)//ref�� �ִ� �ʿ��� ������ �� ������ ���� ����
    {
        stat1= stat1 * fMagnification + fValue;

        
        if (bisUnlockHiden)
        {
            stat2 = stat2 * fHidenValue;
            
        }
    }
}
