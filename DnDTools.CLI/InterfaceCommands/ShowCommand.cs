using DiegoG.CLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiegoG.DnDTools.Base;
using DiegoG.DnDTools.Base.Characters;
using DiegoG.DnDTools.CLI.Display;
using DiegoG.Utilities;
using DiegoG.Utilities.Collections;
using DiegoG.Utilities.Settings;
using System.Collections;
using DiegoG.DnDTools.Base.Attributes;

namespace DiegoG.DnDTools.CLI.InterfaceCommands
{
    [CLICommand]
    public class ShowCommand : CharacterRelatedCommandAbstract, ICommand
    {
        public string HelpExplanation => SLang.HelpExplanation;
        public string HelpUsage => string.Format(SLang.HelpUsage, "[action] (args..)", BasicArg, StatsArg);
        public string Trigger => "show";
        public string Alias => "s";

        private const string BasicArg = "basic";
        private const string StatsArg = "stats";
        private const string DataArg = "data";

        private static Character Selected => DnDManager.Characters.Selected;
        private static string[] LastCall { get; set; }
        void ICommand.ClearData() => LastCall = null;

        public ShowCommand() => DnDManager.Characters.PropertyChanged += Characters_PropertyChanged;

        private async void Characters_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (LastCall is not null && e.PropertyName == nameof(DnDManager.Characters.Selected))
                await Action(LastCall);
        }

        private static readonly Type charactertype = typeof(Character);
        public static async Task<string> Data(string[] args)
        {
            var tsk = ReportBuilder.Footer(Characters.Selected);
            object instance = Characters.Selected;
            var thistype = charactertype;
            foreach (string s in args)
            {
                var prop = thistype.GetProperty(s);
                if (prop is null)
                    throw new InvalidCommandArgumentException($"{thistype.Name} does not contain a property named {s}");
                thistype = prop.PropertyType;
                instance = prop.GetValue(instance);
            }

            List<ReportLine> reportlines = new();
            foreach (var (name, value) in from prop 
                                          in thistype.GetProperties()
                                          let att = prop.GetCustomAttributes(typeof(PresentationRelevantAttribute), false)
                                          where att is not null && att.Length > 0
                                          select ((att[0] as PresentationRelevantAttribute).LangPropertyName, prop.GetValue(instance)))
                reportlines.Add(new()
                {
                    Title = name,
                    Body = value.ToString(),
                });

            OutConsole.DisplayedReport = new()
            {
                Title = string.Format(Settings<Lang>.Current.UI.CharacterDataFormatText, Characters.Selected.Description.Name, Characters.Selected.CharacterFileName),
                Footer = await tsk,
                Lines = reportlines
            };
            return null;
        }

        public static async Task<string> Stats()
        {
            OutConsole.DisplayedReport = await ReportBuilder.StatsReport(Selected);
            OutConsole.Message = SLang.StatsDataText;
            return nameof(ReportBuilder.Reports.Stats).ToLower();
        }

        public static async Task<string> Basic()
        {
            OutConsole.DisplayedReport = await ReportBuilder.CharacterDataReport(Selected);
            OutConsole.Message = SLang.BasicDataText;
            return nameof(ReportBuilder.Reports.Basic).ToLower();
        }

        public async Task<string> Action(params string[] args)
        {
            if (Characters.Selected is null)
                return "No character is selected";
            if (args.Length < 2)
                throw new InvalidCommandArgumentException("Show Command must have an argument.");
            LastCall = args;
            return await (args[1] switch
            {
                StatsArg => ThrowHelper(StatsArg, NoArgs, args.Length, () => Stats()),
                BasicArg => ThrowHelper(BasicArg, NoArgs, args.Length, () => Basic()),
                DataArg  => ThrowHelper(DataArg, NoArgs, args.Length, () => Data(args.StartingAtIndex(2).ToArray())),
                _ => throw new InvalidCommandArgumentException($"Invalid argument for command Character: {args.Flatten()}")
            });
        }
    }
}
