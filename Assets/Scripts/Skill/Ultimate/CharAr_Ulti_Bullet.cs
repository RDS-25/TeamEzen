using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAr_Ulti_Bullet : SkillBullet
{
    
    void OnEnable()
    {
        skillinfo = new CharAr_Ulti();
        myFactory(GameManager.instance.objectFactory.CharAr_Ultimate_Bullet_Factory);
        EndBullet();
    }
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("dfa");
        if (other.tag == "Enemy")
        {
            var monsterStat = other.gameObject.GetComponent<Stat>();
            fMonDadge = monsterStat.fMiss;
            fMonCriresi = monsterStat.fCriticalResist;
            fMonDefense = monsterStat.fDef;
            fMonProperty = monsterStat.fProperty;
            CalculDamage();
            monsterStat.fHealth -= fTotalDamage;            
        }
    }
    //protected override void moveBullet()
    //{

    //}
    void EndBullet()
    {
        StartCoroutine("time");
        //factoryManager.SetObject(gameObject);
        Debug.Log("스타트코루틴");
    }
    IEnumerator time()
    {
        Debug.Log(GetComponent<ParticleSystem>().main.duration);
        yield return new WaitForSeconds(GetComponent<ParticleSystem>().main.duration);
        
        myfactoryManager.SetObject(gameObject);
    }
    // Update is called once per frame

}
