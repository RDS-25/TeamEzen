using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBullet : MonoBehaviour
{
    Rigidbody rig;
    float fSpeed = 100;
    FactoryManager myfactoryManager;
    FactoryManager effectFactoryManager;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            
        }
    }
    void moveBullet()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * fSpeed * Time.deltaTime);
    }
    public virtual void myFactory(FactoryManager myFactoryManager)
    {
        myfactoryManager = myFactoryManager;
    }
    public virtual void EffectFactory(FactoryManager effcet)
    {
        effectFactoryManager = effcet;
    }
    void Update()
    {
        moveBullet();
    }
}
