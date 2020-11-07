using System;
using Serilog;
using System.IO;
using DiegoG.CLI;
using DiegoG.Utilities.IO;
using System.Threading.Tasks;
using DiegoG.Utilities.Settings;
using DiegoG.Utilities.Enumerations;
using Version = DiegoG.Utilities.Version;

namespace DiegoG.DnDNetCore
{
    public static partial class Program
    {
        public static void Init()
        {
            /*--------------------------------------Initialization-------------------------------------*/

            Directories.InitDirectories();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File(Path.Combine(Directories.Logging, String.Format("pre-startup log - {0} - .log", Version.Full)), rollingInterval: RollingInterval.Hour)
                .CreateLogger();

            Serialization.Init();
            Settings<DnDSettings>.Initialize(Directories.Settings, "Settings");

            if (Settings<DnDSettings>.Current.Console)
            {
                Log.Information("Opening console");
                AllocConsole();
                Log.Information("Console opened");
            }

            LoggerConfiguration loggerconfig = new LoggerConfiguration();
            if (Settings<DnDSettings>.Current.Verbosity == Verbosity.Verbose)
            {
                loggerconfig.MinimumLevel.Verbose();
                MinimumLoggerLevel = "Verbose";
            }
            else
            {
                if (Settings<DnDSettings>.Current.Verbosity == Verbosity.Debug)
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
                .WriteTo.File(Path.Combine(Directories.Logging, $"{ShortAppName}-{Version.Full}.log"), rollingInterval: RollingInterval.Hour)
                .CreateLogger();

            Log.Debug("Succesfully started logger with a mimum level of {0}", MinimumLoggerLevel);

            Log.Information("Running D&DTools version: {0}", Version.Full);

            Log.Information("DataOut Directory: {0}", Path.GetFullPath(Directories.DataOut));
            Log.Information("Logging Directory: {0}", Path.GetFullPath(Directories.Logging));
            Log.Information("Characters storage Directory: {0}", Path.GetFullPath(Directories.Characters));
            Log.Information("Entities storage Directory: {0}", Path.GetFullPath(Directories.Entities));
            Log.Information("Temp Directory: {0}", Path.GetFullPath(Directories.Temp));
            Log.Information("Working Directory: {0}", Path.GetFullPath(Directories.Working));

            foreach (var p in Settings<DnDSettings>.CurrentProperties)
                Log.Debug($"Setting \"{p.ObjectA}\" = {p.ObjectB}");

            //Settings<Lang>.Initialize(Settings<DnDSettings>.Current.Lang);

            Log.Information("Finished the Initialization of the Application");
        }

        public static async Task CLI(string[] args) => await Commands.Call(args);
        [STAThread]
        public static async Task Main(string[] args)
        {
            Init();
            await CLI(args);

            GUI = new App();

        }
    }
}