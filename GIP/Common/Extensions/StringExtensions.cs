using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

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

        public static string UnifyPathDelimitter(this string inPath)
        {
            return inPath.Replace("/", "\\");
        }

        public static string RemoveExtraDelimitter(this string inPath)
        {
            string tmp, result = inPath;
            do {
                tmp = result;
                result = inPath.Replace("\\\\", "\\");

            } while (tmp != result);
            return result;
        }

        public static string JoinPath(params string[] inArgs)
        {
            if (inArgs.Length == 0) {
                return "";
            }

            int capacity = 0;
            inArgs.ForEach(s => capacity += s.Length);
            capacity += inArgs.Length - 1;
            StringBuilder builder = new StringBuilder(capacity);
            builder.Append(inArgs.First());
            foreach (var str in inArgs.Skip(1)) {
                builder.Append($"\\{str}");
            }
            return builder.ToString().UnifyPathDelimitter().RemoveExtraDelimitter();
        }

        public static string PathRelativeToAbsolute(this string inBase, string inOther)
        {
            Uri @base = new Uri(inBase);
            Uri other = new Uri(@base, inOther);
            return other.LocalPath;
        }

        public static string PathAbsoluteToRelative(this string inBase, string inOther)
        {
            Uri @base = new Uri(inBase);
            Uri other = new Uri(inOther);

            return @base.MakeRelativeUri(other).ToString().UnifyPathDelimitter();
        }

        public static IEnumerable<(int, char)> Enumerate(this string inText, int inStart = 0, int inEnd = -1)
        {
            int end = (inEnd == -1) ? inText.Length : Math.Min(inText.Length, inEnd);
            for (int i = inStart; i < end; ++i) {
                yield return (i, inText[i]);
            }
        }

        public static int CountLineBreakAllPattern(this string inText, int inFrom = 0, int inTo = -1)
        {
            int result = 0;

            int end = (inTo == -1) ? inText.Length : Math.Min(inText.Length, inTo);
            for (int i = Math.Max(0, inFrom); i < end; ++i) {
                char c = inText[i];
                switch (c) {
                    case '\r':
                        if (i < (end - 1)) {
                            if(inText[i + 1] == '\n') {
                                ++i;
                                ++result;
                            }
                        }
                        ++result;
                        break;
                    case '\n':
                        ++result;
                        break;
                }
            }

            return result;
        }
    }
}
