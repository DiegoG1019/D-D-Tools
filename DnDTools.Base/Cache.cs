using DiegoG.Utilities;

namespace DiegoG.DnDTools.Base.Cache
{
    public static class DnDBase
    {
        public static string AppTitle => $"{GlobalCache.FullAppName}: {Implementation}";
        public static string FullAppTitle => $"{AppTitle} version: {Version.Full}";

        public const string Implementation = "Base";
        public static readonly Version Version = new Version("Alpha", 0, 0, 0, 0);
    }
    public static class DnDDesktop
    {
        public static string AppTitle => $"{GlobalCache.FullAppName}: {Implementation}";
        public static string FullAppTitle => $"{AppTitle} version: {Version.Full}";

        public const string Implementation = "Desktop";
        public static readonly Version Version = new Version("Alpha", 0, 0, 40, 0);
    }
    public static class DnDCLI
    {
        public static string AppTitle => $"{GlobalCache.FullAppName}: {Implementation}";
        public static string FullAppTitle => $"{AppTitle} version: {Version.Full}";

        public const string Implementation = "Command Line Interface";
        public static readonly Version Version = new Version("Alpha", 0, 0, 0, 0);
    }
    public static class GlobalCache
    {
        public const string Author = "Diego Garcia";
        public const string AuthorSignature = "DG";
        public const string ShortAppName = "DnDTools";
        public const string FullAppName = "D&D Tools";
        public const string CopyrightNotice = "Copyright © 2020 Diego Garcia";
    }
}
