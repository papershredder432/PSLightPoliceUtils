using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;

namespace PSLightPoliceUtils
{
    public class PSLightPoliceUtils : RocketPlugin<PSLightPoliceUtilsConfiguration>
    {
        public static PSLightPoliceUtils Instance;

        protected override void Load()
        {
            Logger.LogWarning("[PSLightPoliceUtils] Loaded, made by papershredder432, join the support Discord here: https://discord.gg/ydjYVJ2");
            Instance = this;

            if (!Instance.Configuration.Instance.enabled)
            {
                Instance.UnloadPlugin();
            }
        }

        protected override void Unload()
        {
            Logger.LogWarning("[PSLightPoliceUtils] Unloaded.");
            Instance = null;
        }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "invalid_use", "Invalid use of {0}." },
            { "cuff_success", "Successfully cuffed {0}." },
            { "cuff_failed", "Unable to cuff {0}." },
            { "uncuff_success", "Successfully uncuffed {0}." },
            { "uncuff_failed", "Unable to uncuff {0}." },

            { "caller_tased", "{0} has been tased." },
            { "caller_untased", "{0} has been untased." },
            { "player_tased", "You have been tased." },
            { "player_untased", "You have been untased." },
            { "already_tased", "{0} is already tased." },
            { "not_tased", "{0} is not tased" },
        };
    }
}
