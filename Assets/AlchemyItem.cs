using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AlchemyItem", menuName = "Alchemy Item")]
public class AlchemyItem : ScriptableObject
{
    Sprite sprite;
    string _itemName;
    public string itemName
    {
        get
        {
            var name = this.itemName ?? _itemName;
            _itemName = name;
            return name;
        }
    }
    public string slug { get => itemName.Replace(' ','_'); }
    [SerializeField]
    string description;
    [SerializeField]
    Color color= Color.white;
    [SerializeField]
    Tag[] tags;
}
