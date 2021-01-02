using DiegoG.Utilities.Settings;
using System;

namespace DiegoG.DnDTools.CLI
{
    public class CLILang : ISettings
    {
        public ulong Version => 1;

        public ReportsLang Reports { get; set; } = new();
        public class ReportsLang
        {
            public CharacterDataLang CharacterData { get; set; } = new();
            public class CharacterDataLang
            {
                public string HealthReportBodyFormatString { get; set; } = "Base {0} | Effect {1} | Lethal Damage {2} | Non Lethal Damage {3}";
                public string HealthReportSubtitleFormatString { get; set; } = "Remaining {0}; {1} | State: {2}";
                public string ArmorClassReportBodyFormatString { get; set; } = "AC {0} | Touch {1} | Unaware {2}";
                public string ArmorClassReportSubtitleFormatString { get; set; } = "Base {0} | Size {1} | Natural {2} | Deflection {3} | Bonus {4} | Effect {5} | Armor {6}";
                public string ArmorClassReportExtraFormatString { get; set; } = "Add Dexterity to Unaware: {0}";
                public string InitiativeReportBodyFormatString { get; set; } = "Total {0} | Base Total {1}";
                public string InitiativeReportSubtitleFormatString { get; set; } = "Dex {0} | Bonus {1} | Effect {2} | Base Points {3}";
                public string ExperienceReportBodyFormatString { get; set; } = "Current {0} | Required {1} | Level {2}";
                public string ExperienceReportSubtitleFormatString { get; set; } = "Unspent Levels {0} | Exp. Grant {1} | Next Level {2}; {3}";
                public string CharacterStatReportBody { get; set; } = "Total: {0} | Modifier: {1}";
                public string CharacterStatReportSubtitle { get; set; } = "Base Total: {0} | Base Modifier: {1} | Points: {2}";
                public string CharacterStatReportExtra { get; set; } = "Bonus: {0} | Effect: {1}";
            }
        }

        public CommandsLang Commands { get; set; } = new();
        [Serializable]
        public class CommandsLang
        {
            public string InvalidCommandExceptionText { get; set; } = "Invalid Command";
            public string InvalidCommandArgumentExceptionText { get; set; } = "Invalid Command Argument";
            public string CommandProcessExceptionText { get; set; } = "Problem with command execution";
            public string IntroMessage { get; set; } = "Type {0} to get a list of commands";

            public ShowCommandLang ShowCommand { get; set; } = new();
            [Serializable]
            public class ShowCommandLang
            {
                public string HelpExplanation { get; set; } = "Displays a report on the current character's specified data";
                public string HelpUsage { get; set; } = "{0}\n" +
                    "   *{1} - Displays Basic Data about the Selected Character\n" +
                    "   *{2} - Displays Detailed Stat Data about the Selected Character\n" +
                    "   *{3} - Displays the members of the specified property";
                public string BasicDataText { get; set; } = "Displaying Basic Data";
                public string StatsDataText { get; set; } = "Displaying Stats Data";
                public string DataText { get; set; } = "Displaying Specified Data";
            }

            public CharacterCommandsLang CharacterCommand { get; set; } = new();
            [Serializable]
            public class CharacterCommandsLang
            {
                public string HelpExplanation { get; set; } = "Manipulates the Character List";
                public string HelpUsage { get; set; } = "[{0}] ({1})\n" +
                    "   {0} - action to be taken when the command is issued.\n" +
                    "   Valid actions include:\n" +
                    "   * {4} [{2}] (Save {3}) - Unregisters the specified character, returns {3}\n" +
                    "   * {5} [{2}] - Returns whether the specified character is registered\n" +
                    "   * {6} - Returns the {2} of the currently selected character\n" +
                    "   * {7} [{2}] - Selects a new character based on its filename, returns {3}\n" +
                    "   * {8} - Returns a list enumerating all the currently loaded characters\n" +
                    "   * {9} [index] - Returns the character at the specified index of the character enumeration (It is recommended to call without index first, as the ordering may change unexpectedly)\n" +
                    "   * {10} [{2}] - Loads the given character from a file into memory. Returns {3}\n" +
                    "   * {11} [{2}] - Creates a brand new character with the given filename, and returns the same filename\n" +
                    "   * {12} ({2}) - Saves the specified or currently selected character. Returns {3}\n" +
                    "   * {13} - Obtains a list of all the character files available to load\n" +
                    "   * {14} - Loads and Selects the specified character";
                public string RegisteredResult { get; set; } = "Registered";
                public string NotRegisteredResult { get; set; } = "Not Registered";
                public string SelectedCharacterResult { get; set; } = "Currently Selected Character: ";
                public string SelectedNoCharacterResult { get; set; } = "No Character is Selected";
                public string CharacterSelectedResult { get; set; } = "Character {0} ({1}) is now selected";
                public string CharacterNotExist { get; set; } = "Character {0} doesn't exist";
                public string CharacterUnregister { get; set; } = "Character {0} ({1}) succesfully unregistered";
                public string CharacterUnregisterSaved { get; set; } = "Character {0} ({1}) succesfully saved and unregistered";
                public string CharacterGetBadIndex { get; set; } = "This index is invalid for a character. Try calling \"All\" first";
                public string CharacterLoaded { get; set; } = "Succesfully loaded Character {0} ({1})";
                public string CharacterReloaded { get; set; } = "Succesfully reloaded Character {0} ({1})";
                public string CharacterSaved { get; set; } = "Succesfully saved Character {0} ({1})";
                public string AllCharactersNotif { get; set; } = "Showing all loaded characters";
                public string CharacterCreated { get; set; } = "Succesfully created new character {0}";
            }
        }
    }
}
