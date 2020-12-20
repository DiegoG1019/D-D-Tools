using DiegoG.DnDTools.Base.Cache;
using DiegoG.DnDTools.Base.Scripting;
using DiegoG.Utilities.Collections;
using DiegoG.Utilities.Settings;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;

namespace DiegoG.DnDTools.Base
{
    public static class DnDManager
    {
        public static void SerializationInit()
        {
            Log.Information("Initializing DnDTools.Base Serialization related settings");
            Log.Information("Initializing Script Manager");
            CharacterScript.Initialize();
        }
        public static void Initialize<Settings>() where Settings : DnDAppSettingsBase, new()
        {
            Log.Information($"Running " + DnDBase.FullAppTitle);
            Log.Information("Directories:");
            foreach (var p in Directories.AllDirectories)
                Log.Information($"{p.Directory} Directory: {Path.GetFullPath(p.Path)}");

            Log.Information("Initializing Game Settings");
            Settings<DnDSettings>.Initialize(Directories.Settings, Settings<Settings>.Current.GameSettingsProfile);

            Log.Information("Initializing Language settings");
            Settings<Lang>.Initialize(Directories.Languages, Settings<Settings>.Current.Lang);

            Log.Information("Copying Default Data to AppData directory");
            Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(Directories.InWorking("DnDT"), Directories.DataOut, true);
        }
        public static CharacterList Characters { get; } = new CharacterList();
    }
    public static class Directories
    {
        private static bool isinit;
        public static string Temp { get; private set; } = Path.GetTempPath();

        public static string DataOut { get; private set; }
        public static string InDataOut(string n) => Path.Combine(Working, n);
        public static string Characters { get; private set; }
        public static string InCharacters(string n) => Path.Combine(Working, n);
        public static string Scripts { get; private set; }
        public static string InScripts(string n) => Path.Combine(Working, n);
        public static string Themes { get; private set; }
        public static string InThemes(string n) => Path.Combine(Working, n);

        public static string Working { get; private set; } = Path.GetFullPath(Directory.GetCurrentDirectory());
        public static string InWorking(string n) => Path.Combine(Working, n);
        public static string AppData { get; private set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), GlobalCache.FullAppName);
        public static string InAppData(string n) => Path.Combine(Working, n);

        public static string Logging { get; private set; } = Path.Combine(AppData, "Logs");
        public static string InLogging(string n) => Path.Combine(Working, n);
        public static string Settings { get; private set; } = Path.Combine(AppData, "Settings");
        public static string InSettings(string n) => Path.Combine(Working, n);
        public static string Languages { get; private set; } = Path.Combine(AppData, "Languages");
        public static string InLanguages(string n) => Path.Combine(Working, n);

        public static IEnumerable<(string Directory, string Path)> AllDirectories
            => isinit ? ReflectionCollectionMethods.GetAllMatchingTypeStaticPropertyNameValueTuple<string>(typeof(Directories)) : throw new InvalidOperationException("Directories has not been initialized");

        public static void InitDataDirectories(string dataout)
        {
            isinit = true;
            DataOut = dataout;
            if (DataOut is null)
                DataOut = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), GlobalCache.FullAppName);
            Directory.CreateDirectory(DataOut);

            Characters = Path.Combine(DataOut, "Characters");
            Directory.CreateDirectory(Characters);

            Scripts = Path.Combine(DataOut, "Scripts");
            Directory.CreateDirectory(Scripts);

            Themes = Path.Combine(DataOut, "Themes");
            Directory.CreateDirectory(Themes);
        }

        public static void InitApplicationDirectories()
        {
            Directory.CreateDirectory(Logging);
            Directory.CreateDirectory(Settings);
            Directory.CreateDirectory(Languages);
        }
    }
}
