namespace com.faith.sdk.adnetwork
{
#if FaithAdNetwork_Unity
    public static class FaithUnityAdNetwork
    {
        #region Public Variables

        public static FaithRewardedAdOnUnityAdNetwork RewardedAd { get; private set; }
        public static FaithInterstitialAdOnUnityAdNetwork InterstitialAd { get; private set; }
        public static FaithBannerAdOnUnityAdNetwork BannerAd { get; private set; }

        #endregion

        #region Public Variables

        public static void Initialize(FaithAdNetworkBaseClassForConfiguretionInfo adConfiguretion)
        {

            RewardedAd = new FaithRewardedAdOnUnityAdNetwork(adConfiguretion);
            InterstitialAd = new FaithInterstitialAdOnUnityAdNetwork(adConfiguretion);
            BannerAd = new FaithBannerAdOnUnityAdNetwork(adConfiguretion);
        }

        #endregion
    }
#endif
}



