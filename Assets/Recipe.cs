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

    public static AlchemyItem Craft(IEnumerable<AlchemyItem> inputItems, AlchemyItem RejectItem=null)
    {
        var satisfy = all.Where(r =>
            r.input.Length == inputItems.Count() &&
            r.input.Intersect(inputItems).Count() == r.input.Count()
            );
        int count = satisfy.Count();
        return count > 0 ? satisfy.ElementAt(Random.Range(0, count)).output : RejectItem;

    }
}