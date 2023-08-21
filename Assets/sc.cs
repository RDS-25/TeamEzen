using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc : MonoBehaviour
{
    public GameObject[] ga;
    void Start()
    {

        for (int i = 0; i < ga.Length; i++) {
            Instantiate(ga[i], transform.position, transform.rotation);
            
        }
     
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
