using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using UnityEditor.Build.Content;

[CreateAssetMenu(fileName = "new Recipe", menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    private static HashSet<Recipe> _all = new HashSet<Recipe>();
    public static HashSet<Recipe> all { get { _all.Remove(null); return _all; } }
    public AlchemyItem output;
    public AlchemyItem[] input;
    public void OnDisable()
    {
        all.Remove(this);
    }
    private void OnDestroy()
    {
        all.Remove(this);
    }

    public void OnEnable()
    {
        all.Add(this);
    }

    public static AlchemyItemInstance[] Craft(IEnumerable<AlchemyItemInstance> inputItems, AlchemyItemInstance RejectItem)
    {

        foreach (var s in all.Where(x => x.output == null).ToArray())
            _all.Remove(s);
        var satisfy = all.Where(r =>
            r.input.Length == inputItems.Count() &&
            r.input.Intersect(inputItems.Select(i => i.type)).Count() == r.input.Count()
            );
        int count = satisfy.Count();
        if (count > 0)
        {
            var complexity = satisfy.Max(i => i.input.Length);

            TagBag b = new TagBag();
            foreach (var input in inputItems)
            {
                b.UnionWith(input.tags);
                b.UnionWith(input.type.Tags);
            }
            foreach (var s in satisfy.Where(x => x.output == null))
                Debug.LogError(s, s);
            return satisfy.Where(i => i.input.Length == complexity).Select(i => new AlchemyItemInstance() { type = i.output, tags = b }).ToArray();
        }
        return new AlchemyItemInstance[] { RejectItem };
    }
    [MenuItem("Assets/Create/Alchemy Item/Recipies/Create From...", priority = 0)]
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