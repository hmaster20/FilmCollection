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
            this.cmnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnDirName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCountryString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnGenreString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCategoryString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnRemoveGroup = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.lblActorsSelect = new System.Windows.Forms.Label();
            this.chkActorSelect = new System.Windows.Forms.ListBox();
            this.lblActorsAll = new System.Windows.Forms.Label();
            this.chkActorList = new System.Windows.Forms.CheckedListBox();
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
            this.tabActors = new System.Windows.Forms.TabPage();
            this.scTabActors = new System.Windows.Forms.SplitContainer();
            this.dgvTableActors = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.panelActEditTitle = new System.Windows.Forms.Panel();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cBoxCountryActor = new System.Windows.Forms.ComboBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.btnSaveActor = new System.Windows.Forms.Button();
            this.btnCancelActor = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tbFIO = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnNewActor = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.maskDateOfDeath = new System.Windows.Forms.MaskedTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.maskDateOfBirth = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.colActFIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateOfDeath = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.tabActors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scTabActors)).BeginInit();
            this.scTabActors.Panel1.SuspendLayout();
            this.scTabActors.Panel2.SuspendLayout();
            this.scTabActors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableActors)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panelActEditTitle.SuspendLayout();
            this.tabWriter.SuspendLayout();
            this.tabImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.toolMainMenu.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.dgvTableRec.Size = new System.Drawing.Size(532, 516);
            this.dgvTableRec.TabIndex = 12;
            this.dgvTableRec.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTable_CellMouseDown);
            this.dgvTableRec.SelectionChanged += new System.EventHandler(this.SelectRecord_Info);
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
            this.statusLine.Location = new System.Drawing.Point(0, 626);
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
            this.btnOptions.Size = new System.Drawing.Size(152, 22);
            this.btnOptions.Text = "Параметры";
            // 
            // btnActors
            // 
            this.btnActors.Name = "btnActors";
            this.btnActors.Size = new System.Drawing.Size(152, 22);
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
            this.treeFolder.Size = new System.Drawing.Size(191, 577);
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
            this.tabControl2.Size = new System.Drawing.Size(922, 577);
            this.tabControl2.TabIndex = 11;
            this.tabControl2.Click += new System.EventHandler(this.tabControl_ResetFindStatus_Click);
            // 
            // tabFilm
            // 
            this.tabFilm.Controls.Add(this.scTabFilm);
            this.tabFilm.Location = new System.Drawing.Point(4, 22);
            this.tabFilm.Name = "tabFilm";
            this.tabFilm.Padding = new System.Windows.Forms.Padding(3);
            this.tabFilm.Size = new System.Drawing.Size(914, 551);
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
            this.scTabFilm.Size = new System.Drawing.Size(908, 545);
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
            this.panelEdit.Controls.Add(this.btnMoveDown);
            this.panelEdit.Controls.Add(this.btnMoveUp);
            this.panelEdit.Controls.Add(this.btnRemoveGroup);
            this.panelEdit.Controls.Add(this.btnAddGroup);
            this.panelEdit.Controls.Add(this.lblActorsSelect);
            this.panelEdit.Controls.Add(this.chkActorSelect);
            this.panelEdit.Controls.Add(this.lblActorsAll);
            this.panelEdit.Controls.Add(this.chkActorList);
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
            this.panelEdit.Size = new System.Drawing.Size(368, 543);
            this.panelEdit.TabIndex = 10;
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.BackColor = System.Drawing.Color.LightGray;
            this.btnMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMoveDown.Location = new System.Drawing.Point(13, 453);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(50, 24);
            this.btnMoveDown.TabIndex = 58;
            this.btnMoveDown.Text = "Вниз";
            this.btnMoveDown.UseVisualStyleBackColor = false;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.BackColor = System.Drawing.Color.LightGray;
            this.btnMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMoveUp.Location = new System.Drawing.Point(13, 423);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(50, 24);
            this.btnMoveUp.TabIndex = 57;
            this.btnMoveUp.Text = "Вверх";
            this.btnMoveUp.UseVisualStyleBackColor = false;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnRemoveGroup
            // 
            this.btnRemoveGroup.BackColor = System.Drawing.Color.LightGray;
            this.btnRemoveGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRemoveGroup.Location = new System.Drawing.Point(205, 368);
            this.btnRemoveGroup.Name = "btnRemoveGroup";
            this.btnRemoveGroup.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveGroup.TabIndex = 53;
            this.btnRemoveGroup.Text = "<";
            this.btnRemoveGroup.UseVisualStyleBackColor = false;
            this.btnRemoveGroup.Click += new System.EventHandler(this.btnRemoveGroup_Click);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.BackColor = System.Drawing.Color.LightGray;
            this.btnAddGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddGroup.Location = new System.Drawing.Point(205, 338);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(24, 24);
            this.btnAddGroup.TabIndex = 52;
            this.btnAddGroup.Text = ">";
            this.btnAddGroup.UseVisualStyleBackColor = false;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // lblActorsSelect
            // 
            this.lblActorsSelect.Location = new System.Drawing.Point(232, 299);
            this.lblActorsSelect.Name = "lblActorsSelect";
            this.lblActorsSelect.Size = new System.Drawing.Size(132, 23);
            this.lblActorsSelect.TabIndex = 56;
            this.lblActorsSelect.Text = "Снимались в фильме:";
            this.lblActorsSelect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkActorSelect
            // 
            this.chkActorSelect.Location = new System.Drawing.Point(235, 323);
            this.chkActorSelect.Name = "chkActorSelect";
            this.chkActorSelect.Size = new System.Drawing.Size(115, 95);
            this.chkActorSelect.TabIndex = 55;
            // 
            // lblActorsAll
            // 
            this.lblActorsAll.Location = new System.Drawing.Point(71, 299);
            this.lblActorsAll.Name = "lblActorsAll";
            this.lblActorsAll.Size = new System.Drawing.Size(100, 23);
            this.lblActorsAll.TabIndex = 54;
            this.lblActorsAll.Text = "Список актеров:";
            this.lblActorsAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkActorList
            // 
            this.chkActorList.CheckOnClick = true;
            this.chkActorList.Location = new System.Drawing.Point(71, 323);
            this.chkActorList.Name = "chkActorList";
            this.chkActorList.Size = new System.Drawing.Size(128, 154);
            this.chkActorList.TabIndex = 51;
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
            this.btnSave.Location = new System.Drawing.Point(264, 481);
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
            this.btnCancel.Location = new System.Drawing.Point(264, 510);
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
            this.btnNew.Location = new System.Drawing.Point(99, 511);
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
            this.panelFind.Size = new System.Drawing.Size(368, 543);
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
            this.panelView.Size = new System.Drawing.Size(368, 543);
            this.panelView.TabIndex = 10;
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPlay.Image = global::FilmCollection.Properties.Resources.play;
            this.btnPlay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlay.Location = new System.Drawing.Point(5, 517);
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
            // tabActors
            // 
            this.tabActors.Controls.Add(this.scTabActors);
            this.tabActors.Location = new System.Drawing.Point(4, 22);
            this.tabActors.Name = "tabActors";
            this.tabActors.Padding = new System.Windows.Forms.Padding(3);
            this.tabActors.Size = new System.Drawing.Size(914, 551);
            this.tabActors.TabIndex = 3;
            this.tabActors.Text = "Актеры";
            this.tabActors.UseVisualStyleBackColor = true;
            // 
            // scTabActors
            // 
            this.scTabActors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scTabActors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scTabActors.Location = new System.Drawing.Point(3, 3);
            this.scTabActors.Name = "scTabActors";
            // 
            // scTabActors.Panel1
            // 
            this.scTabActors.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.scTabActors.Panel1.Controls.Add(this.dgvTableActors);
            this.scTabActors.Panel1.Controls.Add(this.menuStrip1);
            // 
            // scTabActors.Panel2
            // 
            this.scTabActors.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.scTabActors.Panel2.Controls.Add(this.panelActEditTitle);
            this.scTabActors.Size = new System.Drawing.Size(908, 545);
            this.scTabActors.SplitterDistance = 437;
            this.scTabActors.TabIndex = 1;
            // 
            // dgvTableActors
            // 
            this.dgvTableActors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTableActors.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTableActors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTableActors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableActors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colActFIO,
            this.colDateOfBirth,
            this.colDateOfDeath,
            this.colCountry});
            this.dgvTableActors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTableActors.Location = new System.Drawing.Point(0, 27);
            this.dgvTableActors.MultiSelect = false;
            this.dgvTableActors.Name = "dgvTableActors";
            this.dgvTableActors.ReadOnly = true;
            this.dgvTableActors.RowHeadersVisible = false;
            this.dgvTableActors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTableActors.Size = new System.Drawing.Size(435, 516);
            this.dgvTableActors.TabIndex = 0;
            this.dgvTableActors.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTable_CellMouseDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripComboBox1,
            this.toolStripComboBox2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(435, 27);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::FilmCollection.Properties.Resources.resetFiltr;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 23);
            this.toolStripMenuItem1.Text = "Сброс фильтра";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "Все",
            "Фильмы",
            "Мульты",
            "Сериалы"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            // 
            // toolStripComboBox2
            // 
            this.toolStripComboBox2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox2.Items.AddRange(new object[] {
            "По именам",
            "По времени",
            "По году",
            "По категориям",
            "По каталогу"});
            this.toolStripComboBox2.Name = "toolStripComboBox2";
            this.toolStripComboBox2.Size = new System.Drawing.Size(121, 23);
            // 
            // panelActEditTitle
            // 
            this.panelActEditTitle.Controls.Add(this.checkBox1);
            this.panelActEditTitle.Controls.Add(this.listBox2);
            this.panelActEditTitle.Controls.Add(this.listBox1);
            this.panelActEditTitle.Controls.Add(this.cBoxCountryActor);
            this.panelActEditTitle.Controls.Add(this.maskDateOfBirth);
            this.panelActEditTitle.Controls.Add(this.maskDateOfDeath);
            this.panelActEditTitle.Controls.Add(this.maskedTextBox1);
            this.panelActEditTitle.Controls.Add(this.btnSaveActor);
            this.panelActEditTitle.Controls.Add(this.btnCancelActor);
            this.panelActEditTitle.Controls.Add(this.textBox2);
            this.panelActEditTitle.Controls.Add(this.tbFIO);
            this.panelActEditTitle.Controls.Add(this.label6);
            this.panelActEditTitle.Controls.Add(this.label10);
            this.panelActEditTitle.Controls.Add(this.label13);
            this.panelActEditTitle.Controls.Add(this.label12);
            this.panelActEditTitle.Controls.Add(this.label11);
            this.panelActEditTitle.Controls.Add(this.label9);
            this.panelActEditTitle.Controls.Add(this.btnNewActor);
            this.panelActEditTitle.Controls.Add(this.label8);
            this.panelActEditTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelActEditTitle.Location = new System.Drawing.Point(0, 0);
            this.panelActEditTitle.Name = "panelActEditTitle";
            this.panelActEditTitle.Size = new System.Drawing.Size(465, 543);
            this.panelActEditTitle.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(76, 354);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(279, 69);
            this.listBox2.TabIndex = 60;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(77, 161);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(279, 134);
            this.listBox1.TabIndex = 60;
            // 
            // cBoxCountryActor
            // 
            this.cBoxCountryActor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCountryActor.FormattingEnabled = true;
            this.cBoxCountryActor.Location = new System.Drawing.Point(192, 56);
            this.cBoxCountryActor.Name = "cBoxCountryActor";
            this.cBoxCountryActor.Size = new System.Drawing.Size(164, 21);
            this.cBoxCountryActor.TabIndex = 59;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(77, 56);
            this.maskedTextBox1.Mask = "0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(57, 20);
            this.maskedTextBox1.TabIndex = 58;
            this.maskedTextBox1.Text = "2016";
            this.maskedTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextBox1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            // 
            // btnSaveActor
            // 
            this.btnSaveActor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveActor.Image = global::FilmCollection.Properties.Resources.save;
            this.btnSaveActor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveActor.Location = new System.Drawing.Point(270, 470);
            this.btnSaveActor.Name = "btnSaveActor";
            this.btnSaveActor.Size = new System.Drawing.Size(86, 23);
            this.btnSaveActor.TabIndex = 57;
            this.btnSaveActor.Text = "Сохранить";
            this.btnSaveActor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveActor.UseVisualStyleBackColor = true;
            this.btnSaveActor.Click += new System.EventHandler(this.btnSaveActor_Click);
            // 
            // btnCancelActor
            // 
            this.btnCancelActor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelActor.Location = new System.Drawing.Point(270, 499);
            this.btnCancelActor.Name = "btnCancelActor";
            this.btnCancelActor.Size = new System.Drawing.Size(86, 23);
            this.btnCancelActor.TabIndex = 56;
            this.btnCancelActor.Text = "Отмена";
            this.btnCancelActor.UseVisualStyleBackColor = true;
            this.btnCancelActor.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(76, 328);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(279, 20);
            this.textBox2.TabIndex = 55;
            // 
            // tbFIO
            // 
            this.tbFIO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFIO.Location = new System.Drawing.Point(77, 27);
            this.tbFIO.Name = "tbFIO";
            this.tbFIO.Size = new System.Drawing.Size(279, 20);
            this.tbFIO.TabIndex = 55;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(143, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 54;
            this.label6.Text = "Страна";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(74, 312);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(160, 13);
            this.label10.TabIndex = 53;
            this.label10.Text = "Введите названия для поиска";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 52;
            this.label9.Text = "Ф.И.О.";
            // 
            // btnNewActor
            // 
            this.btnNewActor.Image = global::FilmCollection.Properties.Resources.add;
            this.btnNewActor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewActor.Location = new System.Drawing.Point(77, 485);
            this.btnNewActor.Name = "btnNewActor";
            this.btnNewActor.Size = new System.Drawing.Size(81, 23);
            this.btnNewActor.TabIndex = 51;
            this.btnNewActor.Text = "Добавить";
            this.btnNewActor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewActor.UseVisualStyleBackColor = true;
            this.btnNewActor.Click += new System.EventHandler(this.btnNewActor_Click);
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(465, 27);
            this.label8.TabIndex = 1;
            this.label8.Text = "Панель редактирования";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabWriter
            // 
            this.tabWriter.BackColor = System.Drawing.SystemColors.Control;
            this.tabWriter.Controls.Add(this.panel2);
            this.tabWriter.Controls.Add(this.panel4);
            this.tabWriter.Controls.Add(this.panel3);
            this.tabWriter.Location = new System.Drawing.Point(4, 22);
            this.tabWriter.Name = "tabWriter";
            this.tabWriter.Padding = new System.Windows.Forms.Padding(3);
            this.tabWriter.Size = new System.Drawing.Size(914, 551);
            this.tabWriter.TabIndex = 1;
            this.tabWriter.Text = "Редактор";
            // 
            // tabImage
            // 
            this.tabImage.Controls.Add(this.btnDownloadPic);
            this.tabImage.Location = new System.Drawing.Point(4, 22);
            this.tabImage.Name = "tabImage";
            this.tabImage.Size = new System.Drawing.Size(914, 551);
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
            this.scMain.Size = new System.Drawing.Size(1117, 577);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(503, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(6, 545);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.splitter1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(908, 545);
            this.panel3.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.Window;
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(15, 543);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(500, 545);
            this.panel4.TabIndex = 1;
            // 
            // maskDateOfDeath
            // 
            this.maskDateOfDeath.Location = new System.Drawing.Point(204, 82);
            this.maskDateOfDeath.Mask = "00.00.0000";
            this.maskDateOfDeath.Name = "maskDateOfDeath";
            this.maskDateOfDeath.Size = new System.Drawing.Size(131, 20);
            this.maskDateOfDeath.TabIndex = 58;
            this.maskDateOfDeath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskDateOfDeath.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.maskDateOfDeath.Validating += new System.ComponentModel.CancelEventHandler(this.maskedTextBox2_Validating);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(341, 85);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(61, 17);
            this.checkBox1.TabIndex = 61;
            this.checkBox1.Text = "Живой";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // maskDateOfBirth
            // 
            this.maskDateOfBirth.Location = new System.Drawing.Point(96, 82);
            this.maskDateOfBirth.Mask = "00.00.0000";
            this.maskDateOfBirth.Name = "maskDateOfBirth";
            this.maskDateOfBirth.Size = new System.Drawing.Size(77, 20);
            this.maskDateOfBirth.TabIndex = 58;
            this.maskDateOfBirth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskDateOfBirth.Validating += new System.ComponentModel.CancelEventHandler(this.maskedTextBox2_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 53;
            this.label11.Text = "Годы жизни:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(80, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 13);
            this.label12.TabIndex = 53;
            this.label12.Text = "с";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(179, 85);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 13);
            this.label13.TabIndex = 53;
            this.label13.Text = "по";
            // 
            // colActFIO
            // 
            this.colActFIO.DataPropertyName = "FIO";
            this.colActFIO.HeaderText = "Ф.И.О.";
            this.colActFIO.Name = "colActFIO";
            this.colActFIO.ReadOnly = true;
            // 
            // colDateOfBirth
            // 
            this.colDateOfBirth.DataPropertyName = "DateOfBirth";
            this.colDateOfBirth.HeaderText = "Дата рождения";
            this.colDateOfBirth.Name = "colDateOfBirth";
            this.colDateOfBirth.ReadOnly = true;
            // 
            // colDateOfDeath
            // 
            this.colDateOfDeath.DataPropertyName = "DateOfDeath";
            this.colDateOfDeath.HeaderText = "Дата смерти";
            this.colDateOfDeath.Name = "colDateOfDeath";
            this.colDateOfDeath.ReadOnly = true;
            // 
            // colCountry
            // 
            this.colCountry.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colCountry.DataPropertyName = "CountryString";
            this.colCountry.HeaderText = "Страна";
            this.colCountry.Name = "colCountry";
            this.colCountry.ReadOnly = true;
            this.colCountry.Width = 68;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 648);
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
            this.tabActors.ResumeLayout(false);
            this.scTabActors.Panel1.ResumeLayout(false);
            this.scTabActors.Panel1.PerformLayout();
            this.scTabActors.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scTabActors)).EndInit();
            this.scTabActors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableActors)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelActEditTitle.ResumeLayout(false);
            this.panelActEditTitle.PerformLayout();
            this.tabWriter.ResumeLayout(false);
            this.tabImage.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.toolMainMenu.ResumeLayout(false);
            this.toolMainMenu.PerformLayout();
            this.panel3.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnRemoveGroup;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Label lblActorsSelect;
        private System.Windows.Forms.ListBox chkActorSelect;
        private System.Windows.Forms.Label lblActorsAll;
        private System.Windows.Forms.CheckedListBox chkActorList;
        private System.Windows.Forms.Panel panelActEditTitle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox cBoxCountryActor;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button btnSaveActor;
        private System.Windows.Forms.Button btnCancelActor;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox tbFIO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnNewActor;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.MaskedTextBox maskDateOfDeath;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.MaskedTextBox maskDateOfBirth;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActFIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateOfDeath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCountry;
    }
}

