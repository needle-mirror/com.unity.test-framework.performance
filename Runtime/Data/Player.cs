using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;
using UnityEngine.Rendering;

namespace Unity.PerformanceTesting.Data
{
    public class Player
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public RuntimePlatform Platform;
        public bool Development;
        public int ScreenWidth;
        public int ScreenHeight;
        public int ScreenRefreshRate;
        public bool Fullscreen;
        public int Vsync;
        public int AntiAliasing;
        [JsonConverter(typeof(StringEnumConverter))]
        public ColorSpace ColorSpace;
        [JsonConverter(typeof(StringEnumConverter))]
        public AnisotropicFiltering AnisotropicFiltering;
        [JsonConverter(typeof(StringEnumConverter))]
        public SkinWeights BlendWeights;
        [JsonConverter(typeof(StringEnumConverter))]
        public GraphicsDeviceType GraphicsApi;
        public bool Batchmode;
        public string RenderThreadingMode;
        public bool GpuSkinning;
        // strings because their enums are editor only
        public string ScriptingBackend;
        public string AndroidTargetSdkVersion;
        public string AndroidBuildSystem;
        public string BuildTarget;
        public string StereoRenderingPath;

    }
}
