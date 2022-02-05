using UnityEditor.Rendering;
using UnityEngine.Rendering.HighDefinition.Custom;

namespace UnityEditor.Rendering.HighDefinition.Custom
{
    [CanEditMultipleObjects]
    [VolumeComponentEditor(typeof(UniformSky))]
    public class UniformSkyEditor : SkySettingsEditor
    {
        SerializedDataParameter m_Color;

        public override void OnEnable()
        {
            base.OnEnable();
            m_CommonUIElementsMask = (uint)SkySettingsUIElement.UpdateMode
                | (uint)SkySettingsUIElement.SkyIntensity;
            var o = new PropertyFetcher<UniformSky>(serializedObject);
            m_Color = Unpack(o.Find(x => x.color));
        }

        public override void OnInspectorGUI()
        {
            PropertyField(m_Color);
            base.CommonSkySettingsGUI();
        }
    }
}