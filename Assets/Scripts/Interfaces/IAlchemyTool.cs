﻿using System.Collections.Generic;
using UnityEngine;

public interface IAlchemyTool:IColorProvider
{
    AlchemyItemInstance Resolve();
    void Craft();
    IEnumerable<AlchemyItemInstance> Empty();
    AlchemyData data { get; }


}