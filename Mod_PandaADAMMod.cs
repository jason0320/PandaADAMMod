using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace Mod_PandaADAMMod 
{
    [BepInPlugin("panda.ADAM.mod", "Panda's ADAM Mod", "1.0.0.0")]
    public class Mod_PandaADAMMod : BaseUnityPlugin
    {
        private void Start()
        {
            var harmony = new Harmony("Panda's ADAM Mod");
            harmony.PatchAll();
        }
    }
}