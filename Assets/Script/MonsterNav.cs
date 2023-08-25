using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterNav : MonoBehaviour
{   
    void Update()
    {
        GameObject targetObject = GameObject.Find("Player");

        NavMeshAgent navigationAgent = GetComponent<NavMeshAgent>();
        navigationAgent.destination = targetObject.transform.position;
    }
}