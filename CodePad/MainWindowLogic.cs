using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePad
{
    public class MainWindowLogic
    {
        public Settings Settings { get; set; }
        public KeywordList Keywords { get; set; }
        public KeywordList FilteredKeywords { get; set; }

        public virtual void OnInitSettings()
        {
            throw new NotImplementedException();
        }

        public virtual void OnInitKeywords()
        {
            throw new NotImplementedException();
        }

        public virtual KeywordList GetEmptyKeywordList()
        {
            throw new NotImplementedException();
        }
    }
}
