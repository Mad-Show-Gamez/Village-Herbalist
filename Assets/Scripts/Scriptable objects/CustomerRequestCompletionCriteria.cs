using NaughtyAttributes;
using System;
using UnityEngine;

[System.Serializable]
internal class CustomerRequestCompletionCriteria
{
    [SerializeField]
    public AlchemyItem[] Solutions;
    [SerializeField]
    public string responce;
    [SerializeField,Label("all rquired to be true to be satisfyed")]
    public TagQuery[] tagValidQuery;
    public CustomerRequest[] requestsProgression;
}