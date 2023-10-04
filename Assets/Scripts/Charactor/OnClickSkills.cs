using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class OnClickSkills : MonoBehaviour
{

	public List<GameObject> BtnSKills;

	public void ClickSkills() {
		GameObject Skill = EventSystem.current.currentSelectedGameObject;
		var scSKill = Skill.GetComponent<SkillTest>();


		if (scSKill.sKillType == SkillTest.SKillType.Ranged) {
			
			scSKill.targetCircle.enabled = true;
			scSKill.indicatorRangeCircle.enabled = true;
			//범위 표시기 크기 지정 
			float maxDistacne = scSKill.maxActiveSkillDistance * 2f;
			//스킬 범위 크기 지정
			float targetSize = scSKill.targetCircleSize * 2f;

			scSKill.indicatorRangeCircle.GetComponent<RectTransform>().sizeDelta = new Vector2(maxDistacne, maxDistacne);
			scSKill.targetCircle.GetComponent<RectTransform>().sizeDelta = new Vector2(targetSize, targetSize);

		}else if (scSKill.sKillType == SkillTest.SKillType.Arrow)
		{
			
			scSKill.ABCImage.enabled = true;
		}


		foreach (GameObject btn in BtnSKills) {
			if (btn != Skill )
			{
				btn.GetComponent<SkillTest>().enabled = false;

				if (btn.GetComponent<SkillTest>().sKillType == SkillTest.SKillType.Ranged) {
					btn.GetComponent<SkillTest>().ABCImage.enabled = false;
				}
				else if (btn.GetComponent<SkillTest>().sKillType == SkillTest.SKillType.Arrow)
				{
					btn.GetComponent<SkillTest>().ABCImage.enabled = true;
					btn.GetComponent<SkillTest>().targetCircle.enabled = false;
					btn.GetComponent<SkillTest>().indicatorRangeCircle.enabled = false;
				}
			}
		
		}
	}
}
