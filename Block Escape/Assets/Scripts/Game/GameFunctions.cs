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
    static public bool gameOver = false;

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
        gameOver = false;
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
            Invoker.InvokeDelayed(MaybeShowAd, 0.5f);
            gameOverScreen.SetActive(true);
        }
    }

    void MaybeShowAd()
    {
        //show ad here 30% of the time
        if (Random.Range(0, 100) <= 30)
        {
            gameOver = true;
            AudioListener.pause = true;
            banner.HideBannerAd();
            intersitialAd.ShowAd();
        }
            print("ad?");
    }

    public bool GetGameState()
    {
        return gameOver;
    }

    public void Continue(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            AudioListener.pause = true;
            banner.HideBannerAd();
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
