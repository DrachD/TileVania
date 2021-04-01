using UnityEngine;

[CreateAssetMenu]
public abstract class Skill : ScriptableObject
{
    public string SkillName;
    public Sprite Icon;
    public abstract BarbarianSkill GetChoicedSkill();
}
