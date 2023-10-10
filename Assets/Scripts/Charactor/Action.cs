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
   
    //��ų ��� ���� ���� 
    public bool bIsCancel;
    //�Ͻ� ���� �Ҷ� ���߱� 
    public bool bIsStop =false;

    Vector3 Vmove;


    Animator ani;
    Stat stat;
    public GameObject UIGroup;
    public Transform tBulletpos;

    //���� �ߴ°� ?
    public bool isEntries;
    //��Ÿ ��Ÿ�
    public float targetingRange;
    //������ �� ����
    public Vector3 lastJoystickDirection;
  


    void Start()
    {
        ani = GetComponent<Animator>();
        stat = GetComponent<Stat>();
        targetingRange = stat.fDefaultRange;

		//���� ĳ���� ��ų 
		for (int i = 0; i < GameManager.instance.objectFactory.AllSkill.listPool.Count; i++)
		{
			if (GameManager.instance.objectFactory.AllSkill.listPool[i].GetComponent<Skill>().fCharToUse == stat.fId)
			{
				GameManager.instance.objectFactory.AllSkill.listPool[i].SetActive(true);
				Debug.Log(GameManager.instance.objectFactory.AllSkill.listPool[i]);

			}
		}


		//ĳ���� 2

		//ĳ���� 3

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
            //��ĳ���Ͱ� ������ �ִ� ��ų  //���ǹ��ɾ����
            
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


	

	//Bool ���� false�� �ٲٴ� ���� 
	public void Pause() {
        bIsStop = true;
        ani.enabled = false;
        isEntries = false;
        UIGroup.SetActive(false);
        
        Debug.Log("�Ͻ� ����");
         
    }
    public void reStart()
    {
        bIsStop = false;
        ani.enabled = true;
        isEntries = true;
        UIGroup.SetActive(true);
        Debug.Log("�Ͻ� ���� ���� ");

    }


    //�̺�Ʈ Ʈ���ſ��� ���
    public void onCancelEnter() {
      /*��� ����  */
        bIsCancel = true;
    }
    public void onCancelExit() {
        Debug.Log("onCancelExit ���� ");
        bIsCancel = false;
    }


    void ShowSkill() { 
    
    }

}
