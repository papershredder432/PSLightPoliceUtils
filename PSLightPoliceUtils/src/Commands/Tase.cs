using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System.Collections.Generic;

namespace PSLightPoliceUtils.Commands
{
    class Tase : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "tase";

        public string Help => "Tases a player.";

        public string Syntax => "/tase <PlayerName>";

        public List<string> Aliases
        {
            get { return new List<string>(); }
        }

        public List<string> Permissions => new List<string>() { "ps.lightpoliceutils.tase" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length < 1)
            {
                UnturnedChat.Say(caller, PSLightPoliceUtils.Instance.Translations.Instance.Translate(string.Format("invalid_use"), "Tase"));
                return;
            }

            UnturnedPlayer selectedPlayer = UnturnedPlayer.FromName(command[0]);

            if (selectedPlayer.Player.movement.totalSpeedMultiplier == 1)
            {
                selectedPlayer.Player.movement.sendPluginSpeedMultiplier(0);
                UnturnedChat.Say(caller, PSLightPoliceUtils.Instance.Translations.Instance.Translate(string.Format("caller_tased"), selectedPlayer.SteamName));
                UnturnedChat.Say(selectedPlayer, PSLightPoliceUtils.Instance.Translations.Instance.Translate(string.Format("player_tased"), selectedPlayer.SteamName));
            }
            else if (selectedPlayer.Player.movement.totalSpeedMultiplier == 0)
            {
                UnturnedChat.Say(caller, PSLightPoliceUtils.Instance.Translations.Instance.Translate(string.Format("already_tased"), selectedPlayer.SteamName));
                return;
            }
        }
    }
}
