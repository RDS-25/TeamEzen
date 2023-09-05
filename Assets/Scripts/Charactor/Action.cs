using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    float fverti;
    float fhori;

    Vector3 Vmove;
    Shot shot;

    Animator ani;

    public GameObject Bullet;
    public Transform Bulletpos;
    Stat stat;

    //입장 했는가 ?
    public bool isEntries = false;
    public float targetingRange;

    void Start()
    {
        ani = GetComponent<Animator>();
        shot = GetComponent<Shot>();
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
    }

    void onMove()
    {
        fhori = Input.GetAxisRaw("Horizontal");
        fverti = Input.GetAxisRaw("Vertical");

        Vmove = new Vector3(fhori, 0, fverti).normalized;

        transform.position += Vmove * 5f * Time.deltaTime;

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


