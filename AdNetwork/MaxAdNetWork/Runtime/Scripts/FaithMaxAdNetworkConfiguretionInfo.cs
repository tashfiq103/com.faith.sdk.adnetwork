namespace com.faith.sdk.adnetwork
{
    using UnityEngine;
    using UnityEngine.Events;

#if UNITY_EDITOR
    using UnityEditor;
#endif

    //[CreateAssetMenu(fileName = "FaithMaxAdNetworkConfiguretionInfo", menuName = FaithAdNetworkGeneralConfiguretionInfo.NAME_OF_SDK + "/FaithMaxAdNetworkConfiguretionInfo")]
    public class FaithMaxAdNetworkConfiguretionInfo : FaithAdNetworkBaseClassForConfiguretionInfo
    {
        #region Public Variables

        public string MaxSdkKey { get { return _maxSdkKey; } }
        public bool VerboseLogingState { get { return _verboseLogingState; } }
        public bool ShowMaxMediationDebugger { get { return _showMaxMediationDebugger; } }
        #endregion

        #region Private Variables

        [SerializeField] private string _maxSdkKey;
        [SerializeField] private bool _verboseLogingState = false;
        [SerializeField] private bool _showMaxMediationDebugger = false;

        #endregion

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
#if UNITY_EDITOR && FaithAdNetwork_Max


            _maxSdkKey = EditorGUILayout.TextField("MaxSDKKey", _maxSdkKey);
            _verboseLogingState = EditorGUILayout.Toggle("VerboseLoging State", _verboseLogingState);
            _showMaxMediationDebugger = EditorGUILayout.Toggle("MaxMediationDebugger", _showMaxMediationDebugger);

            FaithAdNetworkEditorModule.DrawHorizontalLine();
#endif
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



