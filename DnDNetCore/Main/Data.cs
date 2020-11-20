using DiegoG.DnDTCache;
using DiegoG.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Version = DiegoG.Utilities.Version;

namespace DiegoG.DnDNetCore
{
    public partial class App
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public static Version Version => DnDNetCoreCache.Version;
        public static string Author => GlobalCache.Author;
        public static string AuthorSignature => GlobalCache.AuthorSignature;
        public static string ShortAppName => GlobalCache.ShortAppName;
        public static string FullAppName => GlobalCache.FullAppName;
        public static string CopyrightNotice => GlobalCache.CopyrightNotice;

        public static App GUI { get; private set; }

        public static class Directories
        {
            private static readonly TypeInfo typeinfo = (TypeInfo)typeof(Directories);
            public static string Temp { get; private set; } = Path.GetTempPath();

            public static string DataOut { get; private set; }
            public static string Characters { get; private set; }
            public static string Scripts { get; private set; }
            public static string Themes { get; private set; }

            public static string Working { get; private set; } = Path.GetFullPath(Directory.GetCurrentDirectory());
            public static string AppData { get; private set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), GlobalCache.FullAppName);

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
                => from item in typeinfo.GetProperties() select (item.Name, (string)item.GetValue(null));

            public static void InitDataDirectories(string dataout)
            {
                DataOut = dataout;
                if (DataOut is null)
                    DataOut = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), GlobalCache.FullAppName);
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

        public static CharacterList Characters { get; } = new CharacterList();
        public static string MinimumLoggerLevel;
    }
}
