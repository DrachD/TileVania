using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace MySkillSlot
{
    public class SkillSlot : MonoBehaviour
    {
        [SerializeField] Image image;
        [SerializeField] private Sprite Icon;
        [Space]
        private Skill _skill;
        public Skill Skill
        {
            get => _skill;
            set {
                _skill = value;
                if (_skill != null)
                {
                    image.sprite = _skill.Icon;
                }
                else
                    image.sprite = Icon;
            }
        }
        private void OnValidate()
        {
            if (image == null)
                image = GetComponent<Image>();
        }

    }

}
