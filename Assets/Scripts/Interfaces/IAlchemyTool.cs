using System.Collections.Generic;
using UnityEngine;

public interface IAlchemyTool:IColorProvider
{
    AlchemyItem ToolType { get; }
    AlchemyItem Resolve();
    void Craft();
    IEnumerable<AlchemyItem> Empty();

    IEnumerable<AlchemyItem> items { get; }
    void add(AlchemyItem alchemyItem);
    TransformEvent OnCrafted { get; }
    TransformEvent OnStartCraft { get; }


}