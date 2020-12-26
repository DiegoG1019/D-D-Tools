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

        public static Serilog.Core.LoggingLevelSwitch LoggingLevelSwitch { get; } = new();

        public static void Init()
        {
            /*--------------------------------------Initialization-------------------------------------*/
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(
                    path: Directories.InLogging($"DnDTools_CLI.log"),
                    rollingInterval: RollingInterval.Infinite,
                    flushToDiskInterval: TimeSpan.FromMinutes(1),
                    fileSizeLimitBytes: 104857600,
                    levelSwitch: LoggingLevelSwitch
                ).CreateLogger();

            Log.Information("Initializing all application directories");
            Directories.InitApplicationDirectories();

            Log.Debug("Initializing D&DTools.Base serialization settings");
            DnDManager.SerializationInit();

            Log.Debug("Initializing Serialization settings");
            Serialization.Init();

            Log.Information("Loading App Settings");
            Settings<AppSettings>.Initialize(Directories.Settings, "CLISettings");

            LoggingLevelSwitch.MinimumLevel = Settings<AppSettings>.Current.Verbosity;

            Log.Debug($"Succesfully loaded AppSettings, set logging to a mimum level of {Enum.GetName(typeof(Serilog.Events.LogEventLevel), LoggingLevelSwitch.MinimumLevel)}");

            Log.Information($"Running " + DnDCLI.FullAppTitle);

            Log.Information("Settings:");
            foreach (var p in Settings<AppSettings>.CurrentProperties)
                Log.Debug($"Setting \"{p.ObjectA}\" = {p.ObjectB}");

            Log.Information("Initializing Data directories");
            Directories.InitDataDirectories(Settings<AppSettings>.Current.DataDirectory);

            Log.Information("Initializing DnDTools.Base");
            DnDManager.Initialize<AppSettings>();

            Log.Information("Initializing CLI Lang Settings");
            Settings<CLILang>.Initialize(Directories.Languages, DnDCLI.Implementation + Settings<AppSettings>.Current.Lang);

            Log.Information("Initializing CLI Theme Settings");
            Settings<Theme>.Initialize(Directories.Themes, Settings<AppSettings>.Current.Theme);

            Log.Information("Setting Console Settings");
            Log.Debug($"Setting Console Title");
            Console.Title = DnDCLI.FullAppTitle;

            Log.Information("Finished the Initialization of the Application");
        }
    }
}
