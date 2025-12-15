using UnityEngine;

public class Customer : MonoBehaviour
{
    Receipt customerOrder;

    public Customer realCustomer;
    public bool isProxy;
    private CustomerManager manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        customerOrder = GetComponent<Receipt>();
        customerOrder.GenerateOrder();
        manager = GetComponentInParent<CustomerManager>();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AbstractOrder(Receipt order)
    {
        if (isProxy && realCustomer != null)
        {
            realCustomer.AbstractOrder(order);
            return;
        }
        else
        {
            CheckOrder(order);
        }
    }

    private void CheckOrder(Receipt order)
    {
        if (customerOrder.IsEqual(order))
        {

        }
        manager.RequestNextCustomer();
    }

    public void GiveOrder()
    {

    }
}
