namespace com.faith.sdk.adnetwork
{
#if UNITY_EDITOR
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEditor;

    public class FaithAdNetworkIntegrationManagerEditorWindow : EditorWindow
    {
        #region Private Variables

        private static EditorWindow _reference;


        private bool _IsInformationFetched = false;
        private Vector2 _scrollPosition;

        private GUIStyle _settingsTitleStyle;
        private GUIStyle _hyperlinkStyle;
        
        private List<FaithAdNetworkBaseClassForConfiguretionInfo> _listOfAdNetworkConfiguretion;

        private const string _linkForDownload = "https://github.com/tashfiq103/com.faith.sdk.adNetwork";
        private const string _linkForDocumetation = "https://github.com/tashfiq103/com.faith.sdk.adNetwork/blob/main/README.md";

        #endregion

        #region Private Variables   :   FaithAdNetworkConfiguretionInfo

        private FaithAdNetworkGeneralConfiguretionInfo  _faithAdNetworkGeneralConfiguretionInfo;
        private SerializedObject                        _serializedFaithAdNetworkGeneralConfiguretionInfo;

        private GUIContent _generalSettingContent;
        private GUIContent _adNetworkSettingContent;
        private GUIContent _debuggingSettingContent;

        private SerializedProperty _selectedAdConfiguretion;

        private SerializedProperty _autoInitialize;

        private SerializedProperty _showGeneralSettings;
        private SerializedProperty _showAdNetworks;
        private SerializedProperty _showDebuggingSettings;

        private SerializedProperty _showAdNetworkLogInConsole;

        private SerializedProperty _infoLogColor;
        private SerializedProperty _warningLogColor;
        private SerializedProperty _errorLogColor;

        #endregion

        #region Editor

        [MenuItem("Faith/FaithAdNetwork Integration Manager")]
        public static void Create()
        {
            if (_reference == null)
            {
                _reference = GetWindow<FaithAdNetworkIntegrationManagerEditorWindow>("FaithAdNetwork Integration Manager", typeof(FaithAdNetworkIntegrationManagerEditorWindow));
                _reference.minSize = new Vector2(340, 240);
            }
            else
            {
                _reference.Show();
            }
            _reference.Focus();
        }

        private void OnEnable()
        {
            FetchAllTheReference();

        }

        private void OnDisable()
        {
            _IsInformationFetched = false;
        }

        private void OnFocus()
        {
            FetchAllTheReference();
        }

        private void OnLostFocus()
        {
            _IsInformationFetched = false;
        }

        private void OnGUI()
        {

            if (!_IsInformationFetched)
            {
                FetchAllTheReference();
                _IsInformationFetched = true;
            }

            _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition, false, false);
            {
                EditorGUILayout.Space();

                EditorGUI.indentLevel += 1;
                {
                    GeneralSettingGUI();

                    EditorGUILayout.Space();
                    AdNetworkSettingsGUI();

                    EditorGUILayout.Space();
                    DebuggingSettingsGUI();
                }
                EditorGUI.indentLevel -= 1;
            }
            EditorGUILayout.EndScrollView();
        }

        #endregion

        #region CustomGUI

        private void DrawHeaderGUI(string title, ref GUIContent gUIContent, ref GUIStyle gUIStyle, ref SerializedProperty serializedProperty)
        {

            EditorGUILayout.BeginVertical(GUI.skin.box);
            {
                if (GUILayout.Button(gUIContent, gUIStyle, GUILayout.Width(EditorGUIUtility.currentViewWidth)))
                {
                    serializedProperty.boolValue = !serializedProperty.boolValue;
                    serializedProperty.serializedObject.ApplyModifiedProperties();

                    gUIContent = new GUIContent(
                        "[" + (!serializedProperty.boolValue ? "+" : "-") + "] " + title
                    );
                }
            }
            EditorGUILayout.EndVertical();
        }

