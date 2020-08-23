using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Customer : MonoBehaviour
{
    [SerializeField] CustomerRequest requestItem;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ContainerInterraction>() != null)
        {
            ContainerInterraction container = collision.GetComponent<ContainerInterraction>();
            if (container.content.Any() == requestItem)
            {
                Debug.Log("Requested item matches");
                container.emptycontainer();
            }
        }
    }
}
