using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using UnityEditor.Build.Content;

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

    public static AlchemyItemInstance Craft(IEnumerable<AlchemyItemInstance> inputItems, AlchemyItemInstance RejectItem)
    {
        var satisfy = all.Where(r =>
            r.input.Length == inputItems.Count() &&
            r.input.Intersect(inputItems.Select(i => i.type)).Count() == r.input.Count()
            );
        int count = satisfy.Count();
        if (count > 0)
        {
            var toCraft = satisfy.ElementAt(Random.Range(0, count));
            TagBag b = new TagBag();
            foreach (var input in inputItems)
            {
                b.UnionWith(input.tags);
            }
            b.UnionWith(toCraft.output.Tags);
            return new AlchemyItemInstance() { type = toCraft.output, tags = b };
        }
        return RejectItem;
    }
    [MenuItem("Assets/Create/Alchemy Item/Recipies/Create From...")]
    static void CreateRecipyFrom()
    {
        string path = EditorUtility.OpenFilePanel("Open Result", "Scripptable Objects/Potions", "asset");
        path = path.Substring(path.IndexOf("Assets"));
        CreateRecipyFromSaveAs(Selection.objects, AssetDatabase.LoadAssetAtPath(path, typeof(AlchemyItem)));
    }
    public static void CreateRecipyFrom(IEnumerable<Object> objects, Object result)
    {
        var rname = System.String.Join("_", objects.Select(s => s.name.Replace(" ", "_"))) + "To" + result.name;
        string path = System.IO.Path.Combine("Assets/Scripptable Objects/Recipys", objects.First().name, rname) + ".asset";
        var dp = System.IO.Path.GetDirectoryName(path);
        if (!AssetDatabase.IsValidFolder(dp))
            AssetDatabase.CreateFolder("Assets/Scripptable Objects/Recipys", objects.First().name);

        var r = ScriptableObject.CreateInstance<Recipe>();
        r.input = objects.Select(s => s as AlchemyItem).ToArray();
        r.output = result as AlchemyItem;
        AssetDatabase.CreateAsset(r, path);
    }
    static void CreateRecipyFromSaveAs(IEnumerable<Object> objects, Object result)
    {
        var rname = System.String.Join("_", objects.Select(s => s.name.Replace(" ", "_"))) + "To" + result.name;
        string path = EditorUtility.SaveFilePanelInProject("Save Recipy", rname, "asset", "Save recipy", "Assets/Scripptable Objects/Recipys");
        if (path == "")
        {
            return;
        }
        var r = ScriptableObject.CreateInstance<Recipe>();
        r.input = objects.Select(s => s as AlchemyItem).ToArray();

        r.output = result as AlchemyItem;
        AssetDatabase.CreateAsset(r, path);
    }
}