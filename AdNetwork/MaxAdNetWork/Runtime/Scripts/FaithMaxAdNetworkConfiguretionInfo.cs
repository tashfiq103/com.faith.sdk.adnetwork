namespace com.faith.sdk.adnetwork
{
    using UnityEngine;
    using UnityEngine.Events;

    //[CreateAssetMenu(fileName = "FaithMaxAdNetworkConfiguretionInfo", menuName = FaithAdNetworkGeneralConfiguretionInfo.NAME_OF_SDK + "/FaithMaxAdNetworkConfiguretionInfo")]
    public class FaithMaxAdNetworkConfiguretionInfo : FaithAdNetworkBaseClassForConfiguretionInfo
    {
        public override bool AskForAdIds()
        {
            return true;
        }

        public override void SetNameAndIntegrationStatus()
        {
            string sdkName = "FaithAdNetwork_Max";
            SetNameOfConfiguretion(sdkName);
#if UNITY_EDITOR
            _isSDKIntegrated = FaithAdNetworkScriptDefineSymbol.CheckMaxAdNetworkIntegrated(sdkName);
#endif
        }

        public override void PostCustomEditorGUI()
        {

        }

        public override void PreCustomEditorGUI()
        {

        }

        public override void Initialize(FaithAdNetworkGeneralConfiguretionInfo faithAdNetworkGeneralConfiguretionInfo, bool isATTEnable = false)
        {
#if FaithAdNetwork_Max
            FaithMaxAdNetwork.Initialize(this);
#endif
        }

        public override bool IsBannerAdReady()
        {
#if FaithAdNetwork_Max
            return FaithMaxAdNetwork.BannerAd.IsBannerAdReady();
#else
            return false;
#endif
        }

        public override void ShowBannerAd(string adPlacement = "banner", int playerLevel = 0)
        {
#if FaithAdNetwork_Max
            FaithMaxAdNetwork.BannerAd.ShowBannerAd(adPlacement, playerLevel);
#endif
        }

        public override void HideBannerAd()
        {
#if FaithAdNetwork_Max
            FaithMaxAdNetwork.BannerAd.HideBannerAd();
#endif
        }

        public override bool IsCrossPromoAdReady()
        {
#if FaithAdNetwork_Max

#endif
            return false;
        }

        public override void ShowCrossPromoAd(string adPlacement = "crossPromo")
        {
#if FaithAdNetwork_Max

#endif
        }

        public override void HideCrossPromoAd()
        {
#if FaithAdNetwork_Max

#endif
        }


        public override bool IsInterstitialAdReady()
        {
#if FaithAdNetwork_Max
            return FaithMaxAdNetwork.InterstitialAd.IsInterstitialAdReady();
#else
        return false;
#endif

        }

        public override void ShowInterstitialAd(string adPlacement = "interstitial", UnityAction OnAdFailed = null, UnityAction OnAdClosed = null)
        {
#if FaithAdNetwork_Max
            FaithMaxAdNetwork.InterstitialAd.ShowInterstitialAd(adPlacement, OnAdFailed, OnAdClosed);
#endif
        }

        public override bool IsRewardedAdReady()
        {
#if FaithAdNetwork_Max
            return FaithMaxAdNetwork.RewardedAd.IsRewardedAdReady();
#else
            return false;
#endif
        }

        public override void ShowRewardedAd(string adPlacement, UnityAction<bool> OnAdClosed, UnityAction OnAdFailed = null)
        {
#if FaithAdNetwork_Max
            FaithMaxAdNetwork.RewardedAd.ShowRewardedAd(adPlacement, OnAdClosed, OnAdFailed);
#endif
        }
    }
}



