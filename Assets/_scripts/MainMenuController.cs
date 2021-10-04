using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controlador para menu principal. Metodos para botones
/// </summary>
public class MainMenuController : MonoBehaviour
{
    // Juan Lanosa
    
    public GameObject mainPanel;
    public GameObject creditsPanel;
    public GameObject howToPlayPanel;
    public GameObject sceneLoadPanel;


    private void Awake()
    {
        ShowMainMenu();
    }
    public void ShowMainMenu()
    {
        if (mainPanel == null)
        {
            Debug.LogError("Te falto asociar el mainMenuPanel, cabeza");
            return;
        }

        mainPanel.SetActive(true);
        creditsPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        sceneLoadPanel.SetActive(false);
    }

    public void ShowLevelLoad()
    {
        if (sceneLoadPanel == null)
        {
            Debug.LogError("Te falto asociar el sceneLoadPanel, cabeza");
            return;
        }
        mainPanel.SetActive(false);
        creditsPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        sceneLoadPanel.SetActive(true);

    }
    public void ShowCredits()
    {
        if (creditsPanel == null)
        {
            Debug.LogError("Te falto asociar el creditsPanel, cabeza");
            return;
        }

        creditsPanel.SetActive(true);
        sceneLoadPanel.SetActive(false);
        mainPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
    }
    public void ShowHowToPlay()
    {
        if (howToPlayPanel == null)
        {
            Debug.LogError("Te falto asociar el howToPlayPanel, cabeza");
            return;
        }
        howToPlayPanel.SetActive(true);
        sceneLoadPanel.SetActive(false);
        creditsPanel.SetActive(false);
        mainPanel.SetActive(false);
    }

    #region PARA_ACHURAR
    public void PlayNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayIndexedScene(int idx)
    {
        SceneManager.LoadScene(idx);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    #endregion
}
