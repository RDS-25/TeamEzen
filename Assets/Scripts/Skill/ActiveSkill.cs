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
        //{//스킬이 사용가능할떄,스킬이 사용중이 아닐때
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
    
    //쿨타임동안 사용불가 쿨타임 종료시 사용가능
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
{//쿨타임동안 사용불가 쿨타임 종료시 사용가능
    SkilParams.fTimer += Time.deltaTime;
    if (SkilParams.fTimer >= SkilParams.fCoolTime)
        SkilParams.bisCanUse = true;
}*/