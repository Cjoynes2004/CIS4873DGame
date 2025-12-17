using UnityEngine;
using UnityEngine.Playables;
using System.Collections;

public class EntityController : MonoBehaviour
{

    public Light[] barLights;

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

    public void StartEntranceEffects()
    {
        StartCoroutine(FlickerLights());
    }

    IEnumerator FlickerLights()
    {
        foreach (Light light in barLights)
        {
            StartCoroutine(FlickerSingleLight(light));
            yield return new WaitForSeconds(Random.Range(0.2f, 0.6f));
        }
    }

    IEnumerator FlickerSingleLight(Light light)
    {
        int flickers = Random.Range(3, 6);

        for (int i = 0; i < flickers; i++)
        {
            light.enabled = false;
            yield return new WaitForSeconds(Random.Range(0.05f, 0.15f));
            light.enabled = true;
            yield return new WaitForSeconds(Random.Range(0.05f, 0.2f));
        }
    }

}
