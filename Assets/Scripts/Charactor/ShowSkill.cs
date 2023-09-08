using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSkill : MonoBehaviour
{
    public Vector3 lastJoystickDirection;

    FixedJoystick joystick;
    public GameObject gRangeIndicator; // 범위 표시기 오브젝트를 할당합니다.
    public GameObject gMaxRangeIndicator; // 최대 사거리 표시기 오브젝트를 할당합니다.

    Action action;
	private void Start()
	{
        action = GetComponentInParent<Action>();
        joystick = GetComponent<FixedJoystick>();
	}

	// Update is called once per frame
	void Update()
    {
        SkillFunction();
    }

    void SkillFunction()
    {

        //조이스틱 벡터
        Vector3 joystickDirection = new Vector3(joystick.Horizontal, 0, joystick.Vertical);

        if (joystick.Direction.magnitude > 0.1f)
        {
            lastJoystickDirection = joystickDirection;
     
            //Debug.Log(lastJoystickDirection);
            // 스킬 범위 표시
            gRangeIndicator.transform.position = transform.root.position + joystickDirection * 5;//5는 스킬 범위로 

            gRangeIndicator.SetActive(true); //스킬범위
            gMaxRangeIndicator.SetActive(true); //스킬 사거리
            //gSkillCancel.SetActive(true);
            //joystick.transform.GetChild(1).gameObject.SetActive(true);


            if (action.bIsCancel)
            {
                action.motion = Action.Motion.Cancel;
            }
            else
            {
                action.motion = Action.Motion.Action;
            }
        }

        if (joystick.Direction.magnitude <= 0.1f)
        {
            gRangeIndicator.SetActive(false);
            gMaxRangeIndicator.SetActive(false);
            //gSkillCancel.SetActive(false);
           // joystick.transform.GetChild(1).gameObject.SetActive(false);
            if (action.motion == Action.Motion.Cancel)
            {
                Debug.Log("스킬 실행 취소 ");
                action.motion = Action.Motion.Idle;
               action.bIsCancel = false;
            }
            else if (action.motion == Action.Motion.Action)
            {
                Vector3 targetPosition = transform.root.position + lastJoystickDirection;
                transform.root.LookAt(targetPosition);
                Debug.Log("스킬  실행");
                action.motion = Action.Motion.Idle;
            }
        }

    }
}
