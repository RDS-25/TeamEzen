using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTest : MonoBehaviour
{
    
    public Image targetCircle; //타겟팅 범위  이미지
    public Image indicatorRangeCircle; // 최대 사거리 이미지 
    public Canvas ActiveSkillCanvas; //타겟팅캔버스
    public Vector3 Pos; //마우스 포인터 위치 
    public float maxActiveSkillDistance; //최대사거리  
    public float targetCircleSize;



    void Start()
    {
        targetCircle.GetComponent<Image>().enabled = false;
        indicatorRangeCircle.GetComponent<Image>().enabled = false;
        //Gameobj instance ~~~~ 스킬 인스턴스 사거리 값
    }

    // Update is called once per frame
    void Update()
    {
     
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            if (hit.collider.gameObject != this.gameObject) {
                Pos = hit.point;
            }
        }
       
        var hitPosDir = (hit.point - transform.position).normalized; //  나아가는 방향만
       

        float distance = Vector3.Distance(hit.point, transform.position);

        distance = Mathf.Min(distance, maxActiveSkillDistance);  // 3을 스킬 스텟  MaxRange;
       
        var newHitPos = transform.position +new Vector3(0,4.55f,0)+ hitPosDir * distance;

        ActiveSkillCanvas.transform.position = newHitPos;

    }



}
