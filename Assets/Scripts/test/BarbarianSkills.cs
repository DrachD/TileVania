using UnityEngine;

public enum BarbarianSkill
{
    Bash,
    Cleave,
    GroundStomp,
    HammerOfTheAncients,
    IgnorePain,
    Rend,
    None,
}
[CreateAssetMenu]
public class BarbarianSkills : Skill
{
    public BarbarianSkill BarbarianSkill;
    public override BarbarianSkill GetChoicedSkill()
    {
        return BarbarianSkill;
    }
}
