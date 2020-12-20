using DiegoG.DnDTools.Base.Cache;
using System.Runtime.InteropServices;
using Version = DiegoG.Utilities.Version;

namespace DiegoG.DnDTools.Desktop
{
    public partial class App
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public static Version Version => DnDDesktop.Version;
        public static string Author => GlobalCache.Author;
        public static string AuthorSignature => GlobalCache.AuthorSignature;
        public static string AppTitle => DnDDesktop.AppTitle;
        public static string FullAppTitle => DnDDesktop.FullAppTitle;
        public static string CopyrightNotice => GlobalCache.CopyrightNotice;

        public static App GUI { get; private set; }

        public static string MinimumLoggerLevel;
    }
}
