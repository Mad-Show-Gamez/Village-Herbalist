using System.Collections.Generic;
using UnityEngine;

public interface IAlchemyTool:IColorProvider
{
    AlchemyItem Resolve();
    void Craft();
    IEnumerable<AlchemyItem> Empty();
    AlchemyData data { get; }


}