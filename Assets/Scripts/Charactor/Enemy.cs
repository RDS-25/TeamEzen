using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent nav;
    public Transform target;
    Animator ani;

   
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      


        //���߸� ����
        if (Vector3.Distance(target.position, transform.position) <= nav.stoppingDistance) {
            ani.SetBool("doWalk", false);
            //�ٷ� ���߱� 
            nav.SetDestination(transform.position);
            transform.LookAt(target.position);
            ani.SetBool("doAttack", true);
        }
        //�ƴϸ� �̵� 
        else {
            ani.SetBool("doWalk", true);
            ani.SetBool("doAttack", false);
            nav.SetDestination(target.position);
            ani.SetBool("doAttack", false);
        }

    }
}
