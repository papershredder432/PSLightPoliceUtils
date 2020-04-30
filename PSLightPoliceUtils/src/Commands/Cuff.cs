using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;

namespace PSLightPoliceUtils.Commands
{
    class Cuff : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "cuff";

        public string Help => "Force cuffs a player.";

        public string Syntax => "/cuff <Player>";

        public List<string> Aliases => new List<string>() { };

        public List<string> Permissions => new List<string>() { "ps.lightpoliceutils.cuff" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length < 1)
            {
                UnturnedChat.Say(caller, PSLightPoliceUtils.Instance.Translations.Instance.Translate(string.Format("invalid_use"), "Cuff"));
                return;
            }

            UnturnedPlayer selectedPlayer = UnturnedPlayer.FromName(command[0]);

            try
            {
                selectedPlayer.Player.equipment.dequip();
                selectedPlayer.Player.stance.checkStance(EPlayerStance.CROUCH, true);
                selectedPlayer.Player.animator.sendGesture(EPlayerGesture.ARREST_START, true);
                UnturnedChat.Say(caller, PSLightPoliceUtils.Instance.Translations.Instance.Translate(string.Format("cuff_success"), selectedPlayer.SteamName));
            }
            catch (Exception e)
            {
                UnturnedChat.Say(caller, PSLightPoliceUtils.Instance.Translations.Instance.Translate(string.Format("cuff_failed"), selectedPlayer.SteamName));
                return;
            }
        }
    }
}
