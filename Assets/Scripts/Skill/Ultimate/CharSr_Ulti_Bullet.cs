using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSr_Ulti_Bullet : SkillBullet
{
    void Start()
    {
        skillinfo = new CharSr_Ulti();
        myFactory(GameManager.instance.objectFactory.CharSr_Ultimate_Bullet_Factory);
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

    }
    IEnumerator time()
    {
        yield return new WaitForSeconds(GetComponent<ParticleSystem>().main.duration);
        myfactoryManager.SetObject(gameObject);
    }
}
