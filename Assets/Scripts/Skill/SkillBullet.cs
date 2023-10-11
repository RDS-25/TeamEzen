using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBullet : MonoBehaviour
{
    protected Rigidbody rig;
    float fSpeed = 100;
    public FactoryManager myfactoryManager;
    public FactoryManager effectFactoryManager;
    protected Vector3 Firepiont;
    protected float fRancri;
    protected float fRanmondod;
    protected float fMonDadge;
    protected float fMonDefense;
    protected float fMonCriresi;
    protected float fTotalDamage;
    protected float fMonProperty;
    protected Stat ChaStat;
    protected float id;
    int count;
    protected Skill skillinfo;


    void Start()
    {       //skllinfo 총알마다 할당해주기  skllinfo = new CharAr_Active_01();
        id = ChaStat.fId;
        rig = GetComponent<Rigidbody>();
        fRancri = UnityEngine.Random.Range(0f, 100f);
        fRanmondod = UnityEngine.Random.Range(0f, 100f);
        Firepiont = gameObject.GetComponent<Transform>().position;
        count = 0;
    }

    public virtual void myFactory(FactoryManager myFactoryManager)
    {
        myfactoryManager = myFactoryManager;
    }
    public virtual void EffectFactory(FactoryManager effcet)
    {
        effectFactoryManager = effcet;
    }
    public void SkillActivationInit(ref Stat activeObjectStat)
    {
        ChaStat = activeObjectStat;
    }
    public float CalculDamage()
    {
        if (fRanmondod < fMonDadge)
        {
            fTotalDamage = 0;
            return fTotalDamage;
        }
        else
        {
            if (fRancri <= ChaStat.fCriticalPer - fMonCriresi)
            {
                fTotalDamage = (ChaStat.fAtk * ChaStat.fCriticalDmg * (fMonDefense - ChaStat.fDefBreak / fMonDefense + 100)) * CheckPro(ChaStat.fProperty, fMonProperty) * skillinfo.fAttackCount;
            }
            else
            {
                fTotalDamage = ChaStat.fAtk * (fMonDefense - ChaStat.fDefBreak / fMonDefense + 100) * CheckPro(ChaStat.fProperty, fMonProperty) * skillinfo.fAttackCount;
            }
            return fTotalDamage;
        }
    }
    public virtual float CheckPro(float Attacker, float Defender)
    {
        if (Attacker - Defender == -1 || Attacker - Defender == 2)
        {//AttackerWin;
            return 1.3f;
        }
        if (Attacker - Defender == 1 || Attacker - Defender == -2)
        {//AttackerLose;
            return 0.7f;
        }
        else
            return 1f;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            count++;
            
            ContactPoint contactPoint = collision.contacts[0];
            Vector3 pos = contactPoint.point;
            var monsterStat = collision.gameObject.GetComponent<Stat>();
            fMonDadge = monsterStat.fMiss;
            fMonCriresi = monsterStat.fCriticalResist;
            fMonDefense = monsterStat.fDef;
            fMonProperty = monsterStat.fProperty;
            CalculDamage();
            // 오류 있음
            monsterStat.fHealth -= fTotalDamage;

            if (count >= skillinfo.fTargetCount)
            {
                myfactoryManager.SetObject(gameObject);
            }
            ShowEffect(pos);//새로 이펙트 나오는 함수만들기         
        }
    }
    public void ShowEffect(Vector3 contactpoint)
    {        
        GameObject Effect = effectFactoryManager.GetObject();
        Effect.transform.position = contactpoint;
        Effect.SetActive(true);
    }
    protected virtual void moveBullet()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * skillinfo.fSpeed * Time.deltaTime);
    }
    public virtual void CheckDistance()
    {
        float distance = Vector3.Distance(Firepiont, this.transform.position);
        //Debug.Log("ran" + range);
        //Debug.Log("dis" + distance);
        // Debug.Log("ran" + Ex_Active1Skill.Ex_Active1Params.fRange);
        if (distance > skillinfo.fRange)//Ex_Active1Params의 Range를 가져오는 방법??
        {
            // setactive 해주기
            myfactoryManager.SetObject(gameObject);
        }
        else
            return;
    }
    
    void Update()
    {
        moveBullet();
        CheckDistance();
    }
}
