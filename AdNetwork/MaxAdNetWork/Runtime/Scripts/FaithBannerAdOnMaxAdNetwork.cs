namespace com.faith.sdk.adnetwork
{
#if FaithAdNetwork_Max
    using UnityEngine;

    public class FaithBannerAdOnMaxAdNetwork : FaithAdNetworkBaseClassForBannerAd
    {


        #region Public Callback

        public FaithBannerAdOnMaxAdNetwork(FaithAdNetworkBaseClassForConfiguretionInfo adConfiguretion)
        {
            _adConfiguretion = adConfiguretion;

            MaxSdk.CreateBanner(_adConfiguretion.AdUnitId_BannerAd, MaxSdkBase.BannerPosition.BottomCenter);
            MaxSdk.SetBannerBackgroundColor(_adConfiguretion.AdUnitId_BannerAd, Color.white);
        }

        public override void HideBannerAd()
        {
            MaxSdk.HideBanner(_adConfiguretion.AdUnitId_BannerAd);
        }

        public override bool IsBannerAdReady()
        {
            return true;
        }

        public override void ShowBannerAd(string adPlacement = "banner", int playerLevel = 0)
        {
            if (_adConfiguretion.IsBannerAdEnabled)
            {

                _adPlacement = adPlacement;
                MaxSdk.ShowBanner(_adConfiguretion.AdUnitId_BannerAd);
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


