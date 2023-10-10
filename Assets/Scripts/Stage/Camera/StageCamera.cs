using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCamera : MonoBehaviour
{
    private Transform trCam;
    private GameObject Player;
    [SerializeField] private float fHeight = 30.0f;
    [SerializeField] private float fOfset = 15.0f;
    [SerializeField] private float fRotate = 60.0f;

    private void Awake()
    {
        trCam = GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Player = StageManager.Instance.player;
    }

    private void LateUpdate()
    {
        if (Player != StageManager.Instance.player)
            Player = StageManager.Instance.player;

        float fX = Player.transform.position.x;
        float fY = Player.transform.position.y + fHeight;
        float fZ = Player.transform.position.z - fOfset;
        
        trCam.position = new Vector3(fX,fY,fZ);
        trCam.eulerAngles = Vector3.right * fRotate;
    }
}
