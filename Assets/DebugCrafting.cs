using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCrafting : MonoBehaviour
{
    [SerializeField] List<AlchemyItem> inputItems;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (inputItems.Count > 0)
            {
                AlchemyItem newItem = Recipe.Craft(inputItems);
                Debug.Log(newItem.itemName);
            }
            else Debug.Log("No input items");
        }
    }
}
