#if QMM
using System.Reflection;
using HarmonyLib;
using QModManager.API.ModLoading;
using Logger = QModManager.Utility.Logger;

namespace J2bT.ControlChipMod.EntryPoints
{
    [QModCore]
    public static class QMod
    {
        [QModPatch]
        public static void Patch()
        {
            Main.Init();
            Logger.Log(Main.modName + " v" + Main.versionString + " loaded.");
        }
    }
}
#endif