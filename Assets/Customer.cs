using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Customer : MonoBehaviour
{
    AlchemyItem requestItem;

    void Start()
    {
        int randomItemIndex = Random.Range(0, Recipe.all.Count);
        requestItem = Recipe.all.ElementAt(randomItemIndex).output;
        Debug.Log(requestItem.itemName);
    }

    public void ReceiveItem(AlchemyItem receivedItem)
    {
        if (requestItem == receivedItem)
        {
            Debug.Log("Received item matched request item");
            Destroy(this);
        }
        else
        {
            Debug.Log("Wrong item was given");
        }
    }
}
