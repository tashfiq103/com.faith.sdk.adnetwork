namespace com.faith.sdk.adnetwork
{
    using UnityEngine;

    //[CreateAssetMenu(fileName = "FaithAdnetworkGeneralConfiguretionInfo", menuName = NAME_OF_SDK + "/FaithAdnetworkGeneralConfiguretionInfo")]
    public class FaithAdNetworkGeneralConfiguretionInfo : ScriptableObject
    {
        #region Public Variables

        public const float EDITOR_LABEL_WIDTH = 225;
        public const string NAME_OF_SDK = "FaithAdNetwork";

        public FaithAdNetworkBaseClassForConfiguretionInfo SelectedAdConfig
        {
            get {
                return _selectedAdConfiguretion;
            }
        }

        public bool CanShowInterstitialAd
        {
            get
            {
                //FaithAdNetworkLogger.Log(string.Format("RealtimeSinceStartup = {0}. _timeStampForLastInterstitialAdShown = {1}. _timeStampForLastRewardedAdShown = {2}", Time.realtimeSinceStartup, _timeStampForLastInterstitialAdShown, _timeStampForLastRewardedAdShown));

                float interstitialInterval = Time.realtimeSinceStartup - (_timeStampForLastInterstitialAdShown == 0 ? -_intervalBetweenInterstitialAd : _timeStampForLastInterstitialAdShown);
                float interstitialIntervalAfterRV = Time.realtimeSinceStartup - (_timeStampForLastRewardedAdShown == 0 ? -_intervalForInterstitialAdAfterRV : _timeStampForLastRewardedAdShown);

                int checker = 0;

                if (interstitialInterval >= _intervalBetweenInterstitialAd)
                    checker++;
                else
                {
                    FaithAdNetworkLogger.Log(string.Format("InterstitialInterval Remaining = {0}", interstitialInterval));
                }

                if (interstitialIntervalAfterRV >= _intervalForInterstitialAdAfterRV)
                    checker++;
                else
                    FaithAdNetworkLogger.Log(string.Format("InterstitialRVInterval Remaining = {0}", interstitialIntervalAfterRV));

                return (checker == 2? true : false);
            }
        }

        #endregion

        #region Private Variables

#if UNITY_EDITOR
        [HideInInspector, SerializeField] private bool _showGeneralSetting = false;
        [HideInInspector, SerializeField] private bool _showAdNetworks = false;
        [HideInInspector, SerializeField] private bool _showDebuggingSetting = false;
#endif

        [HideInInspector, SerializeField] private FaithAdNetworkBaseClassForConfiguretionInfo _selectedAdConfiguretion;

        [HideInInspector, SerializeField] private bool _autoInitialize = true;

        [HideInInspector, SerializeField] private float _intervalBetweenInterstitialAd = 20;
        [HideInInspector, SerializeField] private float _intervalForInterstitialAdAfterRV = 15;

        [HideInInspector, SerializeField] private bool _showAdNetworkLogInConsole = true;

        [HideInInspector, SerializeField] private Color _infoLogColor = Color.cyan;
        [HideInInspector, SerializeField] private Color _warningLogColor = Color.yellow;
        [HideInInspector, SerializeField] private Color _errorLogColor = Color.red;

        private float _timeStampForLastInterstitialAdShown = 0;
        private float _timeStampForLastRewardedAdShown = 0;

        #endregion

        #region Public Variables

        public bool IsAutoInitialize { get { return _autoInitialize; } }

        public float IntervalBetweenInterstitialAd { get { return _intervalBetweenInterstitialAd; } }
        public float IntervalForInterstitialAdAfterRV { get { return _intervalForInterstitialAdAfterRV; } }

        public bool ShowAdNetworkLogInConsole { get { return _showAdNetworkLogInConsole; } }

        public Color InfoLogColor { get { return _infoLogColor; } }
        public Color WarningLogColor { get { return _warningLogColor; } }
        public Color ErrorLogColor { get { return _errorLogColor; } }

        #endregion

        #region Public Callback

        public void Reset()
        {
            _timeStampForLastInterstitialAdShown = 0;
            _timeStampForLastRewardedAdShown = 0;
        }

        public void SetIntervalBetweenInterstitialAd(float value) { _intervalBetweenInterstitialAd = value; }
        public void SetIntervalForInterstitialAdAfterRV(float value) { _intervalForInterstitialAdAfterRV = value; }

        public void RecordInterstitialAdComplete() { _timeStampForLastInterstitialAdShown = Time.realtimeSinceStartup; }
        public void RecordRVAdComplete(){ _timeStampForLastRewardedAdShown = Time.realtimeSinceStartup;}

        #endregion

    }
}

