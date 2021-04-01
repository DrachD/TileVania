using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Bag : MonoBehaviour
{
    [SerializeField] private Sprite openBag;
    [SerializeField] private Sprite closeBag;

    private Image bagImage;

    public bool isVisibility;

    private void Start()
    {
        bagImage = GetComponent<Image>();

        RemoveVisibilityBag();
    }

    public void ChangeOfVisibility()
    {
        isVisibility = isVisibility ? false : true;
        bagImage.sprite = isVisibility ? openBag : closeBag;
    }

    public void SetVisibilityBag()
    {
        isVisibility = true;
        bagImage.sprite = openBag;
    }

    public void RemoveVisibilityBag()
    {
        isVisibility = false;
        bagImage.sprite = closeBag;
    }
}
