using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameFunctions : MonoBehaviour
{

    static public bool justGothit = false;

    public GameObject continueButton;
    public GameObject gameOverScreen;

    public bool canContinue = true;

    InterstitialAd intersitialAd;
    RewardedAds rewardedAd;
    BannerAd banner;

    
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
        banner = FindObjectOfType<BannerAd>();
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        banner.ShowBannerAd();
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
            AudioListener.pause = true;
            rewardedAd.ShowAd();
            justGothit = false;
            continueButton.SetActive(false);
        }
    }

    public void PlayAgain(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            print("ad should play");
            //AudioListener.pause = true;
            //intersitialAd.ShowAd();
            SceneManager.LoadScene(1);
        }
    }
}
