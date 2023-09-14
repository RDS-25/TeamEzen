using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SelectCharactorUIManager : MonoBehaviour
{
	AudioSource audio;


	 GameObject curChr = null;


	[SerializeField]
	GameObject CharDetail;
	[SerializeField]
	GameObject CharSelect;
    [SerializeField]
    GameObject gStatDetail;
	[SerializeField]
	GameObject gSkillPanel;
	[SerializeField]
	GameObject gSlotPanel;
	[SerializeField]
	GameObject gExit;

	public int curCharID;

	public SlotManager slotManager;
	public SkillPanelUi skillPanelUi;
	public Transform transformSlots;

	//slot 게임오브젝트 리스트 
	List<GameObject> listSlots = new List<GameObject>();


	//씬매니저
	private void OnEnable()
	{
		SlotManager.OnButtonClick += SelectOne;
	}
	private void OnDisable()
	{
		SlotManager.OnButtonClick -= SelectOne;
	}

    private void Start()
	{
		audio = GetComponent<AudioSource>();

		gSlotPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(800f, 900f);
		gSlotPanel.GetComponentInChildren<GridLayoutGroup>().constraintCount= 3;

		slotManager.SetSlot(GameManager.instance.objectFactory.CharSlotFactory.listPool,
			GameManager.instance.objectFactory.characterFactory.listPool,
			transformSlots,
			SlotManager.OBJECT_TYPE.CHARACTER);
		GetComponent<SlotManager>().SetButtonClickedEvent();
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
	public void SelectOne(int index) {
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
		// 현재 선택된 슬롯 인덱스 값 가져오기
		for (int i = 0; i < GameManager.instance.objectFactory.ownCharFactory.listPool.Count; i++)
		{
			if (index == i)
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
		skillPanelUi.ShowSkill();
	}

	public void BtnPrevChar() {
		GameManager.instance.objectFactory.ownCharFactory.listPool[curCharID].SetActive(false);
		if (curCharID <= 0)
			curCharID = GameManager.instance.objectFactory.ownCharFactory.listPool.Count - 1;
		else
			curCharID--;
		GameManager.instance.objectFactory.ownCharFactory.listPool[curCharID].SetActive(true);
		skillPanelUi.ShowSkill();
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
