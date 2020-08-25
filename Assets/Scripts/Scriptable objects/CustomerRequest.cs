using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New CustomerRequest", menuName = "CustomerRequest")]
public class CustomerRequest : ScriptableObject
{
    [SerializeField] internal Sprite customerAvatar;
    [SerializeField] internal string CustomerName;
    [SerializeField] internal string description;
    [SerializeField] internal List<CustomerRequestCompletionCriteria> acceptedAI;
    [SerializeField] internal string defaultResponce;
    [SerializeField] internal string rejectionResponce;
    [SerializeField] internal bool alwaysAddDefaultProgression = false;
    [SerializeField] internal CustomerRequest[] DefaultProgression;

    public CustomerRequestResult getResult(AlchemyItemInstance alchemyItemInstance)
    {
        var accepted = acceptedAI.Where(ai => ai.Solutions.Contains(alchemyItemInstance.type));
        if (accepted.Any())
        {
            accepted = accepted.Where(crcc => crcc.tagValidQuery.All(q => q.ResolveQuery(alchemyItemInstance.tags)));
            if (accepted.Any())
            {
                var responce = accepted.ElementAt(Random.Range(0, accepted.Count() - 1));
                var defaultProgression = alwaysAddDefaultProgression || !responce.requestsProgression.Any() ? DefaultProgression : new CustomerRequest[0];
                return new CustomerRequestResult()
                {
                    unlockedRequests = responce.requestsProgression
                    .Concat(defaultProgression)
                    .ToArray(),
                    isAccepted = true,
                    Responce = responce.responce == "" ? defaultResponce : responce.responce
                };

            }
        }
        return new CustomerRequestResult() { isAccepted = false, unlockedRequests = new CustomerRequest[0], Responce = rejectionResponce };
    }
}
