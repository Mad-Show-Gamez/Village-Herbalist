using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiggerEvent : MonoBehaviour
{
    [SerializeField]
    TransformEvent OnTriggerEnter2DEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerEnter2DEvent.Invoke(collision.transform);
    }
}
