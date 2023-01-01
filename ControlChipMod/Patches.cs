using HarmonyLib;
using J2bT.ControlChipMod.MonoBehaviours;

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
                __instance.gameObject.EnsureComponent<ControlChipMono>();
                //__instance.gameObject.EnsureComponent<uGUI_ResourceIcon>();
            }
        }

        [HarmonyPatch(typeof(uGUI_MapRoomScanner))]
        public static class MapRoomPatch
        {
            [HarmonyPatch(nameof(uGUI_MapRoomScanner.Start))]
            [HarmonyPostfix]
            public static void StartPostfix(uGUI_MapRoomScanner __instance)
            {
                ControlChipMono.mapRooms.Add(__instance);
            }

            [HarmonyPatch(nameof(uGUI_MapRoomScanner.OnDestroy))]
            [HarmonyPostfix]
            public static void OnDestroyPostfix(uGUI_MapRoomScanner __instance)
            {
                ControlChipMono.mapRooms.Remove(__instance);
            }
        }

        [HarmonyPatch(typeof(Equipment))]
        public static class EquipmentPatch
        {
            [HarmonyPatch("GetCount")]
            [HarmonyPrefix]
            public static bool GetCountPrefix(ref Equipment __instance, TechType techType, ref int __result)
            {
                if (techType == TechType.MapRoomHUDChip)
                {
                    int count;
                    __instance.equippedCount.TryGetValue(MapRoomControlChip.TechTypeID, out count);
                    if (count > 0)
                    {
                        __result = count;
                        return false;
                    }
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(uGUI_QuickSlots))]
        public static class QuickSlotsPatch
        {
            [HarmonyPatch(nameof(uGUI_QuickSlots.Init))]
            [HarmonyPostfix]
            public static void InitPostfix(uGUI_ScannerIcon __instance)
            {
                __instance.gameObject.EnsureComponent<uGUI_ResourceIcon>();
            }
        }
    }
}