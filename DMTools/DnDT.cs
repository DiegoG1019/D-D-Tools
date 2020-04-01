#define DEBUG
#define VERBOSE
//#define CONSOLE

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Windows.Forms;
using Serilog;
using Serilog.Sinks.File;
using Serilog.Sinks.SystemConsole;
using System.IO;

namespace DnDTDesktop
{

    public enum Stats
    {
        strength, constitution, dexterity, wisdom, intelligence, charisma,
        fortitude, reflex, will, speed, initiative
    }; //Is it possible to dynamically initialize an enum? Maybe I just need a new object type

    public enum Schools
    {
        abjuration, divination, conjuration, enchantment, evocation, illusion, necromancy, transmutation
    } //Perhaps both of these should be a configuration option

    static class App
    {

        public static readonly Version version = new Version("Alpha", 0, 0, 17, 0);
        public static int statCount = Enum.GetNames(typeof(Stats)).Length;
        public static int schoolCount = Enum.GetNames(typeof(Schools)).Length;

        public const string author = "Diego Garcia";
        public const string appname = "D&DTools Windows";

        public static class Directories
        {
            public static string DataOut = Path.Combine("DnDT");
            public static string Characters = Path.Combine(DataOut, "Characters");
            public static string Entities = Path.Combine(DataOut, "Entities");
            public static string Temp = Path.GetTempPath();
            public static string Working = Path.GetFullPath(Directory.GetCurrentDirectory());
            public static void InitDirectories()
            {
                Directory.CreateDirectory(DataOut);
                Directory.CreateDirectory(Characters);
                Directory.CreateDirectory(Entities);
            }
        }

        public static int tchar;

        public static JsonSerializerOptions JSONOptions = new JsonSerializerOptions{
            WriteIndented = true,
        };/**/

        [STAThread]
        static void Main()
        {

            /*--------------------------------------------  -------------------------------------------*/

            /*--------------------------------------Initialization-------------------------------------*/

            Log.Logger = new LoggerConfiguration()
#if (DEBUG && !VERBOSE)
                .MinimumLevel.Debug()
#endif
#if (VERBOSE)
                .MinimumLevel.Verbose()
#endif
                .WriteTo.Console()
                .WriteTo.File(Path.Combine(Directories.Working,"log-.txt"), rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Debug("Succesfully started logger with a mimum level of {0}",
#if (DEBUG && !VERBOSE)
                "DEBUG"
#endif
#if (VERBOSE)
                "VERBOSE"
#endif
                );

            Log.Information("Program Author: {0}", App.author);
            Log.Information("Running D&DTools version: {0}", App.version.Full);

            Cf.LoadLang();
            Cf.LoadOptions();
            App.Directories.InitDirectories();
            Log.Information("Finished Initializing all Application directories");
            Log.Information("DataOut Directory: {0}", Path.GetFullPath(Directories.DataOut));
            Log.Information("Characters storage Directory: {0}", Path.GetFullPath(Directories.Characters));
            Log.Information("Entities storage Directory: {0}", Path.GetFullPath(Directories.Entities));
            Log.Information("Temp Directory: {0}", Path.GetFullPath(Directories.Temp));
            Log.Information("Working Directory: {0}", Path.GetFullPath(Directories.Working));

            Log.Information("Finished the Initialization of the Application");

            /*-----------------------------------------Testing-----------------------------------------*/

            //test char
            tchar = Character.Create(5, "Tchar");
            /*
            Loaded.Characters.Objects[tchar].armorC.armor = 5;
            Loaded.Characters.Objects[tchar].SetBaseStats(Stats.dexterity, 14);
            Loaded.Characters.Objects[tchar].SetBaseStats(Stats.charisma, 2);

            string tcskt = "{0}, ";
            string tcsk = "";
            for (int i = 0; i < Loaded.Characters.Objects[tchar].abilities.Count; i++)
            {
                tcsk += String.Format(tcskt, Loaded.Characters.Objects[tchar].feats[i].FullName);
            }
            for (int i = 0; i < Loaded.Characters.Objects[tchar].feats.Count; i++)
            {
                tcsk += String.Format(tcskt, Loaded.Characters.Objects[tchar].abilities[i].FullName);
            }

            string tc = "---------------- \n {0}'s significant abilities and feats: {1}";
            string tcs = "-----***----- \n {0}'s {1} #{2}: {3}\n  -{4}\n  Requires: {5}";

            Console.WriteLine(
                tc,
                Loaded.Characters.Objects[tchar].desc.name,
                tcsk.Substring(0, tcsk.Length - 2)
            );

            for (int i = 0; i < Loaded.Characters.Objects[tchar].abilities.Count; i++)
            {
                Console.WriteLine(tcs,
                    Loaded.Characters.Objects[tchar].desc.name,
                    "Ability",
                    i + 1,
                    Loaded.Characters.Objects[tchar].abilities[i].FullName,
                    Loaded.Characters.Objects[tchar].abilities[i].description,
                    Loaded.Characters.Objects[tchar].abilities[i].requirements
                );
            }
            for (int i = 0; i < Loaded.Characters.Objects[tchar].feats.Count; i++)
            {
                Console.WriteLine(tcs,
                    Loaded.Characters.Objects[tchar].desc.name,
                    "Feat",
                    i + 1,
                    Loaded.Characters.Objects[tchar].feats[i].FullName,
                    Loaded.Characters.Objects[tchar].feats[i].description,
                    Loaded.Characters.Objects[tchar].feats[i].requirements
                );
            }

            Console.WriteLine(" *** {0}: {1}", Stats.charisma, Loaded.Characters.Objects[tchar].GetMod(Stats.charisma));
            Console.WriteLine(" *** {0}: {1}", Stats.constitution, Loaded.Characters.Objects[tchar].GetMod(Stats.constitution));
            Console.WriteLine(" *** {0}: {1}", Stats.dexterity, Loaded.Characters.Objects[tchar].GetMod(Stats.dexterity));
            Console.WriteLine(" *** {0}: {1}", Stats.strength, Loaded.Characters.Objects[tchar].GetMod(Stats.strength));
            Console.WriteLine(" *** {0}: {1}", Stats.intelligence, Loaded.Characters.Objects[tchar].GetMod(Stats.intelligence));
            Console.WriteLine(" *** {0}: {1}", Stats.wisdom, Loaded.Characters.Objects[tchar].GetMod(Stats.wisdom));
            /**/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());

            /*---------------------------------------Finalization--------------------------------------*/

        }

    }

}