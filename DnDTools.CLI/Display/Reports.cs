using DiegoG.Utilities.Replacements;
using DiegoG.Utilities.Settings;
using DiegoG.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiegoG.CLI;

namespace DiegoG.DnDTools.CLI.Display
{
    public record Report
    {
        private static ConsoleColor Back { set => DConsole.BackgroundColor = value; }
        private static ConsoleColor Fore { set => DConsole.TextColor = value; }
        private static Theme Theme => Settings<Theme>.Current;
        private static void Write(string n) => DConsole.Write(n);
        private static void WriteL(string n) => DConsole.WriteLine(n);

        public int NewLines
        {
            get
            {
                if(newlinecache == 0)
                {
                    newlinecache += Title.CountMatches('\n');
                    foreach (ReportLine report in Lines)
                    {
                        newlinecache += report.FormattedBody.CountMatches('\n');
                        newlinecache += report.FormattedExtra.CountMatches('\n');
                        newlinecache += report.FormattedTitle.CountMatches('\n');
                        newlinecache += report.FormattedSubtitle.CountMatches('\n');
                    }
                    newlinecache += Footer.CountMatches('\n');
                }
                return newlinecache;
            }
        }
        private int newlinecache;

        public string Title { get; init; }
        public IEnumerable<ReportLine> Lines { get; init; }
        public string Footer { get; init; }
        /// <summary>
        /// Draws the report to the screen
        /// </summary>
        /// <returns></returns>
        public void DrawToConsole(Point offset)
        {
            DConsole.Clear();
            DConsole.SetCursorPosition(offset.X, offset.Y);
            Back = Theme.Background;
            Fore = Theme.ReportTitleColor;
            WriteL(Title);
            foreach (ReportLine report in Lines)
            {
                Fore = Theme.ReportLineTitleColor;
                Write(report.FormattedTitle);

                Fore = Theme.ReportLineBodyColor;
                Write(report.FormattedBody);

                Fore = Theme.ReportLineSubtitleColor;
                Write(report.FormattedSubtitle);

                Fore = Theme.ReportLineExtraDataColor;
                Write(report.FormattedExtra);
            }
            Fore = Theme.ReportFooterColor;
            WriteL(Footer);
        }
    }
    public record ReportLine
    {
        public string Title { get; init; }
        public string Body { get; init; }
        public string Subtitle { get; init; }
        public string Extra { get; init; }

        public string FormattedTitle => $"{Title}: ";
        public string FormattedBody => $"{Body}\n";
        public string FormattedSubtitle => Subtitle is not null ? $"{new string(' ', FormattedTitle.Length)}{Subtitle}\n" : "";
        public string FormattedExtra => Extra is not null ? $"{new string(' ', FormattedSubtitle.Length - Extra.Length -1)}{Extra}\n" : "";
    }
}
