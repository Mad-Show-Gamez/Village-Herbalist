using Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Cauldren : MonoBehaviour, IAlchemyTool
{
    [SerializeField]
    AlchemyData tool;
    [SerializeField, NaughtyAttributes.ReadOnly]
    bool lit;
    bool isLit { get => lit; }

    public AlchemyData data => tool;

    public Color CurrentColor => tool.CurrentColor;

    [SerializeField]
    float cooktime;
    private void Awake()
    {
        tool.CurrentColor = tool.ToolType.Color;
    }

    public void add(AlchemyItem alchemyItem)
    {
        tool.Add(alchemyItem);
    }
    [NaughtyAttributes.Button("light", NaughtyAttributes.EButtonEnableMode.Playmode)]
    public void Craft()
    {
        if (!lit && tool.Any())
        {
            StartCoroutine(LightCauldren());
            StartCoroutine(LerpColorsOverTime(tool.CurrentColor, Resolve().Color, cooktime, c => tool.CurrentColor = c));
        }
    }
    [NaughtyAttributes.Button("empty", NaughtyAttributes.EButtonEnableMode.Playmode)]
    public IEnumerable<AlchemyItemInstance> Empty()
    {
        if (!lit)
        {
            var rval = tool.ToArray();
            tool.Clear();
            tool.CurrentColor = tool.ToolType.Color;
            return rval;
        }
        return new AlchemyItemInstance[0];
    }

    public AlchemyItemInstance Resolve()
    {
        return Recipe.Craft(tool.Append(tool.ToolType), tool.rejectItem);
    }

    private IEnumerator LerpColorsOverTime(Color startingColor, Color endingColor, float time, Action<Color> cb)
    {
        float inversedTime = 1 / time; // Compute this value **once**
        for (var step = 0.0f; step < 1.0f; step += Time.deltaTime * inversedTime)
        {
            cb.Invoke(Color.Lerp(startingColor, endingColor, step));
            yield return null;
        }
    }
    IEnumerator LightCauldren()
    {
        lit = true;
        tool.OnStartCraft.Invoke(transform);
        yield return new WaitForSeconds(cooktime);
        lit = false;

        var result = Resolve();
        tool.Clear();
        tool.Add(result);

        tool.OnCrafted.Invoke(transform);
    }
    private void Update()
    {
        if (!lit && tool.Any())
            tool.CurrentColor = Color.Lerp(tool.CurrentColor, tool.Select(i => i.Color).avrageColor(), Time.deltaTime);
    }
}
