using System.Reflection;
using HarmonyLib;
using QModManager.API.ModLoading;
using Logger = QModManager.Utility.Logger;
using SMLHelper.V2.Handlers;

namespace J2bT.ControlChipMod
{
    [QModCore]
    public static class QMod
    {
        internal static Config Config { get; } = OptionsPanelHandler.Main.RegisterModOptions<Config>();

        [QModPatch]
        public static void Patch()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var modName = ($"J2bT.{assembly.GetName().Name}");
            Logger.Log(Logger.Level.Info, $"Patching {modName}");
            Harmony harmony = new Harmony(modName);
            harmony.PatchAll(assembly);

            MapRoomControlChip mapRoomControlChip = new MapRoomControlChip();
            mapRoomControlChip.Patch();

            Logger.Log(Logger.Level.Info, "Patched successfully!");
        }
    }
}