﻿using System;
using System.Linq;
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
    }
}