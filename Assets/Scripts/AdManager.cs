using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    public static AdManager instance;

    public bool testMode = false;

    private string gameID = "3257979";
    private string bannerID = "banner";

    void Awake()
    {
        #region singleton
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        #endregion

    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        Advertisement.Initialize(gameID, testMode);
        ShowBanner();
    }

    private void OnLevelWasLoaded(int level)
    {
        ShowBanner();
    }

    public void ShowBanner()
    {
        StartCoroutine(ShowBannerWhenIsReady());
    }

    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }

    private IEnumerator ShowBannerWhenIsReady()
    {
        while (!Advertisement.IsReady(bannerID))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(bannerID);
    }
}
