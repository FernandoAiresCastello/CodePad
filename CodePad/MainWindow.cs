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
        private const string FileChangedIndicator = "*";

        protected MainWindowLogic WindowLogic;

        private RecentFiles RecentFiles;
        private Scintilla TxtProgram;
        private Font CurrentFont;

        private Style DefaultStyle => TxtProgram.Styles[Style.Default];

        private string CurrentFile
        {
            get => TxtFilePath.Text;
            set => TxtFilePath.Text = value;
        }

        private bool FileChanged
        {
            get => TxtFilePath.Text.Contains(FileChangedIndicator);
            set => AppendFileChangedIndicator(value);
        }

        private string CurrentFolder => Path.GetDirectoryName(CurrentFile);
        private string CurrentExecutable => Path.Combine(CurrentFolder, Path.GetFileNameWithoutExtension(CurrentFile) + ".exe");

        private bool IsFileSaved => !CurrentFile.Substring(0, Unsaved.Length).Equals(Unsaved);

        private const string Unsaved = "Unsaved";

        private readonly string TempPath = Path.Combine(Application.StartupPath, "temp");

        public MainWindow() : this(null)
        {
        }

        public MainWindow(MainWindowLogic windowLogic)
        {
            InitializeComponent();

            WindowLogic = windowLogic;
            WindowLogic.OnInitSettings();

            Text += " " + WindowLogic.Settings.MainWindowSubtitle;

            InitializeMainWindow();
            InitializeRecentFiles();
            InitializeTempFolder();
            InitializeScintilla();
            InitializeKeywords();

            CurrentFile = Unsaved;
        }

        private void InitializeMainWindow()
        {
            Size = WindowLogic.Settings.MainWindowSize;
        }

        private void InitializeRecentFiles()
        {
            RecentFiles = new RecentFiles();
            UpdateRecentFilesMenu();
        }

        private void UpdateRecentFilesMenu()
        {
            var items = MiBtnOpenRecent.DropDownItems;

            items.Clear();

            if (RecentFiles.IsEmpty)
            {
                ToolStripMenuItem emptyItem = new ToolStripMenuItem("(Empty)");
                emptyItem.Enabled = false;
                items.Add(emptyItem);
            }
            else
            {
                foreach (string file in RecentFiles.Files)
                {
                    items.Add(file, null, (obj, args) => OpenRecentFile(file));
                }

                items.Add(new ToolStripSeparator());
                items.Add("Clear list", null, (obj, args) => ConfirmClearRecentFiles());
            }
        }

        private void OpenRecentFile(string file)
        {
            if (File.Exists(file))
            {
                OpenFile(file);
            }
            else
            {
                if (Confirm("File missing", $"The recent file {file} is missing. Remove it from list?"))
                {
                    RemoveRecentFile(file);
                }
            }
        }

        private void RemoveRecentFile(string file)
        {
            RecentFiles.Files.Remove(file);
            UpdateRecentFilesMenu();
        }

        private void ConfirmClearRecentFiles()
        {
            if (Confirm("Clear recent files", "This will clear the recent files list. Are you sure?"))
            {
                ClearRecentFiles();
            }
        }

        private void ClearRecentFiles()
        {
            RecentFiles.Clear();
            UpdateRecentFilesMenu();
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

            TxtProgram.TextChanged += TxtProgram_TextChanged;

            foreach (var margin in TxtProgram.Margins)
            {
                margin.Width = 0;
            }

            SetFont(WindowLogic.Settings.Font);
            SetMarginColor(WindowLogic.Settings.MarginColor);
            SetForeColor(WindowLogic.Settings.ForeColor);
            SetBackColor(WindowLogic.Settings.BackColor);
        }

        private void TxtProgram_TextChanged(object sender, EventArgs e)
        {
            FileChanged = true;
        }

        private void AppendFileChangedIndicator(bool append)
        {
            if (append)
            {
                if (!TxtFilePath.Text.Contains(FileChangedIndicator))
                    TxtFilePath.Text += FileChangedIndicator;
            }
            else
            {
                TxtFilePath.Text = TxtFilePath.Text.Replace(FileChangedIndicator, "");
            }
        }

        private void MainWindow_SizeChanged(object sender, EventArgs e)
        {
            WindowLogic.Settings.MainWindowSize = Size;
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
            TxtFindKeyword.TextChanged += TxtFindKeyword_TextChanged;
        }

        private void TxtFindKeyword_TextChanged(object sender, EventArgs e)
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
            Keyword keyword = GetSelectedKeyword();

            if (KeywordTable.SelectedRows.Count == 0 || keyword == null)
            {
                HelpBrowser.Navigate("about:blank");
            }
            else
            {
                HelpBrowser.Navigate($"{WindowLogic.Settings.HelpBaseUrl}{keyword.Name}");
            }
        }

        private Keyword GetSelectedKeyword()
        {
            if (KeywordTable.SelectedRows.Count > 0)
            {
                string name = KeywordTable.SelectedRows[0].Cells[0].Value as string;
                return FindKeywordByName(name);
            }

            return null;
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
            if (IsFileSaved)
            {
                SaveFile(CurrentFile);
                CompileAndRun(CurrentFile, CurrentExecutable);
            }
            else
            {
                string tempFilePath = Path.Combine(TempPath, WindowLogic.TempFile);
                string tempExecutablePath = Path.Combine(TempPath, WindowLogic.TempExecutable);

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
                    Error("Unknown Error", $"The compiler did not generate the expected executable file:\n{programExecutablePath}");
                }
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ConfirmCreateNewFile();
        }

        private void ConfirmCreateNewFile()
        {
            if (Confirm("New file", "This will create a new empty file. Are you sure?"))
            {
                CreateNewFile();
            }
        }

        private void CreateNewFile()
        {
            CurrentFile = Unsaved;
            TxtProgram.ClearAll();
            FileChanged = false;
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (!IsFileSaved)
                dialog.InitialDirectory = Application.StartupPath;

            if (dialog.ShowDialog() == DialogResult.OK)
                OpenFile(dialog.FileName);
        }

        private bool OpenFile(string file)
        {
            if (File.Exists(file))
            {
                TxtProgram.Text = File.ReadAllText(file);
                CurrentFile = file;
                RecentFiles.AddIfNotExists(file);
                UpdateRecentFilesMenu();
                return true;
            }
            else
            {
                Warn("File not found", $"The file {file} was not found");
                return false;
            }
        }

        private void BtnSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (IsFileSaved)
                SaveFile(CurrentFile);
            else
                SaveFileAs();
        }

        private void SaveFile(string file)
        {
            if (file.Contains(FileChangedIndicator))
                file = file.Replace(FileChangedIndicator, "");

            CurrentFile = file;
            File.WriteAllText(file, TxtProgram.Text);
            RecentFiles.AddIfNotExists(file);
            UpdateRecentFilesMenu();
        }

        private void SaveFileAs()
        {
            SaveFileDialog dialog = new SaveFileDialog();

            if (!IsFileSaved)
                dialog.InitialDirectory = Application.StartupPath;

            if (dialog.ShowDialog() == DialogResult.OK)
                SaveFile(dialog.FileName);
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
            Inform("About", "CodePad © 2019-2020\n\nDeveloped by Fernando Aires Castello");
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
            if (IsFileSaved)
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
                Warn("Text not found", "The text '" + text + "' was not found ahead of current cursor position.");
            }
        }

        private void MiBtnExit_Click(object sender, EventArgs e)
        {
            ForceExit();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Exit();
        }

        private void ForceExit()
        {
            Exit(true);
        }

        private void Exit(bool force = false)
        {
            WindowLogic.Settings.Save();
            RecentFiles.Save();

            if (force)
            {
                Application.Exit();
            }
        }

        private void Inform(string title, string text)
        {
            MessageBox.Show(text, title,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Warn(string title, string text)
        {
            MessageBox.Show(text, title,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Error(string title, string text)
        {
            MessageBox.Show(text, title,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool Confirm(string title, string text)
        {
            return MessageBox.Show(text, title, 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
        }

        private void TxtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                FindInProgram(TxtFind.Text);
            }
        }

        private void BtnClearKeywordFilter_Click(object sender, EventArgs e)
        {
            TxtFindKeyword.Text = "";
        }
    }
}
