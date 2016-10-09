namespace FilmCollection
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dgvTableRec = new System.Windows.Forms.DataGridView();
            this.TabMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cFind = new System.Windows.Forms.ToolStripMenuItem();
            this.cSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cChange = new System.Windows.Forms.ToolStripMenuItem();
            this.cDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testChangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusLine = new System.Windows.Forms.StatusStrip();
            this.tssLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.FindStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreateBase = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpdateBase = new System.Windows.Forms.ToolStripMenuItem();
            this.tS1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBackupBase = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRecoveryBase = new System.Windows.Forms.ToolStripMenuItem();
            this.tS2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tS4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.btnActors = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRelease = new System.Windows.Forms.ToolStripMenuItem();
            this.treeFolder = new System.Windows.Forms.TreeView();
            this.TreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.сCollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.сExpandAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cExpandSelectNode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cShowSelcetNodeAllFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabFilm = new System.Windows.Forms.TabPage();
            this.scTabFilm = new System.Windows.Forms.SplitContainer();
            this.menudgvTable = new System.Windows.Forms.MenuStrip();
            this.menuResetFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.tscbTypeFilter = new System.Windows.Forms.ToolStripComboBox();
            this.tscbSort = new System.Windows.Forms.ToolStripComboBox();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.cBoxCountry = new System.Windows.Forms.ComboBox();
            this.mtbYear = new System.Windows.Forms.MaskedTextBox();
            this.panelEditTitle = new System.Windows.Forms.Panel();
            this.lblEditTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.btnFileNameEdit = new System.Windows.Forms.Button();
            this.cBoxTypeVideo = new System.Windows.Forms.ComboBox();
            this.numericTime = new System.Windows.Forms.NumericUpDown();
            this.cBoxGenre = new System.Windows.Forms.ComboBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblTimeMin = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.labelTypeVideo = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.panelFind = new System.Windows.Forms.Panel();
            this.btnFindReset = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.btnFindNext = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.cbTypeFind = new System.Windows.Forms.ComboBox();
            this.panelView = new System.Windows.Forms.Panel();
            this.btnPlay = new System.Windows.Forms.Button();
            this.lblRecDescription = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRecName = new System.Windows.Forms.Label();
            this.tbfDesc = new System.Windows.Forms.TextBox();
            this.tbfCountry = new System.Windows.Forms.TextBox();
            this.tbfYear = new System.Windows.Forms.TextBox();
            this.tbfName = new System.Windows.Forms.TextBox();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lblRecTitle = new System.Windows.Forms.Label();
            this.tabWriter = new System.Windows.Forms.TabPage();
            this.tabImage = new System.Windows.Forms.TabPage();
            this.btnDownloadPic = new System.Windows.Forms.Button();
            this.timerLoad = new System.Windows.Forms.Timer(this.components);
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolMainMenu = new System.Windows.Forms.ToolStrip();
            this.tsCreateDB = new System.Windows.Forms.ToolStripButton();
            this.tsUpdateDB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBackupDB = new System.Windows.Forms.ToolStripButton();
            this.tsRecoveryDB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsFind = new System.Windows.Forms.ToolStripButton();
            this.toolinfo = new System.Windows.Forms.ToolTip(this.components);
            this.cmnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnDirName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCountryString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnGenreString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCategoryString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabActors = new System.Windows.Forms.TabPage();
            this.dgvTableActors = new System.Windows.Forms.DataGridView();
            this.scTabActors = new System.Windows.Forms.SplitContainer();
            this.colActFIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActlifetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableRec)).BeginInit();
            this.TabMenu.SuspendLayout();
            this.statusLine.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.TreeMenu.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabFilm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scTabFilm)).BeginInit();
            this.scTabFilm.Panel1.SuspendLayout();
            this.scTabFilm.Panel2.SuspendLayout();
            this.scTabFilm.SuspendLayout();
            this.menudgvTable.SuspendLayout();
            this.panelEdit.SuspendLayout();
            this.panelEditTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTime)).BeginInit();
            this.panelFind.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelView.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.tabImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.toolMainMenu.SuspendLayout();
            this.tabActors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableActors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scTabActors)).BeginInit();
            this.scTabActors.Panel1.SuspendLayout();
            this.scTabActors.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTableRec
            // 
            this.dgvTableRec.AllowUserToAddRows = false;
            this.dgvTableRec.AllowUserToDeleteRows = false;
            this.dgvTableRec.AllowUserToResizeRows = false;
            this.dgvTableRec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTableRec.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTableRec.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTableRec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableRec.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnName,
            this.cmnDirName,
            this.cmnYear,
            this.cmnCountryString,
            this.cmnGenreString,
            this.cmnCategoryString,
            this.cmnTime,
            this.cmnFileName});
            this.dgvTableRec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTableRec.Location = new System.Drawing.Point(0, 27);
            this.dgvTableRec.MultiSelect = false;
            this.dgvTableRec.Name = "dgvTableRec";
            this.dgvTableRec.ReadOnly = true;
            this.dgvTableRec.RowHeadersVisible = false;
            this.dgvTableRec.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTableRec.Size = new System.Drawing.Size(532, 405);
            this.dgvTableRec.TabIndex = 12;
            this.dgvTableRec.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTable_CellMouseDown);
            this.dgvTableRec.SelectionChanged += new System.EventHandler(this.SelectRecord_Info);
            // 
            // TabMenu
            // 
            this.TabMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cFind,
            this.cSeparator3,
            this.cAdd,
            this.cChange,
            this.cDelete,
            this.toolStripSeparator1,
            this.testToolStripMenuItem,
            this.testChangeToolStripMenuItem});
            this.TabMenu.Name = "contextMenuStrip1";
            this.TabMenu.Size = new System.Drawing.Size(140, 148);
            this.TabMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // cFind
            // 
            this.cFind.Image = global::FilmCollection.Properties.Resources.find;
            this.cFind.Name = "cFind";
            this.cFind.Size = new System.Drawing.Size(139, 22);
            this.cFind.Text = "Найти";
            this.cFind.Click += new System.EventHandler(this.cFind_Click);
            // 
            // cSeparator3
            // 
            this.cSeparator3.Name = "cSeparator3";
            this.cSeparator3.Size = new System.Drawing.Size(136, 6);
            // 
            // cAdd
            // 
            this.cAdd.Image = global::FilmCollection.Properties.Resources.add;
            this.cAdd.Name = "cAdd";
            this.cAdd.Size = new System.Drawing.Size(139, 22);
            this.cAdd.Text = "Добавить";
            this.cAdd.Click += new System.EventHandler(this.AddRec_Click);
            // 
            // cChange
            // 
            this.cChange.Image = global::FilmCollection.Properties.Resources.change;
            this.cChange.Name = "cChange";
            this.cChange.Size = new System.Drawing.Size(139, 22);
            this.cChange.Text = "Изменить";
            this.cChange.Click += new System.EventHandler(this.EditRec_Click);
            // 
            // cDelete
            // 
            this.cDelete.Image = global::FilmCollection.Properties.Resources.del;
            this.cDelete.Name = "cDelete";
            this.cDelete.Size = new System.Drawing.Size(139, 22);
            this.cDelete.Text = "Удалить";
            this.cDelete.Click += new System.EventHandler(this.DeleteRec_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(136, 6);
            this.toolStripSeparator1.Visible = false;
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.testToolStripMenuItem.Text = "Test Create";
            this.testToolStripMenuItem.Visible = false;
            this.testToolStripMenuItem.Click += new System.EventHandler(this.OLD_Add_rec);
            // 
            // testChangeToolStripMenuItem
            // 
            this.testChangeToolStripMenuItem.Name = "testChangeToolStripMenuItem";
            this.testChangeToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.testChangeToolStripMenuItem.Text = "Test Change";
            this.testChangeToolStripMenuItem.Visible = false;
            this.testChangeToolStripMenuItem.Click += new System.EventHandler(this.OLD_Change_rec);
            // 
            // statusLine
            // 
            this.statusLine.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabel,
            this.tsProgressBar,
            this.FindStatusLabel});
            this.statusLine.Location = new System.Drawing.Point(0, 515);
            this.statusLine.Name = "statusLine";
            this.statusLine.Size = new System.Drawing.Size(1117, 22);
            this.statusLine.TabIndex = 18;
            this.statusLine.Text = "statusStrip1";
            // 
            // tssLabel
            // 
            this.tssLabel.AutoSize = false;
            this.tssLabel.Name = "tssLabel";
            this.tssLabel.Size = new System.Drawing.Size(200, 17);
            this.tssLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsProgressBar
            // 
            this.tsProgressBar.Name = "tsProgressBar";
            this.tsProgressBar.Size = new System.Drawing.Size(200, 16);
            this.tsProgressBar.Visible = false;
            // 
            // FindStatusLabel
            // 
            this.FindStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.FindStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.FindStatusLabel.Name = "FindStatusLabel";
            this.FindStatusLabel.Size = new System.Drawing.Size(4, 17);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.правкаToolStripMenuItem,
            this.настройкаToolStripMenuItem,
            this.btnHelp});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1117, 24);
            this.mainMenu.TabIndex = 10;
            this.mainMenu.Text = "menuStrip1";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCreateBase,
            this.btnUpdateBase,
            this.tS1,
            this.btnBackupBase,
            this.btnRecoveryBase,
            this.tS2,
            this.btnExportHTML,
            this.btnReport,
            this.tS4,
            this.btnExit});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(48, 20);
            this.MenuFile.Text = "Файл";
            // 
            // btnCreateBase
            // 
            this.btnCreateBase.Image = global::FilmCollection.Properties.Resources.db;
            this.btnCreateBase.Name = "btnCreateBase";
            this.btnCreateBase.Size = new System.Drawing.Size(187, 22);
            this.btnCreateBase.Text = "Создать базу";
            this.btnCreateBase.Click += new System.EventHandler(this.CreateBase_Click);
            // 
            // btnUpdateBase
            // 
            this.btnUpdateBase.Image = global::FilmCollection.Properties.Resources.dbRebuild;
            this.btnUpdateBase.Name = "btnUpdateBase";
            this.btnUpdateBase.Size = new System.Drawing.Size(187, 22);
            this.btnUpdateBase.Text = "Обновить базу";
            this.btnUpdateBase.Click += new System.EventHandler(this.UpdateBase_Click);
            // 
            // tS1
            // 
            this.tS1.Name = "tS1";
            this.tS1.Size = new System.Drawing.Size(184, 6);
            // 
            // btnBackupBase
            // 
            this.btnBackupBase.Image = global::FilmCollection.Properties.Resources.dbBackup;
            this.btnBackupBase.Name = "btnBackupBase";
            this.btnBackupBase.Size = new System.Drawing.Size(187, 22);
            this.btnBackupBase.Text = "Создать копию базы";
            this.btnBackupBase.Click += new System.EventHandler(this.BackupBase_Click);
            // 
            // btnRecoveryBase
            // 
            this.btnRecoveryBase.Image = global::FilmCollection.Properties.Resources.dbRecovery;
            this.btnRecoveryBase.Name = "btnRecoveryBase";
            this.btnRecoveryBase.Size = new System.Drawing.Size(187, 22);
            this.btnRecoveryBase.Text = "Восстановить из...";
            this.btnRecoveryBase.Click += new System.EventHandler(this.btnRecoveryBase_Click);
            // 
            // tS2
            // 
            this.tS2.Name = "tS2";
            this.tS2.Size = new System.Drawing.Size(184, 6);
            this.tS2.Visible = false;
            // 
            // btnExportHTML
            // 
            this.btnExportHTML.Name = "btnExportHTML";
            this.btnExportHTML.Size = new System.Drawing.Size(187, 22);
            this.btnExportHTML.Text = "Экспорт в HTML";
            this.btnExportHTML.Visible = false;
            // 
            // btnReport
            // 
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(187, 22);
            this.btnReport.Text = "Отчет";
            this.btnReport.Visible = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // tS4
            // 
            this.tS4.Name = "tS4";
            this.tS4.Size = new System.Drawing.Size(184, 6);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::FilmCollection.Properties.Resources.Exit;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(187, 22);
            this.btnExit.Text = "Выход";
            this.btnExit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // правкаToolStripMenuItem
            // 
            this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            this.правкаToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.правкаToolStripMenuItem.Text = "Правка";
            // 
            // настройкаToolStripMenuItem
            // 
            this.настройкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOptions,
            this.btnActors});
            this.настройкаToolStripMenuItem.Name = "настройкаToolStripMenuItem";
            this.настройкаToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.настройкаToolStripMenuItem.Text = "Настройка";
            // 
            // btnOptions
            // 
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(138, 22);
            this.btnOptions.Text = "Параметры";
            // 
            // btnActors
            // 
            this.btnActors.Name = "btnActors";
            this.btnActors.Size = new System.Drawing.Size(138, 22);
            this.btnActors.Text = "Актеры";
            this.btnActors.Click += new System.EventHandler(this.btnActors_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAbout,
            this.btnRelease});
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(65, 20);
            this.btnHelp.Text = "Справка";
            // 
            // btnAbout
            // 
            this.btnAbout.Image = global::FilmCollection.Properties.Resources.help;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(149, 22);
            this.btnAbout.Text = "О программе";
            this.btnAbout.Click += new System.EventHandler(this.About_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(149, 22);
            this.btnRelease.Text = "Версии";
            this.btnRelease.Visible = false;
            // 
            // treeFolder
            // 
            this.treeFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFolder.Location = new System.Drawing.Point(0, 0);
            this.treeFolder.Name = "treeFolder";
            this.treeFolder.Size = new System.Drawing.Size(191, 466);
            this.treeFolder.TabIndex = 22;
            this.treeFolder.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeFolder_NodeMouseClick);
            // 
            // TreeMenu
            // 
            this.TreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сCollapseAll,
            this.сExpandAll,
            this.toolStripSeparator2,
            this.cExpandSelectNode,
            this.toolStripSeparator3,
            this.cShowSelcetNodeAllFiles});
            this.TreeMenu.Name = "contextTreeMenu";
            this.TreeMenu.Size = new System.Drawing.Size(268, 104);
            // 
            // сCollapseAll
            // 
            this.сCollapseAll.Name = "сCollapseAll";
            this.сCollapseAll.Size = new System.Drawing.Size(267, 22);
            this.сCollapseAll.Text = "Свернуть все";
            this.сCollapseAll.Click += new System.EventHandler(this.сCollapseAll_Click);
            // 
            // сExpandAll
            // 
            this.сExpandAll.Name = "сExpandAll";
            this.сExpandAll.Size = new System.Drawing.Size(267, 22);
            this.сExpandAll.Text = "Развернуть все";
            this.сExpandAll.Click += new System.EventHandler(this.сExpandAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(264, 6);
            // 
            // cExpandSelectNode
            // 
            this.cExpandSelectNode.Name = "cExpandSelectNode";
            this.cExpandSelectNode.Size = new System.Drawing.Size(267, 22);
            this.cExpandSelectNode.Text = "Развернуть ветку";
            this.cExpandSelectNode.Click += new System.EventHandler(this.cExpandSelectNode_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(264, 6);
            // 
            // cShowSelcetNodeAllFiles
            // 
            this.cShowSelcetNodeAllFiles.Name = "cShowSelcetNodeAllFiles";
            this.cShowSelcetNodeAllFiles.Size = new System.Drawing.Size(267, 22);
            this.cShowSelcetNodeAllFiles.Text = "Отобразить все вложенные файлы";
            this.cShowSelcetNodeAllFiles.Click += new System.EventHandler(this.cShowSelcetNodeAllFiles_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabFilm);
            this.tabControl2.Controls.Add(this.tabActors);
            this.tabControl2.Controls.Add(this.tabWriter);
            this.tabControl2.Controls.Add(this.tabImage);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(922, 466);
            this.tabControl2.TabIndex = 11;
            this.tabControl2.Click += new System.EventHandler(this.tabControl_ResetFindStatus_Click);
            // 
            // tabFilm
            // 
            this.tabFilm.Controls.Add(this.scTabFilm);
            this.tabFilm.Location = new System.Drawing.Point(4, 22);
            this.tabFilm.Name = "tabFilm";
            this.tabFilm.Padding = new System.Windows.Forms.Padding(3);
            this.tabFilm.Size = new System.Drawing.Size(914, 440);
            this.tabFilm.TabIndex = 0;
            this.tabFilm.Text = "Фильмотека";
            this.tabFilm.UseVisualStyleBackColor = true;
            // 
            // scTabFilm
            // 
            this.scTabFilm.BackColor = System.Drawing.SystemColors.Control;
            this.scTabFilm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scTabFilm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scTabFilm.Location = new System.Drawing.Point(3, 3);
            this.scTabFilm.Name = "scTabFilm";
            // 
            // scTabFilm.Panel1
            // 
            this.scTabFilm.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.scTabFilm.Panel1.Controls.Add(this.dgvTableRec);
            this.scTabFilm.Panel1.Controls.Add(this.menudgvTable);
            this.scTabFilm.Panel1MinSize = 400;
            // 
            // scTabFilm.Panel2
            // 
            this.scTabFilm.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.scTabFilm.Panel2.Controls.Add(this.panelEdit);
            this.scTabFilm.Panel2.Controls.Add(this.panelFind);
            this.scTabFilm.Panel2.Controls.Add(this.panelView);
            this.scTabFilm.Panel2MinSize = 200;
            this.scTabFilm.Size = new System.Drawing.Size(908, 434);
            this.scTabFilm.SplitterDistance = 534;
            this.scTabFilm.TabIndex = 17;
            // 
            // menudgvTable
            // 
            this.menudgvTable.BackColor = System.Drawing.SystemColors.Control;
            this.menudgvTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuResetFilter,
            this.tscbTypeFilter,
            this.tscbSort});
            this.menudgvTable.Location = new System.Drawing.Point(0, 0);
            this.menudgvTable.Name = "menudgvTable";
            this.menudgvTable.Size = new System.Drawing.Size(532, 27);
            this.menudgvTable.TabIndex = 23;
            this.menudgvTable.Text = "menuStrip1";
            // 
            // menuResetFilter
            // 
            this.menuResetFilter.Image = global::FilmCollection.Properties.Resources.resetFiltr;
            this.menuResetFilter.Name = "menuResetFilter";
            this.menuResetFilter.Size = new System.Drawing.Size(120, 23);
            this.menuResetFilter.Text = "Сброс фильтра";
            this.menuResetFilter.Click += new System.EventHandler(this.ResetFilter_Click);
            // 
            // tscbTypeFilter
            // 
            this.tscbTypeFilter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tscbTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbTypeFilter.Items.AddRange(new object[] {
            "Все",
            "Фильмы",
            "Мульты",
            "Сериалы"});
            this.tscbTypeFilter.Name = "tscbTypeFilter";
            this.tscbTypeFilter.Size = new System.Drawing.Size(121, 23);
            this.tscbTypeFilter.SelectedIndexChanged += new System.EventHandler(this.Filter);
            // 
            // tscbSort
            // 
            this.tscbSort.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tscbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbSort.Items.AddRange(new object[] {
            "По именам",
            "По времени",
            "По году",
            "По категориям",
            "По каталогу"});
            this.tscbSort.Name = "tscbSort";
            this.tscbSort.Size = new System.Drawing.Size(121, 23);
            this.tscbSort.SelectedIndexChanged += new System.EventHandler(this.Filter);
            // 
            // panelEdit
            // 
            this.panelEdit.Controls.Add(this.cBoxCountry);
            this.panelEdit.Controls.Add(this.mtbYear);
            this.panelEdit.Controls.Add(this.panelEditTitle);
            this.panelEdit.Controls.Add(this.btnSave);
            this.panelEdit.Controls.Add(this.btnCancel);
            this.panelEdit.Controls.Add(this.tbFileName);
            this.panelEdit.Controls.Add(this.btnFileNameEdit);
            this.panelEdit.Controls.Add(this.cBoxTypeVideo);
            this.panelEdit.Controls.Add(this.numericTime);
            this.panelEdit.Controls.Add(this.cBoxGenre);
            this.panelEdit.Controls.Add(this.tbDescription);
            this.panelEdit.Controls.Add(this.tbName);
            this.panelEdit.Controls.Add(this.lblFileName);
            this.panelEdit.Controls.Add(this.lblDescription);
            this.panelEdit.Controls.Add(this.lblTimeMin);
            this.panelEdit.Controls.Add(this.lblTime);
            this.panelEdit.Controls.Add(this.labelTypeVideo);
            this.panelEdit.Controls.Add(this.lblGenre);
            this.panelEdit.Controls.Add(this.lblCountry);
            this.panelEdit.Controls.Add(this.lblYear);
            this.panelEdit.Controls.Add(this.lblName);
            this.panelEdit.Controls.Add(this.btnNew);
            this.panelEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEdit.Location = new System.Drawing.Point(0, 0);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(368, 432);
            this.panelEdit.TabIndex = 10;
            // 
            // cBoxCountry
            // 
            this.cBoxCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCountry.FormattingEnabled = true;
            this.cBoxCountry.Location = new System.Drawing.Point(186, 59);
            this.cBoxCountry.Name = "cBoxCountry";
            this.cBoxCountry.Size = new System.Drawing.Size(164, 21);
            this.cBoxCountry.TabIndex = 50;
            this.cBoxCountry.SelectionChangeCommitted += new System.EventHandler(this.UserModifiedChanged);
            // 
            // mtbYear
            // 
            this.mtbYear.Location = new System.Drawing.Point(71, 59);
            this.mtbYear.Mask = "0000";
            this.mtbYear.Name = "mtbYear";
            this.mtbYear.Size = new System.Drawing.Size(57, 20);
            this.mtbYear.TabIndex = 49;
            this.mtbYear.Text = "2016";
            this.mtbYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtbYear.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.mtbYear.ModifiedChanged += new System.EventHandler(this.UserModifiedChanged);
            this.mtbYear.Validating += new System.ComponentModel.CancelEventHandler(this.mtbYear_Validating);
            // 
            // panelEditTitle
            // 
            this.panelEditTitle.Controls.Add(this.lblEditTitle);
            this.panelEditTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEditTitle.Location = new System.Drawing.Point(0, 0);
            this.panelEditTitle.Name = "panelEditTitle";
            this.panelEditTitle.Size = new System.Drawing.Size(368, 27);
            this.panelEditTitle.TabIndex = 48;
            // 
            // lblEditTitle
            // 
            this.lblEditTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEditTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEditTitle.Location = new System.Drawing.Point(0, 0);
            this.lblEditTitle.Name = "lblEditTitle";
            this.lblEditTitle.Size = new System.Drawing.Size(368, 27);
            this.lblEditTitle.TabIndex = 0;
            this.lblEditTitle.Text = "Панель редактирования";
            this.lblEditTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::FilmCollection.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(264, 304);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 23);
            this.btnSave.TabIndex = 47;
            this.btnSave.Text = "Сохранить";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(264, 333);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 23);
            this.btnCancel.TabIndex = 46;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbFileName
            // 
            this.tbFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFileName.Enabled = false;
            this.tbFileName.Location = new System.Drawing.Point(71, 266);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(250, 20);
            this.tbFileName.TabIndex = 44;
            this.tbFileName.ModifiedChanged += new System.EventHandler(this.UserModifiedChanged);
            // 
            // btnFileNameEdit
            // 
            this.btnFileNameEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileNameEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileNameEdit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnFileNameEdit.Image = global::FilmCollection.Properties.Resources._lock;
            this.btnFileNameEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFileNameEdit.Location = new System.Drawing.Point(326, 263);
            this.btnFileNameEdit.Name = "btnFileNameEdit";
            this.btnFileNameEdit.Size = new System.Drawing.Size(24, 25);
            this.btnFileNameEdit.TabIndex = 43;
            this.btnFileNameEdit.UseVisualStyleBackColor = true;
            this.btnFileNameEdit.Click += new System.EventHandler(this.FileNameEdit_Unlock);
            // 
            // cBoxTypeVideo
            // 
            this.cBoxTypeVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxTypeVideo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxTypeVideo.FormattingEnabled = true;
            this.cBoxTypeVideo.Location = new System.Drawing.Point(71, 122);
            this.cBoxTypeVideo.Name = "cBoxTypeVideo";
            this.cBoxTypeVideo.Size = new System.Drawing.Size(279, 21);
            this.cBoxTypeVideo.TabIndex = 42;
            this.cBoxTypeVideo.SelectionChangeCommitted += new System.EventHandler(this.UserModifiedChanged);
            // 
            // numericTime
            // 
            this.numericTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericTime.Location = new System.Drawing.Point(71, 152);
            this.numericTime.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericTime.Name = "numericTime";
            this.numericTime.Size = new System.Drawing.Size(203, 20);
            this.numericTime.TabIndex = 32;
            this.numericTime.Enter += new System.EventHandler(this.UserModifiedChanged);
            // 
            // cBoxGenre
            // 
            this.cBoxGenre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxGenre.FormattingEnabled = true;
            this.cBoxGenre.Location = new System.Drawing.Point(71, 92);
            this.cBoxGenre.Name = "cBoxGenre";
            this.cBoxGenre.Size = new System.Drawing.Size(279, 21);
            this.cBoxGenre.TabIndex = 31;
            this.cBoxGenre.SelectionChangeCommitted += new System.EventHandler(this.UserModifiedChanged);
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Location = new System.Drawing.Point(71, 182);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(279, 75);
            this.tbDescription.TabIndex = 30;
            this.tbDescription.ModifiedChanged += new System.EventHandler(this.UserModifiedChanged);
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(71, 30);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(279, 20);
            this.tbName.TabIndex = 27;
            this.tbName.ModifiedChanged += new System.EventHandler(this.UserModifiedChanged);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(7, 269);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(64, 13);
            this.lblFileName.TabIndex = 26;
            this.lblFileName.Text = "Имя файла";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(13, 185);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(57, 13);
            this.lblDescription.TabIndex = 25;
            this.lblDescription.Text = "Описание";
            // 
            // lblTimeMin
            // 
            this.lblTimeMin.AutoSize = true;
            this.lblTimeMin.Location = new System.Drawing.Point(280, 154);
            this.lblTimeMin.Name = "lblTimeMin";
            this.lblTimeMin.Size = new System.Drawing.Size(37, 13);
            this.lblTimeMin.TabIndex = 24;
            this.lblTimeMin.Text = "минут";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(10, 154);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(40, 13);
            this.lblTime.TabIndex = 24;
            this.lblTime.Text = "Время";
            // 
            // labelTypeVideo
            // 
            this.labelTypeVideo.AutoSize = true;
            this.labelTypeVideo.Location = new System.Drawing.Point(10, 125);
            this.labelTypeVideo.Name = "labelTypeVideo";
            this.labelTypeVideo.Size = new System.Drawing.Size(26, 13);
            this.labelTypeVideo.TabIndex = 23;
            this.labelTypeVideo.Text = "Тип";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(10, 95);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(36, 13);
            this.lblGenre.TabIndex = 22;
            this.lblGenre.Text = "Жанр";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(137, 62);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(43, 13);
            this.lblCountry.TabIndex = 21;
            this.lblCountry.Text = "Страна";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(10, 62);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(25, 13);
            this.lblYear.TabIndex = 20;
            this.lblYear.Text = "Год";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(5, 33);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 13);
            this.lblName.TabIndex = 19;
            this.lblName.Text = " Название";
            // 
            // btnNew
            // 
            this.btnNew.Image = global::FilmCollection.Properties.Resources.add;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(71, 304);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(81, 23);
            this.btnNew.TabIndex = 18;
            this.btnNew.Text = "Добавить";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // panelFind
            // 
            this.panelFind.Controls.Add(this.btnFindReset);
            this.panelFind.Controls.Add(this.label3);
            this.panelFind.Controls.Add(this.label2);
            this.panelFind.Controls.Add(this.panel1);
            this.panelFind.Controls.Add(this.tbFind);
            this.panelFind.Controls.Add(this.btnFindNext);
            this.panelFind.Controls.Add(this.btnFind);
            this.panelFind.Controls.Add(this.cbTypeFind);
            this.panelFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFind.Location = new System.Drawing.Point(0, 0);
            this.panelFind.Name = "panelFind";
            this.panelFind.Size = new System.Drawing.Size(368, 432);
            this.panelFind.TabIndex = 0;
            // 
            // btnFindReset
            // 
            this.btnFindReset.Location = new System.Drawing.Point(59, 136);
            this.btnFindReset.Name = "btnFindReset";
            this.btnFindReset.Size = new System.Drawing.Size(69, 23);
            this.btnFindReset.TabIndex = 18;
            this.btnFindReset.Text = "Сброс";
            this.btnFindReset.UseVisualStyleBackColor = true;
            this.btnFindReset.Click += new System.EventHandler(this.btnFindReset_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Критерий поиска";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Строка поиска";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 27);
            this.panel1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Панель поиска";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbFind
            // 
            this.tbFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFind.Location = new System.Drawing.Point(22, 59);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(328, 20);
            this.tbFind.TabIndex = 15;
            // 
            // btnFindNext
            // 
            this.btnFindNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindNext.Enabled = false;
            this.btnFindNext.Location = new System.Drawing.Point(227, 136);
            this.btnFindNext.Name = "btnFindNext";
            this.btnFindNext.Size = new System.Drawing.Size(123, 23);
            this.btnFindNext.TabIndex = 14;
            this.btnFindNext.Text = "Найти следующее";
            this.btnFindNext.UseVisualStyleBackColor = true;
            this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Enabled = false;
            this.btnFind.Location = new System.Drawing.Point(227, 107);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(123, 23);
            this.btnFind.TabIndex = 14;
            this.btnFind.Text = "Найти все";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.Find_Click);
            // 
            // cbTypeFind
            // 
            this.cbTypeFind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeFind.FormattingEnabled = true;
            this.cbTypeFind.Items.AddRange(new object[] {
            "Название",
            "Год"});
            this.cbTypeFind.Location = new System.Drawing.Point(22, 107);
            this.cbTypeFind.Name = "cbTypeFind";
            this.cbTypeFind.Size = new System.Drawing.Size(138, 21);
            this.cbTypeFind.TabIndex = 13;
            this.cbTypeFind.SelectedIndexChanged += new System.EventHandler(this.cbTypeFind_SelectedIndexChanged);
            // 
            // panelView
            // 
            this.panelView.Controls.Add(this.btnPlay);
            this.panelView.Controls.Add(this.lblRecDescription);
            this.panelView.Controls.Add(this.label5);
            this.panelView.Controls.Add(this.label4);
            this.panelView.Controls.Add(this.lblRecName);
            this.panelView.Controls.Add(this.tbfDesc);
            this.panelView.Controls.Add(this.tbfCountry);
            this.panelView.Controls.Add(this.tbfYear);
            this.panelView.Controls.Add(this.tbfName);
            this.panelView.Controls.Add(this.panelTitle);
            this.panelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelView.Location = new System.Drawing.Point(0, 0);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(368, 432);
            this.panelView.TabIndex = 10;
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPlay.Image = global::FilmCollection.Properties.Resources.play;
            this.btnPlay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlay.Location = new System.Drawing.Point(5, 406);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(111, 23);
            this.btnPlay.TabIndex = 6;
            this.btnPlay.Text = "Воспроизвести";
            this.btnPlay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.Play_Click);
            // 
            // lblRecDescription
            // 
            this.lblRecDescription.AutoSize = true;
            this.lblRecDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRecDescription.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRecDescription.Location = new System.Drawing.Point(2, 76);
            this.lblRecDescription.Name = "lblRecDescription";
            this.lblRecDescription.Size = new System.Drawing.Size(82, 17);
            this.lblRecDescription.TabIndex = 4;
            this.lblRecDescription.Text = " Описание:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(120, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Страна:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(7, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Год:";
            // 
            // lblRecName
            // 
            this.lblRecName.AutoSize = true;
            this.lblRecName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRecName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRecName.Location = new System.Drawing.Point(2, 29);
            this.lblRecName.Name = "lblRecName";
            this.lblRecName.Size = new System.Drawing.Size(80, 17);
            this.lblRecName.TabIndex = 3;
            this.lblRecName.Text = " Название:";
            // 
            // tbfDesc
            // 
            this.tbfDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbfDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbfDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbfDesc.Location = new System.Drawing.Point(88, 76);
            this.tbfDesc.Multiline = true;
            this.tbfDesc.Name = "tbfDesc";
            this.tbfDesc.ReadOnly = true;
            this.tbfDesc.Size = new System.Drawing.Size(277, 335);
            this.tbfDesc.TabIndex = 8;
            // 
            // tbfCountry
            // 
            this.tbfCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbfCountry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbfCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbfCountry.Location = new System.Drawing.Point(180, 53);
            this.tbfCountry.Name = "tbfCountry";
            this.tbfCountry.ReadOnly = true;
            this.tbfCountry.Size = new System.Drawing.Size(170, 16);
            this.tbfCountry.TabIndex = 7;
            // 
            // tbfYear
            // 
            this.tbfYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbfYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbfYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbfYear.Location = new System.Drawing.Point(41, 53);
            this.tbfYear.Name = "tbfYear";
            this.tbfYear.ReadOnly = true;
            this.tbfYear.Size = new System.Drawing.Size(75, 16);
            this.tbfYear.TabIndex = 7;
            // 
            // tbfName
            // 
            this.tbfName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbfName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbfName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbfName.Location = new System.Drawing.Point(82, 29);
            this.tbfName.Name = "tbfName";
            this.tbfName.ReadOnly = true;
            this.tbfName.Size = new System.Drawing.Size(282, 16);
            this.tbfName.TabIndex = 7;
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.lblRecTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(368, 27);
            this.panelTitle.TabIndex = 7;
            // 
            // lblRecTitle
            // 
            this.lblRecTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRecTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRecTitle.Location = new System.Drawing.Point(0, 0);
            this.lblRecTitle.Name = "lblRecTitle";
            this.lblRecTitle.Size = new System.Drawing.Size(368, 27);
            this.lblRecTitle.TabIndex = 0;
            this.lblRecTitle.Text = "Общие сведения";
            this.lblRecTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabWriter
            // 
            this.tabWriter.Location = new System.Drawing.Point(4, 22);
            this.tabWriter.Name = "tabWriter";
            this.tabWriter.Padding = new System.Windows.Forms.Padding(3);
            this.tabWriter.Size = new System.Drawing.Size(914, 440);
            this.tabWriter.TabIndex = 1;
            this.tabWriter.Text = "Редактор";
            this.tabWriter.UseVisualStyleBackColor = true;
            // 
            // tabImage
            // 
            this.tabImage.Controls.Add(this.btnDownloadPic);
            this.tabImage.Location = new System.Drawing.Point(4, 22);
            this.tabImage.Name = "tabImage";
            this.tabImage.Size = new System.Drawing.Size(914, 440);
            this.tabImage.TabIndex = 2;
            this.tabImage.Text = "Постеры";
            this.tabImage.UseVisualStyleBackColor = true;
            // 
            // btnDownloadPic
            // 
            this.btnDownloadPic.Location = new System.Drawing.Point(632, 95);
            this.btnDownloadPic.Name = "btnDownloadPic";
            this.btnDownloadPic.Size = new System.Drawing.Size(93, 40);
            this.btnDownloadPic.TabIndex = 0;
            this.btnDownloadPic.Text = "Загрузка Изображения";
            this.btnDownloadPic.UseVisualStyleBackColor = true;
            this.btnDownloadPic.Click += new System.EventHandler(this.DownloadPic_Click);
            // 
            // timerLoad
            // 
            this.timerLoad.Tick += new System.EventHandler(this.T_Tick);
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.Location = new System.Drawing.Point(0, 49);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.treeFolder);
            this.scMain.Panel1MinSize = 150;
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.tabControl2);
            this.scMain.Panel2MinSize = 600;
            this.scMain.Size = new System.Drawing.Size(1117, 466);
            this.scMain.SplitterDistance = 191;
            this.scMain.TabIndex = 24;
            // 
            // FileDialog
            // 
            this.FileDialog.FileName = "openFileDialog1";
            // 
            // toolMainMenu
            // 
            this.toolMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCreateDB,
            this.tsUpdateDB,
            this.toolStripSeparator4,
            this.tsBackupDB,
            this.tsRecoveryDB,
            this.toolStripSeparator6,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripSeparator5,
            this.tsFind});
            this.toolMainMenu.Location = new System.Drawing.Point(0, 24);
            this.toolMainMenu.Name = "toolMainMenu";
            this.toolMainMenu.Size = new System.Drawing.Size(1117, 25);
            this.toolMainMenu.TabIndex = 26;
            this.toolMainMenu.Text = "toolStrip1";
            // 
            // tsCreateDB
            // 
            this.tsCreateDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsCreateDB.Image = global::FilmCollection.Properties.Resources.db;
            this.tsCreateDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCreateDB.Name = "tsCreateDB";
            this.tsCreateDB.Size = new System.Drawing.Size(23, 22);
            this.tsCreateDB.Text = "Создать базу";
            this.tsCreateDB.Click += new System.EventHandler(this.CreateBase_Click);
            // 
            // tsUpdateDB
            // 
            this.tsUpdateDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsUpdateDB.Image = global::FilmCollection.Properties.Resources.dbRebuild;
            this.tsUpdateDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUpdateDB.Name = "tsUpdateDB";
            this.tsUpdateDB.Size = new System.Drawing.Size(23, 22);
            this.tsUpdateDB.Text = "Обновить базу";
            this.tsUpdateDB.Click += new System.EventHandler(this.UpdateBase_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBackupDB
            // 
            this.tsBackupDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBackupDB.Image = global::FilmCollection.Properties.Resources.dbBackup;
            this.tsBackupDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBackupDB.Name = "tsBackupDB";
            this.tsBackupDB.Size = new System.Drawing.Size(23, 22);
            this.tsBackupDB.Text = "Создать копию базы";
            this.tsBackupDB.Click += new System.EventHandler(this.BackupBase_Click);
            // 
            // tsRecoveryDB
            // 
            this.tsRecoveryDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsRecoveryDB.Image = global::FilmCollection.Properties.Resources.dbRecovery;
            this.tsRecoveryDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRecoveryDB.Name = "tsRecoveryDB";
            this.tsRecoveryDB.Size = new System.Drawing.Size(23, 22);
            this.tsRecoveryDB.Text = "Восстановить из...";
            this.tsRecoveryDB.Click += new System.EventHandler(this.btnRecoveryBase_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::FilmCollection.Properties.Resources.add;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::FilmCollection.Properties.Resources.change;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::FilmCollection.Properties.Resources.del;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "toolStripButton5";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsFind
            // 
            this.tsFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsFind.Image = global::FilmCollection.Properties.Resources.find;
            this.tsFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFind.Name = "tsFind";
            this.tsFind.Size = new System.Drawing.Size(23, 22);
            this.tsFind.Text = "Найти";
            this.tsFind.Click += new System.EventHandler(this.cFind_Click);
            // 
            // toolinfo
            // 
            this.toolinfo.AutoPopDelay = 5000;
            this.toolinfo.InitialDelay = 300;
            this.toolinfo.ReshowDelay = 100;
            // 
            // cmnName
            // 
            this.cmnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnName.DataPropertyName = "Name";
            this.cmnName.HeaderText = "Название";
            this.cmnName.Name = "cmnName";
            this.cmnName.ReadOnly = true;
            // 
            // cmnDirName
            // 
            this.cmnDirName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmnDirName.DataPropertyName = "DirName";
            this.cmnDirName.HeaderText = "Каталог";
            this.cmnDirName.Name = "cmnDirName";
            this.cmnDirName.ReadOnly = true;
            this.cmnDirName.Width = 73;
            // 
            // cmnYear
            // 
            this.cmnYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cmnYear.DataPropertyName = "Year";
            this.cmnYear.HeaderText = "Год";
            this.cmnYear.Name = "cmnYear";
            this.cmnYear.ReadOnly = true;
            this.cmnYear.Width = 60;
            // 
            // cmnCountryString
            // 
            this.cmnCountryString.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmnCountryString.DataPropertyName = "CountryString";
            this.cmnCountryString.HeaderText = "Страна";
            this.cmnCountryString.Name = "cmnCountryString";
            this.cmnCountryString.ReadOnly = true;
            this.cmnCountryString.Width = 68;
            // 
            // cmnGenreString
            // 
            this.cmnGenreString.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmnGenreString.DataPropertyName = "GenreString";
            this.cmnGenreString.HeaderText = "Жанр";
            this.cmnGenreString.Name = "cmnGenreString";
            this.cmnGenreString.ReadOnly = true;
            this.cmnGenreString.Width = 61;
            // 
            // cmnCategoryString
            // 
            this.cmnCategoryString.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmnCategoryString.DataPropertyName = "CategoryString";
            this.cmnCategoryString.HeaderText = "Категория";
            this.cmnCategoryString.Name = "cmnCategoryString";
            this.cmnCategoryString.ReadOnly = true;
            this.cmnCategoryString.Width = 85;
            // 
            // cmnTime
            // 
            this.cmnTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cmnTime.DataPropertyName = "Time";
            this.cmnTime.HeaderText = "Время";
            this.cmnTime.Name = "cmnTime";
            this.cmnTime.ReadOnly = true;
            this.cmnTime.Width = 60;
            // 
            // cmnFileName
            // 
            this.cmnFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnFileName.DataPropertyName = "FileName";
            this.cmnFileName.HeaderText = "Файл";
            this.cmnFileName.Name = "cmnFileName";
            this.cmnFileName.ReadOnly = true;
            // 
            // tabActors
            // 
            this.tabActors.Controls.Add(this.scTabActors);
            this.tabActors.Location = new System.Drawing.Point(4, 22);
            this.tabActors.Name = "tabActors";
            this.tabActors.Size = new System.Drawing.Size(914, 440);
            this.tabActors.TabIndex = 3;
            this.tabActors.Text = "Актеры";
            this.tabActors.UseVisualStyleBackColor = true;
            // 
            // dgvTableActors
            // 
            this.dgvTableActors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableActors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colActFIO,
            this.colActlifetime,
            this.colCountry});
            this.dgvTableActors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTableActors.Location = new System.Drawing.Point(0, 0);
            this.dgvTableActors.Name = "dgvTableActors";
            this.dgvTableActors.Size = new System.Drawing.Size(363, 440);
            this.dgvTableActors.TabIndex = 0;
            // 
            // scTabActors
            // 
            this.scTabActors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scTabActors.Location = new System.Drawing.Point(0, 0);
            this.scTabActors.Name = "scTabActors";
            // 
            // scTabActors.Panel1
            // 
            this.scTabActors.Panel1.Controls.Add(this.dgvTableActors);
            this.scTabActors.Size = new System.Drawing.Size(914, 440);
            this.scTabActors.SplitterDistance = 363;
            this.scTabActors.TabIndex = 1;
            // 
            // colActFIO
            // 
            this.colActFIO.HeaderText = "Ф.И.О.";
            this.colActFIO.Name = "colActFIO";
            // 
            // colActlifetime
            // 
            this.colActlifetime.HeaderText = "Время жизни";
            this.colActlifetime.Name = "colActlifetime";
            // 
            // colCountry
            // 
            this.colCountry.HeaderText = "Страна";
            this.colCountry.Name = "colCountry";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 537);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.statusLine);
            this.Controls.Add(this.toolMainMenu);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menudgvTable;
            this.Name = "MainForm";
            this.Text = "Фильмотека";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_Close);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableRec)).EndInit();
            this.TabMenu.ResumeLayout(false);
            this.statusLine.ResumeLayout(false);
            this.statusLine.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.TreeMenu.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabFilm.ResumeLayout(false);
            this.scTabFilm.Panel1.ResumeLayout(false);
            this.scTabFilm.Panel1.PerformLayout();
            this.scTabFilm.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scTabFilm)).EndInit();
            this.scTabFilm.ResumeLayout(false);
            this.menudgvTable.ResumeLayout(false);
            this.menudgvTable.PerformLayout();
            this.panelEdit.ResumeLayout(false);
            this.panelEdit.PerformLayout();
            this.panelEditTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericTime)).EndInit();
            this.panelFind.ResumeLayout(false);
            this.panelFind.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panelView.ResumeLayout(false);
            this.panelView.PerformLayout();
            this.panelTitle.ResumeLayout(false);
            this.tabImage.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.toolMainMenu.ResumeLayout(false);
            this.toolMainMenu.PerformLayout();
            this.tabActors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableActors)).EndInit();
            this.scTabActors.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scTabActors)).EndInit();
            this.scTabActors.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvTableRec;
        private System.Windows.Forms.ContextMenuStrip TabMenu;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.TreeView treeFolder;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabFilm;
        private System.Windows.Forms.TabPage tabWriter;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem btnCreateBase;
        private System.Windows.Forms.ToolStripMenuItem btnHelp;
        private System.Windows.Forms.ToolStripMenuItem cAdd;
        private System.Windows.Forms.ToolStripMenuItem cDelete;
        private System.Windows.Forms.ToolStripMenuItem cChange;
        private System.Windows.Forms.ToolStripMenuItem btnAbout;
        private System.Windows.Forms.ToolStripMenuItem btnRelease;
        private System.Windows.Forms.ToolStripMenuItem cFind;
        private System.Windows.Forms.ToolStripSeparator cSeparator3;
        private System.Windows.Forms.ToolStripMenuItem btnExportHTML;
        private System.Windows.Forms.ToolStripSeparator tS4;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripMenuItem btnReport;
        private System.Windows.Forms.Timer timerLoad;
        private System.Windows.Forms.ToolStripMenuItem btnUpdateBase;
        private System.Windows.Forms.ToolStripSeparator tS1;
        private System.Windows.Forms.ToolStripMenuItem btnBackupBase;
        private System.Windows.Forms.ToolStripSeparator tS2;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.SplitContainer scTabFilm;
        private System.Windows.Forms.Panel panelFind;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.Panel panelView;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Button btnFileNameEdit;
        private System.Windows.Forms.ComboBox cBoxTypeVideo;
        private System.Windows.Forms.NumericUpDown numericTime;
        private System.Windows.Forms.ComboBox cBoxGenre;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label labelTypeVideo;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox tbfDesc;
        private System.Windows.Forms.TextBox tbfName;
        private System.Windows.Forms.Label lblRecName;
        private System.Windows.Forms.Label lblRecDescription;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ComboBox cbTypeFind;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.MenuStrip menudgvTable;
        private System.Windows.Forms.ToolStripMenuItem menuResetFilter;
        private System.Windows.Forms.ToolStripComboBox tscbTypeFilter;
        private System.Windows.Forms.ToolStripComboBox tscbSort;
        private System.Windows.Forms.ToolStripStatusLabel tssLabel;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog FileDialog;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem testChangeToolStripMenuItem;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label lblRecTitle;
        private System.Windows.Forms.Panel panelEditTitle;
        private System.Windows.Forms.Label lblEditTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripProgressBar tsProgressBar;
        private System.Windows.Forms.StatusStrip statusLine;
        private System.Windows.Forms.ToolStripMenuItem btnRecoveryBase;
        private TreeViewFast.Controls.TreeViewFast treeViewFast1;
        private System.Windows.Forms.ToolStripMenuItem настройкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnOptions;
        private System.Windows.Forms.ToolStripMenuItem btnActors;
        private System.Windows.Forms.Button btnFindNext;
        private System.Windows.Forms.ToolStripStatusLabel FindStatusLabel;
        private System.Windows.Forms.Button btnFindReset;
        private System.Windows.Forms.TabPage tabImage;
        private System.Windows.Forms.Button btnDownloadPic;
        private System.Windows.Forms.ContextMenuStrip TreeMenu;
        private System.Windows.Forms.ToolStripMenuItem сCollapseAll;
        private System.Windows.Forms.ToolStripMenuItem сExpandAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cExpandSelectNode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cShowSelcetNodeAllFiles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbfCountry;
        private System.Windows.Forms.TextBox tbfYear;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolMainMenu;
        private System.Windows.Forms.ToolStripButton tsCreateDB;
        private System.Windows.Forms.ToolStripButton tsUpdateDB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsFind;
        private System.Windows.Forms.ToolTip toolinfo;
        private System.Windows.Forms.MaskedTextBox mtbYear;
        private System.Windows.Forms.ComboBox cBoxCountry;
        private System.Windows.Forms.Label lblTimeMin;
        private System.Windows.Forms.ToolStripButton tsBackupDB;
        private System.Windows.Forms.ToolStripButton tsRecoveryDB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnDirName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCountryString;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnGenreString;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCategoryString;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnFileName;
        private System.Windows.Forms.TabPage tabActors;
        private System.Windows.Forms.SplitContainer scTabActors;
        private System.Windows.Forms.DataGridView dgvTableActors;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActFIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActlifetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCountry;
    }
}

