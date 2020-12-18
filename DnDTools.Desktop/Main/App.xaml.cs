using System;
using Serilog;
using System.IO;
using DiegoG.CLI;
using DiegoG.Utilities.IO;
using System.Threading.Tasks;
using DiegoG.Utilities.Settings;
using DiegoG.DnDTools.Base;
using DiegoG.Utilities.Enumerations;
using Version = DiegoG.Utilities.Version;
using System.Windows;
using DiegoG.DnDTools.Base.Cache;

namespace DiegoG.DnDTools.Desktop
{
    public partial class App : Application
    {
        public static void Init()
        {
            /*--------------------------------------Initialization-------------------------------------*/

            Directories.InitApplicationDirectories();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File(Path.Combine(Directories.Logging, String.Format("pre-startup log - {0} - .log", Version.Full)), rollingInterval: RollingInterval.Hour)
                .CreateLogger();

            Serialization.Init();
            Settings<AppSettings>.Initialize(Directories.Settings, "Settings");

            if (Settings<AppSettings>.Current.Console)
            {
                Log.Information("Opening console");
                AllocConsole();
                Log.Information("Console opened");
            }

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
                .WriteTo.Console()
                .WriteTo.File(Path.Combine(Directories.Logging, $"{DnDDesktop.Implementation}.log"), rollingInterval: RollingInterval.Minute)
                .CreateLogger();

            Log.Debug("Succesfully started logger with a mimum level of {0}", MinimumLoggerLevel);

            Log.Information($"Running {DnDDesktop.FullAppTitle}");

            Log.Information("Settings:");
            foreach (var p in Settings<AppSettings>.CurrentProperties)
                Log.Debug($"Setting \"{p.ObjectA}\" = {p.ObjectB}");

            Log.Information("Initializing Data directories");
            Directories.InitDataDirectories(Settings<AppSettings>.Current.DataDirectory);

            Log.Information("Directories:");
            foreach (var p in Directories.AllDirectories)
                Log.Information($"{p.Directory} Directory: {Path.GetFullPath(p.Path)}");

            Log.Information("Initializing Game Settings");
            Settings<DnDSettings>.Initialize(Directories.Settings, Settings<AppSettings>.Current.GameSettingsProfile);

            Log.Information("Initializing Language settings");
            Settings<Lang>.Initialize(Directories.Languages, Settings<AppSettings>.Current.Lang);

            Log.Information("Initializing Theme settings");
            Settings<Theme>.Initialize(Directories.Themes, Settings<AppSettings>.Current.Theme);

            Log.Information("Finished the Initialization of the Application");
        }

        public static void NotImplementedMessageBox()
            => MessageBox.Show("Not Implemented", "This should be an exception, but it's compiled as DEBUG apparently", MessageBoxButton.OK);

        public static async Task CLI(string[] args) => await Commands.Call(args);

        [STAThread]
        public static void Main(string[] args)
        {
            Init();

            Log.Information("Running Startup CommandLine arguments");
            Task.WaitAll(CLI(args));
            GUI = new App();
            GUI.InitializeComponent();
            GUI.Run();
        }
    }
}