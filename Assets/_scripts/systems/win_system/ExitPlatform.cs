using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPlatform : MonoBehaviour
{
    [SerializeField] private Collider colExit;
    [SerializeField] private GameObject particles;

    void Start()
    {
        EventManager.SubscribeToEvent(Constants.ON_PLAYER_CLEARED_FLOOR, this.TriggerMe);
        colExit.enabled = false;
        particles.SetActive(false);

    }

    private void TriggerMe(params object[] vs)
    {
        particles.SetActive(true);
        colExit.enabled = true;
    }
}
