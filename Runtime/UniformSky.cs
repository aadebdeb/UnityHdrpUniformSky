using System;

namespace UnityEngine.Rendering.HighDefinition.Custom
{
    [VolumeComponentMenu("Sky/Uniform Sky")]
    [SkyUniqueID(UNIFORM_SKY_UNIQUE_ID)]
    public class UniformSky : SkySettings
    {
        const int UNIFORM_SKY_UNIQUE_ID = 782151;

        [Tooltip("Specifies the color of the sky.")]
        public ColorParameter color = new ColorParameter(Color.white, true, false, true);

        public override Type GetSkyRendererType()
        {
            return typeof(UniformSkyRenderer);
        }

        public override int GetHashCode()
        {
            int hash = base.GetHashCode();
            unchecked
            {
    #if UNITY_2019_3
                hash = hash * 23 + color.value.GetHashCode();
    #else
                hash = hash * 23 + color.GetHashCode();
    #endif
            }
            return hash;
        }
    }
}
