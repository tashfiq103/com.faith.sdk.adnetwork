# FaithAdNetwork Integration Manager
[Reference Videos] : <https://www.youtube.com/watch?v=CoxcUw8iCsM>




## Downloading "FaithAdNetwork" package.

Please go to the release section on this repository and download the latest version of "FaithAdNetwork". Once you download the ".unityPackage", import it to your unity project. Once the project recompilation is complete, you will be able to see the following windows as the given screenshot below (FAITH -> FaithAdNetwork Integration Manager)

![](https://github.com/tashfiq103/com.faith.sdk.adnetwork/blob/main/_GitHubResources/ss0_menu.png)




## Understanding the basic interface.

FaithAdNetwork Integration manager comes with the following section

- General
- AdNetwork
- Debugging




## General
- Download : Will redirect you the following repository
- Documentation : Will redirect you to the README.md file.
- Auto Initialize : For automatic initialization at start for all the analytics, you need to set the value = 'true'. If you want to manually initialize the sdk, make sure to call 'FaithAnalyticsManager.Initialize()' when the value = 'false'.

![](https://github.com/tashfiq103/com.faith.sdk.adnetwork/blob/main/_GitHubResources/ss1_general_auto.png)
![](https://github.com/tashfiq103/com.faith.sdk.adnetwork/blob/main/_GitHubResources/ss2_general_manual.png)



## AdNetwork

![](https://github.com/tashfiq103/com.faith.sdk.adnetwork/blob/main/_GitHubResources/ss3_analytics_overview.png)

![](https://github.com/tashfiq103/com.faith.sdk.adnetwork/blob/main/_GitHubResources/ss4_analytics_enable_disable.png)

- Each AdNetwork will have their own section to confiure it settings.
- The tabs would be grayed out if you haven't imported the following SDK with the status message of 'SDK - Not Found'.
- Once the SDK has been imported, you will be able to interact with the section.
- In order to iniatize the SDK and work properly, make sure to "Enable" the imported SDK.
- Make sure to Enable/Disable the 'RewardedAd'/'InterstitialAd'/'BannerAd'/'CrossPromoAd' in order to make them working properly.

### LionAd

![](https://github.com/tashfiq103/com.faith.sdk.adnetwork/blob/main/_GitHubResources/ss5_adnetwork_lionad.png)

- Go to the  menu item from "LionStudios/Integration Settings".
- 'Enable' the "AppLovin" section.
- Make sure to provide the "SDK Key" for the 'MaxSDK' to be initialized.
- Make sure to check the "Enable MAX AdReview".
- Fill all the necessary IDs for your ads which you are planning to show in your game.
- Now go to the menu item "FAITH/FaithAdNetwork IntegrationManager"
- Under the 'AdNetwork' section, 'Enable' the 'LionKit'.
- Make sure to 'Enable' the ad types you wanted to show in yor game.
- Note : Go to "Applovin Integration Manager' settings to check if the "SDK key" is auto populated.

### MaxAd

![](https://github.com/tashfiq103/com.faith.sdk.adnetwork/blob/main/_GitHubResources/ss6_adnetwork_maxad.png)

- Go to the  menu item from "AppLovin/Integration Settings".
- Make sure to check the "Enable MAX AdReview".
- Provide the "Applovin SDK Key".
- Now go to the menu item "FAITH/FaithAdNetwork IntegrationManager"
- Under the 'AdNetwork' section, 'Enable' the 'Max'.
- Fill all the necessary IDs for your ads which you are planning to show in your game.
- Make sure to 'Enable' the ad types you wanted to show in yor game.

### UnityAd

![](https://github.com/tashfiq103/com.faith.sdk.adnetwork/blob/main/_GitHubResources/ss7_adnetwork_unityad.png)

- Go to the menu item "FAITH/FaithAdNetwork IntegrationManager"
- Under the 'AdNetwork' section, 'Enable' the 'Unity'.
- Fill the "AndroidGameID/iOSGameID" which you can get from the 'UnityDashboard/Projects/"Your Game"'.
- Enable 'TestMode' if you are willing to test on the test-devices.
- Make sure to disable 'TestMode' when you are pushing it for production, otherwise it will show demo ads.
- Fill all the necessary IDs for your ads which you are planning to show in your game.
- Make sure to 'Enable' the ad types you wanted to show in yor game.

### APIs
```sh
using com.faith.sdk.analytics;
public static class AnalyticsCall
{
    public static void ShowBannerAd() {

        FaithBannerAdNetwork.Show();
    }
    
    public static void HideBannerAd() {

        FaithBannerAdNetwork.Hide();
    }
    
    public static void ShowInterstitialAd() {

        FaithInterstitialAdNetwork.Show();
    }
    
    public static void ShowRewardedAd() {

        FaithRewardedAdNetwork.Show(
            "testAd",
            (isRewarded) => {

                FaithAdNetworkLogger.Log(string.Format("RewardedAd Status : {0}", isRewarded));
            });
    }
    
}
```

## Debugging

- You will be able to "Toggle" the FaithAnalytics log by taping "Show AdNetwork Log In Console".
- You will be able to change the colors of the log on the following section as well.

![](https://github.com/tashfiq103/com.faith.sdk.adnetwork/blob/main/_GitHubResources/ss8_debugging.png)
