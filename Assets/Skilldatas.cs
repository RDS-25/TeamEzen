using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SkillParameter;

[CreateAssetMenu(fileName ="Skilldata_",menuName = "Skill / Skilldata")]
public class Skilldatas : ScriptableObject
{
    public List<SkillParameter.SkilParams> Skills;
}
