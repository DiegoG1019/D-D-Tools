using DiegoG.CLI;
using DiegoG.DnDTools.Base;
using DiegoG.DnDTools.Base.Cache;
using DiegoG.Utilities.Enumerations;
using DiegoG.Utilities.IO;
using DiegoG.Utilities.Settings;
using Serilog;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using Version = DiegoG.Utilities.Version;

namespace DiegoG.DnDTools.Desktop
{
    public partial class App : Application
    {
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

            if (Settings<AppSettings>.Current.Console)
            {
                Log.Information("Opening console");
                AllocConsole();
                Log.Information("Console opened");
            }

            Log.Information("Initializing all application directories");
            Directories.InitApplicationDirectories();

            Log.Debug("Initializing D&DTools.Base serialization settings");
            DnDManager.SerializationInit();

            Log.Debug("Initializing Serialization settings");
            Serialization.Init();

            Log.Information("Loading App Settings");
            Settings<AppSettings>.Initialize(Directories.Settings, "WPFDesktopSettings");

            LoggingLevelSwitch.MinimumLevel = Settings<AppSettings>.Current.Verbosity;

            Log.Debug($"Succesfully loaded AppSettings, set logging to a mimum level of {Enum.GetName(typeof(Serilog.Events.LogEventLevel), LoggingLevelSwitch.MinimumLevel)}");

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
            Settings<Theme>.Initialize(Path.Combine(Directories.Themes, DnDDesktop.Implementation), Settings<AppSettings>.Current.Theme);

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