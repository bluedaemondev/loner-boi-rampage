using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObjectOnEvent : MonoBehaviour
{
    [SerializeField] GameObject objectToToggle;
    [SerializeField] string eventString;

    [SerializeField] string compareStr;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.SubscribeToEvent(eventString, ToggleGO);
    }
    private void ToggleGO(params object[] vs)
    {
        if (string.IsNullOrEmpty(compareStr) || compareStr.Equals(vs[0]))
            objectToToggle.SetActive(!objectToToggle.activeSelf);

    }
}
