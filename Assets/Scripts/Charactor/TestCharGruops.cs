using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCharGruops : MonoBehaviour
{


    float fverti;
    float fhori;

    Vector3 Vmove;
 

    Animator ani;

    Action action;

	void Start()
    {
        ani = GetComponentInChildren<Animator>();
        action = GetComponentInChildren<Action>();
    }

	private void OnEnable()
	{
   
    }

	// Update is called once per frame
	void Update()
    {
      
    
       
       
    }


    void onMove()
    {
        fhori = Input.GetAxisRaw("Horizontal");
        fverti = Input.GetAxisRaw("Vertical");

        Vmove = new Vector3(fhori, 0, fverti).normalized;
        Debug.Log(Vmove);

        transform.position += Vmove * 5f * Time.deltaTime;

        ani.SetBool("isRun", Vmove != Vector3.zero);

        transform.LookAt(transform.position + Vmove);
    }


}
