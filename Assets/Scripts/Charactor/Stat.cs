using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Params;

public class Stat : StatParams
{ 
    public CharacterData stat;

    //장비 오브젝트 정보 넣기 스크립터블 오브젝트로
   
	// 기능들구현  공격 
	private string _sFolderPath;
    private string _sFileName;


	private void OnDisable()
	{
        if (fId != 0) {
            Debug.Log("이미 정보 들어감");
            return;
        }
        _sFolderPath = FolderPath.PARAMS_CHARACTER;
        _sFileName = gameObject.name;
        Init();
        // SpriteRenderer 컴포넌트 가져오기
        
    }


    void Init()
	{
        if(GameManager.instance.CheckExist(_sFolderPath, _sFileName))
        {
            //있으면 그냥 읽기
            //JSON->Stat 스크립트
            ReadParams();
		}
		else
		{
            //없으면 쓰고  스크립터블 - > JSON
            WriteParams();

            //다시 읽기   JSON -> Stat 스크립트 
            ReadParams();
        }
	}

    void PlusStat() { 
        //fatk + 장비스텟.text;
    }

    void enterstage() {
       // fatk + 장비스텟 더해서 스테이지로 전달
       // 끝나면 JSon다시 불러오기
    }

   
    void ReadParams()
    {
        Dictionary<string, string> dictTemp = GameManager.instance.DataRead(_sFolderPath + _sFileName);
       // Debug.Log(dictTemp[CharPath.IMAGE]);

        fId = float.Parse(dictTemp[CharPath.ID]);
        sImagepath = dictTemp[CharPath.IMAGE];
        strName = dictTemp[CharPath.NAME];
        fLevel = float.Parse(dictTemp[CharPath.LEVEL]);
        fHealth = float.Parse(dictTemp[CharPath.HEALTH]);
        fAtk = float.Parse(dictTemp[CharPath.ATK]);
        fDef = float.Parse(dictTemp[CharPath.DEF]);
        fCriticalPer = float.Parse(dictTemp[CharPath.CRITIPER]);
        fCriticalDmg = float.Parse(dictTemp[CharPath.CRITIDMG]);
        fMiss = float.Parse(dictTemp[CharPath.MISS]);
        fMoveSpeed = float.Parse(dictTemp[CharPath.MOVESPEED]);
        fAtkSpeed = float.Parse(dictTemp[CharPath.ATKSPEED]);
        fCoolDownReduction = float.Parse(dictTemp[CharPath.COOLDOWNREDUCTION]);
        fExp = float.Parse(dictTemp[CharPath.EXP]);
        fDefBreak = float.Parse(dictTemp[CharPath.DEFBREAK]);
        fCriticalResist = float.Parse(dictTemp[CharPath.CRITICALRESIST]);
        fDamageReduction = float.Parse(dictTemp[CharPath.DAMAGEREDUCTION]);
        fHealthSteel = float.Parse(dictTemp[CharPath.HEALTHSTEEL]);
        fIBD = float.Parse(dictTemp[CharPath.IBD]);
        fHRR = float.Parse(dictTemp[CharPath.HRR]);
        fRecoveryRate = float.Parse(dictTemp[CharPath.RECOVERYRATE]);
        fSightRange = float.Parse(dictTemp[CharPath.SIGHTRANGE]);
        fDefaultRange = float.Parse(dictTemp[CharPath.DEFAULTRANGE]);
        fProperty = float.Parse(dictTemp[CharPath.PROPERTY]);
        strDescription = dictTemp[CharPath.DESCRIPTION];
        fType = float.Parse(dictTemp[CharPath.TYPE]);
        fUltimateGauge = float.Parse(dictTemp[CharPath.UITIMATEGAUGE]);
        bIsOwn = bool.Parse(dictTemp[CharPath.ISOWN]);
    }
    /*private Image LoadAndSetSprite(string imagePath)
    {
        // Resources 폴더 내에 이미지 파일이 있어야 합니다.
        Image loadedSprite = Resources.Load<Image>(imagePath);

        if (loadedSprite != null)
        {
            // SpriteRenderer에 Sprite 설정
          
            return loadedSprite;
        }
        else
        {
            Debug.LogError("Sprite를 찾을 수 없습니다: " + imagePath);
            return null;
        }
    }*/

    void WriteParams() {
        Dictionary<string, string> dicTemp = new();
        dicTemp.Add(CharPath.ID, stat.fId.ToString());
        dicTemp.Add(CharPath.IMAGE, stat.sImage);
        dicTemp.Add(CharPath.NAME, stat.name);
        dicTemp.Add(CharPath.LEVEL, stat.fLevel.ToString());
        dicTemp.Add(CharPath.HEALTH, stat.fHealth.ToString());
        dicTemp.Add(CharPath.ATK, stat.fAtk.ToString());
        dicTemp.Add(CharPath.DEF, stat.fDef.ToString());
        dicTemp.Add(CharPath.CRITIPER, stat.fCriticalPer.ToString());
        dicTemp.Add(CharPath.CRITIDMG, stat.fCriticalDmg.ToString());
        dicTemp.Add(CharPath.MISS, stat.fMiss.ToString());
        dicTemp.Add(CharPath.MOVESPEED, stat.fMoveSpeed.ToString());
        dicTemp.Add(CharPath.ATKSPEED, stat.fAtkSpeed.ToString());
        dicTemp.Add(CharPath.COOLDOWNREDUCTION, stat.fCoolDownReduction.ToString());
        dicTemp.Add(CharPath.EXP, stat.fExp.ToString());
        dicTemp.Add(CharPath.DEFBREAK, stat.fDefBreak.ToString());
        dicTemp.Add(CharPath.CRITICALRESIST, stat.fCriticalResist.ToString());
        dicTemp.Add(CharPath.DAMAGEREDUCTION, stat.fDamageReduction.ToString());
        dicTemp.Add(CharPath.HEALTHSTEEL, stat.fHealthSteel.ToString());
        dicTemp.Add(CharPath.IBD, stat.fIBD.ToString());
        dicTemp.Add(CharPath.HRR, stat.fHRR.ToString());
        dicTemp.Add(CharPath.RECOVERYRATE, stat.fRecoveryRate.ToString());
        dicTemp.Add(CharPath.SIGHTRANGE, stat.fSightRange.ToString());
        dicTemp.Add(CharPath.DEFAULTRANGE, stat.fDefaultRange.ToString());
        dicTemp.Add(CharPath.PROPERTY, stat.fProperty.ToString());
        dicTemp.Add(CharPath.DESCRIPTION, stat.strDescription);
        dicTemp.Add(CharPath.TYPE, stat.fType.ToString());
        dicTemp.Add(CharPath.UITIMATEGAUGE, stat.fUltimateGauge.ToString());
        dicTemp.Add(CharPath.ISOWN, stat.bIsOwn.ToString());

        //스킬 JSON 1,2,3,4 넣기



    


        GameManager.instance.DataWrite(_sFolderPath + _sFileName, dicTemp);
    }

 
}
