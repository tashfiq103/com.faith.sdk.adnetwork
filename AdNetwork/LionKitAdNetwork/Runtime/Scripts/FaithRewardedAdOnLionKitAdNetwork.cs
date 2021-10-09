namespace com.faith.sdk.adnetwork
{
//#if FaithAdNetwork_LionKit

    using UnityEngine.Events;
    using LionStudios.Ads;

    public class FaithRewardedAdOnLionKitAdNetwork : FaithAdNetworkBaseClassForRewardedAd
    {

    #region Private Variables

        private ShowAdRequest               _showRewardedAdRequest;

    #endregion

    #region Configuretion

    #endregion

    #region Public Callback

        public FaithRewardedAdOnLionKitAdNetwork(FaithAdNetworkBaseClassForConfiguretionInfo adConfiguretion) {

            _adConfiguretion = adConfiguretion;

            _showRewardedAdRequest = new ShowAdRequest();

            // Ad event callbacks
            _showRewardedAdRequest.OnDisplayed += adUnitId =>
            {
                FaithAdNetworkLogger.Log("Displayed Rewarded Ad :: Ad Unit ID = " + adUnitId);

                _isEligibleForReward = false;
                IsAdRunning = true;


            };
            _showRewardedAdRequest.OnClicked += adUnitId =>
            {
                FaithAdNetworkLogger.Log("Clicked Rewarded Ad :: Ad Unit ID = " + adUnitId);
            };
            _showRewardedAdRequest.OnHidden += adUnitId =>
            {
                FaithAdNetworkLogger.Log("Closed Rewarded Ad :: Ad Unit ID = " + adUnitId);

                IsAdRunning = false;
                _OnAdClosed?.Invoke(_isEligibleForReward);
            };
            _showRewardedAdRequest.OnFailedToDisplay += (adUnitId, error) =>
            {
                FaithAdNetworkLogger.LogError("Failed To Display Rewarded Ad :: Error = " + error + " :: Ad Unit ID = " + adUnitId);

                IsAdRunning = false;
                _OnAdFailed?.Invoke();
            };
            _showRewardedAdRequest.OnReceivedReward += (adUnitId, reward) =>
            {
                FaithAdNetworkLogger.Log("Received Reward :: Reward = " + reward + " :: Ad Unit ID = " + adUnitId);
                _isEligibleForReward = true;


            };
        }

        public override bool IsRewardedAdReady()
        {
            return LionStudios.Ads.RewardedAd.IsAdReady;
        }

        public override void ShowRewardedAd(string adPlacement, UnityAction<bool> OnAdClosed, UnityAction OnAdFailed = null)
        {
            if (_adConfiguretion.IsRewardedAdEnabled)
            {
                _adPlacement = string.IsNullOrEmpty(adPlacement) ? "rewarded_video" : adPlacement;
                _OnAdClosed = OnAdClosed;
                _OnAdFailed = OnAdFailed;

                LionStudios.Ads.RewardedAd.Show(_showRewardedAdRequest);
            }
            else
            {
                FaithAdNetworkLogger.LogError(string.Format("RewardedAd is set to disabled in 'FaithAdNetwork Integration Manager'. Please set the flag to 'true' to see RewardedAd"));
            }
        }

        


    #endregion


    }

//#endif


}