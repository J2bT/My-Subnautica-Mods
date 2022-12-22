using System.Reflection;
using HarmonyLib;
using QModManager.API.ModLoading;
using Logger = QModManager.Utility.Logger;
using SMLHelper.V2.Json;
using SMLHelper.V2.Options.Attributes;
using SMLHelper.V2.Handlers;
using UnityEngine;

namespace BetterScanChipMod_SN
{
    [QModCore]
    public static class QMod
    {
        internal static Config Config { get; } = OptionsPanelHandler.Main.RegisterModOptions<Config>();

        [QModPatch]
        public static void Patch()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var modName = ($"J2bT_{assembly.GetName().Name}");
            Logger.Log(Logger.Level.Info, $"Patching {modName}");
            Harmony harmony = new Harmony(modName);
            harmony.PatchAll(assembly);

            MapRoomControlChip mapRoomControlChip = new MapRoomControlChip();
            mapRoomControlChip.Patch();

            Logger.Log(Logger.Level.Info, "Patched successfully!");
        }
    }
    [Menu("Scanner Room Control Chip")]
    public class Config : ConfigFile
    {
        [Keybind("Next resource")]
        public KeyCode next = KeyCode.RightArrow;
        [Keybind("Previous resource")]
        public KeyCode previous = KeyCode.LeftArrow;
        [Keybind("Next scanner room")]
        public KeyCode nextRoom = KeyCode.UpArrow;
        [Keybind("Previous scanner room")]
        public KeyCode previousRoom = KeyCode.DownArrow;
        [Keybind("Turn off selected scanner room")]
        public KeyCode stop = KeyCode.RightControl;
    }
}