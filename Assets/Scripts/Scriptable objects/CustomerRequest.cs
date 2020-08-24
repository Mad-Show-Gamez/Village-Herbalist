using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CustomerRequest", menuName = "CustomerRequest")]
public class CustomerRequest : ScriptableObject
{
    [SerializeField] internal Sprite customerAvatar;
    [SerializeField] internal string CustomerName;
    [SerializeField] internal string description;
    [SerializeField] internal List<AlchemyItem> acceptedAI;
    [SerializeField] internal List<CustomerRequest> newRequests;
}
