using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	NavMeshAgent nav;
	public GameObject target;
	Animator ani;
	public GameObject AtkRange;
	public float SightRange;
	public float DefaultRange;
	public GameObject gBullet;
	
	public delegate void DieDelegate(EnemyType Etype,GameObject game);

	public event DieDelegate DieEvent;

	Stat stat;
	public enum EnemyType { 
		Melee,
		Ranged,
		Boss
	}
	public EnemyType enemyType;

	public bool do_attack_coroutine = false;


	public enum State
	{
		IDLE,
		CHASE,
		ATTACK,
		DIE
	}

	public State state;

	Rigidbody rigidbody;

	
	void Start()
	{
		nav = GetComponent<NavMeshAgent>();
		ani = GetComponentInChildren<Animator>();
		rigidbody = GetComponent<Rigidbody>();
		state = State.IDLE;
		stat = GetComponent<Stat>();

		//���� ��Ÿ�
	    SightRange = GetComponent<Stat>().fSightRange;
		//���� ��Ÿ� 
	    DefaultRange = GetComponent<Stat>().fDefaultRange;
	}


	private void FixedUpdate()
	{
		target = GameObject.FindWithTag("Player");
		FreezeVelocity();
		
	    Search();
	    Targeting();
	}

	void Dodie() {
		//���ÿ� �ڵ� 
		if (stat.fHealth <= 0) {
			if (DieEvent != null)
			{
				DieEvent(enemyType,gameObject);
			}
		}
	}

	//�þ� ��Ÿ��ȿ� �� ã�Ƽ�   �����ϱ� 
	void Search()
	{
		float targetRadius = 20f;// ���� ��Ÿ���  �ٲٱ�
		float targetRange = 0; //��ü�� ������ �Ÿ� 
		RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));

		// Chase �����϶� search�� �۵�����
		// Chase �����̸� else if ���� Ÿ��
		// nav.Setdestination�� �ڱ� �ڽ��� ��ġ�� ����

		
		if (rayHits.Length > 0 && state == State.IDLE)
		{
			Debug.Log("�þ� ��Ÿ� �� ��ġ");
			ani.SetBool("doWalk", true);

			state = State.CHASE;
			nav.isStopped = false;
			nav.SetDestination(target.transform.position);
		}
		if (rayHits.Length > 0 && state == State.CHASE)
		{
			nav.SetDestination(target.transform.position);
			nav.isStopped = false;
		}
		else if (rayHits.Length == 0)
		{
			ani.SetBool("doAttack", false);
			ani.SetBool("doWalk", false);
			nav.isStopped = true;
			state = State.IDLE;
		}

	}

	// ���ݻ�Ÿ����� �� ã�Ƽ� �� �����ϱ� 
	void Targeting()
	{
		float targetRadius = 10f;// ���� ��Ÿ���  �ٲٱ�
		float targetRange = 0;// ���� ��Ÿ��� �ٲٱ� 


		RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
		Debug.Log(rayHits.Length);

		if (rayHits.Length > 0f && state != State.ATTACK)
		{
			//��� �ڵ�  ���� : �ߺ� ���� ����
			if (!do_attack_coroutine)
				StartCoroutine("Attack");
			nav.SetDestination(transform.position);
		}
		else if (rayHits.Length == 0 && state == State.ATTACK)
		{

			ani.SetBool("doAttack", false);
			ani.SetBool("doWalk", true);
			nav.SetDestination(target.transform.position);
			state = State.CHASE;
		}
	}


	void BossTargeting() {
		float targetRadius = 10f;// ���� ��Ÿ���  �ٲٱ�
		float targetRange = 0;// ���� ��Ÿ��� �ٲٱ� 

		RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
		if (rayHits.Length > 0f && state != State.ATTACK)
		{
			//��� �ڵ�  ���� : �ߺ� ���� ����
			if (!do_attack_coroutine)
				StartCoroutine("Attack");
			
		}
		else if (rayHits.Length == 0 && state == State.ATTACK)
		{

			ani.SetBool("doAttack", false);
			ani.SetBool("doWalk", true);
		
			state = State.CHASE;
		}
	}
	private void OnDrawGizmos()
	{

		//�þ� ��Ÿ�
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, SightRange);


		//���� ��Ÿ�
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, DefaultRange);
	}

	IEnumerator Attack()
	{
		Vector3 distance = target.transform.position - AtkRange.transform.position;
		do_attack_coroutine = true;
		ani.SetBool("doWalk", false);
		transform.LookAt(target.transform.position);
		ani.SetBool("doAttack", true);
		state = State.ATTACK;
		while (true)
		{
			
			if (state != State.ATTACK)
			{
				do_attack_coroutine = false;
				
				yield break;
			}
			yield return new WaitForSeconds(0.2f);
			AtkRange.SetActive(true);
			if (enemyType == EnemyType.Ranged)
			{
				
				GameObject newBullet = Instantiate(gBullet, AtkRange.transform.position, AtkRange.transform.rotation);
				Rigidbody bulletrigid = newBullet.GetComponent<Rigidbody>();
				bulletrigid.velocity = distance * 3;
				AtkRange.GetComponent<BoxCollider>().enabled = false;
			}
			yield return new WaitForSeconds(ani.GetCurrentAnimatorStateInfo(0).length);
			AtkRange.SetActive(false);
		}
	}
	void FreezeVelocity()
	{
		// navagent �Ҷ� ������ ���� 
		if (nav.enabled)
		{
			rigidbody.angularVelocity = Vector3.zero;
			rigidbody.velocity = Vector3.zero;
			rigidbody.freezeRotation = true;
		}
	}
}
