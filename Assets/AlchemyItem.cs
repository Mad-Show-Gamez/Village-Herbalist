using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("alchemy/Item")]
public class AlchemyItem : ScriptableObject
{
    Sprite sprite;
    string itemName;
    Color color;
    string description;
    Tag[] tags;
}
