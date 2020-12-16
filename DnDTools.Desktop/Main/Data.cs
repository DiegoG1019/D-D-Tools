﻿using DiegoG.DnDTools.Base.Cache;
using DiegoG.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Version = DiegoG.Utilities.Version;

namespace DiegoG.DnDTools.Desktop
{
    public partial class App
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public static Version Version => DnDDesktopCache.Version;
        public static string Author => GlobalCache.Author;
        public static string AuthorSignature => GlobalCache.AuthorSignature;
        public static string ShortAppName => GlobalCache.ShortAppName;
        public static string FullAppName => GlobalCache.FullAppName;
        public static string CopyrightNotice => GlobalCache.CopyrightNotice;

        public static App GUI { get; private set; }

        public static string MinimumLoggerLevel;
    }
}