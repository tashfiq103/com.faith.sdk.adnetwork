namespace com.faith.sdk.adnetwork
{
    public static class FaithMaxAdNetwork
    {
        #region Public Variables

        public static FaithRewardedAdOnMaxAdNetwork RewardedAd { get; private set; }
        public static FaithInterstitialAdOnMaxAdNetwork InterstitialAd { get; private set; }
        public static FaithBannerAdOnMaxAdNetwork BannerAd { get; private set; }

        #endregion

        #region Public Variables

        public static void Initialize(FaithAdNetworkBaseClassForConfiguretionInfo adConfiguretion)
        {

            RewardedAd = new FaithRewardedAdOnMaxAdNetwork(adConfiguretion);
            InterstitialAd = new FaithInterstitialAdOnMaxAdNetwork(adConfiguretion);
            BannerAd = new FaithBannerAdOnMaxAdNetwork(adConfiguretion);
        }

        #endregion
    }
}

