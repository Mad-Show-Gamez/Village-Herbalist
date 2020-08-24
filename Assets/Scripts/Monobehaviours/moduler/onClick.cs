using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class onClick : MonoBehaviour
{
    [SerializeField]
    TransformEvent clickHandler;
    [SerializeField]
    TransformEvent clickReleaseHandler;
    public void ClickRelease(Transform self) => clickReleaseHandler.Invoke(self);

    public void Click(Transform self) => clickHandler.Invoke(self);

}
