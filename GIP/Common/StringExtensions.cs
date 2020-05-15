using System;
using System.Collections.Generic;

namespace GIP.Common
{
    static class StringExtensions
    {
        public static string Linearize(this IEnumerable<string> inLines)
        {
            return Linearize(inLines, Environment.NewLine);
        }

        public static string Linearize(this IEnumerable<string> inLines, string inConnector = "")
        {
            string result = "";
            foreach (var line in inLines) {
                result += line + inConnector;
            }
            if (result.Length == 0) {
                return "";
            }
            result = result.Substring(0, result.Length - inConnector.Length);
            return result;
        }
    }
}
