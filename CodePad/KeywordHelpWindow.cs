using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodePad
{
    public partial class KeywordHelpWindow : Form
    {
        public KeywordHelpWindow()
        {
            InitializeComponent();
        }

        public KeywordHelpWindow(Keyword keyword)
        {
            InitializeComponent();
            Shown += KeywordHelpWindow_Shown;
            Text = "Keyword help: " + keyword.Name;
            TxtHelp.Text = keyword.Description;
        }

        private void KeywordHelpWindow_Shown(object sender, EventArgs e)
        {
            TxtHelp.Select(0, 0);
        }
    }
}
