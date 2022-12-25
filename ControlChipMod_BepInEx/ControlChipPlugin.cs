using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
//using SMLHelper.V2.Json;
//using SMLHelper.V2.Options.Attributes;
//using SMLHelper.V2.Handlers;
using UnityEngine;
using BepInEx.Configuration;

namespace J2bT.ControlChipMod
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    public class ControlChipPlugin : BaseUnityPlugin
    {
        private const string myGUID = "com.j2bt.controlchipmod";
        private const string pluginName = "Scanner Room Control Chip";
        private const string versionString = "1.0.2";

        private static readonly Harmony harmony = new Harmony(myGUID);

        public static ManualLogSource logger;

        //internal static Config ModConfig { get; } = OptionsPanelHandler.Main.RegisterModOptions<Config>();
        public static ConfigEntry<float> ConfigKnifeDamageMultiplier;

        private void Awake()
        {
            ConfigKnifeDamageMultiplier = Config.Bind("General",        // The section under which the option is shown
                "KnifeDamageMultiplier",                                // The key of the configuration option
                1.0f,                                                   // The default value
                "Knife damage multiplier.");

            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "loaded.");
            logger = Logger;
        }
    }

    //[Menu("Scanner Room Control Chip")]
    //public class Config : ConfigFile
    //{
    //    [Keybind("Next resource / Turn on scanner room")]
    //    public KeyCode next = KeyCode.RightArrow;
    //    [Keybind("Previous resource")]
    //    public KeyCode previous = KeyCode.LeftArrow;
    //    [Keybind("Next scanner room")]
    //    public KeyCode nextRoom = KeyCode.UpArrow;
    //    [Keybind("Previous scanner room")]
    //    public KeyCode previousRoom = KeyCode.DownArrow;
    //    [Keybind("Turn off selected scanner room")]
    //    public KeyCode stop = KeyCode.RightControl;
    //}
}
