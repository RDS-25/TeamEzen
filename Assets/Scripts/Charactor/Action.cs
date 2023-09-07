using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    float fverti;
    float fhori;

    public GameObject rangeIndicator; // 범위 표시기 오브젝트를 할당합니다.
    public GameObject maxRangeIndicator; // 최대 사거리 표시기 오브젝트를 할당합니다.
    public float skillRange = 5f; // 스킬 사거리를 설정합니다.
    public float maxSkillRange = 10f; // 스킬의 최대 사거리를 설정합니다.





    public VariableJoystick joystick;
	Vector3 Vmove;
    Animator ani;
    public GameObject Bullet;
    public Transform Bulletpos;
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
        maxRangeIndicator.transform.localScale = new Vector3(maxSkillRange, maxRangeIndicator.transform.localScale.y, maxSkillRange);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEntries)
        {
            onMove();
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
        
 
        Vector3 joystickDirection = new Vector3(joystick.Horizontal, 0, joystick.Vertical);

        if (joystickDirection.magnitude > 0.1f)
        {
            lastJoystickDirection = joystickDirection;
            //Debug.Log(lastJoystickDirection);
            // 스킬 범위 표시
            rangeIndicator.transform.position = transform.position + joystickDirection  * 5;//5는 스킬 범위로 
            rangeIndicator.SetActive(true);
            maxRangeIndicator.SetActive(true);
        }

        if (joystickDirection.magnitude <= 0.1f && lastJoystickDirection.magnitude > 0.1f)
        {
            rangeIndicator.SetActive(false);
            maxRangeIndicator.SetActive(false);

            Vector3 targetPosition = transform.position + lastJoystickDirection;
            transform.LookAt(targetPosition);
            Debug.Log("스킬 실행");
            //스킬 실행
            /*
                스킬 발사 기능 구현 
                이펙트 펙토리에서 바로 받아서 사용
             */


            lastJoystickDirection = Vector3.zero;
        }
    }

    void onMove()
    {
        fhori = Input.GetAxisRaw("Horizontal");
        fverti = Input.GetAxisRaw("Vertical");

        Vmove = new Vector3(fhori, 0, fverti).normalized;

        transform.position += Vmove * 5f *(Input.GetKey(KeyCode.LeftShift)?0.7f:1.3f) * Time.deltaTime;

        ani.SetBool("isWalk",Input.GetKey(KeyCode.LeftShift));
        ani.SetBool("isRun", Vmove != Vector3.zero);

		transform.LookAt(transform.position + Vmove);
	}
      

    IEnumerator onShot()
    {
        GameObject closestEnemy = FindClosestEnemyWithTag("Enemy", targetingRange);
        Vector3 direction;

        if (closestEnemy != null)
        {
            direction = (closestEnemy.transform.position - Bulletpos.position).normalized;
            GameObject bullet = Instantiate(Bullet, Bulletpos.position, Quaternion.LookRotation(direction));
            Rigidbody bulletrigid = bullet.GetComponent<Rigidbody>();
            transform.LookAt(direction);
            bulletrigid.velocity = direction * 50;
        }
        else if (closestEnemy == null) {
            GameObject bullet = Instantiate(Bullet, Bulletpos.position, Bulletpos.rotation);
            Rigidbody bulletrigid = bullet.GetComponent<Rigidbody>();
            bulletrigid.velocity = Bulletpos.forward * 50;
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
            else {

                closest = null;
            }
        }
        Debug.Log(closest);
        return closest;
    }
}


