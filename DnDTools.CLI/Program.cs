using DiegoG.CLI;
using DiegoG.DnDTools.Base;
using DiegoG.DnDTools.Base.Cache;
using DiegoG.DnDTools.Base.Characters;
using DiegoG.Utilities.Enumerations;
using DiegoG.Utilities.IO;
using DiegoG.Utilities.Settings;
using Serilog;
using System;
using System.IO;
using Version = DiegoG.Utilities.Version;

namespace DiegoG.DnDTools.CLI
{
    public static class Program
    {
        public static Version Version => DnDCLI.Version;
        public static string Author => GlobalCache.Author;
        public static string AuthorSignature => GlobalCache.AuthorSignature;
        public static string AppTitle => DnDCLI.AppTitle;
        public static string FullAppTitle => DnDCLI.FullAppTitle;
        public static string CopyrightNotice => GlobalCache.CopyrightNotice;

        public static string MinimumLoggerLevel;

        public static string CurrentCharacterName { get; set; }
        public static Character CurrentCharacter => DnDManager.Characters[CurrentCharacterName];
        public static void Init()
        {
            /*--------------------------------------Initialization-------------------------------------*/
            Directories.InitApplicationDirectories();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(Path.Combine(Directories.Logging, string.Format("pre-startup log - {0} - .log", Version.Full)), rollingInterval: RollingInterval.Minute)
                .CreateLogger();

            Log.Information("Initializing Serialization Settings");
            DnDManager.SerializationInit();

            Serialization.Init();
            Settings<AppSettings>.Initialize(Directories.Settings, "Settings");

            LoggerConfiguration loggerconfig = new LoggerConfiguration();
            if (Settings<AppSettings>.Current.Verbosity == Verbosity.Verbose)
            {
                loggerconfig.MinimumLevel.Verbose();
                MinimumLoggerLevel = "Verbose";
            }
            else
            {
                if (Settings<AppSettings>.Current.Verbosity == Verbosity.Debug)
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
                .WriteTo.File(Path.Combine(Directories.Logging, $"{DnDCLI.Implementation}.log"), rollingInterval: RollingInterval.Minute)
                .CreateLogger();

            Log.Debug($"Succesfully started logger with a mimum level of {MinimumLoggerLevel}");

            Log.Information($"Running " + DnDCLI.FullAppTitle);

            Log.Information("Settings:");
            foreach (var p in Settings<AppSettings>.CurrentProperties)
                Log.Debug($"Setting \"{p.ObjectA}\" = {p.ObjectB}");

            Log.Information("Initializing Data directories");
            Directories.InitDataDirectories(Settings<AppSettings>.Current.DataDirectory);

            Log.Information("Initializing DnDTools.Base");
            DnDManager.Initialize<AppSettings>();

            Log.Information("Initializing CLI Lang Settings");
            Settings<CLILang>.Initialize(Directories.Settings, Settings<AppSettings>.Current.Lang);

            Log.Information("Initializing CLI Theme Settings");
            Settings<Theme>.Initialize(Directories.Settings, Settings<AppSettings>.Current.Lang + DnDCLI.Implementation);

            Log.Information("Setting Console Settings");
            Log.Debug($"Setting Console Title");
            Console.Title = DnDCLI.FullAppTitle;

            Log.Information("Finished the Initialization of the Application");
        }
    }
}
