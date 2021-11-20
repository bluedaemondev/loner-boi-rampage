using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Button = UnityEngine.UI.Button;


public class DefeatScreen : MonoBehaviour, IScreen
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
        foreach (var item in content)
        {
            item.interactable = false;
        }
    }

    public string Free()
    {
        this.gameObject.SetActive(false);
        return "Defeat Screen Disabled";
    }

}
