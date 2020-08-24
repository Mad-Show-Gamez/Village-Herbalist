using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image slotImage;
    InventoryManager manager;
    [NaughtyAttributes.ReadOnly][SerializeField]internal AlchemyItem AI;

    void Start()
    {
        manager = transform.parent.parent.parent.parent.GetComponent<InventoryManager>();
    }

    public void UpdateSlot(AlchemyItem AI = null)
    {
        this.AI = AI;
        if (AI != null)
        {
            slotImage.enabled = true;
            slotImage.sprite = AI.Sprite;
        }
        else
        {
            slotImage.enabled = false;
            slotImage.sprite = null;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        manager.UpdateCurrentSlot(this);   
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        manager.UpdateCurrentSlot(null);
    }
}
