namespace com.faith.sdk.adnetwork
{
    using UnityEngine;
    using UnityEngine.Events;

    public abstract class FaithAdNetworkBaseClassForConfiguretionInfo : ScriptableObject
    {
        #region Public Variables

        public string NameOfConfiguretion { get { return _nameOfConfiguretion; } }

        public string AdUnitId_RewardedAd
        {
            get
            {
#if UNITY_ANDROID
                return _adUnitIdForRewardedAd_Android;

#elif UNITY_IOS
                return _adUnitIdForRewardedAd_iOS;
#else
                return "";
#endif
            }
        }
        public bool IsRewardedAdEnabled { get { return _enableRewardedAd; } }



        public string AdUnitId_InterstitialAd
        {
            get
            {
#if UNITY_ANDROID
                return _adUnitIdForInterstitialAd_Android;
#elif UNITY_IOS
                return _adUnitIdForInterstitialAd_iOS;
#else
                return "";
#endif
            }
        }
        public bool IsInterstitialAdEnabled { get { return _enableInterstitialAd; } }


        public string AdUnitId_BannerAd
        {
            get
            {
#if UNITY_ANDROID
                return _adUnitIdForBannerAd_Android;
#elif UNITY_IOS
                return _adUnitIdForBannerAd_iOS;
#else
                return "";
#endif
            }
        }
        public bool IsBannerAdEnabled { get { return _enableBannerAd; } }
        public bool IsShowBannerAdManually { get { return _showBannerAdManually; } }
        public bool IsCrossPromoAdEnabled { get { return _enableCrossPromoAd; } }

        #endregion

        #region Private Variables


#if UNITY_EDITOR


        [HideInInspector, SerializeField] private bool _showRewardedAdSettings;
        [HideInInspector, SerializeField] private bool _showInterstitialAdSettings;
        [HideInInspector, SerializeField] private bool _showBannerAdSettings;
        [HideInInspector, SerializeField] private bool _showCrossPromoAdSettings;
#endif


        [HideInInspector, SerializeField] protected string  _nameOfConfiguretion;
        [HideInInspector, SerializeField] protected bool    _isSDKIntegrated;

        [Space(5.0f)]
        [HideInInspector, SerializeField] private bool _enableRewardedAd;
        [HideInInspector, SerializeField] private string _adUnitIdForRewardedAd_Android;
        [HideInInspector, SerializeField] private string _adUnitIdForRewardedAd_iOS;

        [Space(5.0f)]
        [HideInInspector, SerializeField] private bool _enableInterstitialAd;
        [HideInInspector, SerializeField] private string _adUnitIdForInterstitialAd_Android;
        [HideInInspector, SerializeField] private string _adUnitIdForInterstitialAd_iOS;

        [Space(5.0f)]
        [HideInInspector, SerializeField] private bool _enableBannerAd;
        [HideInInspector, SerializeField] private string _adUnitIdForBannerAd_Android;
        [HideInInspector, SerializeField] private string _adUnitIdForBannerAd_iOS;
        [HideInInspector, SerializeField] private bool _showBannerAdManually;

        [Space(5.0f)]
        [HideInInspector, SerializeField] private bool _enableCrossPromoAd;

        #endregion

        #region Protected Method

        /// <summary>
        /// Editor Only
        /// </summary>
        /// <param name="scriptDefineSymbol"></param>
        protected void SetNameOfConfiguretion(string scriptDefineSymbol, string concatinate = "")
        {
            string[] splited = scriptDefineSymbol.Split('_');
            _nameOfConfiguretion = splited[1] + concatinate;
        }

        #endregion

        #region Abstract Method

        public abstract void SetNameAndIntegrationStatus();

        public abstract void Initialize(FaithAdNetworkGeneralConfiguretionInfo faithAdNetworkGeneralConfiguretionInfo, bool isATTEnable = false);

        /// <summary>
        /// You can write your editor script for the variables on your derived class before the template editor script
        /// </summary>
        public abstract void PreCustomEditorGUI();

        /// <summary>
        /// You can write your editor script for the variables on your derived class after the template editor script
        /// </summary>
        public abstract void PostCustomEditorGUI();

        #endregion

        #region Abstract Method

        public abstract bool AskForAdIds();

        public abstract bool IsRewardedAdReady();
        public abstract void ShowRewardedAd(
            string adPlacement,
            UnityAction<bool> OnAdClosed,
            UnityAction OnAdFailed = null);

        public abstract bool IsInterstitialAdReady();
        public abstract void ShowInterstitialAd(
            string adPlacement = "interstitial",
            UnityAction OnAdFailed = null,
            UnityAction OnAdClosed = null);

        public abstract bool IsBannerAdReady();
        public abstract void ShowBannerAd(string adPlacement = "banner", int playerLevel = 0);
        public abstract void HideBannerAd();

        public abstract bool IsCrossPromoAdReady();
        public abstract void ShowCrossPromoAd(string adPlacement = "crossPromo");
        public abstract void HideCrossPromoAd();

        #endregion
    }
}


