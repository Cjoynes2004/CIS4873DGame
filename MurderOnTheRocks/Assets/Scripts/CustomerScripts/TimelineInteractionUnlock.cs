using UnityEngine;
using UnityEngine.Playables;

public class TimelineInteractionUnlock : MonoBehaviour
{
    public CustomerManager manager;

    void Awake()
    {
        GetComponent<PlayableDirector>().stopped += OnTimelineStopped;
    }

    void OnTimelineStopped(PlayableDirector director)
    {
        manager.EnableInteraction();
    }
}
