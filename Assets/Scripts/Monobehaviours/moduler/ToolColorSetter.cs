using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolColorSetter : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sr;
    IColorProvider alchemyTool;
    private void Awake()
    {
        alchemyTool = this.GetComponent<IColorProvider>();
        if (alchemyTool == null || sr == null)
            this.enabled = false;
    }
    private void Update()
    {
        sr.color = alchemyTool.CurrentColor;
    }
}
