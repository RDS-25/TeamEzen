using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    float fverti;
    float fhori;

    public VariableJoystick joystick;
	Vector3 Vmove;
    Animator ani;
    public GameObject Bullet;
    public Transform Bulletpos;
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
        /*
        Vector3 joystickDirection = new Vector3(joystick.Horizontal, 0, joystick.Vertical); // ���̽�ƽ ���� ���͸� ���ϼ���.

        Vector3 targetPosition = transform.position + joystickDirection; // ������Ʈ�� �ٶ� ��ǥ ��ġ�� ����ϼ���.
        transform.LookAt(targetPosition); // ������Ʈ�� ��ǥ ��ġ �������� ȸ����Ű����.*/

        Vector3 joystickDirection = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
 
        if (joystickDirection.magnitude > 0.1f)
        {
            lastJoystickDirection = joystickDirection;
        }

        if (joystickDirection.magnitude <= 0.1f && lastJoystickDirection.magnitude > 0.1f)
        {
            Vector3 targetPosition = transform.position + lastJoystickDirection;
            transform.LookAt(targetPosition);
            //��ų ����
            /*
                ��ų �߻� ��� ���� 
                ����Ʈ ���丮���� �ٷ� �޾Ƽ� ���
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


