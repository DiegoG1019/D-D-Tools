using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DiegoG.CLI;
using DiegoG.Utilities.Replacements;
using DiegoG.Utilities.Settings;
using Serilog;

namespace DiegoG.DnDTools.CLI.Display
{
    public static class OutConsole
    {
        private static void CursorToInput() => Console.SetCursorPosition(InputCoord.X, InputCoord.Y);
        public static Task Task { get; private set; }
        public static bool HasBegun => Task is not null;
        private static CancellationTokenSource CancelSource { get; } = new();
        private static string Input { get; set; }
        public static Point InputCoord { get; private set; } = new(0, 0);

        public static void Begin()
        {
            Log.Information("Beginning OutConsole Input loop");
            if (!HasBegun)
            {
                Task = Task.Run(InputMode, CancelSource.Token);
                Commands.CommandCalled += Commands_CommandCalled;
                return;
            }
            throw new InvalidOperationException("OutConsole loop has already begun");
        }

        private static void Commands_CommandCalled(object sender, Commands.CommandCallEventArgs e)
            => ReDraw = true;

        public static void Stop()
        {
            Log.Information("Stopping OutConsole Input loop");
            if (HasBegun)
            {
                CancelSource.Cancel(true);
                Task = null;
                Commands.CommandCalled -= Commands_CommandCalled;
                return;
            }
            throw new InvalidOperationException("OutConsole loop has not begun and cannot be stopped");
        }


        private static async void InputMode()
        {
            WriteOpenInput();
            for (; ; )
            {
                if (CancelSource.IsCancellationRequested)
                    break;
                DrawAll();
                //This will just loop back immediately, but it'll also release the console and let it do whatever it needs to be doing
                DConsole.TextColor = Settings<Theme>.Current.CommandInputColor;
                WriteOpenInput();
                if (DConsole.TryReadLine(out string input, 500))
                {
                    Input = input;
                    Log.Debug($"Processing Console Command Input: {Input}");
                }
                else
                    continue;
                try
                {
                    var outp = await Commands.Call(Input); outp ??= "";
                    Log.Debug($"Output for Console Command Input {Input} :: {outp}");
                    CommandOutput = outp;
                }
                catch(InvalidCommandException e)
                {
                    Message = Settings<CLILang>.Current.Commands.InvalidCommandExceptionText;
                    CommandOutput = e.Message;
                }catch(InvalidCommandArgumentException e)
                {
                    Message = Settings<CLILang>.Current.Commands.InvalidCommandArgumentExceptionText;
                    CommandOutput = e.Message;
                }
                catch (CommandProcessException e)
                {
                    Message = Settings<CLILang>.Current.Commands.CommandProcessExceptionText;
                    CommandOutput = e.Message;
                }
            }
        }
        private static void WriteOpenInput()
        {
            if (InputCoord.Y == Console.CursorTop)
                return;
            DConsole.TextColor = Settings<Theme>.Current.CommandInputColor;
            DConsole.ClearLine(InputCoord.Y);
            CursorToInput();
            DConsole.Write("> ");
        }

        public static Report DisplayedReport
        {
            get { lock (DisplayedReportKey) { return DisplayedReportField; } }
            set
            {
                lock (DisplayedReportKey)
                    DisplayedReportField = value;
                ReDraw = true;
            }
        }
        private static Report DisplayedReportField;
        private static object DisplayedReportKey { get; } = new();

        public static string Message
        {
            get 
            {
                lock (MessageKey)
                    return MessageField;
            }
            set
            {
                value ??= "";
                lock (MessageKey)
                    MessageField = value;
                ReDraw = true;
            }
        }
        private static string MessageField = "";
        private static readonly object MessageKey = new();

        public static string CommandOutput
        {
            get 
            {
                lock (CommandOutputKey) 
                    return CommandOutputField;
            }
            private set 
            {
                value ??= "!null";
                lock (CommandOutputKey)
                    CommandOutputField = value;
                ReDraw = true;
            }
        }
        private static string CommandOutputField = string.Format(Settings<CLILang>.Current.Commands.IntroMessage, "\"Help\"");
        private static readonly object CommandOutputKey = new();

        private static bool ReDraw
        {
            get
            {
                lock (ReDrawKey) 
                    return ReDrawField;
            }
            set 
            { 
                lock (ReDrawKey) 
                    ReDrawField = value; 
            }
        }
        private static bool ReDrawField = true;
        private static readonly object ReDrawKey = new();
        private static void DrawAll()
        {
            if (!ReDraw)
                return;
            ReDraw = false;
            DConsole.Clear();
            DConsole.SetCursorPosition(0, 0);
            if (DisplayedReport is not null)
            {
                DisplayedReport.DrawToConsole(Point.Zero);
                DConsole.Write("\n");
            }
            InputCoord = DConsole.GetCursorPosition();
            DConsole.TextColor = Settings<Theme>.Current.CommandMessageColor;
            DConsole.Write($"\n\n{Message}\n");
            DConsole.TextColor = Settings<Theme>.Current.CommandOutputColor;
            DConsole.Write($"\n{CommandOutput}");
        }
    }
}
