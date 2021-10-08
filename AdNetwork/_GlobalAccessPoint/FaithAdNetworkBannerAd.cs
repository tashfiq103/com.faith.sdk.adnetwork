namespace com.faith.sdk.adnetwork
{
    using UnityEngine;

    public static class FaithAdNetworkBannerAd
    {
        #region Private Variables

        private static FaithAdnetworkGeneralConfiguretionInfo _faithAdNetworkGeneralConfiguretionInfo;

        #endregion

        #region Configuretion

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnGameStart()
        {
            _faithAdNetworkGeneralConfiguretionInfo = Resources.Load<FaithAdnetworkGeneralConfiguretionInfo>("FaithAdnetworkGeneralConfiguretionInfo");
        }

        

        #endregion

        #region Public Callback

        public static bool IsAdReady()
        {

            if (_faithAdNetworkGeneralConfiguretionInfo.SelectedAdConfig != null)
            {
                return _faithAdNetworkGeneralConfiguretionInfo.SelectedAdConfig.IsBannerAdReady();
            }

            FaithAdNetworkLogger.LogWarning("BannerAd not ready");

            return false;
        }

        public static void Show(string adPlacement = "banner", int playerLevel = 0)
        {

            if (_faithAdNetworkGeneralConfiguretionInfo.SelectedAdConfig != null)
            {
                if (IsAdReady())
                {
                    _faithAdNetworkGeneralConfiguretionInfo.SelectedAdConfig.ShowBannerAd(
                        adPlacement,
                        playerLevel
                    );

                }
                else
                {

                    
                }
            }
            else
            {

                FaithAdNetworkLogger.LogError("Failed to display 'BannerAd' as no 'AdNetwork' is selected/enabled");
            }
        }

        public static void Hide()
        {

            if (_faithAdNetworkGeneralConfiguretionInfo.SelectedAdConfig != null)
            {
                _faithAdNetworkGeneralConfiguretionInfo.SelectedAdConfig.HideBannerAd();
            }
        }

        #endregion
    }
}
