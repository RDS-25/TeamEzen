using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem particleSystem;
	private void OnCollisionEnter(Collision collision)
	{
        if (collision.transform.gameObject.tag == "Enemy") {

            ParticleSystem swpanparicle = Instantiate(particleSystem,collision.contacts[0].point, Quaternion.identity);
            swpanparicle.Play();
            Destroy(swpanparicle.gameObject, swpanparicle.main.duration);
            //ÃÑ¾Ë
            Destroy(gameObject);
            

           

        }
	}
}
