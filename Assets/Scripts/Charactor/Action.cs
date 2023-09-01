using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    float fverti;
    float fhori;

    Vector3 Vmove;

    Animator ani;

    //입장 했는가 ?
    bool isEntries = false;

    void Start()
    {
        ani = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {

        if (isEntries) {
            onMove();
        }
        if (isEntries) {
            transform.GetChild(4).gameObject.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0) && isEntries)
        {
            ani.SetBool("isAim", true);
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
}
