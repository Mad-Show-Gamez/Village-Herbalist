using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class onClick : MonoBehaviour
{
    [SerializeField]
    TransformEvent clickReleaseHandler;
    public void ClickRelease(Transform self) => clickReleaseHandler.Invoke(self);

    [SerializeField]
    TransformEvent clickHandler;
    public void Click(Transform self) => clickHandler.Invoke(self);
}
