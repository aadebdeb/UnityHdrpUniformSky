namespace UnityEngine.Rendering.HighDefinition.Custom
{
    public class UniformSkyRenderer : SkyRenderer
    {
        public static readonly int _Color = Shader.PropertyToID("_Color");
        public static readonly int _SkyIntensity = Shader.PropertyToID("_SkyIntensity");
        Material m_UniformSkyMaterial;

        public override void Build()
        {
            m_UniformSkyMaterial = CoreUtils.CreateEngineMaterial(GetUniformSkyShader());
        }

        Shader GetUniformSkyShader()
        {
            return Shader.Find("Hidden/HDRP/Sky/Custom/UniformSky");
        }

        public override void Cleanup()
        {
            CoreUtils.Destroy(m_UniformSkyMaterial);
        }

        protected override bool Update(BuiltinSkyParameters builtinParams)
        {
            return false;
        }

        public override void RenderSky(BuiltinSkyParameters builtinParams, bool renderForCubemap, bool renderSunDisk)
        {

            var uniformSky = builtinParams.skySettings as UniformSky;
            float intensity = GetSkyIntensity(uniformSky, builtinParams.debugSettings);
            m_UniformSkyMaterial.SetColor(_Color, uniformSky.color.value);
            m_UniformSkyMaterial.SetFloat(_SkyIntensity, GetSkyIntensity(uniformSky, builtinParams.debugSettings));
            CoreUtils.DrawFullScreen(builtinParams.commandBuffer, m_UniformSkyMaterial, null, renderForCubemap ? 0 : 1);
        }
    }
}