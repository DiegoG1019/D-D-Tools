using System.IO;
using System.Runtime.InteropServices;
using Version = DiegoG.Utilities.Version;

namespace DiegoG.DnDTDesktop
{
    public static partial class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public static readonly Version Version = new Version("Alpha", 0, 0, 39, 0);

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

    }
}
