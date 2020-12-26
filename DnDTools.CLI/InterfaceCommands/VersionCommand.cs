using DiegoG.CLI;
using DiegoG.DnDTools.CLI.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.DnDTools.CLI.InterfaceCommands
{
    [CLICommand]
    public class VersionCommand : ICommand
    {
        public string HelpExplanation => "Returns the current version ";
        public string HelpUsage => "No special usage requirements";
        public string Trigger => "version";
        public string Alias => null;

        public Task<string> Action(string[] args)
        {
            OutConsole.Message =
            $"{Commands.Version} - Commands Processor and Console Wrapper\n" +
            $"{Utilities.Version.Assembly} - Utilities and General Re-usable code library\n" +
            $"{Base.Cache.DnDBase.FullAppTitle} - Foundation of the app and common code shared throughout implementations\n" +
            $"{Base.Cache.DnDCLI.FullAppTitle} - CLI Application";
            return Task.FromResult<string>(null);
        }
    }
}
