using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    float fverti;
    float fhori;
    public enum Motion { 
        Idle,
        Action,
        Cancel
    }
    Motion motion;
    //기본 상태 
    public bool bIsIdle = true;
    //스킬 취소 상태 여부 
    public bool bIsCancel =false;

    public GameObject gRangeIndicator; // 범위 표시기 오브젝트를 할당합니다.
    public GameObject gMaxRangeIndicator; // 최대 사거리 표시기 오브젝트를 할당합니다.
    public GameObject gSkillCancel;
    public float fSkillRange = 5f; // 스킬 사거리를 설정합니다.
    public float fMaxSkillRange = 10f; // 스킬의 최대 사거리를 설정합니다.


    //일시 정지 할때 멈추기 
    public bool bIsStop =false;
   


    Vector3 Vmove;

    public VariableJoystick joystick;
   
    Animator ani;
    public GameObject gBullet;
    public Transform tBulletpos;
    Stat stat;

    //입장 했는가 ?
    public bool isEntries = false;
    //사거리
    public float targetingRange;
    //마지막 본 방향
    public Vector3 lastJoystickDirection;

    void Start()
    {
        ani = GetComponent<Animator>();
        stat = GetComponent<Stat>();
        targetingRange = stat.fDefaultRange;
      
        // 최대 사거리 표시기 크기 설정
        gMaxRangeIndicator.transform.localScale = new Vector3(fMaxSkillRange, gMaxRangeIndicator.transform.localScale.y, fMaxSkillRange);
    }

	// Update is called once per frame
	void Update()
    {
        if (isEntries)
        {
            onMove();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!bIsStop)
            {
                Pause();
            }else if (bIsStop)
			{
                reStart();
			}
        }
     
        if (Input.GetMouseButtonDown(0) && isEntries)
        {
            ani.SetBool("isAim", true);
            StartCoroutine("onShot");
        }
        else if (Input.GetMouseButtonUp(0) && isEntries)
        {
            ani.SetBool("isAim", false);
        }


        SkillFunction();
      
        
    }

   
    void SkillFunction() {

        //조이스틱 벡터
        Vector3 joystickDirection = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        

        if (joystickDirection.magnitude > 0.1f)
        {
            lastJoystickDirection = joystickDirection;
            //Debug.Log(lastJoystickDirection);
            // 스킬 범위 표시
            gRangeIndicator.transform.position = transform.position + joystickDirection * 5;//5는 스킬 범위로 

            gRangeIndicator.SetActive(true); //스킬범위
            gMaxRangeIndicator.SetActive(true); //스킬 사거리
            gSkillCancel.SetActive(true);
        }

        if (joystickDirection.magnitude <= 0.1f) {
            gRangeIndicator.SetActive(false);
            gMaxRangeIndicator.SetActive(false);
            gSkillCancel.SetActive(false);

        }
        /*
        if (bIsCancel)
        {
            if (joystickDirection.magnitude <= 0.1f)
            {
                gRangeIndicator.SetActive(false);
                gMaxRangeIndicator.SetActive(false);
                gSkillCancel.SetActive(false);
                lastJoystickDirection = Vector3.zero;
                Debug.Log("스킬 실행 취소 ");
                bIsIdle = true;
                bIsCancel = false;
            }
          
        } 
        else if (!bIsCancel&& bIsIdle)
        { 
            if (joystickDirection.magnitude <= 0.1f)
            { 
                gRangeIndicator.SetActive(false);
                gMaxRangeIndicator.SetActive(false);
                gSkillCancel.SetActive(false);
                
               
                Debug.Log("스킬실행");
                Vector3 targetPosition = transform.position + lastJoystickDirection;
                   
                transform.LookAt(targetPosition);

                //스킬 실행

                //스킬 발사 기능 구현 
                // 이펙트 펙토리에서 바로 받아서 사용
                



              
                lastJoystickDirection = Vector3.zero;

            }
        }*/
    }



    void onMove()
    {
        fhori = Input.GetAxisRaw("Horizontal");
        fverti = Input.GetAxisRaw("Vertical");

        Vmove = new Vector3(fhori, 0, fverti).normalized;


        transform.position += Vmove * 5f * (Input.GetKey(KeyCode.LeftShift) ? 0.7f : 1.3f) * Time.deltaTime;
  
        
        ani.SetBool("isWalk", Input.GetKey(KeyCode.LeftShift));
        ani.SetBool("isRun", Vmove != Vector3.zero);

        transform.LookAt(transform.position + Vmove);
    }


    IEnumerator onShot()
    {
        GameObject closestEnemy = FindClosestEnemyWithTag("Enemy", targetingRange);
        Vector3 direction;


        if (closestEnemy != null)
        {
            direction = (closestEnemy.transform.position - tBulletpos.position).normalized;
            GameObject bullet = Instantiate(gBullet, tBulletpos.position, Quaternion.LookRotation(direction));
            Rigidbody bulletrigid = bullet.GetComponent<Rigidbody>();
            transform.LookAt(direction);
            bulletrigid.velocity = direction * 50;
        }
        else if (closestEnemy == null)
        {
            GameObject bullet = Instantiate(gBullet, tBulletpos.position, tBulletpos.rotation);
            Rigidbody bulletrigid = bullet.GetComponent<Rigidbody>();
            bulletrigid.velocity = tBulletpos.forward * 50;
        }


        yield return new WaitForSeconds(0.1f);
    }

    private GameObject FindClosestEnemyWithTag(string tag, float range)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
        GameObject closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            Debug.Log(distance);
            if (distance < closestDistance && distance <= range)
            {
                closest = enemy;
                closestDistance = distance;
            }
            else
            {

                closest = null;
            }
        }
        Debug.Log(closest);
        return closest;
    }


    //Bool 변수 false로 바꾸는 변수 
    public void Pause() {
        bIsStop = true;
        ani.enabled = false;
        isEntries = false;
        Debug.Log("일시 정지");
         
    }
    public void reStart()
    {
        bIsStop = false;
        ani.enabled = true;
        isEntries = true;
        Debug.Log("일시 정지 해제 ");

    }


    //이벤트 트리거에서 사용
    public void onCancelEnter() {
        Debug.Log("onCancelEnter 실행");
        motion=Motion.Cancel;
    }
    public void onCancelExit() {
        Debug.Log("onCancelExit 실행 ");
        motion = Motion.Idle;

    }
    
}
