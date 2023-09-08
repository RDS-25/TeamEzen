using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSkill : MonoBehaviour
{
    public Vector3 lastJoystickDirection;

    FixedJoystick joystick;
    public GameObject gRangeIndicator; // ���� ǥ�ñ� ������Ʈ�� �Ҵ��մϴ�.
    public GameObject gMaxRangeIndicator; // �ִ� ��Ÿ� ǥ�ñ� ������Ʈ�� �Ҵ��մϴ�.

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

        //���̽�ƽ ����
        Vector3 joystickDirection = new Vector3(joystick.Horizontal, 0, joystick.Vertical);

        if (joystick.Direction.magnitude > 0.1f)
        {
            lastJoystickDirection = joystickDirection;
     
            //Debug.Log(lastJoystickDirection);
            // ��ų ���� ǥ��
            gRangeIndicator.transform.position = transform.root.position + joystickDirection * 5;//5�� ��ų ������ 

            gRangeIndicator.SetActive(true); //��ų����
            gMaxRangeIndicator.SetActive(true); //��ų ��Ÿ�
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
                Debug.Log("��ų ���� ��� ");
                action.motion = Action.Motion.Idle;
               action.bIsCancel = false;
            }
            else if (action.motion == Action.Motion.Action)
            {
                Vector3 targetPosition = transform.root.position + lastJoystickDirection;
                transform.root.LookAt(targetPosition);
                Debug.Log("��ų  ����");
                action.motion = Action.Motion.Idle;
            }
        }

    }
}
