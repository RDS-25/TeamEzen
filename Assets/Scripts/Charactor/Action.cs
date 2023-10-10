using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Action : MonoBehaviour
{
    float fverti;
    float fhori;

    public FixedJoystick MoveJoystick;



    public enum Motion { 
        Idle,
        Action,
        Cancel
    }

    public Motion motion;
   
    //스킬 취소 상태 여부 
    public bool bIsCancel;
    //일시 정지 할때 멈추기 
    public bool bIsStop =false;

    Vector3 Vmove;


    Animator ani;
    Stat stat;
    public GameObject UIGroup;
    public Transform tBulletpos;

    //입장 했는가 ?
    public bool isEntries;
    //평타 사거리
    public float targetingRange;
    //마지막 본 방향
    public Vector3 lastJoystickDirection;
  


    void Start()
    {
        ani = GetComponent<Animator>();
        stat = GetComponent<Stat>();
        targetingRange = stat.fDefaultRange;

		//현재 캐릭터 스킬 
		for (int i = 0; i < GameManager.instance.objectFactory.AllSkill.listPool.Count; i++)
		{
			if (GameManager.instance.objectFactory.AllSkill.listPool[i].GetComponent<Skill>().fCharToUse == stat.fId)
			{
				GameManager.instance.objectFactory.AllSkill.listPool[i].SetActive(true);
				Debug.Log(GameManager.instance.objectFactory.AllSkill.listPool[i]);

			}
		}


		//캐릭터 2

		//캐릭터 3

	}

	// Update is called once per frame
	void Update()
    {
        if (isEntries)
        {
            onMove();
        }
        else if (!isEntries) {
          
            ani.SetBool("isRun", false);
        }

    }

    public void ShootStart()
    {
        ani.SetBool("isAim", true);
        StartCoroutine("onShot");
     
    }
     public void ShootEnd()
     {
         ani.SetBool("isAim", false);

     }


    void onMove()
    {
      
        fhori = MoveJoystick.Horizontal;
        fverti = MoveJoystick.Vertical;
    
        Vmove = new Vector3(fhori, 0, fverti).normalized;


        transform.position += Vmove * 5f * (Input.GetKey(KeyCode.LeftShift) ? 0.7f : 1.3f) * Time.deltaTime;
  
       
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
            GameObject aa = GameManager.instance.objectFactory.BulletFactory.GetObject();
            aa.SetActive(true);
            aa.transform.position = tBulletpos.position;
            transform.LookAt(direction);
          
        }
        else if (closestEnemy == null)
        {
            //한캐릭터가 가지고 있는 스킬  //조건문걸어야함
            
          /* GameObject aa=  .GetObject();*/
            /*aa.transform.position = tBulletpos.position;*/

            Debug.Log(00);
            transform.LookAt(Vector3.forward);
        }


        yield return new WaitForSeconds(0.1f);
        ani.SetBool("isAim", false);
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
        UIGroup.SetActive(false);
        
        Debug.Log("일시 정지");
         
    }
    public void reStart()
    {
        bIsStop = false;
        ani.enabled = true;
        isEntries = true;
        UIGroup.SetActive(true);
        Debug.Log("일시 정지 해제 ");

    }


    //이벤트 트리거에서 사용
    public void onCancelEnter() {
      /*취소 실행  */
        bIsCancel = true;
    }
    public void onCancelExit() {
        Debug.Log("onCancelExit 실행 ");
        bIsCancel = false;
    }


    void ShowSkill() { 
    
    }

}
