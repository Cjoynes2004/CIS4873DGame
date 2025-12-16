using UnityEngine;

public class EntityClickBehavior : MonoBehaviour
{
    public float interactDistance = 3f; // How close the player must be
    public LayerMask entityLayer; // So it only detects the entity

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance, entityLayer))
            {
                // Checks if the clicked object has the entity script
                EntityController entity = hit.collider.GetComponent<EntityController>();

                if (entity != null)
                {
                    entity.OnPlayerClicked();
                }

            }
        }
    }
}