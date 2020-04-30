using Rocket.API;

namespace PSLightPoliceUtils
{
    public class PSLightPoliceUtilsConfiguration : IRocketPluginConfiguration
    {
        public bool enabled;

        public void LoadDefaults()
        {
            enabled = true;
        }
    }
}