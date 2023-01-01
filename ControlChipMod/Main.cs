using System.Reflection;
using HarmonyLib;
using SMLHelper.V2.Handlers;

namespace J2bT.ControlChipMod
{
    public static class Main
    {
        public const string modName = "J2bT.ControlChipMod";
        public const string versionString = "1.1.0";

        private static readonly Harmony harmony = new Harmony(modName);

        internal static Config Config { get; private set; }
        public static void Init()
        {
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            MapRoomControlChip mapRoomControlChip = new MapRoomControlChip();
            mapRoomControlChip.Patch();
            Config = OptionsPanelHandler.Main.RegisterModOptions<Config>();
        }
    }
}