using DiegoG.DnDTDesktop.Properties;
using Serilog;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static DiegoG.DnDTDesktop.Enums;
using Version = DiegoG.Utilities.Version;

namespace DiegoG.DnDTDesktop
{
    static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public static readonly Version Version = new Version("Alpha", 0, 0, 30, 0);

        public const string Author = "Diego Garcia";
        public const string appname = "D&DTools Windows";

        public static class Directories
        {
            public static string DataOut = Path.Combine("DnDT");
            public static string Characters = Path.Combine(DataOut, "Characters");
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

        [STAThread]
        static void Main()
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

            foreach (var p in Settings.Default.Properties)
            {
                Log.Debug($"Setting \"{p}\" = {Settings.Default.Properties[p.ToString()]}");
            }

            Log.Information("Running D&DTools version: {0}", Program.Version.Full);

            Log.Information("DataOut Directory: {0}", Path.GetFullPath(Directories.DataOut));
            Log.Information("Logging Directory: {0}", Path.GetFullPath(Directories.Logging));
            Log.Information("Characters storage Directory: {0}", Path.GetFullPath(Directories.Characters));
            Log.Information("Entities storage Directory: {0}", Path.GetFullPath(Directories.Entities));
            Log.Information("Temp Directory: {0}", Path.GetFullPath(Directories.Temp));
            Log.Information("Working Directory: {0}", Path.GetFullPath(Directories.Working));

            Log.Information("Finished the Initialization of the Application");

            /*-----------------------------------------Testing-----------------------------------------*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new GUI.MainMenu());
        }
    }
}