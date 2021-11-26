using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

public class PauseScreen : MonoBehaviour, IScreen
{
    [SerializeField]
    Button[] content;

    public void ExitGame()
    {
        this.Deactivate();
        SceneManager.LoadScene(Constants.MAIN_MENU_BUILD_IDX);
    }
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
        return "Pause Screen Disabled";
    }

}
