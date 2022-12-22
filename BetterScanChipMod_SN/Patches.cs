using HarmonyLib;

namespace BetterScanChipMod_SN
{
    public static class Patches
    {
        [HarmonyPatch(typeof(Player))]
        public class PlayerPatch
        {
            [HarmonyPatch(nameof(Player.Start))]
            [HarmonyPostfix]
            public static void StartPostfix(Player __instance)
            {
                __instance.gameObject.EnsureComponent<Mono>();
            }
        }

        [HarmonyPatch(typeof(uGUI_MapRoomScanner))]
        public static class MapRoomPatch
        {
            [HarmonyPatch(nameof(uGUI_MapRoomScanner.Start))]
            [HarmonyPostfix]
            public static void StartPostfix(uGUI_MapRoomScanner __instance)
            {
                Mono.mapRooms.Add(__instance);
            }
        }
    }
}