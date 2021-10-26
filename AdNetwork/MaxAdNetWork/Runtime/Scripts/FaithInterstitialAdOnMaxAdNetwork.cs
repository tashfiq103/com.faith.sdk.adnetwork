namespace com.faith.sdk.adnetwork
{
    using UnityEngine.Events;

    public class FaithInterstitialAdOnMaxAdNetwork : FaithAdNetworkBaseClassForInterstitialAd
    {
        #region Public Callback

        public FaithInterstitialAdOnMaxAdNetwork(FaithAdNetworkBaseClassForConfiguretionInfo adConfiguretion)
        {
            _adConfiguretion = adConfiguretion;
        }

        public override bool IsInterstitialAdReady()
        {
            throw new System.NotImplementedException();
        }

        public override void ShowInterstitialAd(string adPlacement = "interstitial", UnityAction OnAdFailed = null, UnityAction OnAdClosed = null)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}

