using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePad
{
    public static class WikiTextParser
    {
        public static string Parse(string wikitext)
        {
            string parsed;

            parsed = wikitext.
                Replace("\n", Environment.NewLine).
                Replace("{{KW|", "").
                Replace("{{Cl|", "").
                Replace("{{PageSyntax}}", "Syntax:").
                Replace("{{Parameters}}", "Parameters:").
                Replace("{{PageDescription}}", "Description:").
                Replace("{{PageSeeAlso}}", "See also:").
                Replace("{{PageNavigation}}", "").
                Replace("{{CodeStart}}", "Code: ").
                Replace("{{CodeEnd}}", "").
                Replace("{{OutputStart}}", "Output: ").
                Replace("{{OutputEnd}}", "").
                Replace("{{", "").
                Replace("}}", "").
                Replace("''", "").
                Replace(":::", new string(' ', 4)).
                Replace("* [[", new string(' ', 4)).
                Replace("** [[", new string(' ', 8)).
                Replace(":*", "- ").
                Replace("]]", "").
                Replace("[[", "");

            return parsed;
        }
    }
}
