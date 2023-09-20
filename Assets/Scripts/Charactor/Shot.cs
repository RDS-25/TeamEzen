using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
   public GameObject Bullet;
   public Transform Bulletpos;


	private void OnEnable()
	{
		GameObject newBullet =Instantiate(Bullet,Bulletpos.position,Bulletpos.rotation);
		newBullet.GetComponent<Rigidbody>().velocity = Vector3.forward *5;
	}

}
