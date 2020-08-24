using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayAction : MonoBehaviour
{
    [SerializeField]
    float wait;
    [SerializeField]
    TransformEvent onComplete;
    [SerializeField]
    bool RunOnAwake = false;
    [SerializeField, NaughtyAttributes.ReadOnly]
    bool running = false;
    private void Awake()
    {
        if (RunOnAwake)
            StartTask();
    }
    public void StartTask()
    {
        if (!running)
        {
            running = true;
            StartCoroutine(task());
        }
    }
    IEnumerator task()
    {
        yield return new WaitForSeconds(wait);
        onComplete.Invoke(transform);
        running = false;
    }
}
