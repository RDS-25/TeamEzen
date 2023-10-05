using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem particleSystem;
    public enum BulletType { 
       ENEMY,
       PLAYER
    }
    public BulletType bulletType;

    private void OnCollisionEnter(Collision collision)
    {
        if (bulletType==BulletType.PLAYER&&collision.transform.gameObject.tag == "Enemy")
        {

            ParticleSystem swpanparicle = Instantiate(particleSystem, collision.contacts[0].point, Quaternion.identity);
            swpanparicle.Play();
           
            Destroy(swpanparicle.gameObject, swpanparicle.main.duration);
            //ÃÑ¾Ë
            Destroy(gameObject);
        }
        else if (bulletType == BulletType.ENEMY && collision.transform.gameObject.tag == "Player")
        {
            ParticleSystem swpanparicle = Instantiate(particleSystem, collision.contacts[0].point, Quaternion.identity);
            swpanparicle.Play();
            Destroy(swpanparicle.gameObject, swpanparicle.main.duration);
            //ÃÑ¾Ë
            Destroy(gameObject);
        }
    }
}
