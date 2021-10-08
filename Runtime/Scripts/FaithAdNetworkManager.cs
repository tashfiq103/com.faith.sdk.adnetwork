namespace com.faith.sdk.adnetwork
{
    using UnityEngine;

    public static class FaithAdNetworkManager
    {
        public static bool IsATTEnabled
        {
            get;
            private set;
        } = false;

        public static bool IsInitialized
        {
            get;
            private set;
        } = false;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnGameStart()
        {
            FaithAdNetworkGeneralConfiguretionInfo faithAnalyticsGeneralConfiguretionInfo = Resources.Load<FaithAdNetworkGeneralConfiguretionInfo>("FaithAnalyticsGeneralConfiguretionInfo");

            if (faithAnalyticsGeneralConfiguretionInfo.IsAutoInitialize) {

                FaithAdNetworkLogger.LogWarning(string.Format("IsATTEnabled = {0}, as by-default, the value is set to 'false'. If you want to pass the 'ATTStatus' manually, try to manually initialize the 'SDKs'", IsATTEnabled));
                Initialize();
            }
        }

        public static void Initialize(bool IsATTEnabled = false) {

            FaithAdNetworkManager.IsATTEnabled = IsATTEnabled;

            FaithAdNetworkGeneralConfiguretionInfo faithAdNetworkGeneralConfiguretionInfo = Resources.Load<FaithAdNetworkGeneralConfiguretionInfo>("FaithAnalyticsGeneralConfiguretionInfo");

            Object[] adNetworkConfiguretionObjects = Resources.LoadAll("", typeof(FaithAdNetworkBaseClassForConfiguretionInfo));
            foreach (Object analyticsConfiguretionObject in adNetworkConfiguretionObjects)
            {

                FaithAdNetworkBaseClassForConfiguretionInfo faithAdNetworkConfiguretion = (FaithAdNetworkBaseClassForConfiguretionInfo)analyticsConfiguretionObject;
                if (faithAdNetworkConfiguretion != null)
                    faithAdNetworkConfiguretion.Initialize(faithAdNetworkGeneralConfiguretionInfo, IsATTEnabled);
            }

            IsInitialized = true;
        }
    }
}

