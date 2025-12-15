using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;

public class CustomerManager : MonoBehaviour
{
    public GameObject currCustomerObject;
    public int maxNumCustomers;
    public PlayableDirector entranceTimeline;
    public  PlayableDirector exitTimeline;

    private MeshRenderer currentRenderer;
    private Customer[] customerList;
    private Customer currentCustomer;
    private CapsuleCollider currCollider;
    private bool firstCustomer = true;
    private bool switchingCustomer = false;

    public bool CanClick { get; private set; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentRenderer = currCustomerObject.GetComponent<MeshRenderer>();
        currCollider = currCustomerObject.GetComponent<CapsuleCollider>();
        entranceTimeline = currCustomerObject.GetComponent<PlayableDirector>();
        customerList = GetComponentsInChildren<Customer>()
            .Where(c => !c.isProxy)
            .ToArray(); print(customerList.Length);
        NextCustomer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextCustomer()
    {
        CanClick = false;
        if (!firstCustomer)
        {
            exitTimeline.Play();
        }

        int rand = Random.Range(0, customerList.Length);
        currentCustomer = customerList[rand];

        MeshRenderer renderer = currentCustomer.GetComponent<MeshRenderer>();
        currentRenderer.material = renderer.material;

        Customer proxy = currCustomerObject.GetComponent<Customer>();
        proxy.realCustomer = currentCustomer;

        entranceTimeline.Play();
        currCollider.enabled = true;
        firstCustomer = false;
    }

    public void RequestNextCustomer()
    {
        if (switchingCustomer)
            return;

        switchingCustomer = true;
        NextCustomer();
    }

    public void EnableInteraction()
    {
        CanClick = true;   //unlocked safely
        switchingCustomer = false;
    }
}
