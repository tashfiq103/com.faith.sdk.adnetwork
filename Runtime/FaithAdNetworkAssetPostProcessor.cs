namespace com.faith.sdk.adnetwork
{
#if UNITY_EDITOR

    using UnityEngine;
    using UnityEditor;

    public class FaithAdNetworkAssetPostProcessor : AssetPostprocessor
    {
        public static void LookForSDK()
        {
            Object[] analyticsConfiguretionObjects = Resources.LoadAll("", typeof(FaithBaseClassForAdNetworkConfiguretionInfo));
            foreach (Object analyticsConfiguretionObject in analyticsConfiguretionObjects)
            {

                FaithBaseClassForAdNetworkConfiguretionInfo analyticsConfiguretion = (FaithBaseClassForAdNetworkConfiguretionInfo)analyticsConfiguretionObject;
                if (analyticsConfiguretion != null)
                    analyticsConfiguretion.SetNameAndIntegrationStatus();
            }
        }

        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            LookForSDK();
        }
    }

#endif
}


