using Extensions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ContainerCollect : MonoBehaviour, IColorProvider
{
    [SerializeField]
    int capacity = 1;
    [SerializeField]
    AlchemyItem[] content;
    Color currentColor = new Color(0, 0, 0, 0);

    public Color CurrentColor => currentColor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var tool = collision.GetComponent<IAlchemyTool>();
        if (tool!=null)
        {
            if (tool.items.Count() <= capacity)
            {
                content = tool.Empty().ToArray();
                currentColor = content.Select(i => i.Color).avrageColor();
            }
        }
    }
    private void OnValidate()
    {

        currentColor = content.Where(i=>i!=null).Select(i => i.Color).avrageColor();
    }
}
