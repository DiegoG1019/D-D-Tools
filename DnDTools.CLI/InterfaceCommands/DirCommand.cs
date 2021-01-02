using DiegoG.CLI;
using DiegoG.DnDTools.Base;
using DiegoG.DnDTools.CLI.Display;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.DnDTools.CLI.InterfaceCommands
{
    [CLICommand]
    public class DirCommand : ICommand
    {
        public string HelpExplanation => "Provides information regarding the directories used by the application";
        public string HelpUsage => "(index)";
        public string Trigger => "Dir";
        public string Alias => null;

        private static Task<string> GetAllList()
        {
            var str = "Directories: \n";
            var c = 0;
            foreach (var (d, p) in Directories.AllDirectories)
            {
                str += $"{c}: {d} dir @ {p}\n";
                c++;
            }
            OutConsole.Message = str;
            return Task.FromResult<string>(null);
        }
        void ICommand.ClearData() { return; }

        //This is, ideally, not something that will be called often.
        private static Task<string> OpenDir(string ind)
        {
            if(int.TryParse(ind, out int index))
            {
                try { Process.Start("explorer.exe", Directories.AllDirectories.ToArray()[index].Path); }
                catch(IndexOutOfRangeException e) { throw new InvalidCommandArgumentException("The given argument is not a valid index. Try retrieving the list of directories first", e); }
                return Task.FromResult<string>(null);
            }
            var dirname = Directories.AllDirectories.Where(d => d.Directory.ToLower() == ind.ToLower()).Select(d => d.Path).FirstOrDefault();
            if (dirname is not null)
            {
                Process.Start("explorer.exe", dirname);
                return null;
            }
            throw new InvalidCommandArgumentException("The given argument is not a numerical index nor a valid directory name");
        }
        public Task<string> Action(string[] args)
        {
            if (args.Length > 1)
                return OpenDir(args[1]);
            else
                return GetAllList();
        }
    }
}
