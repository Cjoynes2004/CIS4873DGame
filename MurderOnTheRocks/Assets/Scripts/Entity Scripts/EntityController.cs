using UnityEngine;
using UnityEngine.Playables;

public class EntityController : MonoBehaviour
{
    public void OnPlayerClicked()
    {
        Debug.Log("Entity clicked - giving order!");
        GiveOrder();
    }

    public void GiveOrder()
    {
        // Plug in UI here
        Debug.Log("The Entity whispers: '...Bring me something... foul...'");
    }
}
