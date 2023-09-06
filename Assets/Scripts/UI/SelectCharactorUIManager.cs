using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SelectCharactorUIManager : MonoBehaviour
{
	AudioSource audio;


	public GameObject curChr = null;


	[SerializeField]
	GameObject CharDetail;
	[SerializeField]
	GameObject CharSelect;
    [SerializeField]
    GameObject gStatDetail;
	[SerializeField]
	GameObject gSkillPanel;
	[SerializeField]
	GameObject gExit;

	 public int curCharID;




	//slot 게임오브젝트 리스트 
	List<GameObject> listSlots = new List<GameObject>();

	Transform transformCharSelect;

	Transform transformSlots;

	//씬매니저

	private void Start()
	{
		

		audio = GetComponent<AudioSource>();

		//내가 가지고 있는 캐릭터 리스트를 끌어올곳 
	
		/*이전 코드
		GameManager.instance.objectFactory.ownCharFactory.listPool = OwnChar;*/

	



		transformCharSelect = CharSelect.transform; //charSelectPanel

	    transformSlots = transformCharSelect.GetChild(2).GetChild(0);//charSelectPanel/Charactor/CharactorSelect
		/*
		string a = Application.persistentDataPath + "/";
		var data = GameManager.instance.DataRead(a + FileName.STR_JSON_CHARACTER_PARAMS_2);
		Debug.Log(float.Parse(data["fId"]));*/
	}	

	//캐릭서 상세 
	public void ShowDetail()
	{
		CharDetail.SetActive(true);
		gStatDetail.SetActive(false);
	}
	public void ExitDetail() {

		CharDetail.SetActive(false);
	}
	public void SkillPanel()
    {
		gSkillPanel.SetActive(true);
    }


	//누르면 캐릭터 보여주기 
	public void SelectOne() {
		if (curChr != null) {
			curChr.SetActive(false);
		}
		//버튼 누르면 현재 선택된 게임오브젝트정보 가져오기

		//Slot 게임오브젝트 리스트로 가져오기, 이름 바꾸기
		for (int i = 0; i < transformSlots.childCount; i++)
		{
			listSlots.Add(transformSlots.GetChild(i).gameObject);
			listSlots[i].name = i.ToString();
		}

		//슬롯 이름 
		string name = EventSystem.current.currentSelectedGameObject.name;

		// 현재 선택된 슬롯 인덱스 값 가져오기
		for (int i = 0; i < GameManager.instance.objectFactory.ownCharFactory.listPool.Count; i++)
		{
			if (name == i.ToString())
			{
				curCharID = i;
				break;
			}
		}
		//현재 누른것만 true 해주고 나머지 false
		for(int i = 0; i < GameManager.instance.objectFactory.ownCharFactory.listPool.Count; i ++)
		{
			GameManager.instance.objectFactory.ownCharFactory.listPool[i].SetActive(false);
		}
		GameManager.instance.objectFactory.ownCharFactory.listPool[curCharID].SetActive(true);

		//	//오브젝트 풀을 보여주기
		//GameObject n = GameManager.instance.objectFactory.characterFactory.listPool[(int)curCharID - 1];
		//if (curCharID == n.GetComponent<Stat>().fId) {
		//	n.SetActive(true);
		//	curChr = n;
		//}

		
	}

	//캐릭터 스텟상세보기
	public void StatDetail() {
		gStatDetail.SetActive(true);
	}

	public void StatDetailExit() {
		gStatDetail.SetActive(false);
	}

	//캐릭터 셀렉트 음악
	void BackgroundMusic() {
		AudioManager.instance.PlayBackgroundSound(audio, AudioName.STR_CHARACTER_SELECT_1);
	}


	public void BtnNextChar() {
		GameManager.instance.objectFactory.ownCharFactory.listPool[curCharID].SetActive(false);
		if (curCharID >= GameManager.instance.objectFactory.ownCharFactory.listPool.Count - 1)
			curCharID = 0;
		else
			curCharID++;
		GameManager.instance.objectFactory.ownCharFactory.listPool[curCharID].SetActive(true);
		
	}

	public void BtnPrevChar() {
		GameManager.instance.objectFactory.ownCharFactory.listPool[curCharID].SetActive(false);
		if (curCharID <= 0)
			curCharID = GameManager.instance.objectFactory.ownCharFactory.listPool.Count - 1;
		else
			curCharID--;
		GameManager.instance.objectFactory.ownCharFactory.listPool[curCharID].SetActive(true);
	}

	public void BtnSelectCharExit() {
		CharSelect.SetActive(false);
	}



	public void TestMove() {

		SceneManager.LoadScene("characterMove");
		for (int i = 0; i < GameManager.instance.objectFactory.ownCharFactory.listPool.Count; i++) {
			GameManager.instance.objectFactory.ownCharFactory.listPool[i].GetComponent<Action>().isEntries = true;
		}
	
	}

	



	




}
