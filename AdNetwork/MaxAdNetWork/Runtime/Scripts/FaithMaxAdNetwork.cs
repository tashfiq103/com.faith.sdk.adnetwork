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

        private static bool _isMaxSdkInitialized = false;
        private static MaxSdkBase.SdkConfiguration _sdkConfiguration;
        private static Queue<UnityAction<MaxSdkBase.SdkConfiguration>> _waitingQueueForMaxSdkToBeInitialized = new Queue<UnityAction<MaxSdkBase.SdkConfiguration>>();

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

                foreach (UnityAction<MaxSdkBase.SdkConfiguration> OnMaxInitalized in _waitingQueueForMaxSdkToBeInitialized)
                {
                    OnMaxInitalized?.Invoke(_sdkConfiguration);
                }

                _isMaxSdkInitialized = true;
            };

            MaxSdk.SetSdkKey(maxAdNetworkConfiguretionInfo.MaxSdkKey);
            MaxSdk.SetVerboseLogging(maxAdNetworkConfiguretionInfo.VerboseLogingState);
            MaxSdk.InitializeSdk();
            
        }

        public static void OnRecievingCallbackForMaxSdkInitialization(UnityAction<MaxSdkBase.SdkConfiguration> OnMaxInitialized)
        {
            if (!_isMaxSdkInitialized)
            {
                _waitingQueueForMaxSdkToBeInitialized.Enqueue(OnMaxInitialized);
            }
            else {
                OnMaxInitialized?.Invoke(_sdkConfiguration);
            }
        }

        #endregion
    }
#endif
}

