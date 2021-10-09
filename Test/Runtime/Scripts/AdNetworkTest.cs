namespace com.faith.sdk.adnetwork
{
    using UnityEngine;
    using UnityEngine.UI;
    public class AdNetworkTest : MonoBehaviour
    {
#region Variables

        [SerializeField] private Button _bannerAdShowButton;
        [SerializeField] private Button _bannerAdHideButton;
        [SerializeField] private Button _interstitialAdButton;
        [SerializeField] private Button _rewardedAdButton;
        [SerializeField] private Button _mrecAdButton;

#endregion

#region Mono Behaviour

        private void Awake()
        {
            _bannerAdShowButton.onClick.AddListener(() =>
            {
                FaithBannerAdNetwork.Show();
            });

            _bannerAdHideButton.onClick.AddListener(() =>
            {
                FaithBannerAdNetwork.Hide();
            });

            _interstitialAdButton.onClick.AddListener(() =>
            {
                FaithInterstitialAdNetwork.Show();
            });

            _rewardedAdButton.onClick.AddListener(() =>
            {
                FaithRewardedAdNetwork.Show(
                    "testAd",
                    (isRewarded) => {

                        FaithAdNetworkLogger.Log(string.Format("RewardedAd Status : {0}", isRewarded));
                    });
            });

            _mrecAdButton.onClick.AddListener(() =>
            {
                FaithAdNetworkLogger.LogWarning("Not Implemented");
            });
        }

        private void Start()
        {
            FaithAdNetworkGeneralConfiguretionInfo generalConfiguretion = Resources.Load<FaithAdNetworkGeneralConfiguretionInfo>("FaithAdNetworkGeneralConfiguretionInfo");
            if (!generalConfiguretion.IsAutoInitialize)
                FaithAdNetworkManager.Initialize();
        }

        #endregion
    }
}

