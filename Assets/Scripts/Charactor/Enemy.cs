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
      


        //멈추면 공격
        if (Vector3.Distance(target.position, transform.position) <= nav.stoppingDistance) {
            ani.SetBool("doWalk", false);
            //바로 멈추기 
            nav.SetDestination(transform.position);
            transform.LookAt(target.position);
            ani.SetBool("doAttack", true);
        }
        //아니면 이동 
        else {
            ani.SetBool("doWalk", true);
            ani.SetBool("doAttack", false);
            nav.SetDestination(target.position);
            ani.SetBool("doAttack", false);
        }

    }
}
