using ScintillaNET;
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
    public partial class MainWindow : Form
    {
        private Settings Settings;
        private KeywordList Keywords;
        private KeywordList FilteredKeywords;
        private Scintilla TxtProgram;

        public MainWindow()
        {
            InitializeComponent();
            InitializeScintilla();
            InitializeKeywords();
        }

        private void InitializeScintilla()
        {
            TxtProgram = new Scintilla();
            TxtProgram.Parent = TxtProgramPanel;
            TxtProgram.Dock = DockStyle.Fill;
            TxtProgram.BorderStyle = BorderStyle.None;
            TxtProgram.Margins[0].Width = 40;
            TxtProgram.FontQuality = FontQuality.LcdOptimized;
            TxtProgram.ScrollWidthTracking = true;
            TxtProgram.BorderStyle = BorderStyle.None;

            foreach (Style style in TxtProgram.Styles)
            {
                style.Font = "Consolas";
            }
        }

        private void InitializeKeywords()
        {
            Settings = new Settings("settings.ini");
            Keywords = new KeywordList(Settings.CompilerHelpDirectory);
            FilteredKeywords = new KeywordList(Keywords);
            UpdateKeywordTable(FilteredKeywords);

            KeywordTable.SelectionChanged += KeywordTable_SelectionChanged;
            KeywordTable.DoubleClick += KeywordTable_DoubleClick;
            TxtFindKeyword.TextChanged += TxtFindKeyword_TextChanged1;
        }

        private void TxtFindKeyword_TextChanged1(object sender, EventArgs e)
        {
            FilterKeywords(TxtFindKeyword.Text.Trim());
        }

        private void KeywordTable_DoubleClick(object sender, EventArgs e)
        {
            Keyword keyword = GetSelectedKeyword();
            KeywordHelpWindow window = new KeywordHelpWindow(keyword);
            window.ShowDialog(this);
        }

        private void KeywordTable_SelectionChanged(object sender, EventArgs e)
        {
            if (KeywordTable.SelectedRows.Count > 0)
            {
                Keyword keyword = GetSelectedKeyword();
                if (keyword != null)
                    TxtKeywordHelp.Text = keyword.Description;
            }
            else
            {
                TxtKeywordHelp.Text = "";
            }
        }

        private Keyword GetSelectedKeyword()
        {
            string name = KeywordTable.SelectedRows[0].Cells[0].Value as string;
            return FindKeywordByName(name);
        }

        private Keyword FindKeywordByName(string name)
        {
            foreach (Keyword keyword in Keywords)
            {
                if (keyword.Name.Equals(name))
                    return keyword;
            }

            return null;
        }

        private void UpdateKeywordTable(KeywordList dataSource)
        {
            KeywordTable.DataSource = dataSource;

            if (dataSource != null)
            {
                KeywordTable.Columns["Description"].Visible = false;
            }
        }

        private void FilterKeywords(string filter)
        {
            FilteredKeywords.Clear();
            KeywordTable.DataSource = null;

            if (string.IsNullOrWhiteSpace(filter))
            {
                FilteredKeywords.AddRange(Keywords);
            }
            else
            {
                KeywordList tempKeywordList = new KeywordList();

                foreach (Keyword keyword in Keywords)
                {
                    if (keyword.Name.Contains(filter))
                        tempKeywordList.Add(keyword);
                }

                FilteredKeywords.AddRange(tempKeywordList);
            }

            UpdateKeywordTable(FilteredKeywords);
            SelectKeywordAt(0);
        }

        private void SelectKeywordAt(int index)
        {
            if (index >= 0 && index < KeywordTable.Rows.Count)
            {
                KeywordTable.Rows[index].Selected = true;
                KeywordTable.FirstDisplayedScrollingRowIndex = index;
            }
        }

        private void TxtFindKeyword_TextChanged(object sender, EventArgs e)
        {
            string search = TxtFindKeyword.Text.Trim();
            FilterKeywords(string.IsNullOrWhiteSpace(search) ? null : search);
        }

        private void BtnToggleHelp_Click(object sender, EventArgs e)
        {
            SplitContainer.Panel2Collapsed = !SplitContainer.Panel2Collapsed;
        }
    }
}
