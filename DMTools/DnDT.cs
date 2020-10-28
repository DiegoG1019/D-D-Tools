using DiegoG.DnDTDesktop.Characters;
using DiegoG.DnDTDesktop.Characters.Complements;
using DiegoG.Utilities.IO;
using DiegoG.DnDTDesktop.Properties;
using Serilog;
using System;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static DiegoG.DnDTDesktop.Enumerations;
using Version = DiegoG.Utilities.Version;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiegoG.DnDTDesktop
{
    public static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public static readonly Version Version = new Version("Alpha", 0, 0, 38, 0);

        public const string Author = "Diego Garcia";
        public const string AuthorSignature = "DG";
        public const string ShortAppName = "DnDTools";
#if NETFRAMEWORK
        public const string FullAppName = "D&D Tools (.NET Framework)";
#endif
#if NETCORE
        public const string FullAppName = "D&D Tools (.NET Core)";
#endif
        public const string AppName = "D&D Tools";

        public static class Directories
        {
            public static string DataOut = Path.Combine("DnDT");
            public static string Characters = Path.Combine(DataOut, "Characters");
            public static string Scripts = Path.Combine(DataOut, "Scripts");
            public static string Entities = Path.Combine(DataOut, "Entities");
            public static string Temp = Path.GetTempPath();
            public static string Working = Path.GetFullPath(Directory.GetCurrentDirectory());
            public static string Logging = Path.Combine(Working, "Logs");
            public static string Settings = Path.Combine(Working, "Settings");
            public static void InitDirectories()
            {
                Directory.CreateDirectory(DataOut);
                Directory.CreateDirectory(Characters);
                Directory.CreateDirectory(Entities);
                Directory.CreateDirectory(Logging);
                Directory.CreateDirectory(Settings);
            }
        }

        public static CharacterList Characters { get; } = new CharacterList();
        public static string MinimumLoggerLevel;

        /*-----------------------------------------*/

        public static void Init()
        {
            /*--------------------------------------Initialization-------------------------------------*/

            Directories.InitDirectories();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File(Path.Combine(Directories.Logging, String.Format("pre-startup log - {0} - .txt", Version.Full)), rollingInterval: RollingInterval.Hour)
                .CreateLogger();

            if (Settings.Default.Console)
            {
                Log.Information("Opening console");
                AllocConsole();
                Log.Information("Console opened");
            }

            LoggerConfiguration loggerconfig = new LoggerConfiguration();
            if (Settings.Default.Verbosity == Verbosity.Verbose)
            {
                loggerconfig.MinimumLevel.Verbose();
                MinimumLoggerLevel = "Verbose";
            }
            else
            {
                if (Settings.Default.Verbosity == Verbosity.Debug)
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
                .WriteTo.File(Path.Combine(Directories.Logging, String.Format("log - {0} - .txt", Version.Full)), rollingInterval: RollingInterval.Hour)
                .CreateLogger();

            Log.Debug("Succesfully started logger with a mimum level of {0}", MinimumLoggerLevel);

            Log.Information("Running D&DTools version: {0}", Version.Full);

            Log.Information("DataOut Directory: {0}", Path.GetFullPath(Directories.DataOut));
            Log.Information("Logging Directory: {0}", Path.GetFullPath(Directories.Logging));
            Log.Information("Characters storage Directory: {0}", Path.GetFullPath(Directories.Characters));
            Log.Information("Entities storage Directory: {0}", Path.GetFullPath(Directories.Entities));
            Log.Information("Temp Directory: {0}", Path.GetFullPath(Directories.Temp));
            Log.Information("Working Directory: {0}", Path.GetFullPath(Directories.Working));

            JsonSerializationSettings.JsonSerializerOptions.WriteIndented = Settings.Default.JsonWriteIndented;
            Serialization.Init();

            foreach (SettingsProperty p in Settings.Default.Properties)
                Log.Debug($"Setting \"{p.Name}\" = {Settings.Default[p.Name]}");

            Log.Information("Finished the Initialization of the Application");
        }

        [STAThread]
        public static async Task Main()
        {
            Init();

            //var Quentin = new Character("Quentin");
            //await Quentin.SerializeAsync();
            var Quentin = await Character.DeserializeAndRegisterAsync("Quentin");

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new GUI.MainMenu());
        }
    }
}