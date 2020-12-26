using DiegoG.CLI;
using DiegoG.Utilities.Settings;
using DiegoG.DnDTools.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiegoG.DnDTools.CLI.CLILang.CommandsLang;
using DiegoG.Utilities.Collections;
using DiegoG.Utilities;
using DiegoG.DnDTools.Base.Characters;
using DiegoG.DnDTools.CLI.Display;

namespace DiegoG.DnDTools.CLI.InterfaceCommands
{
    [CLICommand]
    public class CharacterCommand : CharacterRelatedCommandAbstract, ICommand
    {
        public string HelpExplanation => CLang.HelpExplanation;
        public string HelpUsage => string.Format(CLang.HelpUsage, "action", "arg", "characterFileName", "Y/N", UnregisterArg, IsRegisteredArg, SelectedArg, SelectArg, AllArg, GetArg, LoadArg, CreateArg, SaveArg, GetFilesArg);
        public string Trigger => "character";
        public string Alias => "c";

        private const string UnregisterArg   = "unregister";
        private const string IsRegisteredArg = "isregistered";
        private const string SelectedArg     = "selected";
        private const string SelectArg       = "select";
        private const string AllArg          = "all";
        private const string GetArg          = "get";
        private const string LoadArg         = "load";
        private const string CreateArg       = "create";
        private const string SaveArg         = "save";
        private const string GetFilesArg     = "getfiles";

        private static List<string> CfnList { get; } = new();

        private static async Task<string> GetFiles(string index)
        {
            var ind = -1;
            var sindex = 0;
            var returnstr = "";
            if (!string.IsNullOrWhiteSpace(index))
                if (!int.TryParse(index, out ind))
                    throw new InvalidCommandArgumentException($"Argument index of Character GetFiles (index) is invalid. Given string: {index}");
            var str = "";
            foreach (var s in await Character.CharacterFiles())
            {
                if (sindex == ind)
                    returnstr = s;
                str += $" * {sindex} - {s}\n";
                sindex++;
            }
            OutConsole.Message = str;
            return returnstr;
        }
        private static async Task<string> Save(string characterFileName = null)
        {
            characterFileName ??= Characters.Selected.CharacterFileName;
            Character chara = Characters[characterFileName];
            var tks = chara.SerializeAsync();
            OutConsole.Message = string.Format(CLang.CharacterSaved, characterFileName, chara.Description.Name);
            await tks;
            return characterFileName;
        }
        private static Task<string> Create(string characterFileName)
        {
            Characters.Register(new Character(characterFileName));
            OutConsole.Message = string.Format(CLang.CharacterCreated, characterFileName);
            return Task.FromResult(characterFileName);
        }
        private static async Task<string> Load(string characterFileName)
        {
            (Task<Character> Task, bool Reloaded) tskr;
            try
            {
                if (Characters.IsRegistered(characterFileName))
                    tskr = (Character.DeserializeAndReplaceAsync(Characters[characterFileName]), true);
                else
                    tskr = (Character.DeserializeAndRegisterAsync(characterFileName), false);
                OutConsole.Message = string.Format(tskr.Reloaded ? CLang.CharacterLoaded : CLang.CharacterReloaded, characterFileName, (await tskr.Task).Description.Name);
                return characterFileName;
            }catch(InvalidCharacterException e) { throw new CommandProcessException("Failed to load the character, character file is invalid", e); }
        }
        private static Task<string> Get(string index)
        {
            if (!int.TryParse(index, out int ind) || !(ind < CfnList.Count))
            {
                OutConsole.Message = CLang.CharacterGetBadIndex;
                return Task.FromResult<string>(null);
            }
            return Task.FromResult(CfnList[ind]);
        }
        private static Task<string> All()
        {
            CfnList.Clear();
            int ind = 0;
            string str = "";
            foreach(var s in Characters)
            {
                CfnList.Add(s.CharacterFileName);
                str += $"{ind:000} = {s.CharacterFileName} ({s.Description.Name})\n";
                ind++;
            }
            OutConsole.Message = CLang.AllCharactersNotif + "\n" + str;
            return Task.FromResult<string>(null);
        }
        private static Task<string> Select(string cfn)
        {
            if (!Characters.IsRegistered(cfn))
            {
                OutConsole.Message = string.Format(CLang.CharacterNotExist, cfn);
                return Task.FromResult<string>(null);
            }
            Characters.Select(cfn);
            OutConsole.Message = string.Format(CLang.CharacterSelectedResult, cfn, Characters[cfn].Description.Name);
            return Task.FromResult(cfn);
        }
        private static Task<string> Selected()
        {
            OutConsole.Message = CLang.SelectedCharacterResult + Characters.Selected.CharacterFileName;
            return Task.FromResult(Characters.Selected.CharacterFileName);
        }
        private static Task<string> IsRegistered(string cfn) => Task.FromResult(Characters.IsRegistered(cfn) ? CLang.RegisteredResult : CLang.NotRegisteredResult);
        private static async Task<string> Unregister(string cfn, string savestr = null)
        {
            if (cfn is null || savestr is null)
                throw new InvalidCommandArgumentException($"Expected characterFileName and Y/N/true/false, got: {cfn ?? "null"} {savestr ?? "null"}");
            if (!Commands.TryParseYesNo(savestr, out bool save))
                throw new InvalidCommandArgumentException($"Cannot parse argument \"save\" = {save}");

            if (Characters.IsRegistered(cfn))
            {
                var chara = Characters[cfn];
                Task slz = Task.CompletedTask;
                if (save)
                    slz = chara.SerializeAsync();
                Characters.Unregister(cfn);
                OutConsole.Message = string.Format(save ? CLang.CharacterUnregisterSaved : CLang.CharacterUnregister, cfn, chara.Description.Name);
                await slz;
                return cfn;
            }
            OutConsole.Message = string.Format(CLang.CharacterNotExist, cfn);
            return cfn;
        }

        public Task<string> Action(string[] args)
        {
            if (args.Length < 2)
                throw new InvalidCommandArgumentException("Character Command must have an argument.");
            return args[1] switch
            {
                IsRegisteredArg => ThrowHelper(IsRegisteredArg, OneArg, args.Length, () => IsRegistered(args[2])),
                LoadArg => ThrowHelper(LoadArg, OneArg, args.Length, () => Load(args[2])),
                CreateArg => ThrowHelper(CreateArg, OneArg, args.Length, () => Create(args[2])),
                SaveArg => ThrowHelper(SaveArg, OneArg, args.Length, () => Save(args[2])),
                SelectedArg => ThrowHelper(SelectedArg, NoArgs, args.Length, () => Selected()),
                GetArg => ThrowHelper(GetArg, OneArg, args.Length, () => Get(args[2])),
                SelectArg => ThrowHelper(SelectArg, OneArg, args.Length, () => Select(args[2])),
                AllArg => ThrowHelper(AllArg, NoArgs, args.Length, () => All()),
                GetFilesArg => ThrowHelper(GetFilesArg, NoArgs, args.Length, () => GetFiles(args.Length >= 3 ? args[2] : null)),
                UnregisterArg => ThrowHelper(UnregisterArg, OneArg, args.Length, () => Unregister(args[2], args.Length >= 4 ? args[3] : "true")),
                _ => throw new InvalidCommandArgumentException($"Invalid argument for command Character: {args.Flatten()}")
            };
        }
    }
}