        private void DrawAdNetworkGUI(FaithAdNetworkBaseClassForConfiguretionInfo adNetworkConfiguretion)
        {
            //Referencing Variables
            SerializedObject serailizedAdConfiguretion = new SerializedObject(adNetworkConfiguretion);

            SerializedProperty _nameOfConfiguretion = serailizedAdConfiguretion.FindProperty("_nameOfConfiguretion");
            SerializedProperty _isSDKIntegrated = serailizedAdConfiguretion.FindProperty("_isSDKIntegrated");

            SerializedProperty _showSettings = serailizedAdConfiguretion.FindProperty("_showSettings");
            SerializedProperty _showRewardedAdSettings = serailizedAdConfiguretion.FindProperty("_showRewardedAdSettings");
            SerializedProperty _showInterstitialAdSettings = serailizedAdConfiguretion.FindProperty("_showInterstitialAdSettings");
            SerializedProperty _showBannerAdSettings = serailizedAdConfiguretion.FindProperty("_showBannerAdSettings");
            SerializedProperty _showCrossPromoAdSettings = serailizedAdConfiguretion.FindProperty("_showCrossPromoAdSettings");

            SerializedProperty _enableRewardedAd = serailizedAdConfiguretion.FindProperty("_enableRewardedAd");
            SerializedProperty _adUnitIdForRewardedAd_Android = serailizedAdConfiguretion.FindProperty("_adUnitIdForRewardedAd_Android");
            SerializedProperty _adUnitIdForRewardedAd_iOS = serailizedAdConfiguretion.FindProperty("_adUnitIdForRewardedAd_iOS");

            SerializedProperty _enableInterstitialAd = serailizedAdConfiguretion.FindProperty("_enableInterstitialAd");
            SerializedProperty _adUnitIdForInterstitialAd_Android = serailizedAdConfiguretion.FindProperty("_adUnitIdForInterstitialAd_Android");
            SerializedProperty _adUnitIdForInterstitialAd_iOS = serailizedAdConfiguretion.FindProperty("_adUnitIdForInterstitialAd_iOS");

            SerializedProperty _enableBannerAd = serailizedAdConfiguretion.FindProperty("_enableBannerAd");
            SerializedProperty _adUnitIdForBannerAd_Android = serailizedAdConfiguretion.FindProperty("_adUnitIdForBannerAd_Android");
            SerializedProperty _adUnitIdForBannerAd_iOS = serailizedAdConfiguretion.FindProperty("_adUnitIdForBannerAd_iOS");
            SerializedProperty _showBannerAdManually = serailizedAdConfiguretion.FindProperty("_showBannerAdManually");

            SerializedProperty _enableCrossPromoAd = serailizedAdConfiguretion.FindProperty("_enableCrossPromoAd");

            string displayName_AdUnitId_Android = "AdUnitID Android";
            string displayName_AdUnitId_iOS = "AdUnitID iOS";

            //Setting Titles
            GUIContent titleContent = new GUIContent(
                    "[" + (!_showSettings.boolValue ? "+" : "-") + "] " + (_nameOfConfiguretion.stringValue + (_isSDKIntegrated.boolValue ? "" : " - (SDK Not Found)"))
                );
            GUIStyle titleStyle = new GUIStyle(EditorStyles.boldLabel);
            titleStyle.alignment = TextAnchor.MiddleLeft;
            titleStyle.padding.left = 18;

            EditorGUI.BeginDisabledGroup(!_isSDKIntegrated.boolValue);
            {
                EditorGUILayout.BeginHorizontal(GUI.skin.box);
                {
                    if (GUILayout.Button(titleContent, titleStyle, GUILayout.Width(EditorGUIUtility.currentViewWidth - 100f)))
                    {
                        _showSettings.boolValue = !_showSettings.boolValue;
                        _showSettings.serializedObject.ApplyModifiedProperties();

                        titleContent = new GUIContent(
                            "[" + (!_showSettings.boolValue ? "+" : "-") + "] " + (_nameOfConfiguretion.stringValue + (_isSDKIntegrated.boolValue ? "" : " - (SDK Not Found)"))
                        );
                    }

                    if (_faithAdNetworkGeneralConfiguretionInfo.SelectedAdConfig == adNetworkConfiguretion)
                    {
                        if (GUILayout.Button("Disable", GUILayout.Width(80)))
                        {
                            _selectedAdConfiguretion.objectReferenceValue = null;
                            _selectedAdConfiguretion.serializedObject.ApplyModifiedProperties();
                        }
                    }
                    else
                    {
                        if (GUILayout.Button("Enable", GUILayout.Width(80)))
                        {
                            _selectedAdConfiguretion.objectReferenceValue = adNetworkConfiguretion;
                            _selectedAdConfiguretion.serializedObject.ApplyModifiedProperties();
                        }
                    }

                    GUILayout.FlexibleSpace();
                }
                EditorGUILayout.EndHorizontal();

                if (_showSettings.boolValue)
                {

                    EditorGUI.BeginDisabledGroup((_faithAdNetworkGeneralConfiguretionInfo.SelectedAdConfig == adNetworkConfiguretion) ? false : true);
                    {
                        EditorGUI.indentLevel += 1;
                        adNetworkConfiguretion.PreCustomEditorGUI();
                        EditorGUI.indentLevel -= 1;

                        //AdType Configuretion
                        GUIStyle adTypeStyle = new GUIStyle(EditorStyles.boldLabel);
                        adTypeStyle.alignment = TextAnchor.MiddleLeft;
                        adTypeStyle.padding.left = 36;

                        //------------------------------
                        #region RewardedAd

                        EditorGUI.indentLevel += 1;
                        {
                            EditorGUILayout.BeginHorizontal(GUI.skin.box);
                            {
                                string rewardedAdLabel = "[" + (!_showRewardedAdSettings.boolValue ? "+" : "-") + "] [RewardedAd]";
                                GUIContent rewardedAdLabelContent = new GUIContent(
                                        rewardedAdLabel

                                    );

                                if (GUILayout.Button(rewardedAdLabelContent, adTypeStyle, GUILayout.Width(EditorGUIUtility.currentViewWidth)))
                                {
                                    _showRewardedAdSettings.boolValue = !_showRewardedAdSettings.boolValue;
                                    _showRewardedAdSettings.serializedObject.ApplyModifiedProperties();
                                }
                            }
                            EditorGUILayout.EndHorizontal();

                            if (_showRewardedAdSettings.boolValue)
                            {

                                EditorGUI.indentLevel += 2;
                                {
                                    if (adNetworkConfiguretion.AskForAdIds())
                                    {

                                        EditorGUILayout.BeginHorizontal();
                                        {
                                            EditorGUILayout.LabelField(displayName_AdUnitId_Android, GUILayout.Width(FaithAdNetworkGeneralConfiguretionInfo.EDITOR_LABEL_WIDTH));
                                            EditorGUI.BeginChangeCheck();
                                            _adUnitIdForRewardedAd_Android.stringValue = EditorGUILayout.TextField(_adUnitIdForRewardedAd_Android.stringValue);
                                            if (EditorGUI.EndChangeCheck())
                                                _adUnitIdForRewardedAd_Android.serializedObject.ApplyModifiedProperties();
                                        }
                                        EditorGUILayout.EndHorizontal();

                                        EditorGUILayout.BeginHorizontal();
                                        {
                                            EditorGUILayout.LabelField(displayName_AdUnitId_iOS, GUILayout.Width(FaithAdNetworkGeneralConfiguretionInfo.EDITOR_LABEL_WIDTH));
                                            EditorGUI.BeginChangeCheck();
                                            _adUnitIdForRewardedAd_iOS.stringValue = EditorGUILayout.TextField(_adUnitIdForRewardedAd_iOS.stringValue);
                                            if (EditorGUI.EndChangeCheck())
                                                _adUnitIdForRewardedAd_iOS.serializedObject.ApplyModifiedProperties();
                                        }
                                        EditorGUILayout.EndHorizontal();

                                        FaithAdNetworkEditorModule.DrawHorizontalLine();
                                    }

                                    EditorGUILayout.BeginHorizontal();
                                    {
                                        EditorGUILayout.LabelField(_enableRewardedAd.displayName, GUILayout.Width(FaithAdNetworkGeneralConfiguretionInfo.EDITOR_LABEL_WIDTH));
                                        EditorGUI.BeginChangeCheck();
                                        _enableRewardedAd.boolValue = EditorGUILayout.Toggle(_enableRewardedAd.boolValue);
                                        if (EditorGUI.EndChangeCheck())
                                            _enableRewardedAd.serializedObject.ApplyModifiedProperties();
                                    }
                                    EditorGUILayout.EndHorizontal();
                                }
                                EditorGUI.indentLevel -= 2;

                            }
                        }
                        EditorGUI.indentLevel -= 1;


                        #endregion

                        //------------------------------
                        #region InterstitialAd

                        EditorGUI.indentLevel += 1;
                        {
                            EditorGUILayout.BeginHorizontal(GUI.skin.box);
                            {
                                string interstitialAdLabel = "[" + (!_showInterstitialAdSettings.boolValue ? "+" : "-") + "] [InterstitialAd]";
                                GUIContent interstialAdLabelContent = new GUIContent(
                                        interstitialAdLabel

                                    );

                                if (GUILayout.Button(interstialAdLabelContent, adTypeStyle, GUILayout.Width(EditorGUIUtility.currentViewWidth)))
                                {
                                    _showInterstitialAdSettings.boolValue = !_showInterstitialAdSettings.boolValue;
                                    _showInterstitialAdSettings.serializedObject.ApplyModifiedProperties();
                                }
                            }
                            EditorGUILayout.EndHorizontal();

                            if (_showInterstitialAdSettings.boolValue)
                            {
                                EditorGUI.indentLevel += 2;
                                {

                                    if (adNetworkConfiguretion.AskForAdIds())
                                    {

                                        EditorGUILayout.BeginHorizontal();
                                        {
                                            EditorGUILayout.LabelField(displayName_AdUnitId_Android, GUILayout.Width(FaithAdNetworkGeneralConfiguretionInfo.EDITOR_LABEL_WIDTH));
                                            EditorGUI.BeginChangeCheck();
                                            _adUnitIdForInterstitialAd_Android.stringValue = EditorGUILayout.TextField(_adUnitIdForInterstitialAd_Android.stringValue);
                                            if (EditorGUI.EndChangeCheck())
                                                _adUnitIdForInterstitialAd_Android.serializedObject.ApplyModifiedProperties();
                                        }
                                        EditorGUILayout.EndHorizontal();

                                        EditorGUILayout.BeginHorizontal();
                                        {
                                            EditorGUILayout.LabelField(displayName_AdUnitId_iOS, GUILayout.Width(FaithAdNetworkGeneralConfiguretionInfo.EDITOR_LABEL_WIDTH));
                                            EditorGUI.BeginChangeCheck();
                                            _adUnitIdForInterstitialAd_iOS.stringValue = EditorGUILayout.TextField(_adUnitIdForInterstitialAd_iOS.stringValue);
                                            if (EditorGUI.EndChangeCheck())
                                                _adUnitIdForInterstitialAd_iOS.serializedObject.ApplyModifiedProperties();
                                        }
                                        EditorGUILayout.EndHorizontal();

                                        FaithAdNetworkEditorModule.DrawHorizontalLine();
                                    }

                                    EditorGUILayout.BeginHorizontal();
                                    {
                                        EditorGUILayout.LabelField(_enableInterstitialAd.displayName, GUILayout.Width(FaithAdNetworkGeneralConfiguretionInfo.EDITOR_LABEL_WIDTH));
                                        EditorGUI.BeginChangeCheck();
                                        _enableInterstitialAd.boolValue = EditorGUILayout.Toggle(_enableInterstitialAd.boolValue);
                                        if (EditorGUI.EndChangeCheck())
                                            _enableInterstitialAd.serializedObject.ApplyModifiedProperties();
                                    }
                                    EditorGUILayout.EndHorizontal();
                                }
                                EditorGUI.indentLevel -= 2;

                            }
                        }
                        EditorGUI.indentLevel -= 1;


                        #endregion

                        //------------------------------
                        #region BannerAd

                        EditorGUI.indentLevel += 1;
                        {
                            EditorGUILayout.BeginHorizontal(GUI.skin.box);
                            {
                                string bannerAdLabel = "[" + (!_showBannerAdSettings.boolValue ? "+" : "-") + "] [BannerAd]";
                                GUIContent bannerAdLabelContent = new GUIContent(
                                        bannerAdLabel

                                    );

                                if (GUILayout.Button(bannerAdLabelContent, adTypeStyle, GUILayout.Width(EditorGUIUtility.currentViewWidth)))
                                {
                                    _showBannerAdSettings.boolValue = !_showBannerAdSettings.boolValue;
                                    _showBannerAdSettings.serializedObject.ApplyModifiedProperties();
                                }
                            }
                            EditorGUILayout.EndHorizontal();

                            if (_showBannerAdSettings.boolValue)
                            {
                                EditorGUI.indentLevel += 2;
                                {

                                    if (adNetworkConfiguretion.AskForAdIds())
                                    {

                                        EditorGUILayout.BeginHorizontal();
                                        {
                                            EditorGUILayout.LabelField(displayName_AdUnitId_Android, GUILayout.Width(FaithAdNetworkGeneralConfiguretionInfo.EDITOR_LABEL_WIDTH));
                                            EditorGUI.BeginChangeCheck();
                                            _adUnitIdForBannerAd_Android.stringValue = EditorGUILayout.TextField(_adUnitIdForBannerAd_Android.stringValue);
                                            if (EditorGUI.EndChangeCheck())
                                                _adUnitIdForBannerAd_Android.serializedObject.ApplyModifiedProperties();
                                        }
                                        EditorGUILayout.EndHorizontal();

                                        EditorGUILayout.BeginHorizontal();
                                        {
                                            EditorGUILayout.LabelField(displayName_AdUnitId_iOS, GUILayout.Width(FaithAdNetworkGeneralConfiguretionInfo.EDITOR_LABEL_WIDTH));
                                            EditorGUI.BeginChangeCheck();
                                            _adUnitIdForBannerAd_iOS.stringValue = EditorGUILayout.TextField(_adUnitIdForBannerAd_iOS.stringValue);
                                            if (EditorGUI.EndChangeCheck())
                                                _adUnitIdForBannerAd_iOS.serializedObject.ApplyModifiedProperties();
                                        }
                                        EditorGUILayout.EndHorizontal();

                                        FaithAdNetworkEditorModule.DrawHorizontalLine();
                                    }

                                    EditorGUILayout.BeginHorizontal();
                                    {
                                        EditorGUILayout.LabelField(_enableBannerAd.displayName, GUILayout.Width(FaithAdNetworkGeneralConfiguretionInfo.EDITOR_LABEL_WIDTH));
                                        EditorGUI.BeginChangeCheck();
                                        _enableBannerAd.boolValue = EditorGUILayout.Toggle(_enableBannerAd.boolValue);
                                        if (EditorGUI.EndChangeCheck())
                                            _enableBannerAd.serializedObject.ApplyModifiedProperties();
                                    }
                                    EditorGUILayout.EndHorizontal();

                                    EditorGUILayout.BeginHorizontal();
                                    {
                                        EditorGUILayout.LabelField(_showBannerAdManually.displayName, GUILayout.Width(FaithAdNetworkGeneralConfiguretionInfo.EDITOR_LABEL_WIDTH));
                                        EditorGUI.BeginChangeCheck();
                                        _showBannerAdManually.boolValue = EditorGUILayout.Toggle(_showBannerAdManually.boolValue);
                                        if (EditorGUI.EndChangeCheck())
                                            _showBannerAdManually.serializedObject.ApplyModifiedProperties();
                                    }
                                    EditorGUILayout.EndHorizontal();
                                }
                                EditorGUI.indentLevel -= 2;

                            }
                        }
                        EditorGUI.indentLevel -= 1;


                        #endregion

                        //------------------------------
                        #region CrossPromoAd

                        EditorGUI.indentLevel += 1;
                        {
                            EditorGUILayout.BeginHorizontal(GUI.skin.box);
                            {
                                string crossPromoAdLabel = "[" + (!_showCrossPromoAdSettings.boolValue ? "+" : "-") + "] [CrossPromoAd]";
                                GUIContent crossPromoAdLabelContent = new GUIContent(
                                        crossPromoAdLabel

                                    );

                                if (GUILayout.Button(crossPromoAdLabelContent, adTypeStyle, GUILayout.Width(EditorGUIUtility.currentViewWidth)))
                                {
                                    _showCrossPromoAdSettings.boolValue = !_showCrossPromoAdSettings.boolValue;
                                    _showCrossPromoAdSettings.serializedObject.ApplyModifiedProperties();
                                }
                            }
                            EditorGUILayout.EndHorizontal();

                            if (_showCrossPromoAdSettings.boolValue)
                            {

                                EditorGUI.indentLevel += 2;
                                {
                                    EditorGUILayout.BeginHorizontal();
                                    {
                                        EditorGUILayout.LabelField(_enableCrossPromoAd.displayName, GUILayout.Width(FaithAdNetworkGeneralConfiguretionInfo.EDITOR_LABEL_WIDTH));
                                        EditorGUI.BeginChangeCheck();
                                        _enableCrossPromoAd.boolValue = EditorGUILayout.Toggle(_enableCrossPromoAd.boolValue);
                                        if (EditorGUI.EndChangeCheck())
                                            _enableCrossPromoAd.serializedObject.ApplyModifiedProperties();
                                    }
                                    EditorGUILayout.EndHorizontal();
                                }
                                EditorGUI.indentLevel -= 2;

                            }
                        }
                        EditorGUI.indentLevel -= 1;


                        #endregion

                        EditorGUI.indentLevel += 1;
                        adNetworkConfiguretion.PostCustomEditorGUI();
                        EditorGUI.indentLevel -= 1;
                    }
                    EditorGUI.EndDisabledGroup();

                }

            }
            EditorGUI.EndDisabledGroup();
        }

