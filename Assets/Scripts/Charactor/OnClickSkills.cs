using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class OnClickSkills : MonoBehaviour
{

	public void ClickSkills() {

		GameObject Skill = EventSystem.current.currentSelectedGameObject;
		var a = Skill.GetComponent<SkillTest>();
		a.targetCircle.enabled = true;
		a.indicatorRangeCircle.enabled = true;

		//4.5f�� ���� ���̹����� 4.5ĭ�̾ 1�� ����� �ֱ�����, 3�� ĳ���ͻ����ŭ ���� 
		Vector2 abc = a.indicatorRangeCircle.GetComponent<RectTransform>().sizeDelta;
		float x = abc.x / 4.5f * 3f;
		float y = abc.y / 4.5f * 3f;
		float maxDistacne = a.maxActiveSkillDistance;
		float targetSize = a.targetCircleSize;
		a.indicatorRangeCircle.GetComponent<RectTransform>().sizeDelta = new Vector2(maxDistacne*3f ,  maxDistacne*3f);

	}
}
