using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Params;

public class SkillBullet : MonoBehaviour
{
    protected Rigidbody rig;
    float fSpeed = 100;
    public FactoryManager myfactoryManager;
    public FactoryManager effectFactoryManager;
    protected Vector3 Firepiont;
    [SerializeField]
    protected float fRancri;
    [SerializeField]
    protected float fRanmondod;
    [SerializeField]
    protected float fMonDadge;
    [SerializeField]
    protected float fMonDefense;
    [SerializeField]
    protected float fMonCriresi;
    [SerializeField]
    protected float fTotalDamage;
    [SerializeField]
    protected float fMonProperty;
   // protected Stat ChaStat;
    protected float id;
    int count;
    protected Skill skillinfo;
    public SkillParams skillParams;
    //fTargetCount,fAttackCount,fMaxRange
    protected float TartgetCount;
    protected float AttackCount;
    protected float fMaxRange;    
    void Start()
    {       //skllinfo �Ѿ˸��� �Ҵ����ֱ�  skllinfo = new CharAr_Active_01();
        /*id = ChaStat.fId;*/
        rig = GetComponent<Rigidbody>();  
        count = 0;
    }
	private void OnEnable()
	{
     
    }

	public virtual void myFactory(FactoryManager myFactoryManager)
    {
        myfactoryManager = myFactoryManager;
    }
    public virtual void EffectFactory(FactoryManager effcet)
    {
        effectFactoryManager = effcet;
    }
  /*  public void SkillActivationInit(ref Stat activeObjectStat)
    {
        ChaStat = activeObjectStat;
    }*/
    public float CalculDamage()
    {
        var ChaStat = GameManager.instance.arrCurCharacters[0].GetComponent<Stat>();
        if (fRanmondod < fMonDadge)
        {
            fTotalDamage = 0;
            return fTotalDamage;
            Debug.Log("ȸ��"+fTotalDamage);
        }
        else
        {
            if (fRancri <= ChaStat.fCriticalPer - fMonCriresi)
            {
                fTotalDamage = (ChaStat.fAtk * ChaStat.fCriticalDmg * (fMonDefense - ChaStat.fDefBreak / fMonDefense + 100)) * CheckPro(ChaStat.fProperty, fMonProperty) * skillParams.fAttackCount;
            }
            else
            {
                //������ ���� ����
                fTotalDamage = ChaStat.fAtk * (fMonDefense - ChaStat.fDefBreak / (fMonDefense + 100)) * CheckPro(ChaStat.fProperty, fMonProperty) * skillParams.fAttackCount;
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
	private void OnTriggerEnter(Collider other)
	{

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("��Ʈ");
            fRancri = UnityEngine.Random.Range(0f, 100f);
            fRanmondod = UnityEngine.Random.Range(0f, 100f);

            count++;
            var monsterStat = other.gameObject.GetComponent<Stat>();
            fMonDadge = monsterStat.fMiss;
            fMonCriresi = monsterStat.fCriticalResist;
            fMonDefense = monsterStat.fDef;
            fMonProperty = monsterStat.fProperty;
            
            CalculDamage();
            // ���� ����
            Debug.Log(fTotalDamage);
            monsterStat.fHealth -= fTotalDamage;


            if (count >= skillParams.fTargetCount)
            {
                myfactoryManager.SetObject(gameObject);
            }
            ShowEffect(transform.position);//���� ����Ʈ ������ �Լ������         
        }
    }
/*	private void OnCollisionEnter(Collision collision)
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
            // ���� ����
            monsterStat.fHealth -= fTotalDamage;

            if (count >= skillinfo.fTargetCount)
            {
                myfactoryManager.SetObject(gameObject);
            }
            ShowEffect(pos);//���� ����Ʈ ������ �Լ������         
        }
    }*/
    public void ShowEffect(Vector3 contactpoint)
    {        
        GameObject Effect = effectFactoryManager.GetObject();
        Effect.transform.position = contactpoint;
        Effect.SetActive(true);
       Debug.Log( Effect.GetComponent<ParticleSystem>().main.duration);
    }
    protected virtual void moveBullet()
    {
        Debug.Log("�̵� ����");
        //GetComponent<Rigidbody>().AddForce(transform.forward * 10f, ForceMode.Impulse);
        GetComponent<Rigidbody>().velocity = transform.forward * 10f;
    }
    public virtual void CheckDistance()
    {
        float distance = Vector3.Distance(Firepiont, this.transform.position);
        //Debug.Log("ran" + range);
        //Debug.Log("dis" + distance);
        // Debug.Log("ran" + Ex_Active1Skill.Ex_Active1Params.fRange);
        if (distance > skillParams.fMaxRange)//skillParams.fMaxRange)//Ex_Active1Params�� Range�� �������� ���??
        {
            // setactive ���ֱ�
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
