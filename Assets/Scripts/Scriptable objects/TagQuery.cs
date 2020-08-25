using NaughtyAttributes;
using System;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TagQuery
{
    [SerializeField]
    Tag tag;
    [SerializeField]
    oporator _oporator = oporator.equels;
    [SerializeField]
    bool invert;
    static Dictionary<oporator, Func<float, float, bool>> oporations = new Dictionary<oporator, Func<float, float, bool>>()
    {
        { oporator.equels, (a,b)=>a==b },
        { oporator.greaterthan, (a,b)=>a>b },
        { oporator.lessthan, (a,b)=>a<b }
    };
    [SerializeField]
    float value;
    public bool ResolveQuery(TagBag tags)
    {
        var B = oporations[_oporator].Invoke(tags.GetAmount(tag), value);
        return !invert && B || invert && !B;
    }
}
public enum oporator
{
    greaterthan, lessthan, equels
}