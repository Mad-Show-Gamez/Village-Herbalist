using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class AlchemyItemInstance
{
    [SerializeField]
    public AlchemyItem type;
    [SerializeField]
    public TagBag tags;

    public Color Color { get=>type.Color; }
}