using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float fSpeed = 5.0f;
    private float frot_Speed = 180.0f;
    [SerializeField]
   // private FieldofView fv;


    Dictionary<int, string> users = new Dictionary<int, string>();


    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveVec = new Vector3(0, 0, vertical);
        moveVec = moveVec.normalized * fSpeed * Time.deltaTime;
        Vector3 RotVec = new Vector3(0, horizontal, 0);
        RotVec = RotVec.normalized * frot_Speed * Time.deltaTime;
        this.transform.Translate(moveVec);
        this.transform.Rotate(RotVec);
        //fv.View();
        //fv.SetAimDirection();

        //fv.SetAimDirection(transform.position);
       // fv.SetOrigin(transform.position);
    }
}
