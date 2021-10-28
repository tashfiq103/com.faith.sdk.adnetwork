namespace com.faith.sdk.adnetwork
{
    using UnityEngine;
    using UnityEngine.Events;
#if FaithAdNetwork_Unity
    using UnityEngine.Advertisements;
#endif

#if UNITY_EDITOR
    using UnityEditor;
#endif

    //[CreateAssetMenu(fileName = "FaithUnityAdNetworkConfiguretionInfo", menuName = FaithAdNetworkGeneralConfiguretionInfo.NAME_OF_SDK + "/FaithUnityAdNetworkConfiguretionInfo")]
    public class FaithUnityAdNetworkConfiguretionInfo : FaithAdNetworkBaseClassForConfiguretionInfo
    {
        #region Custom Variables

        private class UnityAdsInitializationCallback    :   IUnityAdsInitializationListener
        {

            private UnityAction _OnAdInitialization;

            public UnityAdsInitializationCallback(UnityAction OnAdInitialization) {
                _OnAdInitialization = OnAdInitialization;
            }

            public void OnInitializationComplete()
            {
                FaithAdNetworkLogger.Log("Unity Ads initialization complete.");
                _OnAdInitialization?.Invoke();
            }

            public void OnInitializationFailed(UnityAdsInitializationError error, string message)
            {
                FaithAdNetworkLogger.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
            }
        }

        #endregion

        #region Public Varaibles

        public string GameID
        {
            get
            {
#if UNITY_ANDROID
                return AndroidGameID;
#elif UNITY_IOS
                return iOSGameID;
#else
                return "InvalidPlatform";
#endif
            }
        }
        public string AndroidGameID { get { return _androidGameID; } }
        public string iOSGameID { get { return _iOSGameID; } }

        public bool TestMode { get { return _testMode; } }
        public bool EnablePerPlacementMode { get { return _enablePerPlacementMode; } }

        #endregion

        #region Private Variables

        [SerializeField] private string _androidGameID;
        [SerializeField] private string _iOSGameID;

        [SerializeField] private bool _testMode = false;
        [SerializeField] private bool _enablePerPlacementMode = false;

#endregion

#region Override Method

        public override bool AskForAdIds()
        {
            return true;
        }

        public override void SetNameAndIntegrationStatus()
        {
            string sdkName = "FaithAdNetwork_Unity";
            SetNameOfConfiguretion(sdkName);
#if UNITY_EDITOR
            _isSDKIntegrated = FaithAdNetworkScriptDefineSymbol.CheckUnityAdNetworkIntegrated(sdkName);
#endif
        }

        public override void PreCustomEditorGUI()
        {
#if UNITY_EDITOR && FaithAdNetwork_Unity
            EditorGUILayout.BeginVertical();
            {
                EditorGUI.indentLevel += 1;
                {
                    EditorGUILayout.BeginHorizontal();
                    {
                        EditorGUILayout.LabelField("AndroidGameID", GUILayout.Width(FaithAdNetworkGeneralConfiguretionInfo.EDITOR_LABEL_WIDTH));
                        _androidGameID = EditorGUILayout.TextField(_androidGameID);
                    }
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    {
                        EditorGUILayout.LabelField("iOSGameID", GUILayout.Width(FaithAdNetworkGeneralConfiguretionInfo.EDITOR_LABEL_WIDTH));
                        _iOSGameID = EditorGUILayout.TextField(_iOSGameID);
                    }
                    EditorGUILayout.EndHorizontal();


                    EditorGUILayout.Space(5.0f);
                    EditorGUILayout.BeginHorizontal();
                    {
                        EditorGUILayout.LabelField("TestMode", GUILayout.Width(FaithAdNetworkGeneralConfiguretionInfo.EDITOR_LABEL_WIDTH));
                        _testMode = EditorGUILayout.Toggle(_testMode);
                    }
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    {
                        EditorGUILayout.LabelField("EnablePerPlacementMode", GUILayout.Width(FaithAdNetworkGeneralConfiguretionInfo.EDITOR_LABEL_WIDTH));
                        _enablePerPlacementMode = EditorGUILayout.Toggle(_enablePerPlacementMode);
                    }
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.Space(5.0f);
                }
                EditorGUI.indentLevel -= 1;


               
            }
            EditorGUILayout.EndVertical();
#endif
        }

        public override void PostCustomEditorGUI()
        {
            
        }


        public override void Initialize(FaithAdNetworkGeneralConfiguretionInfo faithAdNetworkGeneralConfiguretionInfo, bool isATTEnable = false)
        {
#if FaithAdNetwork_Unity
            
            Advertisement.Initialize(
                    GameID,
                    TestMode,
                    EnablePerPlacementMode,
                    new UnityAdsInitializationCallback(() => { FaithUnityAdNetwork.Initialize(this); })
                );
#endif
        }

        public override bool IsBannerAdReady()
        {
#if FaithAdNetwork_Unity
            return FaithUnityAdNetwork.BannerAd.IsBannerAdReady();
#else
            return false;
#endif
        }

        public override void ShowBannerAd(string adPlacement = "banner", int playerLevel = 0)
        {
#if FaithAdNetwork_Unity
            FaithUnityAdNetwork.BannerAd.ShowBannerAd(adPlacement, playerLevel);
#endif
        }

        public override void HideBannerAd()
        {
#if FaithAdNetwork_Unity
            FaithUnityAdNetwork.BannerAd.HideBannerAd();
#endif
        }

        public override void HideCrossPromoAd()
        {
            throw new System.NotImplementedException();
        }

        public override bool IsCrossPromoAdReady()
        {
            throw new System.NotImplementedException();
        }

        public override void ShowCrossPromoAd(string adPlacement = "crossPromo")
        {
            throw new System.NotImplementedException();
        }

        public override bool IsInterstitialAdReady()
        {
#if FaithAdNetwork_Unity
            return FaithUnityAdNetwork.InterstitialAd.IsInterstitialAdReady();
#else
            return false;
#endif
        }

        public override void ShowInterstitialAd(string adPlacement = "interstitial", UnityAction OnAdFailed = null, UnityAction OnAdClosed = null)
        {
#if FaithAdNetwork_Unity
            FaithUnityAdNetwork.InterstitialAd.ShowInterstitialAd(adPlacement, OnAdFailed, OnAdClosed);
#endif
        }

        public override bool IsRewardedAdReady()
        {
#if FaithAdNetwork_Unity
            return FaithUnityAdNetwork.RewardedAd.IsRewardedAdReady();
#else
            return false;
#endif
        }

        public override void ShowRewardedAd(string adPlacement, UnityAction<bool> OnAdClosed, UnityAction OnAdFailed = null)
        {
#if FaithAdNetwork_Unity
            FaithUnityAdNetwork.RewardedAd.ShowRewardedAd(adPlacement, OnAdClosed, OnAdFailed);
#endif
        }

        #endregion

    }
}

