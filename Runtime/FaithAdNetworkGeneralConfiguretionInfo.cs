namespace com.faith.sdk.adnetwork
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "FaithAdnetworkGeneralConfiguretionInfo", menuName = NAME_OF_SDK + "/FaithAdnetworkGeneralConfiguretionInfo")]
    public class FaithAdnetworkGeneralConfiguretionInfo : ScriptableObject
    {
        #region Public Variables

        public const float EDITOR_LABEL_WIDTH = 200;
        public const string NAME_OF_SDK = "FaithAdNetwork";

        #endregion

        #region Private Variables

#if UNITY_EDITOR
        [HideInInspector, SerializeField] private bool _showGeneralSetting = false;
        [HideInInspector, SerializeField] private bool _showAdNetworks = false;
        [HideInInspector, SerializeField] private bool _showDebuggingSetting = false;
#endif

        [HideInInspector, SerializeField] private bool _autoInitialize = true;

        [HideInInspector, SerializeField] private bool _showAdNetworkLogInConsole = true;

        [HideInInspector, SerializeField] private Color _infoLogColor = Color.cyan;
        [HideInInspector, SerializeField] private Color _warningLogColor = Color.yellow;
        [HideInInspector, SerializeField] private Color _errorLogColor = Color.red;


        #endregion

        #region Public Variables

        public bool IsAutoInitialize { get { return _autoInitialize; } }

        public bool ShowAdNetworkLogInConsole { get { return _showAdNetworkLogInConsole; } }

        public Color InfoLogColor { get { return _infoLogColor; } }
        public Color WarningLogColor { get { return _warningLogColor; } }
        public Color ErrorLogColor { get { return _errorLogColor; } }

        #endregion

    }
}

