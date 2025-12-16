using UnityEngine;

public class SpookyTriggerEvent : MonoBehaviour
{
    public bool eventTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (eventTriggered) return; // Prevents multiple triggers

        if (other.CompareTag("Player"))
        {
            eventTriggered = true;
            TriggerSpookyEvent();
        }
    }

    void TriggerSpookyEvent()
    {
        Debug.Log("SPOOKY EVENT HAPPENED!");
    }
}
