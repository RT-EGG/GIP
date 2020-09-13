using System;
using System.Windows.Forms;
using System.IO;
using CommandLine;

namespace GIP
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string logPath = $"{AppDomain.CurrentDomain.BaseDirectory}/log.log";
            if (File.Exists(logPath)) {
                File.Delete(logPath);
            }
            Logger.DefaultLogger.Add(new FileLogger(logPath));

            Arguments arguments = null;
            CommandLine.ParserSettings settings = new ParserSettings();
            CommandLine.Parser.Default.ParseArguments<Arguments>(args)
                .WithParsed(a => arguments = a)
                .WithNotParsed(e => {
                    Console.WriteLine($"Argument parse error. See log file \"{logPath}\".");
                    foreach (var item in e) {
                        Logger.DefaultLogger.PushLog(null, new LogData(LogLevel.Error, item.ToString()));
                    }
                });

            if (arguments == null) {
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain(arguments));
        }
    }
}
