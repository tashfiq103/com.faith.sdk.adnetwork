namespace com.faith.sdk.adnetwork
{
#if FaithAdNetwork_Unity

    using System.Threading.Tasks;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.Advertisements;

    public class FaithInterstitialAdOnUnityAdNetwork : FaithAdNetworkBaseClassForInterstitialAd, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        #region Private Variables

        private int _retryAttempt;

        #endregion

        #region Configuretion

        private async void LoadAd(float delayInSeconds = 0)
        {
            await Task.Delay((int)delayInSeconds * 1000);

            Advertisement.Load(_adConfiguretion.AdUnitId_InterstitialAd, this);
        }

        #endregion

        #region Abstract Method

        public override bool IsInterstitialAdReady()
        {
            return Advertisement.IsReady(_adConfiguretion.AdUnitId_InterstitialAd);
        }

        public override void ShowInterstitialAd(string adPlacement = "interstitial", UnityAction OnAdFailed = null, UnityAction OnAdClosed = null)
        {
            if (_adConfiguretion.IsRewardedAdEnabled)
            {
                _adPlacement = string.IsNullOrEmpty(adPlacement) ? "interstitial" : adPlacement;
                _OnAdClosed = OnAdClosed;
                _OnAdFailed = OnAdFailed;

                Advertisement.Show(_adConfiguretion.AdUnitId_RewardedAd, this);
            }
            else
            {
                FaithAdNetworkLogger.LogError(string.Format("Interstitial is set to disabled in FaithAdNetworkIntegrationManager. Please set the flag to 'true' to see RewardedAd"));
            }
        }

        #endregion

        #region Public Callback

        public FaithInterstitialAdOnUnityAdNetwork(FaithAdNetworkBaseClassForConfiguretionInfo adConfiguretion)
        {
            _adConfiguretion = adConfiguretion;

            LoadAd();
        }

        #endregion

        #region Interface : IUnityAdsLoadListener

        public void OnUnityAdsAdLoaded(string placementId)
        {
            FaithAdNetworkLogger.Log("Successfully Loaded InterstitialAd");
            _retryAttempt = 0;
        }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
            FaithAdNetworkLogger.LogError("Failed To Load InterstitialAd");
            _retryAttempt++;
            float retryDelay = Mathf.Pow(2, Mathf.Min(6, _retryAttempt));

            LoadAd(retryDelay);
            _OnAdFailed?.Invoke();
        }

        #endregion

        #region Interface : IUnityAdsShowListener

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            FaithAdNetworkLogger.LogError("Failed To Display InterstitialAd");

            LoadAd();
            _OnAdFailed?.Invoke();
        }

        public void OnUnityAdsShowStart(string placementId)
        {
            FaithAdNetworkLogger.Log("Displayed InterstitialAd");

            IsAdRunning = true;
        }

        public void OnUnityAdsShowClick(string placementId)
        {
            FaithAdNetworkLogger.Log("Clicked InterstitialAd");
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            FaithAdNetworkLogger.Log("Closed InterstitialAd");

            _OnAdClosed?.Invoke();
            IsAdRunning = false;
            LoadAd();
        }

        #endregion
    }
#endif

}

