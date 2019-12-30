using ScintillaNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CodePad
{
    public partial class MainWindow : Form
    {
        private Settings Settings;
        private KeywordList Keywords;
        private KeywordList FilteredKeywords;
        private Scintilla TxtProgram;
        private Font CurrentFont;

        private Style DefaultStyle => TxtProgram.Styles[Style.Default];

        private string CurrentFile
        {
            get => TxtFilePath.Text;
            set => TxtFilePath.Text = value;
        }

        private string CurrentFolder => Path.GetDirectoryName(CurrentFile);
        private string CurrentExecutable => Path.Combine(CurrentFolder, Path.GetFileNameWithoutExtension(CurrentFile) + ".exe");

        private bool FileSaved => !CurrentFile.Equals(Unsaved);

        private const string Unsaved = "Unsaved";
        private const string TempFile = "temp.bas";
        private const string TempExecutable = "temp.exe";

        private readonly string TempPath = Path.Combine(Application.StartupPath, "temp");

        public MainWindow()
        {
            Settings = new Settings();

            InitializeComponent();
            InitializeTempFolder();
            InitializeScintilla();
            InitializeKeywords();

            CurrentFile = Unsaved;
        }

        private void InitializeTempFolder()
        {
            if (!Directory.Exists(TempPath))
                Directory.CreateDirectory(TempPath);

            var tempFiles = Directory.EnumerateFiles(TempPath);

            foreach (string file in tempFiles)
                File.Delete(file);
        }

        private void InitializeScintilla()
        {
            TxtProgram = new Scintilla
            {
                Parent = TxtProgramPanel,
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                FontQuality = FontQuality.LcdOptimized,
                ScrollWidthTracking = true,
                CaretStyle = CaretStyle.Block,
                EdgeColumn = 80,
                EdgeMode = EdgeMode.None
            };

            //TxtProgram.Margins[0].Width = 40;
            foreach (var margin in TxtProgram.Margins)
                margin.Width = 0;

            SetFont(Settings.Font);
            SetForeColor(Settings.ForeColor);
            SetBackColor(Settings.BackColor);
        }

        private void SetFont(Font font)
        {
            SetFont(font.Name, font.Size, font.Style == FontStyle.Bold);
        }

        private void SetFont(string name, float size, bool bold = false)
        {
            CurrentFont = new Font(name, size);

            DefaultStyle.Font = name;
            DefaultStyle.Size = (int)size;
            DefaultStyle.Bold = bold;

            TxtProgram.StyleClearAll();
        }

        private void SetBackColor(Color color)
        {
            DefaultStyle.BackColor = color;
            TxtProgram.SetSelectionForeColor(true, color);
            TxtProgram.StyleClearAll();
        }

        private void SetForeColor(Color color)
        {
            DefaultStyle.ForeColor = color;
            TxtProgram.CaretForeColor = color;
            TxtProgram.SetSelectionBackColor(true, color);
            TxtProgram.StyleClearAll();
        }

        private void SetMarginForeColor(Color color)
        {
            TxtProgram.Styles[Style.LineNumber].ForeColor = color;
        }

        private void SetMarginBackColor(Color color)
        {
            TxtProgram.Styles[Style.LineNumber].BackColor = color;
        }

        private void InitializeKeywords()
        {
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

        private void BtnOpenSettings_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.SettingsFile);
        }

        private void BtnFont_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();
            dialog.Font = CurrentFont;

            if (dialog.ShowDialog() == DialogResult.OK)
                SetFont(dialog.Font.Name, dialog.Font.SizeInPoints, dialog.Font.Bold);
        }


        private void BtnCompileRun_Click(object sender, EventArgs e)
        {
            if (FileSaved)
            {
                SaveFile(CurrentFile);
                CompileAndRun(CurrentFile, CurrentExecutable);
            }
            else
            {
                string tempFilePath = Path.Combine(TempPath, TempFile);
                string tempExecutablePath = Path.Combine(TempPath, TempExecutable);

                SaveFile(tempFilePath);
                CompileAndRun(tempFilePath, tempExecutablePath);
            }
        }

        private void CompileAndRun(string programSourcePath, string programExecutablePath)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(
                Settings.CompilerExecutable,
                "-c \"" + programSourcePath + "\" -o " + "\"" + programExecutablePath + "\"");

            Process proc = new Process();
            proc.StartInfo = startInfo;
            proc.Start();
            proc.WaitForExit();

            if (proc.ExitCode == 0 && File.Exists(programExecutablePath))
                Process.Start(programExecutablePath);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void NewFile()
        {
            CurrentFile = Unsaved;
            TxtProgram.ClearAll();
        }

        private void OpenFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (!FileSaved)
                dialog.InitialDirectory = Application.StartupPath;

            if (dialog.ShowDialog() == DialogResult.OK)
                OpenFile(dialog.FileName);
        }

        private void OpenFile(string file)
        {
            TxtProgram.Text = File.ReadAllText(file);
            CurrentFile = file;
        }

        private void BtnSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void SaveFileAs()
        {
            SaveFileDialog dialog = new SaveFileDialog();

            if (!FileSaved)
                dialog.InitialDirectory = Application.StartupPath;

            if (dialog.ShowDialog() == DialogResult.OK)
                SaveFile(dialog.FileName);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (FileSaved)
                SaveFile(CurrentFile);
            else
                SaveFileAs();
        }

        private void SaveFile(string file)
        {
            File.WriteAllText(file, TxtProgram.Text);
            CurrentFile = file;
        }

        private void BtnOpenCurrentFolder_Click(object sender, EventArgs e)
        {
            if (FileSaved)
                Process.Start(CurrentFolder);
            else
                Process.Start(TempPath);
        }

        private void BtnSetBackgroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = DefaultStyle.BackColor;

            if (dialog.ShowDialog() == DialogResult.OK)
                SetBackColor(dialog.Color);
        }

        private void BtnSetForegroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = DefaultStyle.BackColor;

            if (dialog.ShowDialog() == DialogResult.OK)
                SetForeColor(dialog.Color);
        }

        private void BtnViewWiki_Click(object sender, EventArgs e)
        {
            string url = "http://www.qb64.org/wiki/" + GetSelectedKeyword().Name;
            Process.Start(url);
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "CodePad (C) 2019\n\nDeveloped by Fernando Aires Castello",
                "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            FindInProgram(TxtFind.Text);
        }

        private void FindInProgram(string text)
        {
            TxtProgram.TargetStart = TxtProgram.CurrentPosition;
            TxtProgram.TargetEnd = TxtProgram.TextLength;

            int result = TxtProgram.SearchInTarget(text);

            if (result >= 0)
            {
                TxtProgram.CurrentPosition = result;
                TxtProgram.SelectionStart = result;
                TxtProgram.SelectionEnd = result + text.Length;
                TxtProgram.ScrollCaret();
            }
            else
            {
                MessageBox.Show("Text " + text + " not found", "Search result", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
