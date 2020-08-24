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

    int MaxCustomerCount = 3;
    int CurrentCustomerCount = 0;
    float CustomerSpawnCooldown = 5;
    float SpawnTime = 0;

    void Start()
    {
        AvailableRequests = defaultList.ToList();
    }

    void Update()
    {
        SpawnTime += Time.deltaTime;
        if (CurrentCustomerCount < MaxCustomerCount && SpawnTime >= CustomerSpawnCooldown)
        {
            CurrentCustomerCount++;
            Customer newCustomer;
            newCustomer = Instantiate(CustomerPrefab, Vector3.zero, Quaternion.identity).GetComponent<Customer>();
            newCustomer.Initialize(this, GetNewRequest(), Canvas, CustomerText);
            SpawnTime = 0;
        }
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
        CurrentCustomerCount--;
    }
}
