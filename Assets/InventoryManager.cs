using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{
    int DefaultSlotCount = 9;
    [SerializeField] GameObject onClick;
    [SerializeField] GameObject GridLayoutGO;
    [SerializeField] GameObject ItemBox;
    [SerializeField] GameObject AlchemyPrefab;
    [SerializeField] Inventory inventory;
    [SerializeField] ItemSlot[] itemSlots;
    [SerializeField] ItemSlot CurrentSlot;
    GameObject selectedObject;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CurrentSlot != null && CurrentSlot.AI != null)
            {
                GetItem(CurrentSlot.AI);
                UpdateCurrentSlot(CurrentSlot);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (selectedObject != null && CurrentSlot != null && CurrentSlot.AI == null) AddItem(selectedObject);
        }

        if (onClick.transform.childCount > 0) selectedObject = onClick.transform.GetChild(0).gameObject;
        else selectedObject = null;
    }

    void Start()
    {
        itemSlots = new ItemSlot[DefaultSlotCount];

        for (int i = 0; i < DefaultSlotCount; i++)
        {
            Debug.Log(i);
            GameObject newSlot = Instantiate(ItemBox, Vector3.zero, Quaternion.identity);
            newSlot.transform.SetParent(GridLayoutGO.transform);
            newSlot.transform.localScale = Vector3.one;
            itemSlots[i] = newSlot.GetComponent<ItemSlot>();
            if (i < inventory.contents.Count) itemSlots[i].UpdateSlot(inventory.contents[i]);
            else itemSlots[i].UpdateSlot();
        }
    }

    public void UpdateCurrentSlot(ItemSlot slot)
    {
        CurrentSlot = slot;
    }

    public void AddItem(GameObject newItem)
    {
        CurrentSlot.UpdateSlot(newItem.GetComponent<AlchemyItemMB>().item.type);
        Destroy(newItem);
    }

    public void GetItem(AlchemyItem newItem)
    {
        AlchemyItemMB alMB = Instantiate(AlchemyPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward, Quaternion.identity).GetComponent<AlchemyItemMB>();
        alMB.item.type = newItem;
        alMB.populateGO();
        CurrentSlot.UpdateSlot();
    }
}
