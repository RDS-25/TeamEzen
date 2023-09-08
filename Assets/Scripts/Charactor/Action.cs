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
    //�⺻ ���� 
    public bool bIsIdle = true;
    //��ų ��� ���� ���� 
    public bool bIsCancel =false;

    public GameObject gRangeIndicator; // ���� ǥ�ñ� ������Ʈ�� �Ҵ��մϴ�.
    public GameObject gMaxRangeIndicator; // �ִ� ��Ÿ� ǥ�ñ� ������Ʈ�� �Ҵ��մϴ�.
    public GameObject gSkillCancel;
    public float fSkillRange = 5f; // ��ų ��Ÿ��� �����մϴ�.
    public float fMaxSkillRange = 10f; // ��ų�� �ִ� ��Ÿ��� �����մϴ�.


    //�Ͻ� ���� �Ҷ� ���߱� 
    public bool bIsStop =false;
   


    Vector3 Vmove;

    public VariableJoystick joystick;
   
    Animator ani;
    public GameObject gBullet;
    public Transform tBulletpos;
    Stat stat;

    //���� �ߴ°� ?
    public bool isEntries = false;
    //��Ÿ�
    public float targetingRange;
    //������ �� ����
    public Vector3 lastJoystickDirection;

    void Start()
    {
        ani = GetComponent<Animator>();
        stat = GetComponent<Stat>();
        targetingRange = stat.fDefaultRange;
      
        // �ִ� ��Ÿ� ǥ�ñ� ũ�� ����
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

        //���̽�ƽ ����
        Vector3 joystickDirection = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        

        if (joystickDirection.magnitude > 0.1f)
        {
            lastJoystickDirection = joystickDirection;
            //Debug.Log(lastJoystickDirection);
            // ��ų ���� ǥ��
            gRangeIndicator.transform.position = transform.position + joystickDirection * 5;//5�� ��ų ������ 

            gRangeIndicator.SetActive(true); //��ų����
            gMaxRangeIndicator.SetActive(true); //��ų ��Ÿ�
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
                Debug.Log("��ų ���� ��� ");
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
                
               
                Debug.Log("��ų����");
                Vector3 targetPosition = transform.position + lastJoystickDirection;
                   
                transform.LookAt(targetPosition);

                //��ų ����

                //��ų �߻� ��� ���� 
                // ����Ʈ ���丮���� �ٷ� �޾Ƽ� ���
                



              
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


    //Bool ���� false�� �ٲٴ� ���� 
    public void Pause() {
        bIsStop = true;
        ani.enabled = false;
        isEntries = false;
        Debug.Log("�Ͻ� ����");
         
    }
    public void reStart()
    {
        bIsStop = false;
        ani.enabled = true;
        isEntries = true;
        Debug.Log("�Ͻ� ���� ���� ");

    }


    //�̺�Ʈ Ʈ���ſ��� ���
    public void onCancelEnter() {
        Debug.Log("onCancelEnter ����");
        motion=Motion.Cancel;
    }
    public void onCancelExit() {
        Debug.Log("onCancelExit ���� ");
        motion = Motion.Idle;

    }
    
}
