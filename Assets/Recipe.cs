using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : ScriptableObject
{
    public static HashSet<Recipe> all = new HashSet<Recipe>();
    AlchemyItem output;
    AlchemyItem[] input;
    public void OnDisable()
    {
        Recipe.all.Remove(this);
    }
    public void OnEnable()
    {
        Recipe.all.Add(this);
    }
}
