using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Tag : ScriptableObject
{

    private string _tagName;
    public string tagName
    {
        get
        {
            var name = this.tagName ?? _tagName;
            _tagName = name;
            return name;
        }
    }

    string description;
}
