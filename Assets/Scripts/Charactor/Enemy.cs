using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
	NavMeshAgent nav;
	public GameObject target;
	Animator ani;
	public GameObject AtkRange;
	public float SightRange; //서치 시야 사거리 
	public float DefaultRange;//공격사거리 
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

	Material mat;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponentInChildren<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        stat = GetComponent<Stat>();

     

       
    }
    void Start()
	{
		state = State.IDLE;

        //추적 사거리
        SightRange = GetComponent<Stat>().fSightRange;
        //공격 사거리 
        DefaultRange = GetComponent<Stat>().fDefaultRange;

        mat = GetComponentInChildren<MeshRenderer>().material;
    }

    private void OnEnable()
    {
		Scene sc = SceneManager.GetActiveScene();

		if (sc.name == "StageScene") {
			if (nav == null)
			{
				nav = GetComponent<NavMeshAgent>();
				nav.enabled = true;
			}
			else {
				nav.enabled = true;
			}
		}

    }





    private void FixedUpdate()
	{
		target = GameObject.FindWithTag("Player");
		FreezeVelocity();
		if (nav.enabled)
		{
			if (GetComponent<Stat>().fHealth > 0)
			{
				Search();
				Targeting();
			}
		}
	}

	public void Dodie() {
        //예시용 코드 

        if (DieEvent != null)
        {
			if (stat.fHealth <= 0)
			{
				DieEvent(enemyType, gameObject);
			}
			DieEvent = null;
        }
 
	}

	//시야 사거리안에 적 찾아서   추적하기 
	void Search()
	{
		float targetRadius = SightRange;// 적의 사거리로  바꾸기
		float targetRange = 0; //구체가 나가는 거리 
		RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));

		// Chase 상태일때 search가 작동안함
		// Chase 상태이면 else if 문을 타서
		// nav.Setdestination이 자기 자신의 위치가 찍힘

		
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
		float targetRadius = DefaultRange;// 적의 사거리로  바꾸기
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


	void BossTargeting() {
		float targetRadius = 10f;// 적의 사거리로  바꾸기
		float targetRange = 0;// 적의 사거리로 바꾸기 

		RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
		if (rayHits.Length > 0f && state != State.ATTACK)
		{
			//방어 코드  이유 : 중복 실행 방지
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

		//시야 사거리
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, SightRange);


		//공격 사거리
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
		// navagent 할때 물리력 제외 
		if (nav.enabled)
		{
			rigidbody.angularVelocity = Vector3.zero;
			rigidbody.velocity = Vector3.zero;
			rigidbody.freezeRotation = true;
		}
	}

    private void OnTriggerEnter(Collider other)
    {
		if (other.tag == "Bullet") {
			Vector3 reactVec = transform.position - other.transform.position;
			Debug.Log(reactVec);
            StartCoroutine(onDamage(reactVec));
		}
    }

	//2023.10.12 ENEMY 피격로직 수정
	IEnumerator onDamage(Vector3 reactVec) 
	{
		mat.color = Color.red;
		yield return new WaitForSeconds(0.1f);

		if (GetComponent<Stat>().fHealth > 0)
		{
			mat.color = Color.white;
			Debug.Log("살았어요");
		}
		else {
            nav.enabled = false;
            mat.color = Color.gray;
			Debug.Log("죽었어요");

			reactVec = reactVec.normalized;
			reactVec += Vector3.up;
			rigidbody.AddForce(reactVec *5,ForceMode.Impulse);

            yield return new WaitForSeconds(2f);
			ani.SetBool("doDie", true);
            gameObject.SetActive(false);
        }
      

    }
}
