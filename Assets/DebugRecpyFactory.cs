using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu]
public class DebugRecpyFactory : ScriptableObject
{
    [SerializeField]
    int ingredent_count;
    [SerializeField]
    AlchemyItem[] ingredents;
    [SerializeField]
    AlchemyItem[] outputs;
    [SerializeField]
    AlchemyItem tool;

    [NaughtyAttributes.Button("create random Recipy")]
    private void gen()
    {
        AlchemyItem[] ingredents = new AlchemyItem[ingredent_count+1];
        for (int i = 0; i < ingredent_count; i++)
            ingredents[i] = this.ingredents[Random.Range(0, this.ingredents.Length-1)];
        AlchemyItem output = outputs[Random.Range(0, outputs.Length-1)];
        ingredents[ingredent_count] = tool;
        var rname = System.String.Join("_", ingredents.Select(s => s.name.Replace(" ", "_"))) + "To" + output.name;
        string path = System.IO.Path.Combine("Assets/Scripptable Objects/Recipys", tool.name, rname) + ".asset";
        var dp = System.IO.Path.GetDirectoryName(path);
        if (!AssetDatabase.IsValidFolder(dp))
            AssetDatabase.CreateFolder("Assets/Scripptable Objects/Recipys", tool.name);

        var r = ScriptableObject.CreateInstance<Recipe>();
        r.input = ingredents.ToArray();
        r.output = output;
        AssetDatabase.CreateAsset(r, path);
    }

}
