using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNetcodeStuff;
using HarmonyLib;

namespace LCTheEgotist.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {
        private bool isEgoist;

        PlayerControllerBPatch(bool isEgoist)
        {
            this.isEgoist = isEgoist;
        }

        [HarmonyPatch("KillPlayerServerRpc")]
        [HarmonyPostfix]
        static void patchKillPlayer(ref float ___isPlayerDead)
        {

        }
    }
}
