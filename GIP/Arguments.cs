using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;
using GIP.Common;

namespace GIP
{
    public class Arguments
    {
        [Option('t', "task", Required = false, HelpText = "project file pathes for auto run. can set multiple with ';' separated.")]
        public string Tasks
        { get; set; } = null;

        [Option('l', "log", Required = false, HelpText = "log file path.")]
        public string LogFile
        { get; set; } = null;

        [Value(1, MetaName = "other")]
        public IEnumerable<string> Others
        { get; set; } = null;

        public bool MinWindow => Others.Contains("min");
        public bool AutoClose => Others.Contains("autocls");
    }

    public static class ArgumentsExtensions
    {
        public static void PushLog(this Arguments inArgs, ILogger inLogger)
        {
            string log = "";
            if (inArgs.Tasks != null) {
                log += $"{Environment.NewLine}\t";

                IEnumerable<string> tasks = inArgs.Tasks.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (tasks.Empty()) {
                    log += "No tasks.";
                } else {
                    log += "Tasks";
                    foreach (var task in tasks) {
                        log += $"{Environment.NewLine}\t\t{task}";
                    }
                }
            }

            if (!inArgs.Others.Empty()) {
                log += $"{Environment.NewLine}\tOthers";
                foreach (var other in inArgs.Others) {
                    log += $"{Environment.NewLine}\t\t{other}";
                }
            }

            if (log == "") {
                inLogger.PushLog(inArgs, new LogData(LogLevel.Information, "No arguments."));
            } else {
                log = $"Arguments{Environment.NewLine}{log}";
                inLogger.PushLog(inArgs, new LogData(LogLevel.Information, log));
            }

            return;
        }
    }
}
