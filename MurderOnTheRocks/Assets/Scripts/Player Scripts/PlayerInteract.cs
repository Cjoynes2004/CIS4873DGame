using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float interactRange;

    private Glass heldGlass = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPrimary(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (heldGlass == null)
        {
            EmptyHand();
        }
        else
        {
            HeldItem();
        }
    }

    public void OnSecondary(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        DropGlass();
    }

    private void DropGlass()
    {
        if (heldGlass == null) return;

        Vector3 dropPos;

        // Raycast to detect walls so we don't clip objects
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, 1f))
        {
            // Drop slightly in front of the hit point
            dropPos = hit.point - cameraTransform.forward * 0.1f;
        }
        else
        {
            // If nothing ahead, drop 0.3m in front of camera (safer for tiny rooms)
            dropPos = cameraTransform.position + cameraTransform.forward * 0.3f;
        }

        heldGlass.gameObject.SetActive(true);
        heldGlass.transform.position = dropPos;
        heldGlass.transform.rotation = Quaternion.identity;

        heldGlass = null;
    }

    private void HeldItem()
    {
        if (!Raycast(out RaycastHit hit)) return;

        Ingredient ingredient = hit.collider.GetComponent<Ingredient>();
        if (ingredient)
        {
            //To be implemented by hailey
            return;
        }

        Customer customer = hit.collider.GetComponent<Customer>();
        if (customer)
        {
            //To be implemented by Chandler
            return;
        }
    }

    private void EmptyHand()
    {
        if (!Raycast(out RaycastHit hit)) return;

        Glass glass = hit.collider.GetComponent<Glass>();
        if (glass)
        {
            PickUp(glass);
            return;
        }

        Customer customer = hit.collider.GetComponent<Customer>();
        if (customer)
        {
            //To be implemented by Chandler
            return;
        }

    }

    private void PickUp(Glass glass)
    {
        heldGlass = glass;

        glass.gameObject.SetActive(false);
    }

    private bool Raycast(out RaycastHit hit)
    {
        return Physics.Raycast(
            cameraTransform.position,
            cameraTransform.forward,
            out hit,
            interactRange
        );
    }
}
