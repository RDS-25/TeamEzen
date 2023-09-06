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




	//slot ���ӿ�����Ʈ ����Ʈ 
	List<GameObject> listSlots = new List<GameObject>();

	Transform transformCharSelect;

	Transform transformSlots;

	//���Ŵ���

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

	//ĳ���� �� 
	public void ShowDetail()
	{
		CharDetail.SetActive(true);
		gStatDetail.SetActive(false);
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

		//���� �̸� 
		string name = EventSystem.current.currentSelectedGameObject.name;

		// ���� ���õ� ���� �ε��� �� ��������
		for (int i = 0; i < OwnChar.Count; i++)
		{
			if (name == i.ToString())
			{
				curCharID = i;
				break;
			}
		}
		//���� �����͸� true ���ְ� ������ false
		for(int i = 0; i < OwnChar.Count; i ++)
		{
			OwnChar[i].SetActive(false);
		}
		OwnChar[curCharID].SetActive(true);

		//	//������Ʈ Ǯ�� �����ֱ�
		//GameObject n = GameManager.instance.stageFactory.characterFactory.listPool[(int)curCharID - 1];
		//if (curCharID == n.GetComponent<Stat>().fId) {
		//	n.SetActive(true);
		//	curChr = n;
		//}

		
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
