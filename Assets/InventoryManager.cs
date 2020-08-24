using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject AlchemyPrefab;
    [SerializeField] Inventory inventory;

    public void AddItem(GameObject newItem)
    {
        AlchemyItem alItem = newItem.GetComponent<AlchemyItem>();
        inventory.contents.Add(alItem);
        Destroy(alItem);
    }

    public void GetItem(AlchemyItem newItem)
    {
        inventory.contents.Remove(newItem);
        AlchemyItemMB alMB = Instantiate(AlchemyPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity).GetComponent<AlchemyItemMB>();
        alMB.item.type = newItem;
        alMB.populateGO();
    }
}
