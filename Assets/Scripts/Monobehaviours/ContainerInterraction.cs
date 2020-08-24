using Extensions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ContainerInterraction : MonoBehaviour, IColorProvider
{
    [SerializeField]
    int capacity = 1;
    [SerializeField]
    public AlchemyItemInstance[] content;
    Color currentColor = new Color(0, 0, 0, 0);

    public Color CurrentColor => currentColor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var tool = collision.GetComponent<IAlchemyTool>();
        if (tool != null)
        {
            if (content.Any())
            {
                foreach (var item in content)
                {
                    tool.data.Add(item);
                }
                emptycontainer();
            }
            else if (tool.data.Count() <= capacity)
            {
                content = tool.Empty().ToArray();
                currentColor = content.Select(i => i.Color).avrageColor();
            }
        }
    }

    public  void emptycontainer()
    {
        currentColor = new Color(0, 0, 0, 0);
        content = new AlchemyItemInstance[0];
    }

    private void OnValidate()
    {

        currentColor = content.Where(i => i != null).Select(i => i.Color).avrageColor();
    }
}
