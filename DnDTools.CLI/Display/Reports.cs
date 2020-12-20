using DiegoG.Utilities.Settings;
using System;
using System.Collections.Generic;

namespace DiegoG.DnDTools.CLI.Display
{
    public static class Reports
    {
        public static Report Report
        {
            get => ReportField;
            set
            {
                ReportField = value;
                ReportField.DrawToConsole();
            }
        }
        private static Report ReportField;
    }
    public record Report
    {
        private static ConsoleColor Back { set => Console.BackgroundColor = value; }
        private static ConsoleColor Fore { set => Console.ForegroundColor = value; }
        private static Theme Theme => Settings<Theme>.Current;
        private static void Write(string n) => Console.Write(n);
        private static void WriteL(string n) => Console.WriteLine(n);

        public string Title { get; init; }
        public IEnumerable<ReportLine> Lines { get; init; }
        public string Footer { get; init; }
        public void DrawToConsole()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
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
