using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CustomerManager : MonoBehaviour
{
    public GameObject currCustomerObject;
    public int maxNumCustomers;
    
    private PlayableDirector entranceTimeline;
    private MeshRenderer currentRenderer;
    private Customer[] customerList;
    private Customer currentCustomer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentRenderer = currCustomerObject.GetComponent<MeshRenderer>();
        entranceTimeline = currCustomerObject.GetComponent<PlayableDirector>();
        customerList = GetComponentsInChildren<Customer>();
        print(customerList.Length);
        NextCustomer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextCustomer()
    {
        currentCustomer = currCustomerObject.AddComponent<Customer>();

        int rand = Random.Range(0, customerList.Length);
        currentCustomer = customerList[rand];

        MeshRenderer renderer = currentCustomer.gameObject.GetComponent<MeshRenderer>();
        currentRenderer.material = renderer.material;

        entranceTimeline.Play();
    }
}
