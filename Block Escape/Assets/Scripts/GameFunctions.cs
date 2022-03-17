using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameFunctions : MonoBehaviour
{

    static public bool justGothit = false;

    public GameObject continueButton;
    public GameObject gameOverScreen;

    public bool canContinue = true;

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        continueButton.SetActive(false);
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayerGotHit()
    {
        //for when left and right cube got hit at the same time
        if (justGothit)
            return;

        FindObjectOfType<Spawn>().Save();
        GameObject.FindGameObjectWithTag("HitSound").GetComponent<AudioSource>().Play();
        Time.timeScale = 0;

        justGothit = true;

        if (canContinue)
        {
            continueButton.SetActive(true);
            canContinue = false;
        }
        else
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void Continue(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            Time.timeScale = 1;
            justGothit = false;
            continueButton.SetActive(false);
        }
    }
}
