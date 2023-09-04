using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent nav;
    public GameObject target;
    Animator ani;

   
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponentInChildren<Animator>();
        
        

    }

    // Update is called once per frame
    void Update()
	{
		target = GameObject.FindWithTag("Player");
        if (target == null) {
            Debug.Log("�÷��̾� ����  ����");
            ani.SetBool("doWalk", false);
            nav.SetDestination(transform.position);
            return;
        }
        


		//���߸� ����
		if (Vector3.Distance(target.transform.position, transform.position) <= nav.stoppingDistance)
            {
                ani.SetBool("doWalk", false);
                //�ٷ� ���߱� 
                nav.SetDestination(transform.position);
                transform.LookAt(target.transform.position);
                ani.SetBool("doAttack", true);
            }
            //�ƴϸ� �̵� 
            else
            {
                ani.SetBool("doWalk", true);
                ani.SetBool("doAttack", false);
                nav.SetDestination(target.transform.position);
                ani.SetBool("doAttack", false);
            }
        

    }
}
