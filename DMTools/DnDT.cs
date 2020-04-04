//#define DEBUG
//#define VERBOSE
#define CONSOLE

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Windows.Forms;
using Serilog;
using Serilog.Sinks.File;
using Serilog.Sinks.SystemConsole;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;

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

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public static readonly Version version = new Version("Alpha", 0, 0, 18, 1);
        public static int statCount = Enum.GetNames(typeof(Stats)).Length;
        public static int schoolCount = Enum.GetNames(typeof(Schools)).Length;

        public const string author = "Diego Garcia";
        public const string appname = "D&DTools Windows";

        public static class Directories
        {
            public static string DataOut = Path.Combine("DnDT");
            public static string Logging = Path.Combine(DataOut, "Logs");
            public static string Characters = Path.Combine(DataOut, "Characters");
            public static string Entities = Path.Combine(DataOut, "Entities");
            public static string Temp = Path.GetTempPath();
            public static string Working = Path.GetFullPath(Directory.GetCurrentDirectory());
            public static void InitDirectories()
            {
                Directory.CreateDirectory(DataOut);
                Directory.CreateDirectory(Logging);
                Directory.CreateDirectory(Characters);
                Directory.CreateDirectory(Entities);
            }
        }

        public static string MinimumLoggerLevel;

        public static JsonSerializerOptions JSONOptions = new JsonSerializerOptions{
            WriteIndented = true,
        };/**/

        /*-------------- Test fields --------------*/
        public static int tchar;
        /*-----------------------------------------*/

        [STAThread]
        static void Main()
        {

            /*--------------------------------------------  -------------------------------------------*/

        /*--------------------------------------Initialization-------------------------------------*/

        Cf.LoadSystemOptions();

            if (Cf.System.Flags["console"])
            {
                AllocConsole();
            }

            LoggerConfiguration loggerconfig = new LoggerConfiguration();
            if (Cf.System.Flags["verbose"])
            {
                loggerconfig.MinimumLevel.Verbose();
                MinimumLoggerLevel = "Verbose";
            }
            else
            {
                if (Cf.System.Flags["debug"])
                {
                    loggerconfig.MinimumLevel.Debug();
                    MinimumLoggerLevel = "Debug";
                }
                else
                {
                    loggerconfig.MinimumLevel.Information();
                    MinimumLoggerLevel = "Information";
                }
            }

            Log.Logger = loggerconfig
                .WriteTo.Console()
                .WriteTo.File(Path.Combine(Directories.Logging, String.Format("log - {0} - .txt", version.Full)), rollingInterval: RollingInterval.Hour)
                .CreateLogger();

            Log.Debug("Succesfully started logger with a mimum level of {0}", MinimumLoggerLevel);

            foreach (KeyValuePair<string, bool> ind in Cf.System.Flags)
            {
                Log.Information("System Setting: {0} :: {1}",ind.Key, ind.Value);
            }

            Log.Information("Program Author: {0}", App.author);
            Log.Information("Running D&DTools version: {0}", App.version.Full);

            Cf.LoadLang();
            Cf.LoadOptions();

            App.Directories.InitDirectories();
            Log.Information("Finished Initializing all Application directories");
            Log.Information("DataOut Directory: {0}", Path.GetFullPath(Directories.DataOut));
            Log.Information("Logging Directory: {0}", Path.GetFullPath(Directories.Logging));
            Log.Information("Characters storage Directory: {0}", Path.GetFullPath(Directories.Characters));
            Log.Information("Entities storage Directory: {0}", Path.GetFullPath(Directories.Entities));
            Log.Information("Temp Directory: {0}", Path.GetFullPath(Directories.Temp));
            Log.Information("Working Directory: {0}", Path.GetFullPath(Directories.Working));

            Log.Information("Finished the Initialization of the Application");

            /*-----------------------------------------Testing-----------------------------------------*/

            //test char
            int tchar1 = Character.Create(5, "Tchar");
            Loaded.Characters[tchar1].Exp.Gain(573);
            Loaded.Characters[tchar1].Serialize();
            tchar = Character.Create("Tchar");
            Loaded.Characters[tchar].Exp.Gain(69);
            Loaded.Characters[tchar].Health.LethalDamage.Harm(69);
            Loaded.Characters[tchar].Serialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());

            /*---------------------------------------Finalization--------------------------------------*/

        }

    }

}