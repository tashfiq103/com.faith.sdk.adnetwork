namespace com.faith.sdk.adnetwork
{
#if FaithAdNetwork_LionKit

    public static class FaithLionKitAdNetwork
    {
    #region Public Variables

        public static FaithRewardedAdOnLionKitAdNetwork RewardedAd { get; private set; }
        public static FaithInterstitialAdOnLionKitAdNetwork InterstitialAd { get; private set; }
        public static FaithBannerAdOnLionKitAdNetwork BannerAd { get; private set; }

    #endregion

    #region Public Variables

        public static void Initialize(FaithAdNetworkBaseClassForConfiguretionInfo adConfiguretion) {

            RewardedAd = new FaithRewardedAdOnLionKitAdNetwork(adConfiguretion);
            InterstitialAd = new FaithInterstitialAdOnLionKitAdNetwork(adConfiguretion);
            BannerAd = new FaithBannerAdOnLionKitAdNetwork(adConfiguretion);
        }

    #endregion


    }

#endif
}