using DiegoG.DnDTools.Base;
using DiegoG.DnDTools.Base.Characters;
using DiegoG.DnDTools.Base.Characters.Complements;
using DiegoG.Utilities;
using DiegoG.Utilities.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.CLI.Display
{
    public static class ReportBuilder
    {
        public enum Reports { Basic, Stats }
        private static Lang.OtherLang OtherLang => Settings<Lang>.Current.Other;
        private static Lang.CharacterDataLang ChardatLang => Settings<Lang>.Current.CharacterData;
        private static Lang.UILang UILang => Settings<Lang>.Current.UI;
        private static CLILang.ReportsLang RLang => Settings<CLILang>.Current.Reports;
        private static Dictionary<Stats, string> ShStats => Settings<Lang>.Current.ShortStatsStrings;
        private static Dictionary<Stats, string> LoStats => Settings<Lang>.Current.StatsStrings;
        private static Dictionary<SavingThrow, string> SThrows => Settings<Lang>.Current.SavingThrowStrings;

        public static Task<Report> GetReport(Reports report, Character c) => report switch
        {
            Reports.Basic => CharacterDataReport(c),
            Reports.Stats => StatsReport(c),
            _ => throw new System.NotSupportedException("Unknown Reports enum value"),
        };

        public async static Task<Report> StatsReport(Character c)
        {
            var footer = Footer(c);
            var lines = Task.Run
                (() =>
                {
                    List<ReportLine> list = new();
                    foreach (var(stat, prop) in c.Stats.GetKVTuple())
                        list.Add(new()
                        {
                            Title = LoStats[stat],
                            Body = string.Format(RLang.CharacterData.CharacterStatReportBody, prop.Total, prop.Modifier),
                            Subtitle = string.Format(RLang.CharacterData.CharacterStatReportSubtitle, prop.BaseTotal, prop.BaseModifier, prop.BasePoints),
                            Extra = string.Format(RLang.CharacterData.CharacterStatReportExtra, prop.Bonus, prop.EffectPoints)
                        });
                    return list;
                });
            return await Task.Run
            (async () =>
            {
                return new Report()
                {
                    Title = string.Format(UILang.CharacterStatsFormatText, c.Description.Name, c.CharacterFileName),
                    Lines = await lines,
                    Footer = await footer,
                };
            }
            );
        }
        public async static Task<Report> CharacterDataReport(Character c)
        {
            AsyncTaskManager tasks = new();
            var footer = Footer(c);

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
                    stats = stats[0..^3] + $" — {OtherLang.CurrentText}";
                    basestats = basestats[0..^3] + $" — {OtherLang.BaseText}";
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
                        sthrows += $"{SThrows[s]} {c.SavingThrows[s].Total:00} | ";
                        basesthrows += $"{SThrows[s]} {c.SavingThrows[s].BaseTotal:0} | ";
                    }
                    sthrows = sthrows[0..^3] + $" — {OtherLang.CurrentText}";
                    basesthrows = basesthrows[0..^3] + $" — {OtherLang.BaseText}";
                }
            );

            Health chp = c.Health;
            ArmorClass cac = c.ArmorClass;
            Experience cexp = c.Experience;

            await tasks;

            return new()
            {
                Title = string.Format(UILang.CharacterBasicDataFormatText, c.Description.Name, c.CharacterFileName),
                Lines = new ReportLine[]
                {
                    new()
                    {
                        Title = ChardatLang.StatsText,
                        Body = stats,
                        Subtitle = basestats
                    },
                    new()
                    {
                        Title = ChardatLang.SavingThrowsText,
                        Body = sthrows,
                        Subtitle = basesthrows
                    },
                    new()
                    {
                        Title = ChardatLang.HealthText,
                        Body = RLang.CharacterData.HealthReportBodyFormatString.Format(chp.BaseHP, chp.EffectHP, chp.LethalDamage.Damage, chp.NonlethalDamage.Damage),
                        Subtitle = RLang.CharacterData.HealthReportSubtitleFormatString.Format(chp.RemainingHP, chp.HPRelation.PercentageString, Settings<Lang>.Current.CombatStateStrings[chp.State]),
                    },
                    new()
                    {
                        Title = ChardatLang.ArmorClassText,
                        Body = RLang.CharacterData.ArmorClassReportBodyFormatString.Format(cac.AC, cac.TouchAC, cac.UnawareAC),
                        Subtitle = RLang.CharacterData.ArmorClassReportSubtitleFormatString.Format(cac.BaseAC, cac.Size, cac.Natural, cac.Deflection, cac.Bonus, cac.Effect, cac.Armor),
                        Extra = RLang.CharacterData.ArmorClassReportExtraFormatString.Format(cac.UnawareDex)
                    },
                    new()
                    {
                        Title = ChardatLang.InitiativeText,
                        Body = RLang.CharacterData.InitiativeReportBodyFormatString.Format(c.Initiative.Total, c.Initiative.BaseTotal),
                        Subtitle = RLang.CharacterData.InitiativeReportSubtitleFormatString.Format(c.Stats[Stats.Dexterity].Modifier, c.Initiative.Bonus, c.Initiative.EffectPoints, c.Initiative.BasePoints)
                    },
                    new()
                    {
                        Title = ChardatLang.ExperienceText,
                        Body = RLang.CharacterData.ExperienceReportBodyFormatString.Format(cexp.Current, cexp.Required, cexp.Level),
                        Subtitle = RLang.CharacterData.ExperienceReportSubtitleFormatString.Format(cexp.UnspentLevels, cexp.Grant, cexp.Left, cexp.Progress.String)
                    }
                },
                Footer = await footer,
            };
        }

        private static async Task<string> GetClassList(Character c) => await Task.Run
            (
                () =>
                {
                    string classes = "";
                    if (c.Jobs.Count > 0)
                    {
                        classes = ":";
                        foreach (var j in c.Jobs)
                            classes += $" {j.Name},";
                        classes = classes[0..^2];
                    }
                    return classes;
                }
            );
        public static async Task<string> Footer(Character c) => $"{c.Description.Name}, {ChardatLang.LevelText} {c.Jobs.AllLevels}" + await GetClassList(c);
    }
}
