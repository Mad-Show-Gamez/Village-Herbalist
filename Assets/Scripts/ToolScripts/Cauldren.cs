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
    AlchemyItem toolType;
    [SerializeField]
    AlchemyItem rejectItem;
    [SerializeField]
    List<AlchemyItem> currentIngredents;
    [NaughtyAttributes.ReadOnly]
    public bool lit;
    [NaughtyAttributes.ReadOnly]
    Color currentColor;
    [SerializeField]
    TransformEvent onCrafted;
    [SerializeField]
    TransformEvent onLit;
    [SerializeField]
    float cooktime;
    private void Awake()
    {
        currentColor = toolType.Color;
    }
    public AlchemyItem ToolType => toolType;

    public IEnumerable<AlchemyItem> items => currentIngredents;

    public TransformEvent OnCrafted => onCrafted;

    public TransformEvent OnStartCraft => onLit;

    public Color CurrentColor => currentColor;

    public void add(AlchemyItem alchemyItem)
    {
        currentIngredents.Add(alchemyItem);
    }
    [NaughtyAttributes.Button("light", NaughtyAttributes.EButtonEnableMode.Playmode)]
    public void Craft()
    {
        if (!lit && currentIngredents.Any())
        {
            StartCoroutine(LightCauldren());
            StartCoroutine(LerpColorsOverTime(currentColor, Resolve().Color, cooktime, c => currentColor = c));
        }
    }
    [NaughtyAttributes.Button("empty", NaughtyAttributes.EButtonEnableMode.Playmode)]
    public IEnumerable<AlchemyItem> Empty()
    {
        if (!lit)
        {
            var rval = currentIngredents.ToArray();
            currentIngredents.Clear();
            currentColor = toolType.Color;
            return rval;
        }
        return new AlchemyItem[0];
    }

    public AlchemyItem Resolve()
    {
        return Recipe.Craft(currentIngredents.Append(toolType), rejectItem);
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
        onLit.Invoke(transform);
        yield return new WaitForSeconds(cooktime);
        lit = false;

        var result = Resolve();
        currentIngredents.Clear();
        currentIngredents.Add(result);

        onCrafted.Invoke(transform);
    }
    private void Update()
    {
        if (!lit && currentIngredents.Any())
            currentColor = Color.Lerp(currentColor, currentIngredents.Select(i => i.Color).avrageColor(), Time.deltaTime);
    }
}
