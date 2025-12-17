using TMPro;
using UnityEngine;

public class Customer : MonoBehaviour
{
    Receipt customerOrder;

    public Customer realCustomer;
    public TextMeshProUGUI orderText;

    public bool isProxy;
    private CustomerManager manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        customerOrder = GetComponent<Receipt>();
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

    private void CheckOrder(Receipt order) //Eventually this will be more than just pass/fail
    {
        if (customerOrder.IsEqual(order))
        {
            manager.RequestNextCustomer();
            orderText.text = "No Current Order";
        }
    }

    public void GiveOrder()
    {
        string glass = customerOrder.glassType;
        string baseIng = customerOrder.baseType;
        string ingredients = string.Join(", ", customerOrder.customIngredients);

        orderText.text = $"{customerOrder.glassType}\n" +
            $"{customerOrder.baseType}\n" +
            $"{ingredients}";
    }
}
