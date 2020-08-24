using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Customer : MonoBehaviour
{
    [NaughtyAttributes.ReadOnly][SerializeField] internal CustomerRequest requestItem;

    public void Initialize(CustomerRequest newRequest, GameObject canvas, GameObject CustomerText)
    {
        GameObject textField = Instantiate(CustomerText);
        textField.transform.SetParent(canvas.transform);
        Vector3 textOffset = new Vector3(0, 1, 0);
        textField.transform.position = Camera.main.WorldToScreenPoint(transform.position + textOffset);
        textField.GetComponent<Text>().text = newRequest.description;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ContainerInterraction container = collision.GetComponent<ContainerInterraction>();

        if (container != null)
        {
            if (container.content.Intersect(requestItem.acceptedAI).Any())
            {
                container.emptycontainer();
                if (requestItem.newRequests.Count != 0)
                {
                    CustomerManager.AvailableRequests.ToList().AddRange(requestItem.newRequests);
                }
            }
        }
    }
}
