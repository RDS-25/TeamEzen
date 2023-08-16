using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        if (CheckHitWall(movement))
        {
            movement = Vector3.zero;
        }

        transform.Translate(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
    }

    bool CheckHitWall(Vector3 movement)
    {
        // 움직임에 대한 로컬 벡터를 월드 벡터로 변환해준다.
        movement = transform.TransformDirection(movement);
        // scope로 ray 충돌을 확인할 범위를 지정할 수 있다.
        float scope = 1f;

        // 플레이어의 머리, 가슴, 발 총 3군데에서 ray를 쏜다.
        List<Vector3> rayPositions = new List<Vector3>();
        rayPositions.Add(transform.position + Vector3.up * 0.1f);

        // 디버깅을 위해 ray를 화면에 그린다.
        foreach (Vector3 pos in rayPositions)
        {
            Debug.DrawRay(pos, movement * scope, Color.red);
        }

        // ray와 벽의 충돌을 확인한다.
        foreach (Vector3 pos in rayPositions)
        {
            if (Physics.Raycast(pos, movement, out RaycastHit hit, scope))
            {
                if (hit.collider.CompareTag("Wall"))
                    return true;
            }
        }
        return false;
    }
}