        private void GeneralSettingGUI()
        {
            DrawHeaderGUI("General", ref _generalSettingContent, ref _settingsTitleStyle, ref _showGeneralSettings);

            if (_showGeneralSettings.boolValue)
            {

                EditorGUI.indentLevel += 1;
                {
                    EditorGUILayout.BeginHorizontal();
                    {
                        EditorGUILayout.LabelField("Reference/Link", GUILayout.Width(FaithAdNetworkGeneralConfiguretionInfo.EDITOR_LABEL_WIDTH + 30));
                        if (GUILayout.Button("Download", _hyperlinkStyle, GUILayout.Width(100)))
                        {
                            Application.OpenURL(_linkForDownload);
                        }
                        if (GUILayout.Button("Documentation", _hyperlinkStyle, GUILayout.Width(100)))
                        {
                            Application.OpenURL(_linkForDocumetation);
                        }
                    }
                    EditorGUILayout.EndHorizontal();

                    //-----------
                    EditorGUILayout.BeginHorizontal();
                    {
                        EditorGUILayout.LabelField(_autoInitialize.displayName, GUILayout.Width(FaithAdNetworkGeneralConfiguretionInfo.EDITOR_LABEL_WIDTH));
                        EditorGUI.BeginChangeCheck();
                        _autoInitialize.boolValue = EditorGUILayout.Toggle(_autoInitialize.boolValue);
                        if (EditorGUI.EndChangeCheck())
                        {
                            _autoInitialize.serializedObject.ApplyModifiedProperties();
                        }
                    }
                    EditorGUILayout.EndHorizontal();

                    if (!_autoInitialize.boolValue) {

                        FaithAdNetworkEditorModule.DrawHorizontalLine();
                        EditorGUILayout.HelpBox(
                            "For automatic initialization at start for all the adNetwork, you need to set the value = 'true'. If you want to manually initialize the sdk, make sure to call 'FaithAdNetworkManager.Initialize()' when the value = 'false'",
                            MessageType.Warning);
                    }
                }
                EditorGUI.indentLevel -= 1;
            }
        }


