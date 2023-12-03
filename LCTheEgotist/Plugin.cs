using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LCTheEgotist.Patches;
using UnityEngine;

namespace LCTheEgotist
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class TheEgotist : BaseUnityPlugin
    {
        private const string modGUID = "Charoux.LCTheEgoist";
        private const string modName = "The Egoist";
        private const string modVersion = "0.0.1";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static TheEgotist Instance;

        static ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("TheEgoist is awake");

            harmony.PatchAll(typeof(TheEgotist));
            harmony.PatchAll(typeof(PlayerControllerBPatch));
        }

        // TODO : This should be called by the host on the creation of the game.
        static string[] createEgoists(string[] playerIds)
        {
            string[] egoistIds = new string[0];

            System.Random rnd = new System.Random();

            foreach (string id in playerIds)
            {
                // TODO : 1/8 might be too high or too low. Needs testing.
                if (rnd.Next(8) == 0)
                {
                    egoistIds.Append(id);
                }
            }
            mls.LogInfo($"{egoistIds.Length} egoists created.");

            return egoistIds;
        }
    }
}
