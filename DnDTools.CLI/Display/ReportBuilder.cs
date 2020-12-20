using DiegoG.DnDTools.Base;
using DiegoG.DnDTools.Base.Characters;
using DiegoG.Utilities;
using DiegoG.Utilities.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.CLI.Display
{
    public static class ReportBuilder
    {
        private static Lang Lang => Settings<Lang>.Current;
        private static CLILang CLang => Settings<CLILang>.Current;
        private static Dictionary<Stats, string> ShStats => Lang.ShortStatsStrings;
        public async static Task<Report> CharacterData(Character c)
        {
            AsyncTaskManager tasks = new();

            var classes = string.Empty;
            tasks.Run
            (
                () =>
                {
                    if (c.Jobs.Count > 0)
                    {
                        classes = ":";
                        foreach (var j in c.Jobs)
                            classes += $" {j.Name},";
                        classes = classes[0..^2];
                    }
                }
            );

            string stats = "";
            string basestats = "";
            tasks.Run
            (
                () =>
                {
                    foreach (var s in StatsCollection)
                    {
                        stats += $"{ShStats[s]} {c.Stats[s].Total:00} : {c.Stats[s].Modifier:0} | ";
                        basestats += $"{ShStats[s]} {c.Stats[s].BaseTotal:00} : {c.Stats[s].BaseModifier:0} | ";
                    }
                    stats = stats[0..^3] + $" — {Lang.CurrentText}";
                    basestats = basestats[0..^3] + $" — {Lang.BaseText}";
                }
            );

            string sthrows = "";
            string basesthrows = "";
            tasks.Run
            (
                () =>
                {
                    foreach (var s in SavingThrowCollection)
                    {
                        sthrows += $"{Lang.SavingThrowStrings[s]} {c.SavingThrows[s].Total:00} | ";
                        basesthrows += $"{Lang.SavingThrowStrings[s]} {c.SavingThrows[s].BaseTotal:0} | ";
                    }
                    sthrows = sthrows[0..^3] + Lang.CurrentText + $" — {Lang.CurrentText}";
                    basesthrows = basesthrows[0..^3] + Lang.BaseText + $" — {Lang.BaseText}";
                }
            );


            //
            Health chp = c.Health;
            ArmorClass cac = c.ArmorClass;
            Experience cexp = c.Experience;

            await tasks;

            return new()
            {
                Title = Lang.CharacterDataText,
                Footer = $"{c.Description.Name}, {Lang.LevelText} {c.Jobs.AllLevels}" + classes,
                Lines = new List<ReportLine>()
                {
                    new()
                    {
                        Title = Lang.StatsText,
                        Body = stats,
                        Subtitle = basestats
                    },
                    new()
                    {
                        Title = Lang.SavingThrowsText,
                        Body = sthrows,
                        Subtitle = basesthrows
                    },
                    new()
                    {
                        Title = Lang.HealthText,
                        Body = CLang.HealthReportBodyFormatString.Format(chp.BaseHP, chp.EffectHP, chp.LethalDamage.Damage, Lang.NonLethalDamageText, chp.NonlethalDamage.Damage),
                        Subtitle = CLang.HealthReportSubtitleFormatString.Format(chp.RemainingHP, chp.HPRelation.PercentageString, Lang.CombatStateStrings[chp.State]),
                    },
                    new()
                    {
                        Title = Lang.ArmorClassText,
                        Body = CLang.ArmorClassReportBodyFormatString.Format(cac.AC, cac.TouchAC, cac.UnawareAC),
                        Subtitle = CLang.ArmorClassReportSubtitleFormatString.Format(cac.BaseAC, cac.Size, cac.Natural, cac.Deflection, cac.Bonus, cac.Effect, cac.Armor),
                        Extra = CLang.ArmorClassReportExtraFormatString.Format(cac.UnawareDex)
                    },
                    new()
                    {
                        Title = Lang.InitiativeText,
                        Body = CLang.InitiativeReportBodyFormatString.Format(c.Initiative.Total, c.Initiative.BaseTotal),
                        Subtitle = CLang.InitiativeReportSubtitleFormatString.Format(c.Stats[Stats.Dexterity].Modifier, c.Initiative.Bonus, c.Initiative.EffectPoints, c.Initiative.BasePoints)
                    },
                    new()
                    {
                        Title = Lang.ExperienceText,
                        Body = CLang.ExperienceReportBodyFormatString.Format(cexp.Current, cexp.Required, cexp.Level),
                        Subtitle = CLang.ExperienceReportSubtitleFormatString.Format(cexp.UnspentLevels, cexp.Grant, cexp.Left, cexp.Progress.String)
                    }
                }
            };
        }
    }
}
