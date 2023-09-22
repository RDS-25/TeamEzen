using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jghjg : MonoBehaviour
{
    float fSpeed = 100;
    Rigidbody rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.AddForce(transform.forward * fSpeed);
    }
}
