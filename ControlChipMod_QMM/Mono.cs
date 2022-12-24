#if SUBNAUTICA
using GameSpecificTracker = ResourceTracker;
#elif BELOWZERO
using GameSpecificTracker = ResourceTrackerDatabase;
#endif
using Logger = QModManager.Utility.Logger;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace J2bT.ControlChipMod
{
    internal class Mono : MonoBehaviour
    {
        int roomIndex = 0;
        int[] resourceIndex = new int[16] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};
        public static List<uGUI_MapRoomScanner> mapRooms = new List<uGUI_MapRoomScanner>();
        public void Update()
        {
            if (ChipIsInSlot() && mapRooms.Count > 0)
            {
                if (roomIndex > mapRooms.Count - 1)
                {
                    resourceIndex[roomIndex] = -1;
                    roomIndex = mapRooms.Count - 1;
                    ErrorMessage.AddMessage("Selected scanner room was destroyed. Selecting previous one.");
                }
                if (Input.GetKeyUp(QMod.Config.next))
                {
                    SelectResource(true);
                }
                else if (Input.GetKeyUp(QMod.Config.previous))
                {
                    SelectResource(false);
                }
                else if (Input.GetKeyUp(QMod.Config.nextRoom))
                {
                    SelectRoom(true);
                }
                else if (Input.GetKeyUp(QMod.Config.previousRoom))
                {
                    SelectRoom(false);
                }
                else if (Input.GetKeyUp(QMod.Config.stop))
                {
                    SelectResource(false, true);
                }
            }
            else
            {
                roomIndex = 0;
                resourceIndex[roomIndex] = -1;
            }
        }

        public void SelectResource(bool nextRes, bool stop = false)
        {
            if (stop)
            {
                mapRooms[roomIndex].mapRoom.StartScanning(TechType.None);
                mapRooms[roomIndex].UpdateGUIState();
                resourceIndex[roomIndex] = -1;
            }
            else if (nextRes && resourceIndex[roomIndex] + 1 < GameSpecificTracker.resources.Count)
            {
                resourceIndex[roomIndex] += 1;
                Logger.Log(Logger.Level.Debug, $"Current resource index: {resourceIndex[roomIndex]}", showOnScreen: true);
                mapRooms[roomIndex].mapRoom.StartScanning(GameSpecificTracker.resources.ElementAt(resourceIndex[roomIndex]).Key);
                mapRooms[roomIndex].UpdateGUIState();
            }
            else if (nextRes)
            {
                ErrorMessage.AddMessage("Can't select next resource! The last resource is currently selected.");
            }
            else if (!nextRes && resourceIndex[roomIndex] - 1 > -1)
            {
                resourceIndex[roomIndex] -= 1;
                Logger.Log(Logger.Level.Debug, $"Current resource index: {resourceIndex[roomIndex]}", showOnScreen: true);
                mapRooms[roomIndex].mapRoom.StartScanning(GameSpecificTracker.resources.ElementAt(resourceIndex[roomIndex]).Key);
                mapRooms[roomIndex].UpdateGUIState();
            }
            else if (!nextRes && mapRooms[roomIndex].mapRoom.typeToScan != TechType.None)
            {
                ErrorMessage.AddMessage("Can't select previous resource! The first resource is currently selected.");
            }
            else if (!nextRes)
            {
                ErrorMessage.AddMessage("Can't select previous resource! Selected room is not active.");
            }
        }

        public void SelectRoom(bool nextRoom)
        {
            if (nextRoom && roomIndex + 1 < mapRooms.Count && roomIndex + 1 < 16)
            {
                roomIndex += 1;
                Logger.Log(Logger.Level.Debug, $"Current room index: {roomIndex}", showOnScreen: true);
            }
            else if (nextRoom)
            {
                ErrorMessage.AddMessage("Can't select next room! The last room is currently selected.");
            }
            else if (!nextRoom && roomIndex - 1 > -1)
            {
                roomIndex -= 1;
                Logger.Log(Logger.Level.Debug, $"Current room index: {roomIndex}", showOnScreen: true);
            }
            else if (!nextRoom)
            {
                ErrorMessage.AddMessage("Can't select previous room! The first room is currently selected.");
            }
        }

        public static bool ChipIsInSlot()
        {
            Equipment equipment = Inventory.main?.equipment;

            if (equipment == null)
            {
                return false;
            }

            List<string> Slotslist = new List<string>();
            equipment.GetSlots(EquipmentType.Chip, Slotslist);

            for (int i = 0; i < Slotslist.Count; i++)
            {
                string slot = Slotslist[i];
                if (equipment.GetTechTypeInSlot(slot) == MapRoomControlChip.TechTypeID)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
