﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAdsScript : MonoBehaviour, IUnityAdsListener
{
    //private Player player;
   string gameId = "3953625";
    string videoPlacementId = "rewardedVideo";
    string bannerPlacementId = "BannerAB";
    bool testMode = false;
    public int deaths;
    public static RewardedAdsScript instance;

    public static RewardedAdsScript getInstance() {
        if(instance == null) {
            instance = GameObject.FindObjectOfType<RewardedAdsScript>();
        }
        return instance;
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Initialize the Ads listener and service:
    void Start () {
        //player = FindObjectOfType(typeof(Player)) as Player;
        Advertisement.AddListener (this);
        Advertisement.Initialize (gameId, testMode);
    }
    public void ShowInterstitialAd() {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady()) {
            Advertisement.Show();
        } 
        else {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
    }

    IEnumerator ShowBannerWhenReady () {
        while (!Advertisement.IsReady (bannerPlacementId)) {
            yield return new WaitForSeconds (0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);    
        Advertisement.Banner.Show (bannerPlacementId);
        yield return new WaitForSeconds (20f);
        Advertisement.Banner.Hide();
    }

    public void ShowBanner() {
        StartCoroutine (ShowBannerWhenReady ());
    }
    public void ShowRewardedVideo() {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(videoPlacementId)) {
            Advertisement.Show(videoPlacementId);
        } 
        else {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished) {
            // Reward the user for watching the ad to completion.
            //if(player == null){
            //    player = FindObjectOfType(typeof(Player)) as Player;
           // }
           // player.CallBackmoreArrows(10);

        } else if (showResult == ShowResult.Skipped) {
            // Do not reward the user for skipping the ad.
        } else if (showResult == ShowResult.Failed) {
            Debug.LogWarning ("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady (string placementId) {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == videoPlacementId) {
            // Optional actions to take when the placement becomes ready(For example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError (string message) {
        // Log the error.
    }

    public void OnUnityAdsDidStart (string placementId) {
        // Optional actions to take when the end-users triggers an ad.
    } 

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy() {
        Advertisement.RemoveListener(this);
    }

    public void RegraInterstitial()
    {
        deaths++;
        if (deaths >= 10)
        {
            deaths = 0;
            ShowInterstitialAd();
        }
    }

    
}
