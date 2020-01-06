using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePad.QB64
{
    public class MainWindowLogicQB64 : MainWindowLogic
    {
        public override string TempFile => "temp.bas";
        public override string TempExecutable => "temp.exe";

        public override void OnInitSettings()
        {
            Settings = new SettingsQB64();
        }

        public override void OnInitKeywords()
        {
            Keywords = new KeywordListQB64(Settings.CompilerHelpDirectory);
            FilteredKeywords = new KeywordListQB64(Keywords);
        }

        public override KeywordList GetEmptyKeywordList()
        {
            return new KeywordListQB64();
        }
    }
}
