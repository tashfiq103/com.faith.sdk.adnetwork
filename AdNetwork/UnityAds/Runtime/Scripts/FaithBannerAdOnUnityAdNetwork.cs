namespace com.faith.sdk.adnetwork
{
#if FaithAdNetwork_Unity
    
    using UnityEngine.Advertisements;

    public class FaithBannerAdOnUnityAdNetwork : FaithAdNetworkBaseClassForBannerAd
    {
        #region Configuretion

        private void OnBannerLoaded()
        {
            FaithAdNetworkLogger.Log("Banner Loaded");
        }

        private void OnBannerLoadError(string errorMessage)
        {
            FaithAdNetworkLogger.LogError(string.Format("Banner Load Failed : {0}", errorMessage));
        }

        private void OnBannerShow()
        {
            FaithAdNetworkLogger.Log("Banner Show");
        }

        private void OnBannerClicked()
        {
            FaithAdNetworkLogger.Log("Banner Clicked");
        }

        private void OnBannerHide()
        {
            FaithAdNetworkLogger.Log("Banner Hide");
        }

        

        #endregion

        #region Public Callback

        public FaithBannerAdOnUnityAdNetwork(FaithAdNetworkBaseClassForConfiguretionInfo adConfiguretion)
        {
            _adConfiguretion = adConfiguretion;

            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Load(
                    _adConfiguretion.AdUnitId_BannerAd,
                    new BannerLoadOptions
                    {
                        loadCallback = OnBannerLoaded,
                        errorCallback = OnBannerLoadError
                    });
        }

        #endregion

        #region Abstract Method

        public override void HideBannerAd()
        {
            Advertisement.Banner.Hide();
        }

        public override bool IsBannerAdReady()
        {
            return Advertisement.Banner.isLoaded;
        }

        public override void ShowBannerAd(string adPlacement = "banner", int playerLevel = 0)
        {
            if (_adConfiguretion.IsBannerAdEnabled)
            {

                _adPlacement = adPlacement;
                Advertisement.Banner.Show(
                    _adConfiguretion.AdUnitId_BannerAd,
                    new BannerOptions
                    {
                        showCallback = OnBannerShow,
                        clickCallback = OnBannerClicked,
                        hideCallback = OnBannerHide
                        
                    });
            }
            else
            {
                FaithAdNetworkLogger.LogError(string.Format("BannerAd is set to disabled in APSDKIntegrationManager. Please set the flag to 'true' to see BannerAd"));
            }
        }

        #endregion

    }
#endif

}

