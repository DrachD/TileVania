using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    [SerializeField] private GameObject characterPanel;
    [SerializeField] private Bag bagData;
    [SerializeField] private List<Button_Bag> buttons;

    private BagScript bagScript;

    int currentButton = 0;
    private void Awake()
    {
        if (bagScript == null)
        {
            bagScript = Instantiate(bagData.BagPrefab, transform).GetComponent<BagScript>();
            bagScript.AddSlots(16);
            bagScript.RemoveVisibility();
        }

        isActiveCharPanel = false;
        characterPanel.gameObject.SetActive(isActiveCharPanel);
    }

    void Update()
    {
        HandleInput();

        //if (Input.GetKeyDown(KeyCode.J) && currentButton < buttons.Count)
        //{
        //    buttons[currentButton].SetVisibilityBag();
        //    bagScript = Instantiate(bagData.BagPrefab, transform).GetComponent<BagScript>();
        //    bagScript.AddSlots(16);
        //    currentButton++;
        //}
    }

    private bool isActiveCharPanel;

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            buttons[0].ChangeOfVisibility();
            bagScript.ChangeOfVisibility();
            characterPanel.gameObject.SetActive(ChangeActiveInventory());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            buttons[1].ChangeOfVisibility();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            buttons[2].ChangeOfVisibility();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            buttons[3].ChangeOfVisibility();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            buttons[4].ChangeOfVisibility();
        }
    }

    private bool ChangeActiveInventory()
    {
        return isActiveCharPanel ? isActiveCharPanel = false : isActiveCharPanel = true;
    }
}
