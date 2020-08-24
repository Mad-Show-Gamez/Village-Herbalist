using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemyItemMB : MonoBehaviour,IColorProvider
{
    [SerializeField]
    public AlchemyItemInstance item;
    [SerializeField]
    SpriteRenderer sr;

    public Color CurrentColor => item.Color;

    // Start is called before the first frame update
    void Awake()
    {
        populateGO();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var tool = collision.GetComponent<IAlchemyTool>();
        if (tool != null)
        {
            tool.data.Add(item);
            Destroy(this.gameObject);
        }
    }

    private void OnValidate()
    {
        populateGO();
    }
    private void populateGO()
    {
        if (item.type != null)
        {
            if (sr != null && item.type.Sprite != null)
                sr.sprite = item.type.Sprite;
            name = "AI:" + item.type.slug;
        }
    }
}
