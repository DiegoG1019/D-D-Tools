using DiegoG.DnDTools.Base.Cache;
using DiegoG.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using DiegoG.Utilities.Settings;

namespace DiegoG.DnDTools.Base
{
    public static class DnDManager
    {
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
        }
        public static CharacterList Characters { get; } = new CharacterList();
    }
    public static class Directories
    {
        private static bool isinit;
        public static string Temp { get; private set; } = Path.GetTempPath();

        public static string DataOut { get; private set; }
        public static string Characters { get; private set; }
        public static string Scripts { get; private set; }
        public static string Themes { get; private set; }

        public static string Working { get; private set; } = Path.GetFullPath(Directory.GetCurrentDirectory());
        public static string AppData { get; private set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), GlobalCache.FullAppName);

#if DEBUG
        public static string Logging { get; private set; } = Path.Combine(Working, "Logs");
        public static string Settings { get; private set; } = Path.Combine(Working, "Settings");
        public static string Languages { get; private set; } = Path.Combine(Working, "Languages");
#else
            public static string Logging { get; private set; } = Path.Combine(AppData, "Logs");
            public static string Settings { get; private set; } = Path.Combine(AppData, "Settings");
            public static string Languages { get; private set; } = Path.Combine(AppData, "Languages");
#endif

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
