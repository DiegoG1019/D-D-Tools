using DiegoG.Utilities.Settings;

namespace DiegoG.DnDTools.CLI
{
    public class CLILang : ISettings
    {
        public ulong Version => 0;

        public string HealthReportBodyFormatString { get; set; } = "Base {0} | Effect {1} | Lethal Damage {2} | Non Lethal Damage {3}";
        public string HealthReportSubtitleFormatString { get; set; } = "Remaining {0}; {1} | State: {2}";
        public string ArmorClassReportBodyFormatString { get; set; } = "AC {0} | Touch {1} | Unaware {2}";
        public string ArmorClassReportSubtitleFormatString { get; set; } = "Base {0} | Size {1} | Natural {2} | Deflection {3} | Bonus {4} | Effect {5} | Armor {6}";
        public string ArmorClassReportExtraFormatString { get; set; } = "Add Dexterity to Unaware: {0}";
        public string InitiativeReportBodyFormatString { get; set; } = "Total {0} | Base Total {1}";
        public string InitiativeReportSubtitleFormatString { get; set; } = "Dex {0} | Bonus {1} | Effect {2} | Base Points {3}";
        public string ExperienceReportBodyFormatString { get; set; } = "Current {0} | Required {1} | Level {2}";
        public string ExperienceReportSubtitleFormatString { get; set; } = "Unspent Levels {0} | Exp. Grant {1} | Next Level {2}; {3}";
    }
}
