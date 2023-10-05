using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTest : MonoBehaviour
{
    public Canvas ABC;
    public Image ABCImage;
    public Image targetCircle; //타겟팅 범위  이미지
    public Image indicatorRangeCircle; // 최대 사거리 이미지 
    public Canvas ActiveSkillCanvas; //타겟팅캔버스
    public Vector3 Pos; //마우스 포인터 위치 
    public float maxActiveSkillDistance; //최대사거리  
    public float targetCircleSize;
    public GameObject TestOBJ;
   
    public Camera cam;

    public enum SKillType {Arrow,Ranged }
    public SKillType sKillType;

    public enum SkillState {Init,Clicked,Active,}
    public SkillState Skillstate;
    GameObject Player;
    //스킬 사용중?
    public bool isSkilling;
    //스킬 캔슬
    public bool isCancel;



    void Start()
    {
        
        Player = GameObject.FindWithTag("Player");
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
   
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin,ray.direction ,Color.yellow);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Pos = new Vector3(hit.point.x,hit.point.y,hit.point.z);
        }

        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            if (hit.collider.gameObject != this.gameObject) {
                Pos = hit.point;
            }
        }

        Quaternion transRot = Quaternion.LookRotation(Pos - Player.transform.position);
        ABC.transform.rotation = Quaternion.Lerp(transRot, ABC.transform.rotation, 0f);

       
        var hitPosDir = (hit.point - Player.transform.position).normalized; //  나아가는 방향만
       
        float distance = Vector3.Distance(hit.point, Player.transform.position);

        distance = Mathf.Min(distance, maxActiveSkillDistance);  // 3을 스킬 스텟  MaxRange;
       
        var newHitPos = Player.transform.position  + hitPosDir * distance;

        ActiveSkillCanvas.transform.position = newHitPos;
        
        //Arrow와 Range의 나가는 스킬이 다르다 
        //Arrow는  발사체  Range는 소환

        //버튼 누를때 실행 안되게 and 처음에 실행 안되게 
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("겟마우스 다운 실행");
			if (isCancel)
			{
                isCancel = !isCancel;
                return;
			}
            Instantiate(TestOBJ, newHitPos, TestOBJ.transform.rotation);
            isSkilling = false;
            AllImageFalse();
            Debug.Log(hit.collider.gameObject);
        }

    }

    void AllImageFalse() {

        targetCircle.GetComponent<Image>().enabled = false;
        indicatorRangeCircle.GetComponent<Image>().enabled = false;
        ABCImage.GetComponent<Image>().enabled = false;
    }



}
