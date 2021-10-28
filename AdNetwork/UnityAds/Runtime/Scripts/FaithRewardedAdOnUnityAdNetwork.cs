namespace com.faith.sdk.adnetwork
{
#if FaithAdNetwork_Unity

    using System.Threading.Tasks;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.Advertisements;

    public class FaithRewardedAdOnUnityAdNetwork : FaithAdNetworkBaseClassForRewardedAd, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        #region Private Variables

        private int _retryAttempt;

        #endregion

        #region Configuretion

        private async void LoadAd(float delayInSeconds = 0)
        {
            await Task.Delay((int)delayInSeconds * 1000);

            Advertisement.Load(_adConfiguretion.AdUnitId_RewardedAd, this);
        }

        #endregion

        #region Public Callback

        public FaithRewardedAdOnUnityAdNetwork(FaithAdNetworkBaseClassForConfiguretionInfo adConfiguretion)
        {
            _adConfiguretion = adConfiguretion;

            LoadAd();
        }

        #endregion

        #region Abstract Method

        public override bool IsRewardedAdReady()
        {
            return Advertisement.IsReady(_adConfiguretion.AdUnitId_RewardedAd);
        }

        public override void ShowRewardedAd(string adPlacement, UnityAction<bool> OnAdClosed, UnityAction OnAdFailed = null)
        {
            if (_adConfiguretion.IsRewardedAdEnabled)
            {
                _adPlacement = string.IsNullOrEmpty(adPlacement) ? "rewarded_video" : adPlacement;
                _OnAdClosed = OnAdClosed;
                _OnAdFailed = OnAdFailed;

                Advertisement.Show(_adConfiguretion.AdUnitId_RewardedAd, this);
            }
            else
            {
                FaithAdNetworkLogger.LogError(string.Format("RewardedAd is set to disabled in FaithAdNetworkIntegrationManager. Please set the flag to 'true' to see RewardedAd"));
            }
        }

        #endregion

        #region Interface : IUnityAdsLoadListener

        public void OnUnityAdsAdLoaded(string placementId)
        {
            FaithAdNetworkLogger.Log("Successfully Loaded RewardedAd");
            _retryAttempt = 0;
        }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
            FaithAdNetworkLogger.LogError("Failed To Load RewardedAd");

            _retryAttempt++;
            float retryDelay = Mathf.Pow(2, Mathf.Min(6, _retryAttempt));

            LoadAd(retryDelay);
            _OnAdFailed?.Invoke();
        }

        #endregion

        #region Interface : IUnityAdsShowListener

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            FaithAdNetworkLogger.LogError("Failed To Display RewardedAd");

            LoadAd();
            _OnAdFailed?.Invoke();
        }

        public void OnUnityAdsShowStart(string placementId)
        {
            FaithAdNetworkLogger.Log("Displayed Rewarded Ad");

            _isEligibleForReward = false;
            IsAdRunning = true;
        }

        public void OnUnityAdsShowClick(string placementId)
        {
            FaithAdNetworkLogger.Log("Clicked RewardedAd");
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            switch (showCompletionState) {
                case UnityAdsShowCompletionState.COMPLETED:
                    FaithAdNetworkLogger.Log("Received Reward");
                    _isEligibleForReward = true;
                    break;
                default:

                    break;
            }

            FaithAdNetworkLogger.Log("Closed RewardedAd");

            _OnAdClosed?.Invoke(_isEligibleForReward);
            IsAdRunning = false;
            LoadAd();
        }

        #endregion
    }

#endif

            }

