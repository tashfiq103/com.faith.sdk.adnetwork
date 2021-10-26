namespace com.faith.sdk.adnetwork
{
    public class FaithBannerAdOnMaxAdNetwork : FaithAdNetworkBaseClassForBannerAd
    {
        #region Public Callback

        public FaithBannerAdOnMaxAdNetwork(FaithAdNetworkBaseClassForConfiguretionInfo adConfiguretion)
        {
            _adConfiguretion = adConfiguretion;
        }

        public override void HideBannerAd()
        {
            throw new System.NotImplementedException();
        }

        public override bool IsBannerAdReady()
        {
            throw new System.NotImplementedException();
        }

        public override void ShowBannerAd(string adPlacement = "banner", int playerLevel = 0)
        {
            throw new System.NotImplementedException();
        }

        #endregion


    }
}


