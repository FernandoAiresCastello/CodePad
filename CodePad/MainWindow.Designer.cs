namespace CodePad
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MiBtnNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MiBtnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MiBtnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MiBtnSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnOpenCurrentFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MiBtnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.buildRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MiBtnCompileRun = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnFont = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnSetForegroundColor = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnSetBackgroundColor = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnSetMarginColor = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnOpenSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TxtFilePath = new System.Windows.Forms.ToolStripStatusLabel();
            this.RootPanel = new System.Windows.Forms.Panel();
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.TxtFind = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.TxtProgramPanel = new System.Windows.Forms.Panel();
            this.TxtConsole = new System.Windows.Forms.TextBox();
            this.CommandTablePanel = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.KeywordTable = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnOpenHelpInBrowser = new System.Windows.Forms.Button();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.TxtFindKeyword = new System.Windows.Forms.ToolStripTextBox();
            this.MiBtnOpenRecent = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.HelpBrowser = new System.Windows.Forms.WebBrowser();
            this.BtnNew = new System.Windows.Forms.ToolStripButton();
            this.BtnOpen = new System.Windows.Forms.ToolStripButton();
            this.BtnSave = new System.Windows.Forms.ToolStripButton();
            this.BtnSaveAs = new System.Windows.Forms.ToolStripButton();
            this.BtnRun = new System.Windows.Forms.ToolStripButton();
            this.BtnFind = new System.Windows.Forms.ToolStripButton();
            this.BtnClearKeywordFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.RootPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.CommandTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KeywordTable)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.buildRunToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(774, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiBtnNew,
            this.MiBtnOpen,
            this.MiBtnOpenRecent,
            this.MiBtnSave,
            this.MiBtnSaveAs,
            this.toolStripSeparator3,
            this.BtnOpenCurrentFolder,
            this.toolStripSeparator1,
            this.MiBtnExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // MiBtnNew
            // 
            this.MiBtnNew.Name = "MiBtnNew";
            this.MiBtnNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.MiBtnNew.Size = new System.Drawing.Size(184, 22);
            this.MiBtnNew.Text = "New";
            this.MiBtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // MiBtnOpen
            // 
            this.MiBtnOpen.Name = "MiBtnOpen";
            this.MiBtnOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MiBtnOpen.Size = new System.Drawing.Size(184, 22);
            this.MiBtnOpen.Text = "Open";
            this.MiBtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // MiBtnSave
            // 
            this.MiBtnSave.Name = "MiBtnSave";
            this.MiBtnSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MiBtnSave.Size = new System.Drawing.Size(184, 22);
            this.MiBtnSave.Text = "Save";
            this.MiBtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // MiBtnSaveAs
            // 
            this.MiBtnSaveAs.Name = "MiBtnSaveAs";
            this.MiBtnSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.MiBtnSaveAs.Size = new System.Drawing.Size(184, 22);
            this.MiBtnSaveAs.Text = "Save as";
            this.MiBtnSaveAs.Click += new System.EventHandler(this.BtnSaveAs_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);
            // 
            // BtnOpenCurrentFolder
            // 
            this.BtnOpenCurrentFolder.Name = "BtnOpenCurrentFolder";
            this.BtnOpenCurrentFolder.Size = new System.Drawing.Size(184, 22);
            this.BtnOpenCurrentFolder.Text = "Open current folder";
            this.BtnOpenCurrentFolder.Click += new System.EventHandler(this.BtnOpenCurrentFolder_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // MiBtnExit
            // 
            this.MiBtnExit.Name = "MiBtnExit";
            this.MiBtnExit.Size = new System.Drawing.Size(184, 22);
            this.MiBtnExit.Text = "Exit";
            this.MiBtnExit.Click += new System.EventHandler(this.MiBtnExit_Click);
            // 
            // buildRunToolStripMenuItem
            // 
            this.buildRunToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiBtnCompileRun});
            this.buildRunToolStripMenuItem.Name = "buildRunToolStripMenuItem";
            this.buildRunToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.buildRunToolStripMenuItem.Text = "Compile/Run";
            // 
            // MiBtnCompileRun
            // 
            this.MiBtnCompileRun.Name = "MiBtnCompileRun";
            this.MiBtnCompileRun.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.MiBtnCompileRun.Size = new System.Drawing.Size(182, 22);
            this.MiBtnCompileRun.Text = "Compile and run";
            this.MiBtnCompileRun.Click += new System.EventHandler(this.BtnCompileRun_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnFont,
            this.toolStripSeparator6,
            this.BtnSetForegroundColor,
            this.BtnSetBackgroundColor,
            this.BtnSetMarginColor});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.viewToolStripMenuItem.Text = "Font/Colors";
            // 
            // BtnFont
            // 
            this.BtnFont.Name = "BtnFont";
            this.BtnFont.Size = new System.Drawing.Size(187, 22);
            this.BtnFont.Text = "Set font";
            this.BtnFont.Click += new System.EventHandler(this.BtnFont_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(184, 6);
            // 
            // BtnSetForegroundColor
            // 
            this.BtnSetForegroundColor.Name = "BtnSetForegroundColor";
            this.BtnSetForegroundColor.Size = new System.Drawing.Size(187, 22);
            this.BtnSetForegroundColor.Text = "Set foreground color";
            this.BtnSetForegroundColor.Click += new System.EventHandler(this.BtnSetForegroundColor_Click);
            // 
            // BtnSetBackgroundColor
            // 
            this.BtnSetBackgroundColor.Name = "BtnSetBackgroundColor";
            this.BtnSetBackgroundColor.Size = new System.Drawing.Size(187, 22);
            this.BtnSetBackgroundColor.Text = "Set background color";
            this.BtnSetBackgroundColor.Click += new System.EventHandler(this.BtnSetBackgroundColor_Click);
            // 
            // BtnSetMarginColor
            // 
            this.BtnSetMarginColor.Name = "BtnSetMarginColor";
            this.BtnSetMarginColor.Size = new System.Drawing.Size(187, 22);
            this.BtnSetMarginColor.Text = "Set margin color";
            this.BtnSetMarginColor.Click += new System.EventHandler(this.BtnSetMarginColor_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnOpenSettings});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // BtnOpenSettings
            // 
            this.BtnOpenSettings.Name = "BtnOpenSettings";
            this.BtnOpenSettings.Size = new System.Drawing.Size(166, 22);
            this.BtnOpenSettings.Text = "Open settings file";
            this.BtnOpenSettings.Click += new System.EventHandler(this.BtnOpenSettings_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnHelp,
            this.BtnAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // BtnHelp
            // 
            this.BtnHelp.Name = "BtnHelp";
            this.BtnHelp.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.BtnHelp.Size = new System.Drawing.Size(150, 22);
            this.BtnHelp.Text = "Help panel";
            this.BtnHelp.Click += new System.EventHandler(this.BtnToggleHelp_Click);
            // 
            // BtnAbout
            // 
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.Size = new System.Drawing.Size(150, 22);
            this.BtnAbout.Text = "About";
            this.BtnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.TxtFilePath});
            this.statusStrip1.Location = new System.Drawing.Point(0, 478);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(774, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TxtFilePath
            // 
            this.TxtFilePath.Margin = new System.Windows.Forms.Padding(0);
            this.TxtFilePath.Name = "TxtFilePath";
            this.TxtFilePath.Size = new System.Drawing.Size(25, 26);
            this.TxtFilePath.Text = "File";
            this.TxtFilePath.Click += new System.EventHandler(this.StatusBarCurrentFolder_Click);
            // 
            // RootPanel
            // 
            this.RootPanel.Controls.Add(this.SplitContainer);
            this.RootPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RootPanel.Location = new System.Drawing.Point(0, 24);
            this.RootPanel.Name = "RootPanel";
            this.RootPanel.Size = new System.Drawing.Size(774, 454);
            this.RootPanel.TabIndex = 3;
            // 
            // SplitContainer
            // 
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer.Name = "SplitContainer";
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.splitContainer3);
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.CommandTablePanel);
            this.SplitContainer.Size = new System.Drawing.Size(774, 454);
            this.SplitContainer.SplitterDistance = 533;
            this.SplitContainer.TabIndex = 3;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.TxtConsole);
            this.splitContainer3.Panel2Collapsed = true;
            this.splitContainer3.Size = new System.Drawing.Size(533, 454);
            this.splitContainer3.SplitterDistance = 324;
            this.splitContainer3.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TxtProgramPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(533, 454);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnNew,
            this.BtnOpen,
            this.BtnSave,
            this.BtnSaveAs,
            this.toolStripSeparator2,
            this.BtnRun,
            this.toolStripSeparator4,
            this.TxtFind,
            this.BtnFind,
            this.toolStripSeparator5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(533, 31);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // TxtFind
            // 
            this.TxtFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtFind.Margin = new System.Windows.Forms.Padding(4);
            this.TxtFind.Name = "TxtFind";
            this.TxtFind.Size = new System.Drawing.Size(100, 23);
            this.TxtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFind_KeyPress);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 31);
            // 
            // TxtProgramPanel
            // 
            this.TxtProgramPanel.BackColor = System.Drawing.SystemColors.Control;
            this.TxtProgramPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TxtProgramPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtProgramPanel.Location = new System.Drawing.Point(0, 31);
            this.TxtProgramPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TxtProgramPanel.Name = "TxtProgramPanel";
            this.TxtProgramPanel.Size = new System.Drawing.Size(533, 423);
            this.TxtProgramPanel.TabIndex = 4;
            // 
            // TxtConsole
            // 
            this.TxtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtConsole.Font = new System.Drawing.Font("Consolas", 8F);
            this.TxtConsole.Location = new System.Drawing.Point(0, 0);
            this.TxtConsole.Multiline = true;
            this.TxtConsole.Name = "TxtConsole";
            this.TxtConsole.ReadOnly = true;
            this.TxtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtConsole.Size = new System.Drawing.Size(150, 46);
            this.TxtConsole.TabIndex = 1;
            this.TxtConsole.WordWrap = false;
            // 
            // CommandTablePanel
            // 
            this.CommandTablePanel.Controls.Add(this.splitContainer2);
            this.CommandTablePanel.Controls.Add(this.toolStrip2);
            this.CommandTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommandTablePanel.Location = new System.Drawing.Point(0, 0);
            this.CommandTablePanel.Name = "CommandTablePanel";
            this.CommandTablePanel.Size = new System.Drawing.Size(237, 454);
            this.CommandTablePanel.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 31);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.KeywordTable);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Size = new System.Drawing.Size(237, 423);
            this.splitContainer2.SplitterDistance = 205;
            this.splitContainer2.TabIndex = 5;
            // 
            // KeywordTable
            // 
            this.KeywordTable.AllowUserToAddRows = false;
            this.KeywordTable.AllowUserToDeleteRows = false;
            this.KeywordTable.AllowUserToResizeRows = false;
            this.KeywordTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.KeywordTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.KeywordTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.KeywordTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KeywordTable.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.KeywordTable.DefaultCellStyle = dataGridViewCellStyle1;
            this.KeywordTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KeywordTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.KeywordTable.Location = new System.Drawing.Point(0, 0);
            this.KeywordTable.MultiSelect = false;
            this.KeywordTable.Name = "KeywordTable";
            this.KeywordTable.ReadOnly = true;
            this.KeywordTable.RowHeadersVisible = false;
            this.KeywordTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.KeywordTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.KeywordTable.ShowCellErrors = false;
            this.KeywordTable.ShowRowErrors = false;
            this.KeywordTable.Size = new System.Drawing.Size(237, 205);
            this.KeywordTable.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.BtnOpenHelpInBrowser, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(237, 214);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // BtnOpenHelpInBrowser
            // 
            this.BtnOpenHelpInBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnOpenHelpInBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpenHelpInBrowser.Location = new System.Drawing.Point(3, 181);
            this.BtnOpenHelpInBrowser.Name = "BtnOpenHelpInBrowser";
            this.BtnOpenHelpInBrowser.Size = new System.Drawing.Size(231, 30);
            this.BtnOpenHelpInBrowser.TabIndex = 1;
            this.BtnOpenHelpInBrowser.Text = "Open in external browser";
            this.BtnOpenHelpInBrowser.UseVisualStyleBackColor = true;
            this.BtnOpenHelpInBrowser.Click += new System.EventHandler(this.BtnViewWiki_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TxtFindKeyword,
            this.BtnClearKeywordFilter});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip2.Size = new System.Drawing.Size(237, 31);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // TxtFindKeyword
            // 
            this.TxtFindKeyword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtFindKeyword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtFindKeyword.Margin = new System.Windows.Forms.Padding(4);
            this.TxtFindKeyword.Name = "TxtFindKeyword";
            this.TxtFindKeyword.Size = new System.Drawing.Size(100, 23);
            // 
            // MiBtnOpenRecent
            // 
            this.MiBtnOpenRecent.Name = "MiBtnOpenRecent";
            this.MiBtnOpenRecent.Size = new System.Drawing.Size(184, 22);
            this.MiBtnOpenRecent.Text = "Open recent";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.HelpBrowser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 178);
            this.panel1.TabIndex = 2;
            // 
            // HelpBrowser
            // 
            this.HelpBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HelpBrowser.Location = new System.Drawing.Point(0, 0);
            this.HelpBrowser.Margin = new System.Windows.Forms.Padding(0);
            this.HelpBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.HelpBrowser.Name = "HelpBrowser";
            this.HelpBrowser.Size = new System.Drawing.Size(233, 174);
            this.HelpBrowser.TabIndex = 3;
            // 
            // BtnNew
            // 
            this.BtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnNew.Image = global::CodePad.Properties.Resources.page_white;
            this.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(23, 28);
            this.BtnNew.Text = "New file";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnOpen
            // 
            this.BtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnOpen.Image = global::CodePad.Properties.Resources.folder;
            this.BtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(23, 28);
            this.BtnOpen.Text = "Open file";
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSave.Image = global::CodePad.Properties.Resources.diskette;
            this.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(23, 28);
            this.BtnSave.Text = "Save file";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnSaveAs
            // 
            this.BtnSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSaveAs.Image = global::CodePad.Properties.Resources.file_save_as;
            this.BtnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSaveAs.Name = "BtnSaveAs";
            this.BtnSaveAs.Size = new System.Drawing.Size(23, 28);
            this.BtnSaveAs.Text = "Save file as";
            this.BtnSaveAs.Click += new System.EventHandler(this.BtnSaveAs_Click);
            // 
            // BtnRun
            // 
            this.BtnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnRun.Image = global::CodePad.Properties.Resources.control_play_blue;
            this.BtnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRun.Name = "BtnRun";
            this.BtnRun.Size = new System.Drawing.Size(23, 28);
            this.BtnRun.Text = "Compile/Run";
            this.BtnRun.ToolTipText = "Compile and run";
            this.BtnRun.Click += new System.EventHandler(this.BtnCompileRun_Click);
            // 
            // BtnFind
            // 
            this.BtnFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnFind.Image = global::CodePad.Properties.Resources.magnifier;
            this.BtnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnFind.Name = "BtnFind";
            this.BtnFind.Size = new System.Drawing.Size(23, 28);
            this.BtnFind.Text = "toolStripButton1";
            this.BtnFind.ToolTipText = "Find";
            this.BtnFind.Click += new System.EventHandler(this.BtnFind_Click);
            // 
            // BtnClearKeywordFilter
            // 
            this.BtnClearKeywordFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnClearKeywordFilter.Image = global::CodePad.Properties.Resources.filter_clear;
            this.BtnClearKeywordFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnClearKeywordFilter.Name = "BtnClearKeywordFilter";
            this.BtnClearKeywordFilter.Size = new System.Drawing.Size(23, 28);
            this.BtnClearKeywordFilter.Text = "toolStripButton1";
            this.BtnClearKeywordFilter.ToolTipText = "Clear keyword filter";
            this.BtnClearKeywordFilter.Click += new System.EventHandler(this.BtnClearKeywordFilter_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::CodePad.Properties.Resources.script_code;
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(5, 5, 2, 5);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 16);
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.StatusBarCurrentFolder_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 504);
            this.Controls.Add(this.RootPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodePad";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.SizeChanged += new System.EventHandler(this.MainWindow_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.RootPanel.ResumeLayout(false);
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.CommandTablePanel.ResumeLayout(false);
            this.CommandTablePanel.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KeywordTable)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MiBtnOpen;
        private System.Windows.Forms.ToolStripMenuItem MiBtnSave;
        private System.Windows.Forms.ToolStripMenuItem MiBtnSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MiBtnExit;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MiBtnNew;
        private System.Windows.Forms.ToolStripMenuItem BtnOpenSettings;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel RootPanel;
        private System.Windows.Forms.SplitContainer SplitContainer;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel TxtProgramPanel;
        private System.Windows.Forms.TextBox TxtConsole;
        private System.Windows.Forms.Panel CommandTablePanel;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView KeywordTable;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripTextBox TxtFindKeyword;
        private System.Windows.Forms.ToolStripStatusLabel TxtFilePath;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnNew;
        private System.Windows.Forms.ToolStripButton BtnOpen;
        private System.Windows.Forms.ToolStripButton BtnSave;
        private System.Windows.Forms.ToolStripButton BtnSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BtnRun;
        private System.Windows.Forms.ToolStripMenuItem buildRunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MiBtnCompileRun;
        private System.Windows.Forms.ToolStripMenuItem BtnFont;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem BtnOpenCurrentFolder;
        private System.Windows.Forms.ToolStripMenuItem BtnSetBackgroundColor;
        private System.Windows.Forms.ToolStripMenuItem BtnSetForegroundColor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BtnOpenHelpInBrowser;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BtnHelp;
        private System.Windows.Forms.ToolStripMenuItem BtnAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripTextBox TxtFind;
        private System.Windows.Forms.ToolStripButton BtnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem BtnSetMarginColor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem MiBtnOpenRecent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser HelpBrowser;
        private System.Windows.Forms.ToolStripButton BtnClearKeywordFilter;
    }
}

