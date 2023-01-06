using System.Reflection;
using HarmonyLib;
using SMLHelper.V2.Handlers;

namespace J2bT.ControlChipMod
{
    public static class Main
    {
        public const string modName = "J2bT.ControlChipMod";
        public const string versionString = "1.1.0";

        internal static Config Config { get; private set; }
        public static void Init()
        {
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), modName);
            Lang.Patch();
            new MapRoomControlChip().Patch();
            Config = OptionsPanelHandler.Main.RegisterModOptions<Config>();
        }
    }
}