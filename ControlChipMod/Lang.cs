using System.Collections.Generic;
using SMLHelper.V2.Handlers;

namespace J2bT.ControlChipMod
{
    internal static class Lang
    {
        internal static class Messages
        {
            public const string MapRoomDestroyed = Main.modName + ".Messages.MapRoomDestroyed";
            public const string SearchFor = Main.modName + ".Messages.SearchFor";
            public const string MapRoomDeact = Main.modName + ".Messages.MapRoomDeact";
            public const string ErrLastRes = Main.modName + ".Messages.ErrLastRes";
            public const string ErrFirstRes = Main.modName + ".Messages.ErrFirstRes";
            public const string ErrLastRoom = Main.modName + ".Messages.ErrLastRoom";
            public const string ErrFirstRoom = Main.modName + ".Messages.ErrFirstRoom";
            public const string ErrRoomOff = Main.modName + ".Messages.ErrRoomOff";
        }

        internal static class Options
        {
            public const string MenuName = Main.modName + ".Options.MenuName";
            public const string NextResource = Main.modName + ".Options.NextResource";
            public const string PreviousResource = Main.modName + ".Options.PreviousResource";
            public const string NextRoom = Main.modName + ".Options.NextRoom";
            public const string PreviousRoom = Main.modName + ".Options.PreviousRoom";
            public const string StopRoom = Main.modName + ".Options.StopRoom";
            public const string MessageChoice = Main.modName + ".Options.MessageChoice";
            public const string IconChoice = Main.modName + ".Options.IconChoice";
            public const string ChipEquippedTooltip = Main.modName + ".Options.ChipEquippedTooltip";
            public const string Always = Main.modName + ".Options.Always";
            public const string OnSelect = Main.modName + ".Options.OnSelect";
        }

        public static void Patch()
        {
            foreach (var entry in new Dictionary<string, string>()
            {
                [Options.MenuName] = "Scanner Room Control Chip",
                [Options.NextResource] = "Next resource / Turn on scanner room",
                [Options.PreviousResource] = "Previous resource",
                [Options.NextRoom] = "Next scanner room",
                [Options.PreviousRoom] = "Previous scanner room",
                [Options.StopRoom] = "Turn off selected scanner room",
                [Options.MessageChoice] = "Display a message on selecting a resource?",
                [Options.IconChoice] = "Display the icon of the selected resource?",
                [Options.ChipEquippedTooltip] = "Will only work if the chip is equipped.",
                [Options.Always] = "Always, if the room is on",
                [Options.OnSelect] = "On selecting a resource",
                [Messages.MapRoomDestroyed] = "Selected scanner room was destroyed. Selecting previous one.",
                [Messages.SearchFor] = "Searching for",
                [Messages.MapRoomDeact] = "Turning off selected scanner room.",
                [Messages.ErrLastRes] = "Can't select next resource! The last resource is currently selected.",
                [Messages.ErrFirstRes] = "Can't select previous resource! The first resource is currently selected.",
                [Messages.ErrLastRoom] = "Can't select next room! The last room is currently selected.",
                [Messages.ErrFirstRoom] = "Can't select previous room! The first room is currently selected.",
                [Messages.ErrRoomOff] = "Can't select previous resource! Selected room is not active."
            })
            {
                LanguageHandler.Main.SetLanguageLine(entry.Key, entry.Value);
            }
        }
    }
}
