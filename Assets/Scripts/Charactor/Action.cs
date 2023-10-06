using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Action : MonoBehaviour
{
    float fverti;
    float fhori;

    public FixedJoystick MoveJoystick;
    public FixedJoystick ActiveJoystick;
    public FixedJoystick UltimateJoystick;


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

    public GameObject gBullet;
    public Transform tBulletpos;

    //���� �ߴ°� ?
    public bool isEntries;
    //��Ÿ�
    public float targetingRange;
    //������ �� ����
    public Vector3 lastJoystickDirection;
  


    void Start()
    {
        ani = GetComponent<Animator>();
        stat = GetComponent<Stat>();
        targetingRange = stat.fDefaultRange;

        //���� ĳ���� ��ų 
        for (int i = 0; i < GameManager.instance.objectFactory.AllSkill.listPool.Count;i++) {
            
        }
        GameManager.instance.objectFactory.AllSkill.listPool[0].SetActive(true);//active
        GameManager.instance.objectFactory.AllSkill.listPool[8].SetActive(true); //basic
        GameManager.instance.objectFactory.AllSkill.listPool[20].SetActive(true); //passive
        GameManager.instance.objectFactory.AllSkill.listPool[24].SetActive(true); //ultimate

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
            //ani.SetBool("isWalk",false);
            ani.SetBool("isRun", false);
        }

        /*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!bIsStop)
            {
                Pause();
            }else if (bIsStop)
			{
                reStart();
			}
        }*/
     
        /*
        if (Input.GetMouseButtonDown(0) && isEntries)
        {
            ani.SetBool("isAim", true);
            StartCoroutine("onShot");
        }
        else if (Input.GetMouseButtonUp(0) && isEntries)
        {
            ani.SetBool("isAim", false);
        }*/

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
        /*
        fhori = Input.GetAxisRaw("Horizontal");
        fverti = Input.GetAxisRaw("Vertical");
        */
        fhori = MoveJoystick.Horizontal;
        fverti = MoveJoystick.Vertical;
        //Debug.Log(MoveJoystick.Horizontal);
        //Debug.Log(MoveJoystick.Vertical);
        Vmove = new Vector3(fhori, 0, fverti).normalized;


        transform.position += Vmove * 5f * (Input.GetKey(KeyCode.LeftShift) ? 0.7f : 1.3f) * Time.deltaTime;
  
        
        //ani.SetBool("isWalk", Input.GetKey(KeyCode.LeftShift));
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
            GameObject bullet = GameManager.instance.objectFactory.CharARActive01EffectFactory.listPool[0];
            bullet.SetActive(true);
            //Rigidbody bulletrigid = bullet.GetComponent<Rigidbody>();
            transform.LookAt(direction);
            //bulletrigid.velocity = direction * 50;
        }
        else if (closestEnemy == null)
        {
            //��ĳ���Ͱ� ������ �ִ� ��ų  //���ǹ��ɾ����
            GameManager.instance.objectFactory.AllSkill.listPool[8].GetComponent<Skill>().ShotEffect(tBulletpos.position);
            //Rigidbody bulletrigid = bullet.GetComponent<Rigidbody>();
            //bulletrigid.velocity = tBulletpos.forward * 50;
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


	private void OnTriggerEnter(Collider other)
	{
        if (other.tag == "EnemyBullet") {
            //������ �����
            stat.fHealth -= 10; 
        }
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

   

}
