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
	GameObject	gStatDetail;
	[SerializeField]
	GameObject gExit;


	 public List<GameObject> OwnChar;

	 public int curCharID;




	//slot 게임오브젝트 리스트 
	List<GameObject> listSlots = new List<GameObject>();

	Transform transformCharSelect;

	Transform transformSlots;

	//씬매니저

	private void Start()
	{
		audio = GetComponent<AudioSource>();

		OwnChar = CharSelect.GetComponentInChildren<CharactorSelect>().Chacters;

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
		for (int i = 0; i < OwnChar.Count; i++)
		{
			if (name == i.ToString())
			{
				curCharID = i;
				break;
			}
		}
		//현재 누른것만 true 해주고 나머지 false
		for(int i = 0; i < OwnChar.Count; i ++)
		{
			OwnChar[i].SetActive(false);
		}
		OwnChar[curCharID].SetActive(true);

		//	//오브젝트 풀을 보여주기
		//GameObject n = GameManager.instance.stageFactory.characterFactory.listPool[(int)curCharID - 1];
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
		OwnChar[curCharID].SetActive(false);
		if (curCharID >= OwnChar.Count - 1)
			curCharID = 0;
		else
			curCharID++;
		OwnChar[curCharID].SetActive(true);
		
	}

	public void BtnPrevChar() {
		OwnChar[curCharID].SetActive(false);
		if (curCharID <= 0)
			curCharID = OwnChar.Count - 1;
		else
			curCharID--;
		OwnChar[curCharID].SetActive(true);
	}


	public void TestMove() {

		SceneManager.LoadScene("characterMove");
	
	}

	



	




}
