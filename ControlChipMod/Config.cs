using SMLHelper.V2.Json;
using SMLHelper.V2.Options.Attributes;
using UnityEngine;

namespace J2bT.ControlChipMod
{
    [Menu(Lang.Options.MenuName)]
    public class Config : ConfigFile
    {
        [Keybind(LabelLanguageId = Lang.Options.NextResource)]
        public KeyCode next = KeyCode.RightArrow;
        [Keybind(LabelLanguageId = Lang.Options.PreviousResource)]
        public KeyCode previous = KeyCode.LeftArrow;
        [Keybind(LabelLanguageId = Lang.Options.NextRoom)]
        public KeyCode nextRoom = KeyCode.UpArrow;
        [Keybind(LabelLanguageId = Lang.Options.PreviousRoom)]
        public KeyCode previousRoom = KeyCode.DownArrow;
        [Keybind(LabelLanguageId = Lang.Options.StopRoom)]
        public KeyCode stop = KeyCode.RightControl;
        [Toggle(LabelLanguageId = Lang.Options.MessageChoice, TooltipLanguageId = Lang.Options.ChipEquippedTooltip)]
        public bool messageChoice = true;
        [Choice(Lang.Options.IconChoice, Lang.Options.Always, "Off", Lang.Options.OnSelect, TooltipLanguageId = Lang.Options.ChipEquippedTooltip)]
        public int iconChoice = 2;
    }
}
