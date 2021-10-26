namespace com.faith.sdk.adnetwork
{

    using UnityEngine.Events;

    public class FaithRewardedAdOnMaxAdNetwork : FaithAdNetworkBaseClassForRewardedAd
    {
        #region Public Callback

        public FaithRewardedAdOnMaxAdNetwork(FaithAdNetworkBaseClassForConfiguretionInfo adConfiguretion) {

            _adConfiguretion = adConfiguretion;
        }

        public override bool IsRewardedAdReady()
        {
            throw new System.NotImplementedException();
        }

        public override void ShowRewardedAd(string adPlacement, UnityAction<bool> OnAdClosed, UnityAction OnAdFailed = null)
        {
            throw new System.NotImplementedException();
        }

        #endregion


    }
}

