using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Params;
public class BuffType : Skill
{    
    
    public override void SetType()
    {
        skillDetail = "BUFF";//��ųʸ� ����� ����
        enumSkillDetail = SkillDetailType.BUFF;
    }
    public override void SetDefault()
    {
        fSkillLevel = 1;
        fId = 10;
        strName = "Act1";
        strDiscription = "ok";
        //strIconpath=
        //strEffectPath=
        fSkillExp = 0;
        fSkillRequireExp = 100;
        fUnlockLevel = 1;
        fUnlockHidenLevel = 20;
        fValue = 10;
        fHidenValue = 10;
        fMagnification = 10;
        bisUnlockSkill = false;
        bisUnlockHiden = false;
        bisActtivate = false;
    }

    public override void LoadParams()
    {
        Dictionary<string, string> dicTemp = GameManager.instance.DataRead(strSkillFolderPath + strSkillParamsName);

        fId = float.Parse(dicTemp["fId"]);
        enumSkillDetail = (SkillDetailType)Enum.Parse(typeof(SkillDetailType), dicTemp["skillDetail"]);//�̳����� �־��ֱ�, Ÿ�Ե� ���ֱ�
        strName = dicTemp["strName"];
<<<<<<< Updated upstream
        strDiscription = dicTemp["fSkillLevel"];
        strIconName = dicTemp["strIconName"];
=======
        strDiscription = dicTemp["strDiscription"];
        strIconName = dicTemp["strIconpath"];
>>>>>>> Stashed changes
        strSkillFolderPath = dicTemp["strSkillFolderPath"];
        strSkillParamsName = dicTemp["strSkillParamsName"];
        strEffectPath = dicTemp["strEffectPath"];
        fSkillLevel = float.Parse(dicTemp["fSkillLevel"]);
        fSkillExp = float.Parse(dicTemp["fSkillExp"]);
        fSkillRequireExp = float.Parse(dicTemp["fSkillRequireExp"]);
        fUnlockLevel = float.Parse(dicTemp["fUnlockLevel"]);
        fUnlockHidenLevel = float.Parse(dicTemp["fUnlockHidenLevel"]);
        fValue = float.Parse(dicTemp["fValue"]);
        fHidenValue = float.Parse(dicTemp["fHidenValue"]);
        fMagnification = float.Parse(dicTemp["fMagnification"]);
        bisUnlockSkill = Convert.ToBoolean(dicTemp["bisUnlockSkill"]);
        bisUnlockHiden = Convert.ToBoolean(dicTemp["bisUnlockHiden"]);
        bisActtivate = Convert.ToBoolean(dicTemp["bisActtivate"]);
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
    public void CharaterStatUp(ref float stat1, ref float stat2)//ref�� �ִ� �ʿ��� ������ �� ������ ���� ����
    {
        stat1 = stat1 * fMagnification + fValue;

        //�ø� ������ ĳ���Ķ����� ��������ֱ�
        if (bisUnlockHiden)
        {
            stat2 = stat2 * fHidenValue;
            //�ø� ������ ĳ���Ķ����� ��������ֱ�
        }
    }
}
