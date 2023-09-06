using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCamera : MonoBehaviour
{
    private Transform trCam;
    private Transform trPlayer;
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
        trPlayer = StageManager.Instance.player.transform;
    }
    private void LateUpdate()
    {
        float fX = trPlayer.position.x;
        float fY = trPlayer.position.y + fHeight;
        float fZ = trPlayer.position.z - fOfset;
        
        trCam.position = new Vector3(fX,fY,fZ);
        trCam.eulerAngles = Vector3.right * fRotate;
    }
}
