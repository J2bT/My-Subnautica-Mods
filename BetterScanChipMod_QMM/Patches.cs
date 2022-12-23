﻿using HarmonyLib;

namespace J2bT.ControlChipMod
{
    public static class Patches
    {
        [HarmonyPatch(typeof(Player))]
        public static class PlayerPatch
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