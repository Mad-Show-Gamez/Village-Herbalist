using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AlchemyItem", menuName = "Alchemy Item")]
public class AlchemyItem : ScriptableObject
{
    Sprite sprite;
    string itemName;
    string description;
    Tag[] tags;
}