        private void AdNetworkSettingsGUI()
        {

            DrawHeaderGUI("AdNetwork", ref _adNetworkSettingContent, ref _settingsTitleStyle, ref _showAdNetworks);

            if (_showAdNetworks.boolValue)
            {
                
                foreach (FaithAdNetworkBaseClassForConfiguretionInfo adNetworkConfiguretion in _listOfAdNetworkConfiguretion)
                {
                    if (adNetworkConfiguretion != null)
                        DrawAdNetworkGUI(adNetworkConfiguretion);
                }
            }
        }

        private void DebuggingSettingsGUI()
        {

            DrawHeaderGUI("Debugging", ref _debuggingSettingContent, ref _settingsTitleStyle, ref _showDebuggingSettings);

            if (_showDebuggingSettings.boolValue)
            {
                EditorGUI.indentLevel += 1;

                EditorGUILayout.BeginVertical();
                {
                    EditorGUILayout.BeginHorizontal();
                    {
                        EditorGUILayout.LabelField(_showAdNetworkLogInConsole.displayName, GUILayout.Width(FaithAdNetworkGeneralConfiguretionInfo.EDITOR_LABEL_WIDTH));
                        EditorGUI.BeginChangeCheck();
                        _showAdNetworkLogInConsole.boolValue = EditorGUILayout.Toggle(_showAdNetworkLogInConsole.boolValue);
                        if (EditorGUI.EndChangeCheck())
                        {
                            _showAdNetworkLogInConsole.serializedObject.ApplyModifiedProperties();
                        }
                    }
                    EditorGUILayout.EndHorizontal();


                    EditorGUILayout.BeginHorizontal(GUI.skin.box);
                    {
                        EditorGUI.BeginChangeCheck();
                        EditorGUILayout.PropertyField(_infoLogColor);
                        if (EditorGUI.EndChangeCheck())
                        {

                            _infoLogColor.serializedObject.ApplyModifiedProperties();
                        }

                        EditorGUI.BeginChangeCheck();
                        EditorGUILayout.PropertyField(_warningLogColor);
                        if (EditorGUI.EndChangeCheck())
                        {
                            _warningLogColor.serializedObject.ApplyModifiedProperties();
                        }

                        EditorGUI.BeginChangeCheck();
                        EditorGUILayout.PropertyField(_errorLogColor);
                        if (EditorGUI.EndChangeCheck())
                        {
                            _errorLogColor.serializedObject.ApplyModifiedProperties();
                        }
                    }
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndVertical();

                EditorGUI.indentLevel -= 1;
            }
        }

        #endregion

        #region Configuretion

        private void FetchAllTheReference() {

            _faithAdNetworkGeneralConfiguretionInfo             = Resources.Load<FaithAdNetworkGeneralConfiguretionInfo>("FaithAdNetworkGeneralConfiguretionInfo");
            _serializedFaithAdNetworkGeneralConfiguretionInfo     = new SerializedObject(_faithAdNetworkGeneralConfiguretionInfo);

            _selectedAdConfiguretion = _serializedFaithAdNetworkGeneralConfiguretionInfo.FindProperty("_selectedAdConfiguretion");

            _autoInitialize                     = _serializedFaithAdNetworkGeneralConfiguretionInfo.FindProperty("_autoInitialize");


            _showGeneralSettings                = _serializedFaithAdNetworkGeneralConfiguretionInfo.FindProperty("_showGeneralSetting");
            _showAdNetworks                      = _serializedFaithAdNetworkGeneralConfiguretionInfo.FindProperty("_showAdNetworks");
            _showDebuggingSettings              = _serializedFaithAdNetworkGeneralConfiguretionInfo.FindProperty("_showDebuggingSetting");


            _generalSettingContent = new GUIContent(
                        "[" + (!_showGeneralSettings.boolValue ? "+" : "-") + "] General"
                    );
            _adNetworkSettingContent = new GUIContent(
                       "[" + (!_showAdNetworks.boolValue ? "+" : "-") + "] " + "AdNetwork"
                   );

            _debuggingSettingContent = new GUIContent(
                        "[" + (!_showDebuggingSettings.boolValue ? "+" : "-") + "] Debugging"
                    );

            _settingsTitleStyle = new GUIStyle();
            _settingsTitleStyle.normal.textColor = Color.white;
            _settingsTitleStyle.fontStyle = FontStyle.Bold;
            _settingsTitleStyle.alignment = TextAnchor.MiddleLeft;

            _hyperlinkStyle = new GUIStyle();
            _hyperlinkStyle.normal.textColor = new Color(50 / 255.0f, 139 / 255.0f, 217 / 255.0f);
            _hyperlinkStyle.fontStyle = FontStyle.BoldAndItalic;
            _hyperlinkStyle.wordWrap = true;
            _hyperlinkStyle.richText = true;

            _showAdNetworkLogInConsole = _serializedFaithAdNetworkGeneralConfiguretionInfo.FindProperty("_showAdNetworkLogInConsole");

            _infoLogColor = _serializedFaithAdNetworkGeneralConfiguretionInfo.FindProperty("_infoLogColor");
            _warningLogColor = _serializedFaithAdNetworkGeneralConfiguretionInfo.FindProperty("_warningLogColor");
            _errorLogColor = _serializedFaithAdNetworkGeneralConfiguretionInfo.FindProperty("_errorLogColor");

            _listOfAdNetworkConfiguretion = new List<FaithAdNetworkBaseClassForConfiguretionInfo>();
            Object[] adNetworkConfiguretionObjects = Resources.LoadAll("", typeof(FaithAdNetworkBaseClassForConfiguretionInfo));
            foreach (Object adNetworkConfiguretionObject in adNetworkConfiguretionObjects) {

                FaithAdNetworkBaseClassForConfiguretionInfo faithAdNetworkConfiguretion = (FaithAdNetworkBaseClassForConfiguretionInfo)adNetworkConfiguretionObject;
                if (faithAdNetworkConfiguretion != null)
                    _listOfAdNetworkConfiguretion.Add(faithAdNetworkConfiguretion);
            }

            FaithAdNetworkAssetPostProcessor.LookForSDK();
        }

        #endregion
    }
#endif
}

