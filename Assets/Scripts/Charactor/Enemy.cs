using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent nav;
    public GameObject target;
    Animator ani;

    bool do_attack_coroutine=false;


    public enum State { 
        IDLE,
        CHASE,
        ATTACK
    }

    public State state;

    Rigidbody rigidbody;

    public BoxCollider AtkRange;


    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponentInChildren<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        state = State.CHASE;

    }


    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {
            Debug.Log("플레이어 없음  없음");
            state = State.IDLE;
        }


        if(state ==State.CHASE)
        {
           
            target = GameObject.FindWithTag("Player");
            nav.SetDestination(target.transform.position);
            ani.SetBool("doWalk", true);
        }
         
        
       
        



        /*
        //멈추면 공격
        if (Vector3.Distance(target.transform.position, transform.position) <= nav.stoppingDistance)
            {
                ani.SetBool("doWalk", false);
                //바로 멈추기 
                nav.SetDestination(transform.position);
                transform.LookAt(target.transform.position);
                ani.SetBool("doAttack", true);
            }
            //아니면 이동 
            else
            {
                ani.SetBool("doWalk", true);
                ani.SetBool("doAttack", false);
                nav.SetDestination(target.transform.position);
                ani.SetBool("doAttack", false);
            }*/
    }

    private void FixedUpdate()
    {
        Targeting();
        FreezeVelocity();
    }
    void Targeting()
	{
        float targetRadius = 0.5f;
        float tartgeRange = 0.5f;
        

        RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, tartgeRange, LayerMask.GetMask("Player"));
        Debug.Log(rayHits.Length);

        if (rayHits.Length > 0f && state != State.ATTACK)
        {
            //방어 코드  이유 : 중복 실행 방지
            if(!do_attack_coroutine)
            StartCoroutine("Attack");
        }
        else if(rayHits.Length == 0) {
            state = State.CHASE;
            ani.SetBool("doWalk",true);
            ani.SetBool("doAttack", false);
        }
      
        
      
	}
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }



    IEnumerator Attack() {
        do_attack_coroutine = true;
        ani.SetBool("doWalk", false);
        ani.SetBool("doAttack", true);
        state = State.ATTACK;
        while (true)
        {
            if (state != State.ATTACK) break;
                yield return new WaitForSeconds(0.2f);
                AtkRange.enabled = true;
                yield return new WaitForSeconds(ani.GetCurrentAnimatorStateInfo(0).length);
                AtkRange.enabled = false;
        }

        do_attack_coroutine = false;



    }
    void FreezeVelocity()
    {
        // navagent 할때 물리력 제외 
        if (nav.enabled)
        {
            rigidbody.angularVelocity = Vector3.zero;
            rigidbody.velocity = Vector3.zero;
        }
    }
}
