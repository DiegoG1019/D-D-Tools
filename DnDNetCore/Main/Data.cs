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

        public static readonly Version Version = new Version("Alpha", 0, 0, 39, 0);

        public static App GUI { get; private set; }

        public const string Author = "Diego Garcia";
        public const string AuthorSignature = "DG";
        public const string ShortAppName = "DnDTools";
        public const string CopyrightNotice = "Copyright © 2020 Diego Garcia";
#if NETFRAMEWORK
        public const string FullAppName = "D&D Tools (.NET Framework)";
#endif
#if NETCORE
        public const string FullAppName = "D&D Tools (.NET Core)";
#endif
        public const string AppName = "D&D Tools";

        public static class Directories
        {
            private static TypeInfo typeinfo = (TypeInfo)typeof(Directories);
            public static string Temp = Path.GetTempPath();

            public static string DataOut;
            public static string Characters;
            public static string Scripts;
            public static string Themes;
            
            public static string Working = Path.GetFullPath(Directory.GetCurrentDirectory());
            public static string AppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

#if DEBUG
            public static string Logging = Path.Combine(Working, "Logs");
            public static string Settings = Path.Combine(Working, "Settings");
            public static string Languages = Path.Combine(Working, "Languages");
#else
            public static string Logging = Path.Combine(AppData, "Logs");
            public static string Settings = Path.Combine(AppData, "Settings");
            public static string Languages = Path.Combine(AppData, "Languages");
#endif

            public static IEnumerable<Pair<string, string>> AllDirectories
                => from item in typeinfo.GetFields() select new Pair<string, string>(item.Name, (string)item.GetValue(null));

            public static void InitDataDirectories(string dataout)
            {
                DataOut = dataout;
                if (DataOut is null)
                    DataOut = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "D&D Tools");
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
