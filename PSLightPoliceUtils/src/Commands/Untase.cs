using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System.Collections.Generic;

namespace PSLightPoliceUtils.Commands
{
    class Untase : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "untase";

        public string Help => "Untases a player.";

        public string Syntax => "/untase <PlayerName>";

        public List<string> Aliases
        {
            get { return new List<string>(); }
        }

        public List<string> Permissions => new List<string>() { "ps.lightpoliceutils.untase" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length < 1)
            {
                UnturnedChat.Say(caller, PSLightPoliceUtils.Instance.Translations.Instance.Translate(string.Format("invalid_use"), "Unase"));
                return;
            }

            UnturnedPlayer selectedPlayer = UnturnedPlayer.FromName(command[0]);

            if (selectedPlayer.Player.movement.totalSpeedMultiplier == 1)
            {
                UnturnedChat.Say(caller, PSLightPoliceUtils.Instance.Translations.Instance.Translate(string.Format("not_tased"), selectedPlayer.SteamName));
                return;
            }
            else if (selectedPlayer.Player.movement.totalSpeedMultiplier == 0)
            {
                selectedPlayer.Player.movement.sendPluginSpeedMultiplier(1);
                UnturnedChat.Say(caller, PSLightPoliceUtils.Instance.Translations.Instance.Translate(string.Format("caller_untased"), selectedPlayer.SteamName));
                UnturnedChat.Say(selectedPlayer, PSLightPoliceUtils.Instance.Translations.Instance.Translate(string.Format("player_untased"), selectedPlayer.SteamName));
            }
        }
    }
}
