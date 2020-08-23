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
    [SerializeField]
    [NaughtyAttributes.ResizableTextArea]
    string description;
    [SerializeField]
    Color color = Color.white;
    [SerializeField]
    Tag[] tags;
    [SerializeField]
    int value;
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
    public Sprite Sprite { get => sprite; private set => sprite = value; }
    public string Description { get => description; private set => description = value; }
    public Color Color { get => color; private set => color = value; }
    public IEnumerable<Tag> Tags { get => tags; private set => tags = value.ToArray(); }
    public int Value { get => value; private set => this.value = value; }

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
    [MenuItem("Assets/Create/Alchemy Item/Animal/All With Tool")]
    static void createSubAllAnimalWithTool()
    {
        createSubAllWithTool(new string[] { "Heart", "Eye", "Blood", "Brain" });
    }
    [MenuItem("Assets/Create/Alchemy Item/Plant/All With Tool")]
    static void createSubAllPlantWithTool()
    {
        createSubAllWithTool(new string[] { "Leaf", "Flower", "Fruit", "Seed" });
    }
    static void createSubAllWithTool(IEnumerable<string> types) { 
        string path = EditorUtility.OpenFilePanel("Open Tool", "Scripptable Objects/Tools", "asset");
        foreach (var parttype in types)
            foreach (var part in createSubItem(parttype, path))
            {
                Recipe.CreateRecipyFrom(new Object[] { part.Item1, part.Item2 }, part.Item3);
            }
    }
    static IEnumerable<(Object, Object, Object)> createSubItem(string item_type, string tool_path = null)
    {
        List<(Object, Object, Object)> newpaths = new List<(Object, Object, Object)>();
        foreach (var s in Selection.objects)
        {
            var path1 = AssetDatabase.GetAssetPath(s);
            var extention = Path.GetExtension(path1);
            var path2 = path1.Replace(extention, "_" + item_type + extention);
            var fn = Path.GetFileName(path2);
            path2 = path2.Replace(fn, "");
            path2 = Path.Combine(path2, item_type, fn);
            AssetDatabase.CopyAsset(path1, path2);
            if (tool_path == null)
            {
                return newpaths;
            }
            tool_path = tool_path.Substring(tool_path.IndexOf("Assets"));
            var tool = AssetDatabase.LoadAssetAtPath(tool_path, typeof(AlchemyItem));
            var ing = AssetDatabase.LoadAssetAtPath(path1, typeof(AlchemyItem));
            var result = AssetDatabase.LoadAssetAtPath(path2, typeof(AlchemyItem));
            newpaths.Add((tool, ing, result));
        };
        return newpaths;
    }
}
