using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc : MonoBehaviour
{
    public GameObject ga;
    void Start()
    {
       GameObject a= Instantiate(ga,transform.position,transform.rotation);
        a.transform.parent = transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
