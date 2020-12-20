using DiegoG.DnDTools.Base.Characters;
using DiegoG.DnDTools.CLI;
using DiegoG.DnDTools.CLI.Display;
using System;

Program.Init();

await new Character("No'One").SerializeAsync(); 
//await Character.DeserializeAndRegisterAsync("No'One");
var Quentin = await Character.DeserializeAndRegisterAsync("Quentin");

(await ReportBuilder.CharacterData(Quentin)).DrawToConsole();

//await Commands.Call(args);
Console.ReadKey();