using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Knife : MonoBehaviour, IAlchemyTool
{
    [SerializeField]
    AlchemyData tool;
    public AlchemyData data => tool;
    public Color CurrentColor => tool.CurrentColor;

    public void Craft()
    {
        Debug.Log("Called");
        Debug.Log(tool.ToArray().Count());
        Debug.Log(Resolve().type.itemName);
        Empty();
    }

    public AlchemyItemInstance Resolve()
    {
        return Recipe.Craft(tool.Append(tool.ToolType), tool.rejectItem);
    }

    public IEnumerable<AlchemyItemInstance> Empty()
    {
        tool.Clear();
        return new AlchemyItemInstance[0];
    }
}
