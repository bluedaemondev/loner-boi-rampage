using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager instance;

    public bool isPaused;

    private void Awake()
    {
        instance = this;
    }

    private void OnApplicationFocus(bool focus)
    {
        TogglePause(!focus);

        //if (!focus)
        //{
        //    TogglePause(true);
        //}
        //else
        //{
        //    isPaused = false;
        //    Time.timeScale = 1;
        //}
    }
    public void TogglePause(bool paused)
    {
        isPaused = paused;
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
