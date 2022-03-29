using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseButton : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseButtonUI;
    public GameObject resumeButtonUI;


    private void Start()
    {
        pauseButtonUI.SetActive(true);
        resumeButtonUI.SetActive(false);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        resumeButtonUI.SetActive(false);
        pauseButtonUI.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
        resumeButtonUI.SetActive(true);
        HidePause();
    }

    public void togglePauseState(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void HidePause()
    {
        pauseButtonUI.SetActive(false);
        
    }

    public void test()
    {
        print("test");
    }

}