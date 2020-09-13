using System.Collections.Generic;
using System.Linq;
using CommandLine;

namespace GIP
{
    public class Arguments
    {
        [Option('t', "task", Required = false, HelpText = "project file pathes for auto run. can set multiple with ';' separated.")]
        public string Tasks
        { get; set; } = null;

        [Value(1, MetaName = "other")]
        public IEnumerable<string> Others
        { get; set; } = null;

        public bool MinWindow => Others.Contains("min");
        public bool AutoClose => Others.Contains("autocls");
    }
}
