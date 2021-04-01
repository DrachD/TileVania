using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using CharacterStats;

public class StatDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private CharacterStat _stat;
    public CharacterStat Stat { 
        get => _stat; 
        set {
            _stat = value;
            UpdateStatValue();
        }
    }
    private string _name;
    public string Name { 
        get => _name; 
        set {
            _name = value;
            nameText.name = _name.ToLower();
        }
    }
    [SerializeField] Text nameText;
    [SerializeField] Text valueText;
    [SerializeField] StatTooltip tooltip;

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.ShowTooltip(Stat, Name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideTooltip();
    }

    private void OnValidate()
    {
        Text[] texts = GetComponentsInChildren<Text>();
        nameText = texts[0];
        valueText = texts[1];

        if (tooltip == null)
            tooltip = FindObjectOfType<StatTooltip>();
    }
    public void UpdateStatValue()
    {
        valueText.text = _stat.Value.ToString();
    }
}
