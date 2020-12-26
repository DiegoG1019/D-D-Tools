using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiegoG.CLI;
using DiegoG.DnDTools.Base;
using DiegoG.Utilities.Settings;
using static DiegoG.DnDTools.CLI.CLILang.CommandsLang;

namespace DiegoG.DnDTools.CLI.InterfaceCommands
{
    public abstract class CharacterRelatedCommandAbstract
    {
        protected static string ThrowHelper(string argname, int expected, int gotten, Func<string> method)
            => expected >= gotten ? method() : throw new InvalidCommandArgumentException($"Invalid number of arguments for {argname}. Expected {expected}, gotten {gotten}");
        protected static async Task<string> ThrowHelper(string argname, int expected, int gotten, Func<Task<string>> method)
            => expected <= gotten ? await method() : throw new InvalidCommandArgumentException($"Invalid number of arguments for {argname}. Expected {expected}, gotten {gotten}");

        protected const int NoArgs = 2;
        protected const int OneArg = 3;
        protected static int Args(int n) => n + 2;
        protected static ShowCommandLang SLang => Settings<CLILang>.Current.Commands.ShowCommand;
        protected static CharacterCommandsLang CLang => Settings<CLILang>.Current.Commands.CharacterCommand;
        protected static CharacterList Characters => DnDManager.Characters;

    }
}
