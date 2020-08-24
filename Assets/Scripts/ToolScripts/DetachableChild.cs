using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachableChild : MonoBehaviour
{
    public void clearParent()
    {
        transform.parent = null;
    }
}
