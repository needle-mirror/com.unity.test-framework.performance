using System;
using Unity.PerformanceTesting.Runtime;
using UnityEngine;

namespace Unity.PerformanceTesting
{
    internal class ResourcesLoader
    {
        public static T Load<T>(string assetPath, string prefsKey) where T : class
        {
            try
            {
                var runResource = Resources.Load<TextAsset>(assetPath.Replace(".json", ""));
                var json = Application.isEditor ? PlayerPrefs.GetString(prefsKey) : runResource.text;
                var run = JsonUtility.FromJson<T>(json);
                return run;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }

            return null;
        }
    }
}