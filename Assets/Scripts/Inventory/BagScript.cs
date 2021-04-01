using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagScript : MonoBehaviour
{
    [SerializeField]
    private GameObject slotPrefab;

    private bool isVisibility;

    public void AddSlots(int countSlots)
    {
        for (int i = 0; i < countSlots; i++)
        {
            Instantiate(slotPrefab, transform);
        }
    }

    public void ChangeOfVisibility()
    {
        isVisibility = isVisibility ? false : true;
        gameObject.SetActive(isVisibility);
    }

    public void RemoveVisibility()
    {
        gameObject.SetActive(isVisibility);
    }
}
