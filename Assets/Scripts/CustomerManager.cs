using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] CustomerRequestList defaultList;
    public static List<CustomerRequest> AvailableRequests;
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject GridLayoutGO;
    [SerializeField] GameObject CustomerBoxPrefab;
    [SerializeField] Image CustomerImage;
    [SerializeField] Text CustomerName;
    [SerializeField] Text CustomerDesc;

    void Start()
    {
        for (int i = 0; i < defaultList.Count(); i++)
        {
            UpdateCanvasQuest(defaultList[i]);
        }
    }

    void UpdateCanvasQuest(CustomerRequest newRequest)
    {
        Instantiate(CustomerBoxPrefab, Vector3.zero, Quaternion.identity).transform.SetParent(GridLayoutGO.transform);
        CustomerImage.sprite = newRequest.customerAvatar;
        CustomerName.text = newRequest.CustomerName;
        CustomerDesc.text = newRequest.description;
    }

    void Update()
    {
        
    }

    CustomerRequest GetNewRequest()
    {
        CustomerRequest newRequest = AvailableRequests[Random.Range(0, AvailableRequests.Count)];
        AvailableRequests.Remove(newRequest);
        return newRequest;
    }

    public void DestroyCustomer(Customer customer)
    {
        Destroy(customer);
    }
}
