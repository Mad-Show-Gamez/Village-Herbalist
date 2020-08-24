using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

public class Knife : MonoBehaviour, IAlchemyTool
{
    [SerializeField]
    AlchemyData tool;
    public AlchemyData data => tool;
    public Color CurrentColor => tool.CurrentColor;
    [SerializeField]
    GameObject AlchemyItemPrefab;
    [SerializeField]
    SpriteRenderer choppingRepr;
    public void Craft()
    {
        if (!tool.Any())
            return;
        var rval = Resolve();
        tool.Clear();
        int d = 0;
        foreach (var item in rval)
        {
            var ai = Instantiate(AlchemyItemPrefab, transform);
            var i = ai.GetComponent<AlchemyItemMB>();
                i.item = item;
            ai.transform.parent = null;
            ai.transform.position += Vector3.right * d++*0.1f;
            i.populateGO();
        }
        choppingRepr.sprite = null;
    }

    public IEnumerable<AlchemyItemInstance> Resolve()
    {
        return Recipe.Craft(tool.Append(tool.ToolType), tool.rejectItem);
    }
    public void Drop()
    {
        int d = 0;
        foreach (var item in tool)
        {
            var ai = Instantiate(AlchemyItemPrefab, transform);
            var i = ai.GetComponent<AlchemyItemMB>();
            i.item = item;
            ai.transform.parent = null;
            ai.transform.position += Vector3.right * d++ * 0.1f;
            i.populateGO();
        }
        tool.Clear();
        choppingRepr.sprite = null;

    }

    public IEnumerable<AlchemyItemInstance> Empty()
    {
        var rval = tool.ToArray();
        tool.Clear();
        return rval;
    }
    private void Update()
    {
        if (tool.Any())
            choppingRepr.sprite = tool.First().type.Sprite;
    }
}
