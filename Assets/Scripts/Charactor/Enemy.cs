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
	public GameObject gBullet;

	public bool do_attack_coroutine = false;
	public enum MonsterType { 
		Melee,
		Range,
		Boss
	}
	public MonsterType monsterType;

	public enum State
	{
		IDLE,
		CHASE,
		ATTACK
	}

	public State state;

	Rigidbody rigidbody;

	


	void Start()
	{
		nav = GetComponent<NavMeshAgent>();
		ani = GetComponentInChildren<Animator>();
		rigidbody = GetComponent<Rigidbody>();
		state = State.IDLE;

	}


	// Update is called once per frame
	/*  void Update()
	  {
		  target = GameObject.FindWithTag("Player");

		  if (state == State.CHASE)
		  { 
			  nav.SetDestination(target.transform.position);
			  ani.SetBool("doWalk", true);
		  }

		  if (target == null)
		  {
			  Debug.Log("플레이어 없음  없음");
			  state = State.IDLE;
		  }

	  }*/

	private void FixedUpdate()
	{
		target = GameObject.FindWithTag("Player");
		FreezeVelocity();
		Search();
		Targeting();


	}
	
	//시야 사거리안에 적 찾아서   추적하기 
	void Search()
	{
		float targetRadius = 20f;// 적의 사거리로  바꾸기
		float targetRange = 0;// 적의 사거리로 바꾸기 
		RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));

		// Chase 상태일때 search가 작동안함
		// Chase 상태이면 else if 문을 타서
		// nav.Setdestination이 자기 자신의 위치가 찍힘
		// 상태는 IDLE임? -> 이건 모르겠음
		
		if (rayHits.Length > 0 && state == State.IDLE)
		{
			Debug.Log("시야 사거리 적 서치");
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

	// 공격사거리안의 적 찾아서 적 공격하기 
	void Targeting()
	{
		float targetRadius = 10f;// 적의 사거리로  바꾸기
		float targetRange = 0;// 적의 사거리로 바꾸기 


		RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
		Debug.Log(rayHits.Length);

		if (rayHits.Length > 0f && state != State.ATTACK)
		{
			//방어 코드  이유 : 중복 실행 방지
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
	private void OnDrawGizmos()
	{

		//시야 사거리
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, 20);


		//공격 사거리
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, 10);
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
			GameObject newBullet = Instantiate(gBullet, AtkRange.transform.position, AtkRange.transform.rotation);
			Rigidbody bulletrigid = newBullet.GetComponent<Rigidbody>();
			
			bulletrigid.velocity = target.transform.position * 3;
			yield return new WaitForSeconds(ani.GetCurrentAnimatorStateInfo(0).length);
			AtkRange.SetActive(false);
		}






	}
	void FreezeVelocity()
	{
		// navagent 할때 물리력 제외 
		if (nav.enabled)
		{
			rigidbody.angularVelocity = Vector3.zero;
			rigidbody.velocity = Vector3.zero;
			rigidbody.freezeRotation = true;
		}
	}
}
