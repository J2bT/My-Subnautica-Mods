#if BEPINEX
using BepInEx;

namespace J2bT.ControlChipMod.EntryPoints
{
    [BepInPlugin("com.j2bt.controlchipmod", Main.modName, Main.versionString)]
    [BepInDependency("com.ahk1221.smlhelper")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Main.Init();
            Logger.LogInfo(Main.modName + " v" + Main.versionString + " loaded.");
        }
    }
}
#endif