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
        protected MainWindowLogic WindowLogic;

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

        public MainWindow() : this(null)
        {
        }

        public MainWindow(MainWindowLogic windowLogic)
        {
            WindowLogic = windowLogic;
            WindowLogic.OnInitSettings();

            InitializeComponent();
            InitializeMainWindow();
            InitializeTempFolder();
            InitializeScintilla();
            InitializeKeywords();

            CurrentFile = Unsaved;
        }

        private void InitializeMainWindow()
        {
            Size = WindowLogic.Settings.MainWindowSize;
        }

        private void InitializeTempFolder()
        {
            if (!Directory.Exists(TempPath))
                Directory.CreateDirectory(TempPath);
        }

        private void InitializeScintilla()
        {
            TxtProgram = new Scintilla
            {
                Parent = TxtProgramPanel,
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                FontQuality = FontQuality.LcdOptimized,
                CaretStyle = CaretStyle.Block,
                EdgeColumn = 80,
                EdgeMode = EdgeMode.None
            };

            foreach (var margin in TxtProgram.Margins)
            {
                margin.Width = 0;
            }

            SetFont(WindowLogic.Settings.Font);
            SetMarginColor(WindowLogic.Settings.MarginColor);
            SetForeColor(WindowLogic.Settings.ForeColor);
            SetBackColor(WindowLogic.Settings.BackColor);
        }

        private void SetFont(Font font)
        {
            SetFont(font.Name, font.Size, font.Style == FontStyle.Bold);
        }

        private void SetFont(string name, float size, bool bold = false)
        {
            CurrentFont = new Font(name, size, bold ? FontStyle.Bold : FontStyle.Regular);

            WindowLogic.Settings.Font = CurrentFont;

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
            WindowLogic.Settings.BackColor = color;
        }

        private void SetForeColor(Color color)
        {
            DefaultStyle.ForeColor = color;
            TxtProgram.CaretForeColor = color;
            TxtProgram.SetSelectionBackColor(true, color);
            TxtProgram.StyleClearAll();
            WindowLogic.Settings.ForeColor = color;
        }

        private void SetMarginColor(Color color)
        {
            Margin margin = TxtProgram.Margins[0];
            margin.Width = 40;
            margin.Type = MarginType.Color;
            margin.BackColor = color;
            WindowLogic.Settings.MarginColor = color;
        }

        private void InitializeKeywords()
        {
            WindowLogic.OnInitKeywords();

            UpdateKeywordTable(WindowLogic.FilteredKeywords);

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
            foreach (Keyword keyword in WindowLogic.Keywords)
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
            WindowLogic.FilteredKeywords.Clear();
            KeywordTable.DataSource = null;

            if (string.IsNullOrWhiteSpace(filter))
            {
                WindowLogic.FilteredKeywords.AddRange(WindowLogic.Keywords);
            }
            else
            {
                KeywordList tempKeywordList = WindowLogic.GetEmptyKeywordList();

                foreach (Keyword keyword in WindowLogic.Keywords)
                {
                    if (keyword.Name.Contains(filter))
                        tempKeywordList.Add(keyword);
                }

                WindowLogic.FilteredKeywords.AddRange(tempKeywordList);
            }

            UpdateKeywordTable(WindowLogic.FilteredKeywords);
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
            Process.Start(WindowLogic.Settings.SettingsFile);
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
            if (File.Exists(programExecutablePath))
                File.Delete(programExecutablePath);

            ProcessStartInfo startInfo = WindowLogic.Settings.GetCompilerProcessInfo(
                programSourcePath, programExecutablePath);

            Process proc = new Process();
            proc.StartInfo = startInfo;
            proc.Start();
            proc.WaitForExit();

            if (proc.ExitCode == 0)
            {
                if (File.Exists(programExecutablePath))
                {
                    Process.Start(programExecutablePath);
                }
                else
                {
                    MessageBox.Show(
                        $"The compiler did not generate the expected executable file:\n{programExecutablePath}",
                        "Unknown Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            OpenCurrentFolder();
        }

        private void BtnSetBackgroundColor_Click(object sender, EventArgs e)
        {
            SetBackColor(SelectColor(DefaultStyle.BackColor));
        }

        private void BtnSetForegroundColor_Click(object sender, EventArgs e)
        {
            SetForeColor(SelectColor(DefaultStyle.ForeColor));
        }

        private void BtnSetMarginColor_Click(object sender, EventArgs e)
        {
            SetMarginColor(SelectColor(TxtProgram.Margins[0].BackColor));
        }

        private Color SelectColor(Color initialColor)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = initialColor;

            if (dialog.ShowDialog() == DialogResult.OK)
                return dialog.Color;

            return initialColor;
        }

        private void BtnViewWiki_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(WindowLogic.Settings.HelpBaseUrl))
            {
                string url = WindowLogic.Settings.HelpBaseUrl + GetSelectedKeyword().Name;
                Process.Start(url);
            }
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

        private void StatusBarCurrentFolder_Click(object sender, EventArgs e)
        {
            OpenCurrentFolder();
        }

        private void OpenCurrentFolder()
        {
            if (FileSaved)
                Process.Start(CurrentFolder);
            else
                Process.Start(TempPath);
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

        private void MiBtnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Exit();
        }

        private void Exit()
        {
            WindowLogic.Settings.Save();
        }

        private void MainWindow_SizeChanged(object sender, EventArgs e)
        {
            WindowLogic.Settings.MainWindowSize = Size;
        }
    }
}
