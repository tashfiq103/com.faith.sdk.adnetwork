namespace com.faith.sdk.adnetwork
{
    using UnityEngine;
    using UnityEngine.Events;

    //[CreateAssetMenu(fileName = "FaithLionKitAdNetworkConfiguretionInfo", menuName = FaithAdNetworkGeneralConfiguretionInfo.NAME_OF_SDK + "/FaithLionKitAdNetworkConfiguretionInfo")]
    public class FaithLionKitAdNetworkConfiguretionInfo : FaithAdNetworkBaseClassForConfiguretionInfo
    {
        public override void Initialize(FaithAdNetworkGeneralConfiguretionInfo faithAdNetworkGeneralConfiguretionInfo, bool isATTEnable = false)
        {
#if FaithAdNetwork_LionKit
            FaithLionKitAdNetwork.Initialize(this);
#endif
        }

        public override bool IsBannerAdReady()
        {
#if FaithAdNetwork_LionKit
            return FaithLionKitAdNetwork.BannerAd.IsBannerAdReady();
#else
            return false;
#endif
        }

        public override void ShowBannerAd(string adPlacement = "banner", int playerLevel = 0)
        {
#if FaithAdNetwork_LionKit
            FaithLionKitAdNetwork.BannerAd.ShowBannerAd(adPlacement, playerLevel);
#endif
        }

        public override void HideBannerAd()
        {
#if FaithAdNetwork_LionKit
            FaithLionKitAdNetwork.BannerAd.HideBannerAd();
#endif
        }

        public override bool IsInterstitialAdReady()
        {
#if FaithAdNetwork_LionKit
            return FaithLionKitAdNetwork.InterstitialAd.IsInterstitialAdReady();
#else
            return false;
#endif
        }

        public override void ShowInterstitialAd(string adPlacement = "interstitial", UnityAction OnAdFailed = null, UnityAction OnAdClosed = null)
        {
#if FaithAdNetwork_LionKit
            FaithLionKitAdNetwork.InterstitialAd.ShowInterstitialAd(adPlacement, OnAdFailed, OnAdClosed);
#endif
        }

        public override bool IsRewardedAdReady()
        {
#if FaithAdNetwork_LionKit
            return FaithLionKitAdNetwork.RewardedAd.IsRewardedAdReady();
#else
            return false;
#endif
        }

        public override void ShowRewardedAd(string adPlacement, UnityAction<bool> OnAdClosed, UnityAction OnAdFailed = null)
        {
#if FaithAdNetwork_LionKit
            FaithLionKitAdNetwork.RewardedAd.ShowRewardedAd(adPlacement, OnAdClosed, OnAdFailed);
#endif
        }

        public override void SetNameAndIntegrationStatus()
        {
            string sdkName = "FaithAdNetwork_LionKit";
            SetNameOfConfiguretion(sdkName);
#if UNITY_EDITOR
            _isSDKIntegrated = FaithAdNetworkScriptDefineSymbol.CheckLionKitIntegration(sdkName);
#endif
        }

        public override bool IsCrossPromoAdReady()
        {
            throw new System.NotImplementedException();
        }

        public override void ShowCrossPromoAd(string adPlacement = "crossPromo")
        {
            throw new System.NotImplementedException();
        }

        public override void HideCrossPromoAd()
        {
            throw new System.NotImplementedException();
        }

        public override bool AskForAdIds()
        {
            return false;
        }

        public override void PreCustomEditorGUI()
        {

        }

        public override void PostCustomEditorGUI()
        {

        }
    }
}

