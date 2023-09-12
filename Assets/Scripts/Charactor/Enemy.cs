using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent nav;
    public GameObject target;
    Animator ani;


    public bool isChase;   
    public bool isAttack;

    Rigidbody rigidbody;

    public BoxCollider AtkRange;




   
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponentInChildren<Animator>();
        rigidbody = GetComponent<Rigidbody>();

        Invoke("ChaseStart", 2f);
    }

    void ChaseStart() {
        isChase = true;
        ani.SetBool("doWalk",true);
    }
    // Update is called once per frame
    void Update()
	{
		//target = GameObject.FindWithTag("Player");


        if (target == null) {
            Debug.Log("�÷��̾� ����  ����");
        }

        if (nav.enabled)
        {
            nav.SetDestination(target.transform.position);
    
        }
        /*
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
            }*/
    }

    private void FixedUpdate()
    {

        Targeting();
        FreezeVelocity();
    }
    void Targeting()
	{
        float targetRadius = 1.5f;
        float tartgeRange = 1.5f;
        
        RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, tartgeRange, LayerMask.GetMask("Player"));
        Debug.Log(rayHits.Length);

        if (rayHits.Length < 0.5f && !isAttack) {
            StartCoroutine(Attack());
        }
	}
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 1.5f);
    }



    IEnumerator Attack() {

        isChase = false;
        isAttack = true;
        ani.SetBool("doAttack", true);

        yield return new WaitForSeconds(0.2f);
        AtkRange.enabled = true;




        yield return new WaitForSeconds(1f);
        AtkRange.enabled = false;

        isChase = true;
        isAttack = false;
        ani.SetBool("doAttack", false);
    }
    void FreezeVelocity()
    {
        // navagent �Ҷ� ������ ���� 
        if (isChase)
        {
            rigidbody.angularVelocity = Vector3.zero;
            rigidbody.velocity = Vector3.zero;
        }
    }

}
