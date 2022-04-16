namespace com.faith.sdk.adnetwork
{
#if FaithAdNetwork_Max
    using UnityEngine;
    using UnityEngine.Events;
    using System.Collections.Generic;
    public static class FaithMaxAdNetwork
    {
        #region Public Variables

        public static FaithRewardedAdOnMaxAdNetwork RewardedAd { get; private set; }
        public static FaithInterstitialAdOnMaxAdNetwork InterstitialAd { get; private set; }
        public static FaithBannerAdOnMaxAdNetwork BannerAd { get; private set; }

        #endregion

        #region Private Variabels

        public static bool HasConcent { get; private set; } = false;
        public static bool IsIOS14_5Plus { get; private set; } = false;

        private static bool _isMaxSdkInitialized = false;
        private static MaxSdkBase.SdkConfiguration _sdkConfiguration;
        private static Queue<UnityAction<MaxSdkBase.SdkConfiguration, bool>> _waitingQueueForMaxSdkToBeInitialized = new Queue<UnityAction<MaxSdkBase.SdkConfiguration, bool>>();

        #endregion

        #region Public Variables

        public static void Initialize(FaithAdNetworkBaseClassForConfiguretionInfo adConfiguretion)
        {
            FaithMaxAdNetworkConfiguretionInfo maxAdNetworkConfiguretionInfo = (FaithMaxAdNetworkConfiguretionInfo)adConfiguretion;
            MaxSdkCallbacks.OnSdkInitializedEvent += (MaxSdkBase.SdkConfiguration sdkConfiguration) =>
            {
                _sdkConfiguration = sdkConfiguration;

                RewardedAd = new FaithRewardedAdOnMaxAdNetwork(adConfiguretion);
                InterstitialAd = new FaithInterstitialAdOnMaxAdNetwork(adConfiguretion);
                BannerAd = new FaithBannerAdOnMaxAdNetwork(adConfiguretion);

#if UNITY_IOS
                if (MaxSdkUtils.CompareVersions(UnityEngine.iOS.Device.systemVersion, "14.5") != MaxSdkUtils.VersionComparisonResult.Lesser)
                {
                    // Note that App transparency tracking authorization can be checked via `sdkConfiguration.AppTrackingStatus` for Unity Editor and iOS targets
                    // 1. Set Facebook ATE flag here, THEN
                    HasConcent = (sdkConfiguration.AppTrackingStatus == MaxSdkBase.AppTrackingStatus.Authorized);
                    IsIOS14_5Plus = true;

                }
                else
                {
                    HasConcent = true;
                }
#else
                HasConcent = true;
#endif

                while (_waitingQueueForMaxSdkToBeInitialized.Count > 0)
                {
                    _waitingQueueForMaxSdkToBeInitialized.Dequeue()?.Invoke(_sdkConfiguration, HasConcent);
                }

                _isMaxSdkInitialized = true;

                if(maxAdNetworkConfiguretionInfo.ShowMaxMediationDebugger)
                {
                    MaxSdk.ShowMediationDebugger();
                }

                FaithAdNetworkLogger.Log("MaxInitialized");
            };

            MaxSdk.SetSdkKey(maxAdNetworkConfiguretionInfo.MaxSdkKey);
            MaxSdk.SetVerboseLogging(maxAdNetworkConfiguretionInfo.VerboseLogingState);
            MaxSdk.InitializeSdk();
            
        }

        public static void OnRecievingCallbackForMaxSdkInitialization(UnityAction<MaxSdkBase.SdkConfiguration, bool> OnMaxInitialized)
        {
            if (!_isMaxSdkInitialized)
            {
                _waitingQueueForMaxSdkToBeInitialized.Enqueue(OnMaxInitialized);
            }
            else {
                OnMaxInitialized?.Invoke(_sdkConfiguration, HasConcent);
            }
        }

        #endregion
    }
#endif
}

