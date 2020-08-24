using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] CustomerRequestList defaultList;
    public static List<CustomerRequest> AvailableRequests;
    [SerializeField] GameObject CustomerPrefab;
    [SerializeField] GameObject CustomerText;
    [SerializeField] GameObject Canvas;

    int MaxCustomerCount = 1;
    int CurrentCustomerCount = 0;

    void Start()
    {
        AvailableRequests = defaultList.ToList();
    }

    void Update()
    {
        if (CurrentCustomerCount < MaxCustomerCount)
        {
            CurrentCustomerCount++;
            Customer newCustomer;
            newCustomer = Instantiate(CustomerPrefab, Vector3.zero, Quaternion.identity).GetComponent<Customer>();
            CustomerRequest newRequest = AvailableRequests.ElementAt(Random.Range(0, AvailableRequests.Count));
            newCustomer.Initialize(newRequest, Canvas, CustomerText);
        }
    }
}
