using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private Transform parent;
    [SerializeField] private Inventory inventory;
    private void OnValidate()
    {
        GetComponent<SpriteRenderer>().sprite = item.Icon;
        GetComponent<BoxCollider2D>().size = new Vector2(.6f, .6f);
        gameObject.name = "PickUpItem " + item.ItemName;
    }
    private void Awake()
    {
        transform.SetParent(parent);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inventory.AddItem(item);
            Destroy(gameObject);
        }
    }
}
