using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    float fverti;
    float fhori;

    Vector3 Vmove;
    Shot shot;

    Animator ani;

    
    public GameObject Bullet;
    public Transform Bulletpos;

    //입장 했는가 ?
    public bool isEntries = true;

    void Start()
    {
        ani = GetComponent<Animator>();
        shot = GetComponent<Shot>();

    }


    // Update is called once per frame
    void Update()
    {
        
        if (isEntries) {
            onMove();
        }
        

        if (Input.GetMouseButtonDown(0) && isEntries)
        {
            ani.SetBool("isAim", true);
            StartCoroutine("onShot");

        }
        else if (Input.GetMouseButtonUp(0) && isEntries) {
            ani.SetBool("isAim", false);
        
        }
    }

    void onMove() {
        fhori = Input.GetAxisRaw("Horizontal");
        fverti = Input.GetAxisRaw("Vertical");

        Vmove = new Vector3(fhori, 0, fverti).normalized;

        transform.position += Vmove * 5f * Time.deltaTime;

        ani.SetBool("isRun", Vmove != Vector3.zero);

        transform.LookAt(transform.position + Vmove);
    }


    IEnumerator onShot()
    {
        GameObject bullet = Instantiate(Bullet, Bulletpos.position, Bulletpos.rotation);
        Rigidbody bulletrigid = bullet.GetComponent<Rigidbody>();
        bulletrigid.velocity = Bulletpos.forward * 50;

        yield return new WaitForSeconds(0.1f);
    }

    
}
