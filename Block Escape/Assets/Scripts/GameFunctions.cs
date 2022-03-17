using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameFunctions : MonoBehaviour
{

    static public bool justGothit = false;

    public GameObject continueButton;
    public GameObject gameOverScreen;

    public bool canContinue = true;

    InterstitialAd intersitialAd;
    RewardedAds rewardedAd;

    
    void Awake()
    {
        Time.timeScale = 1;
        justGothit = false;
        canContinue = true;
        continueButton.SetActive(false);
        gameOverScreen.SetActive(false);
    }

    private void Start()
    {
        intersitialAd = FindObjectOfType<InterstitialAd>();
        rewardedAd = FindObjectOfType<RewardedAds>();
        intersitialAd.LoadAd();
        rewardedAd.LoadAd();
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
            rewardedAd.ShowAd();
            //Time.timeScale = 1;
            justGothit = false;
            continueButton.SetActive(false);
        }
    }

    public void PlayAgain(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            print("ad should play");
            intersitialAd.ShowAd();
            SceneManager.LoadScene(1);
        }
    }
}
