namespace com.faith.sdk.adnetwork
{
    using UnityEngine;
    using UnityEngine.Events;

    public static class FaithInterstitialAdNetwork
    {
        #region Private Variables

        private static FaithAdNetworkGeneralConfiguretionInfo _faithAdNetworkGeneralConfiguretionInfo;


        #endregion

        #region Configuretion

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnGameStart()
        {
            _faithAdNetworkGeneralConfiguretionInfo = Resources.Load<FaithAdNetworkGeneralConfiguretionInfo>("FaithAdnetworkGeneralConfiguretionInfo");
        }

        #endregion

        #region Public Callback

        public static bool IsAdReady()
        {

            if (_faithAdNetworkGeneralConfiguretionInfo.SelectedAdConfig != null)
            {
                return _faithAdNetworkGeneralConfiguretionInfo.SelectedAdConfig.IsInterstitialAdReady();
            }

            FaithAdNetworkLogger.LogWarning("InterstitialAd not ready");

            return false;
        }

        public static void Show(
            string adPlacement = "interstitial",
            UnityAction OnAdFailed = null,
            UnityAction OnAdClosed = null)
        {
            if (_faithAdNetworkGeneralConfiguretionInfo.SelectedAdConfig != null)
            {
                if (_faithAdNetworkGeneralConfiguretionInfo.CanShowInterstitialAd)
                {
                    _faithAdNetworkGeneralConfiguretionInfo.SelectedAdConfig.ShowInterstitialAd(
                        adPlacement,
                        OnAdClosed: () => {

                            FaithAdNetworkManager.RecordInterstitialAdComplete();
                            OnAdClosed?.Invoke();


                        },
                        OnAdFailed: () => {

                            OnAdFailed?.Invoke();


                        }
                    );
                }
            }
            else
            {

                FaithAdNetworkLogger.LogError("Failed to display 'InterstialAd' as no 'AdNetwork' is selected/enabled");
            }
        }

        #endregion
    }


}
