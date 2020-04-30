using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;

namespace PSLightPoliceUtils.Commands
{
    class Uncuff : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "uncuff";

        public string Help => "Force uncuffs a player.";

        public string Syntax => "/uncuff <Player>";

        public List<string> Aliases => new List<string>() { };

        public List<string> Permissions => new List<string>() { "ps.lightpoliceutils.uncuff" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length < 1)
            {
                UnturnedChat.Say(caller, PSLightPoliceUtils.Instance.Translations.Instance.Translate(string.Format("invalid_use"), "Uncuff"));
                return;
            }

            UnturnedPlayer selectedPlayer = UnturnedPlayer.FromName(command[0]);

            try
            {
                selectedPlayer.Player.stance.checkStance(EPlayerStance.STAND, true);
                selectedPlayer.Player.animator.sendGesture(EPlayerGesture.ARREST_STOP, true);
                UnturnedChat.Say(caller, PSLightPoliceUtils.Instance.Translations.Instance.Translate(string.Format("uncuff_success"), selectedPlayer.SteamName));
            }
            catch (Exception e)
            {
                UnturnedChat.Say(caller, PSLightPoliceUtils.Instance.Translations.Instance.Translate(string.Format("uncuff_failed"), selectedPlayer.SteamName));
                return;
            }
        }
    }
}
