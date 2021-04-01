using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bag", menuName = "Inventory/Bag", order = 1)]
public class Bag : ScriptableObject
{
    [SerializeField] private GameObject bagPrefab;

    [SerializeField] private Sprite iconBag;

    public GameObject BagPrefab { get => bagPrefab; }
    public Sprite IconBag { get => iconBag; }
}