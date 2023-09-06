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
	GameObject gSlotPanel;
	[SerializeField]
	GameObject gExit;

	public int curCharID;

	public Transform SlotsInViewport;
	public Button[] SlotButtons;
	int nButtonNum;


	//slot ���ӿ�����Ʈ ����Ʈ 
	List<GameObject> listSlots = new List<GameObject>();

	Transform transformCharSelect;

	Transform transformSlots;

	//���Ŵ���

	private void Start()
	{
		audio = GetComponent<AudioSource>();

		gSlotPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(800f, 900f);
		SlotButtons = SlotsInViewport.GetComponentsInChildren<Button>();
		for (int i = 0; i < SlotButtons.Length; i++)
		{
			int buttonIndex = i;
			SlotButtons[i].onClick.AddListener(() => OnClickButton(buttonIndex));
		}


		transformCharSelect = CharSelect.transform; //charSelectPanel

	    transformSlots = transformCharSelect.GetChild(2).GetChild(0);//charSelectPanel/Charactor/CharactorSelect
		/*
		string a = Application.persistentDataPath + "/";
		var data = GameManager.instance.DataRead(a + FileName.STR_JSON_CHARACTER_PARAMS_2);
		Debug.Log(float.Parse(data["fId"]));*/
	}	

	//ĳ���� �� 
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


	//������ ĳ���� �����ֱ� 
	public void SelectOne() {
		if (curChr != null) {
			curChr.SetActive(false);
		}
		//��ư ������ ���� ���õ� ���ӿ�����Ʈ���� ��������

		//Slot ���ӿ�����Ʈ ����Ʈ�� ��������, �̸� �ٲٱ�
		for (int i = 0; i < transformSlots.childCount; i++)
		{
			listSlots.Add(transformSlots.GetChild(i).gameObject);
			listSlots[i].name = i.ToString();
		}
		// ���� ���õ� ���� �ε��� �� ��������
		for (int i = 0; i < GameManager.instance.objectFactory.ownCharFactory.listPool.Count; i++)
		{
			if (nButtonNum == i)
			{
				curCharID = i;
				break;
			}
		}
		//���� �����͸� true ���ְ� ������ false
		for(int i = 0; i < GameManager.instance.objectFactory.ownCharFactory.listPool.Count; i ++)
		{
			GameManager.instance.objectFactory.ownCharFactory.listPool[i].SetActive(false);
		}
		GameManager.instance.objectFactory.ownCharFactory.listPool[curCharID].SetActive(true);
	}

	//ĳ���� ���ݻ󼼺���
	public void StatDetail() {
		gStatDetail.SetActive(true);
	}

	public void StatDetailExit() {
		gStatDetail.SetActive(false);
	}

	//ĳ���� ����Ʈ ����
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

	void OnClickButton(int index)
	{
		nButtonNum = index;
		SelectOne();
		Debug.Log(nButtonNum);
	}
}
