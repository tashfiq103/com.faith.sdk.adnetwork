namespace com.faith.sdk.adnetwork
{
    using UnityEngine;
    using UnityEngine.Events;

    public static class FaithRewardedAdNetwork
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
                return _faithAdNetworkGeneralConfiguretionInfo.SelectedAdConfig.IsRewardedAdReady();
            }

            return false;
        }

        public static void Show(
            string adPlacement,
            UnityAction<bool> OnAdClosed,
            UnityAction OnAdFailed = null)
        {
            if (_faithAdNetworkGeneralConfiguretionInfo.SelectedAdConfig != null)
            {
                _faithAdNetworkGeneralConfiguretionInfo.SelectedAdConfig.ShowRewardedAd(
                        adPlacement,
                        (isEligibleForReward) =>
                        {
                            OnAdClosed.Invoke(isEligibleForReward);


                        },
                        () => {

                            OnAdFailed?.Invoke();

                        }
                    );
            }
            else
            {

                FaithAdNetworkLogger.LogError("Failed to display 'RewardedAd' as no 'AdNetwork' is selected/enabled");
            }
        }

        #endregion
    }

}