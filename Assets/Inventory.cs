using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<AlchemyItem> inventory;

    void Start()
    {
        inventory = new List<AlchemyItem>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Inventory Items: ");
            for (int i = 0; i < inventory.Count; i++)
                Debug.Log(inventory[i].itemName);
            Debug.Log("-------------------");
        }
    }
}
