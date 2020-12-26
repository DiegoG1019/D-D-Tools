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

        private static Character Selected => DnDManager.Characters.Selected;
        private static string[] LastCall { get; set; }
        
        public ShowCommand() => DnDManager.Characters.PropertyChanged += Characters_PropertyChanged;

        private async void Characters_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (LastCall is not null && e.PropertyName == nameof(DnDManager.Characters.Selected))
                await Action(LastCall);
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
            if (args.Length < 2)
                throw new InvalidCommandArgumentException("Show Command must have an argument.");
            LastCall = args;
            return await (args[1] switch
            {
                StatsArg => ThrowHelper(StatsArg, NoArgs, args.Length, () => Stats()),
                BasicArg => ThrowHelper(BasicArg, NoArgs, args.Length, () => Basic()),
                _ => throw new InvalidCommandArgumentException($"Invalid argument for command Character: {args.Flatten()}")
            });
        }
    }
}
