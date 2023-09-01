using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private void Awake()
    {
        if (cam == null)
            cam = GetComponent<Camera>();
        Initialize();
    }


    public void Initialize()
    {
        cam.clearFlags = CameraClearFlags.Color;
    }

    private void OnPostRender()
    {
        cam.clearFlags = CameraClearFlags.Nothing;
    }
}
