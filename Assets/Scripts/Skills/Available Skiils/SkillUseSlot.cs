using UnityEngine;

public class SkillUseSlot : AvailableSkillSlot
{
    public bool CanReceiveItem(Skill skill)
    {
        if (Skill == null )
            return true;
        return false;
    }
}
