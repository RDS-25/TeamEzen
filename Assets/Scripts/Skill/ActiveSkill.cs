using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkill : Skill
{
    [SerializeField]
    SkillParameter.SkillType SkillType = SkillParameter.SkillType.ACTIVE;
    
    public override void SkillTriger()
    {
        //if (skilParams.bisCanUse == true && skilParams.bisActtivate == false)
        //{//��ų�� ��밡���ҋ�,��ų�� ������� �ƴҶ�
        //    skilParams.bisActtivate = true;
        //    skilParams.fTimer = 0;
        //    SkillCoolDown();
        //    skilParams.bisCanUse = false;
        //    PlayAnimation();
        //    PlaySound();
        //}
        //else
        //    return;
    }
    public virtual IEnumerator SkillCoolDown()
    {
        yield return new WaitForSeconds(0);
    }
    
    //��Ÿ�ӵ��� ���Ұ� ��Ÿ�� ����� ��밡��
        //skilParams.fTimer += Time.deltaTime;
        //if (skilParams.fTimer >= skilParams.fCoolTime)
        //    skilParams.bisCanUse = true;
    
    public virtual void PlayAnimation()
    {

    }
    public virtual void PlaySound()
    {

    }

}
/*public virtual void SkillCoolDown()
{//��Ÿ�ӵ��� ���Ұ� ��Ÿ�� ����� ��밡��
    SkilParams.fTimer += Time.deltaTime;
    if (SkilParams.fTimer >= SkilParams.fCoolTime)
        SkilParams.bisCanUse = true;
}*/