namespace com.faith.sdk.adnetwork
{
    using UnityEngine.Events;

    public abstract class FaithAdNetworkBaseClassForRewardedAd
    {
        #region Public Variables

        public bool IsAdRunning { get; protected set; }

        #endregion

        #region Protected Variables

        protected FaithAdNetworkBaseClassForConfiguretionInfo _adConfiguretion;

        protected bool _isEligibleForReward = false;

        protected string _adPlacement;

        protected UnityAction _OnAdFailed;
        protected UnityAction<bool> _OnAdClosed;

        #endregion

        #region Abstract Method

        public abstract bool IsRewardedAdReady();
        public abstract void ShowRewardedAd(
            string adPlacement,
            UnityAction<bool> OnAdClosed,
            UnityAction OnAdFailed = null);

        #endregion

    }
}