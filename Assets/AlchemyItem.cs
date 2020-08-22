using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;
using System.IO;

[CreateAssetMenu(fileName = "New AlchemyItem", menuName = "Alchemy Item")]
public class AlchemyItem : ScriptableObject
{
    [SerializeField]
    Sprite sprite;
    string _itemName;
    public string itemName
    {
        get
        {
            var name = this.name ?? _itemName;
            _itemName = name;
            return name;
        }
    }
    public string slug { get => itemName.Replace(' ', '_'); }
    [SerializeField]
    [NaughtyAttributes.ResizableTextArea]
    string description;
    [SerializeField]
    Color color = Color.white;
    [SerializeField]
    Tag[] tags;
  

    [MenuItem("Assets/Create/Alchemy Item/Plant/Leaf")]
    static void createSubLeaf()
    {
        createSubItem("Leaf");
    }
    [MenuItem("Assets/Create/Alchemy Item/Plant/Flower")]
    static void createSubFlower()
    {
        createSubItem("Flower");
    }
    [MenuItem("Assets/Create/Alchemy Item/Plant/Fruit")]
    static void createSubFruit()
    {
        createSubItem("Fruit");
    }
    [MenuItem("Assets/Create/Alchemy Item/Plant/Seed")]
    static void createSubSeed()
    {
        createSubItem("Seed");
    }
    [MenuItem("Assets/Create/Alchemy Item/Plant/All")]
    static void createSubAllPlant()
    {
        createSubItem("Leaf");
        createSubItem("Flower");
        createSubItem("Fruit");
        createSubItem("Seed");
    }
    [MenuItem("Assets/Create/Alchemy Item/Animal/Heart")]
    static void createSubHeart()
    {
        createSubItem("Heart");
    }
    [MenuItem("Assets/Create/Alchemy Item/Animal/Eye")]
    static void createSubEye()
    {
        createSubItem("Eye");
    }
    [MenuItem("Assets/Create/Alchemy Item/Animal/Blood")]
    static void createSubBlood()
    {
        createSubItem("Blood");
    }
    [MenuItem("Assets/Create/Alchemy Item/Animal/Brain")]
    static void createSubBrain()
    {
        createSubItem("Seed");
    }
    [MenuItem("Assets/Create/Alchemy Item/Animal/All")]
    static void createSubAllAnimal()
    {
        createSubItem("Heart");
        createSubItem("Eye");
        createSubItem("Blood");
        createSubItem("Brain");
    }
    static void createSubItem(string item_type)
    {
        foreach (var s in Selection.objects)
        {
            var path1 = AssetDatabase.GetAssetPath(s);
            var extention = Path.GetExtension(path1);
            var path2 = path1.Replace(extention, "_" + item_type + extention);
            AssetDatabase.CopyAsset(path1, path2);
        };
    }
}
