using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObjectOnEvent : MonoBehaviour
{
    [SerializeField] GameObject objectToToggle;
    [SerializeField] string eventString;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.SubscribeToEvent(eventString, ToggleGO);
    }
    private void ToggleGO(params object[] vs)
    {
        objectToToggle.SetActive(!objectToToggle.activeSelf);
    }
}
