using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CustomerRequest", menuName = "CustomerRequest")]
public class CustomerRequest : ScriptableObject
{
    [SerializeField] string description;
    [SerializeField] internal List<AlchemyItem> acceptedAI;
    [SerializeField] internal List<CustomerRequest> newQuests;
}
