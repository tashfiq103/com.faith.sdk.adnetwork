namespace com.faith.sdk.adnetwork
{
    public abstract class FaithAdNetworkBaseClassForBannerAd
    {
        #region Public Variables

        public bool IsAdRunning { get; protected set; }

        #endregion

        #region Protected Variables

        protected FaithAdNetworkBaseClassForConfiguretionInfo _adConfiguretion;
        protected string _adPlacement;

        #endregion

        #region Abstract Method

        public abstract bool IsBannerAdReady();
        public abstract void ShowBannerAd(string adPlacement = "banner", int playerLevel = 0);
        public abstract void HideBannerAd();

        #endregion
    }
}