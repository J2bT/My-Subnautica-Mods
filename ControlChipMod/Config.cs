using SMLHelper.V2.Json;
using SMLHelper.V2.Options.Attributes;
using UnityEngine;

namespace J2bT.ControlChipMod
{
    [Menu("Scanner Room Control Chip")]
    public class Config : ConfigFile
    {
        [Keybind("Next resource / Turn on scanner room")]
        public KeyCode next = KeyCode.RightArrow;
        [Keybind("Previous resource")]
        public KeyCode previous = KeyCode.LeftArrow;
        [Keybind("Next scanner room")]
        public KeyCode nextRoom = KeyCode.UpArrow;
        [Keybind("Previous scanner room")]
        public KeyCode previousRoom = KeyCode.DownArrow;
        [Keybind("Turn off selected scanner room")]
        public KeyCode stop = KeyCode.RightControl;
        [Toggle("Display a message on selecting a resource?", Tooltip = "Will only work if the chip is equipped.")]
        public bool messageChoice = true;
        [Choice("Display the icon of the selected resource?", "Always, if the room is on", "Off", "On selecting a resource", Tooltip = "Will only work if the chip is equipped.")]
        public int iconChoice = 2;
    }
}
