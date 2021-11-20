using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Button = UnityEngine.UI.Button;


public class VictoryScreen : MonoBehaviour, IScreen
{
    [SerializeField]
    Button[] content;

    public void Activate()
    {
        foreach (var item in content)
        {
            item.interactable = true;
        }
    }

    public void Deactivate()
    {
        Debug.Log("Victory end");
    }

    public string Free()
    {
        this.gameObject.SetActive(false);
        return "Victory Screen Disabled";
    }

}
