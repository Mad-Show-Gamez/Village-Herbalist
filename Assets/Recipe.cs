using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "new Recipe", menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    public static HashSet<Recipe> all = new HashSet<Recipe>();
    public AlchemyItem output;
    public AlchemyItem[] input;
    public void OnDisable()
    {
        all.Remove(this);
    }

    public void OnEnable()
    {
        all.Add(this);
    }

    public static AlchemyItem Craft(List<AlchemyItem> inputItems)
    {
        AlchemyItem outputItem = null;

        foreach (Recipe recipe in all)
        {
            if (recipe.input.Length == inputItems.Count)
            {
                if (recipe.input.Intersect(inputItems).Count() == recipe.input.Count())
                {
                    return recipe.output;
                }
            }

        }

        return outputItem;
    }
}