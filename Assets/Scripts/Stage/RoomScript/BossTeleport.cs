using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTeleport : MonoBehaviour
{
    private Transform test = null;

   private void OnTriggerEnter(Collider other)
    {
        test = GameObject.Find("Board").transform;

        Debug.Log(GameObject.Find("Board").transform.parent);
        Debug.Log("�δ볦");
    }
}
