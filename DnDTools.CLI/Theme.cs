using DiegoG.Utilities.Settings;
using System;

namespace DiegoG.DnDTools.CLI
{
    public class Theme : ISettings
    {
        public ulong Version => 2;
        public ConsoleColor Background { get; set; } = ConsoleColor.Black;
        public ConsoleColor ReportTitleColor { get; set; } = ConsoleColor.White;
        public ConsoleColor ReportFooterColor { get; set; } = ConsoleColor.Cyan;
        public ConsoleColor ReportLineTitleColor { get; set; } = ConsoleColor.Gray;
        public ConsoleColor ReportLineSubtitleColor { get; set; } = ConsoleColor.DarkBlue;
        public ConsoleColor ReportLineExtraDataColor { get; set; } = ConsoleColor.DarkGray;
        public ConsoleColor ReportLineBodyColor { get; set; } = ConsoleColor.DarkMagenta;
        public ConsoleColor CommandMessageColor { get; set; } = ConsoleColor.DarkYellow;
        public ConsoleColor CommandOutputColor { get; set; } = ConsoleColor.Yellow;
        public ConsoleColor CommandInputColor { get; set; } = ConsoleColor.DarkGreen;
    }
}
