using DiegoG.Utilities.Settings;
using System;

namespace DiegoG.DnDTools.CLI
{
    public class Theme : ISettings
    {
        public ulong Version => 0;
        public ConsoleColor Background { get; set; } = ConsoleColor.Black;
        public ConsoleColor ReportTitleColor { get; set; } = ConsoleColor.White;
        public ConsoleColor ReportFooterColor { get; set; } = ConsoleColor.Cyan;
        public ConsoleColor ReportLineTitleColor { get; set; } = ConsoleColor.Gray;
        public ConsoleColor ReportLineSubtitleColor { get; set; } = ConsoleColor.Blue;
        public ConsoleColor ReportLineExtraDataColor { get; set; } = ConsoleColor.DarkGray;
        public ConsoleColor ReportLineBodyColor { get; set; } = ConsoleColor.Magenta;
    }
}
