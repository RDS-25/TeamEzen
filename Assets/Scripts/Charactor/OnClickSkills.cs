using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class OnClickSkills : MonoBehaviour
{

	public List<GameObject> BtnSKills;

	public GameObject BtnPrev;//이전

	public void ClickSkills() {

		
		GameObject Skill = EventSystem.current.currentSelectedGameObject;
		var scSKill = Skill.GetComponent<SkillTest>();
		
		scSKill.enabled = true;
		Skill.GetComponent<SkillTest>().isSkilling = true;
		/*Skill.GetComponent<SkillTest>().Skillstate = SkillTest.SkillState.Clicked;*/
		if(Skill != BtnPrev)
		{
			scSKill.isCancel = true;
		}
			if (scSKill.sKillType == SkillTest.SKillType.Ranged)
			{

				scSKill.targetCircle.enabled = true;
				scSKill.indicatorRangeCircle.enabled = true;
				scSKill.ABCImage.enabled = false;
				//범위 표시기 크기 지정 
				float maxDistacne = scSKill.maxActiveSkillDistance * 2f;
				//스킬 범위 크기 지정
				float targetSize = scSKill.targetCircleSize * 2f;

				scSKill.indicatorRangeCircle.GetComponent<RectTransform>().sizeDelta = new Vector2(maxDistacne, maxDistacne);
				scSKill.targetCircle.GetComponent<RectTransform>().sizeDelta = new Vector2(targetSize, targetSize);

			}
			else if (scSKill.sKillType == SkillTest.SKillType.Arrow)
			{
				scSKill.ABCImage.enabled = true;
				scSKill.targetCircle.enabled = false;
				scSKill.indicatorRangeCircle.enabled = false;
			}
		

		foreach (GameObject btn in BtnSKills) {
			if (btn != Skill )
			{
				btn.GetComponent<SkillTest>().enabled = false;
			}
	
		}

		BtnPrev = Skill;
	}
}
