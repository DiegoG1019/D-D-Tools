using DiegoG.CLI;
using DiegoG.DnDTools.Base.Characters;
using DiegoG.DnDTools.CLI;
using DiegoG.DnDTools.CLI.Display;
using System.Threading.Tasks;
using System;

Program.Init();
OutConsole.Begin();

for (; ; )
    await Task.Delay(500);

/*
await new Character("No'One").SerializeAsync(); 
//await Character.DeserializeAndRegisterAsync("No'One");
var Quentin = await Character.DeserializeAndRegisterAsync("Quentin");

(await ReportBuilder.CharacterData(Quentin)).DrawToConsole();

//await Commands.Call(args);*/