using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseButtonUI; 
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }   
        }

    }   

    void Resume()
    {
        pauseButtonUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseButtonUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

}
