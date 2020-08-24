using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Customer : MonoBehaviour
{
    [NaughtyAttributes.ReadOnly] [SerializeField] List<AlchemyItem> requestedItems;
    internal CustomerRequest customerRequest;
    Text custText;
    CustomerManager manager;

    public void Initialize(CustomerManager manager, CustomerRequest newRequest, GameObject canvas, GameObject CustomerText)
    {
        customerRequest = newRequest;
        this.manager = manager;
        GameObject textField = Instantiate(CustomerText);
        textField.transform.SetParent(canvas.transform);
        Vector3 textOffset = new Vector3(0, 1, 0);
        textField.transform.position = Camera.main.WorldToScreenPoint(transform.position + textOffset);
        custText = textField.GetComponent<Text>();
        custText.text = newRequest.description;
        requestedItems.AddRange(newRequest.acceptedAI);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ContainerInterraction container = collision.GetComponent<ContainerInterraction>();

        if (container != null)
        {
            if (container.content.Select(i => i.type).Intersect(requestedItems).Any())
            {
                Debug.Log("yes");
                CustomerSatisfied(container);
            }
        }
    }

    void CustomerSatisfied(ContainerInterraction container)
    {
        container.emptycontainer();
        if (customerRequest.newRequests.Count != 0)
        {
            CustomerManager.AvailableRequests.ToList().AddRange(customerRequest.newRequests);
            StartCoroutine(DestroyAfterDialogue());
        }
    }

    IEnumerator DestroyAfterDialogue()
    {
        custText.text = "Thank you!";
        yield return new WaitForSeconds(2);
        manager.DestroyCustomer(this);
    }
}
