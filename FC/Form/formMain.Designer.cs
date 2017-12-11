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
            this.TableRec = new System.Windows.Forms.DataGridView();
            this.cmnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCountryString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnGenreString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCategoryString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cFind = new System.Windows.Forms.ToolStripMenuItem();
            this.cSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.cAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cChange = new System.Windows.Forms.ToolStripMenuItem();
            this.cDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.cClearMetaData = new System.Windows.Forms.ToolStripMenuItem();
            this.cSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.cOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.cSep4 = new System.Windows.Forms.ToolStripSeparator();
            this.UpdateFIlmInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.cSep5 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowChart = new System.Windows.Forms.ToolStripMenuItem();
            this.statusLine = new System.Windows.Forms.StatusStrip();
            this.tssLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.FindStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssDayTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssWorkTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreateBase = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpdateBase = new System.Windows.Forms.ToolStripMenuItem();
            this.ts1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBackupBase = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRecoveryBase = new System.Windows.Forms.ToolStripMenuItem();
            this.ts2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReport = new System.Windows.Forms.ToolStripMenuItem();
            this.ts3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuChange = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChange = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ts4 = new System.Windows.Forms.ToolStripSeparator();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.btnActors = new System.Windows.Forms.ToolStripMenuItem();
            this.ts5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCleanDB = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenCatalogDB = new System.Windows.Forms.ToolStripMenuItem();
            this.ts6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOpenReportForm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReindexerForm = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.ts7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCheckUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.ts8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.treeFolder = new System.Windows.Forms.TreeView();
            this.imageLst = new System.Windows.Forms.ImageList(this.components);
            this.TreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.сCollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.сExpandAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tcSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.cExpandSelectNode = new System.Windows.Forms.ToolStripMenuItem();
            this.tcSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.cShowSelcetNodeAllFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tcSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.cRenameFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tcSep4 = new System.Windows.Forms.ToolStripSeparator();
            this.cOpenCurrentFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tcSep5 = new System.Windows.Forms.ToolStripSeparator();
            this.UpdateCatalogInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tcSep6 = new System.Windows.Forms.ToolStripSeparator();
            this.ChangeCatalogTypeVideo = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeCatalogTypeVideo2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabFilm = new System.Windows.Forms.TabPage();
            this.scTabFilm = new System.Windows.Forms.SplitContainer();
            this.cbIsVisible = new System.Windows.Forms.CheckBox();
            this.menuTableRec = new System.Windows.Forms.MenuStrip();
            this.btnResetFilterRec = new System.Windows.Forms.ToolStripMenuItem();
            this.tscbTypeFilter = new System.Windows.Forms.ToolStripComboBox();
            this.tscbSort = new System.Windows.Forms.ToolStripComboBox();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.gMedia = new System.Windows.Forms.GroupBox();
            this.rtDescription = new System.Windows.Forms.RichTextBox();
            this.checkNewRecord = new System.Windows.Forms.CheckBox();
            this.cbNameMedia = new System.Windows.Forms.ComboBox();
            this.cBoxTypeVideo = new System.Windows.Forms.ComboBox();
            this.cBoxGenre = new System.Windows.Forms.ComboBox();
            this.cBoxCountry = new System.Windows.Forms.ComboBox();
            this.mtbYear = new System.Windows.Forms.MaskedTextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblTypeVideo = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.btnRemoveAllGroup = new System.Windows.Forms.Button();
            this.btnRemoveGroup = new System.Windows.Forms.Button();
            this.lblActorsAll = new System.Windows.Forms.Label();
            this.lblActorsSelect = new System.Windows.Forms.Label();
            this.chkActorSelect = new System.Windows.Forms.ListBox();
            this.chkActorList = new System.Windows.Forms.CheckedListBox();
            this.panelEditTitle = new System.Windows.Forms.Panel();
            this.lblEditTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gRecord = new System.Windows.Forms.GroupBox();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.lblNameR = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.mtbTime = new System.Windows.Forms.MaskedTextBox();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.btnFileNameEdit = new System.Windows.Forms.Button();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.tbNameRecord = new System.Windows.Forms.TextBox();
            this.btnGetTime = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.panelView = new System.Windows.Forms.Panel();
            this.panelFolder = new System.Windows.Forms.Panel();
            this.btnSaveFolder = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panelScheme = new System.Windows.Forms.Panel();
            this.panelFind = new System.Windows.Forms.Panel();
            this.cbFullFind = new System.Windows.Forms.CheckBox();
            this.btnHidePanel = new System.Windows.Forms.Button();
            this.btnFindReset = new System.Windows.Forms.Button();
            this.lCritery = new System.Windows.Forms.Label();
            this.lFindText = new System.Windows.Forms.Label();
            this.panelFindTitle = new System.Windows.Forms.Panel();
            this.lblFindTitle = new System.Windows.Forms.Label();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.btnFindNext = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.cbTypeFind = new System.Windows.Forms.ComboBox();
            this.tabActors = new System.Windows.Forms.TabPage();
            this.scTabActors = new System.Windows.Forms.SplitContainer();
            this.dgvTableActors = new System.Windows.Forms.DataGridView();
            this.colActFIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateOfDeath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuTableAct = new System.Windows.Forms.MenuStrip();
            this.btnResetFilterAct = new System.Windows.Forms.ToolStripMenuItem();
            this.tsActCountryFilter = new System.Windows.Forms.ToolStripComboBox();
            this.tsActSort = new System.Windows.Forms.ToolStripComboBox();
            this.panelEditAct = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listViewFilm = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colYear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label10 = new System.Windows.Forms.Label();
            this.lvSelectRecord = new System.Windows.Forms.ListView();
            this.colSelectName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSelectYear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbFilmFind = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.gActAbout = new System.Windows.Forms.GroupBox();
            this.chLifeState = new System.Windows.Forms.CheckBox();
            this.cBoxCountryActor = new System.Windows.Forms.ComboBox();
            this.tbBIO = new System.Windows.Forms.TextBox();
            this.tbFIO = new System.Windows.Forms.TextBox();
            this.maskDateOfBirth = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.maskDateOfDeath = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSaveActor = new System.Windows.Forms.Button();
            this.btnCancelActor = new System.Windows.Forms.Button();
            this.btnNewActor = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panelViewAct = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewFilmV = new System.Windows.Forms.ListView();
            this.column1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbFIOv = new System.Windows.Forms.TextBox();
            this.tbCountryAv = new System.Windows.Forms.TextBox();
            this.linkBIOv = new System.Windows.Forms.LinkLabel();
            this.maskDateOfBirthV = new System.Windows.Forms.MaskedTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.maskDateOfDeathV = new System.Windows.Forms.MaskedTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.tabImage = new System.Windows.Forms.TabPage();
            this.panelMain = new System.Windows.Forms.Panel();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.trackBarSize = new System.Windows.Forms.TrackBar();
            this.tabDiagram = new System.Windows.Forms.TabPage();
            this.timerLoad = new System.Windows.Forms.Timer(this.components);
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.mainMenuIcon = new System.Windows.Forms.ToolStrip();
            this.tsCreateDB = new System.Windows.Forms.ToolStripButton();
            this.tsUpdateDB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBackupDB = new System.Windows.Forms.ToolStripButton();
            this.tsRecoveryDB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsAdd = new System.Windows.Forms.ToolStripButton();
            this.tsChange = new System.Windows.Forms.ToolStripButton();
            this.tsRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsFind = new System.Windows.Forms.ToolStripButton();
            this.tsFindbyName = new System.Windows.Forms.ToolStripTextBox();
            this.tsHidePanel = new System.Windows.Forms.ToolStripButton();
            this.toolinfo = new System.Windows.Forms.ToolTip(this.components);
            this.Tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.About = new System.Windows.Forms.ToolStripMenuItem();
            this.separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.timerForDateTime = new System.Windows.Forms.Timer(this.components);
            this.ucView = new FilmCollection.ucMediaInfo();
            this.ucScheme = new FilmCollection.ucChart();
            this.ucDiagr = new FilmCollection.ucChart();
            ((System.ComponentModel.ISupportInitialize)(this.TableRec)).BeginInit();
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
            this.menuTableRec.SuspendLayout();
            this.panelEdit.SuspendLayout();
            this.gMedia.SuspendLayout();
            this.panelEditTitle.SuspendLayout();
            this.gRecord.SuspendLayout();
            this.panelView.SuspendLayout();
            this.panelFolder.SuspendLayout();
            this.panelScheme.SuspendLayout();
            this.panelFind.SuspendLayout();
            this.panelFindTitle.SuspendLayout();
            this.tabActors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scTabActors)).BeginInit();
            this.scTabActors.Panel1.SuspendLayout();
            this.scTabActors.Panel2.SuspendLayout();
            this.scTabActors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableActors)).BeginInit();
            this.menuTableAct.SuspendLayout();
            this.panelEditAct.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gActAbout.SuspendLayout();
            this.panelViewAct.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabImage.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize)).BeginInit();
            this.tabDiagram.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.mainMenuIcon.SuspendLayout();
            this.TrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableRec
            // 
            this.TableRec.AllowDrop = true;
            this.TableRec.AllowUserToAddRows = false;
            this.TableRec.AllowUserToDeleteRows = false;
            this.TableRec.AllowUserToResizeRows = false;
            this.TableRec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TableRec.BackgroundColor = System.Drawing.SystemColors.Window;
            this.TableRec.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TableRec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableRec.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnName,
            this.cmnYear,
            this.cmnCountryString,
            this.cmnGenreString,
            this.cmnCategoryString,
            this.cmnTime,
            this.cmnFileName});
            this.TableRec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableRec.Location = new System.Drawing.Point(0, 27);
            this.TableRec.MultiSelect = false;
            this.TableRec.Name = "TableRec";
            this.TableRec.ReadOnly = true;
            this.TableRec.RowHeadersVisible = false;
            this.TableRec.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TableRec.Size = new System.Drawing.Size(590, 579);
            this.TableRec.TabIndex = 12;
            this.TableRec.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableRec_CellContentDoubleClick);
            this.TableRec.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Table_CellMouseDown);
            this.TableRec.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.TableRec_ColumnHeaderMouseClick);
            this.TableRec.SelectionChanged += new System.EventHandler(this.TableRec_SelectionChanged);
            this.TableRec.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TableRec_KeyDown);
            this.TableRec.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TableRec_MouseClick);
            // 
            // cmnName
            // 
            this.cmnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnName.DataPropertyName = "mName";
            this.cmnName.HeaderText = "Название";
            this.cmnName.Name = "cmnName";
            this.cmnName.ReadOnly = true;
            // 
            // cmnYear
            // 
            this.cmnYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cmnYear.DataPropertyName = "mYear";
            this.cmnYear.HeaderText = "Год";
            this.cmnYear.Name = "cmnYear";
            this.cmnYear.ReadOnly = true;
            this.cmnYear.Width = 60;
            // 
            // cmnCountryString
            // 
            this.cmnCountryString.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmnCountryString.DataPropertyName = "mCountry";
            this.cmnCountryString.HeaderText = "Страна";
            this.cmnCountryString.Name = "cmnCountryString";
            this.cmnCountryString.ReadOnly = true;
            this.cmnCountryString.Width = 68;
            // 
            // cmnGenreString
            // 
            this.cmnGenreString.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmnGenreString.DataPropertyName = "mGenre";
            this.cmnGenreString.HeaderText = "Жанр";
            this.cmnGenreString.Name = "cmnGenreString";
            this.cmnGenreString.ReadOnly = true;
            this.cmnGenreString.Width = 61;
            // 
            // cmnCategoryString
            // 
            this.cmnCategoryString.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmnCategoryString.DataPropertyName = "mCategory";
            this.cmnCategoryString.HeaderText = "Категория";
            this.cmnCategoryString.Name = "cmnCategoryString";
            this.cmnCategoryString.ReadOnly = true;
            this.cmnCategoryString.Width = 85;
            // 
            // cmnTime
            // 
            this.cmnTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cmnTime.DataPropertyName = "TimeString";
            this.cmnTime.HeaderText = "Время";
            this.cmnTime.Name = "cmnTime";
            this.cmnTime.ReadOnly = true;
            this.cmnTime.Width = 50;
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
            this.cSep1,
            this.cAdd,
            this.cChange,
            this.cDelete,
            this.cSep2,
            this.cClearMetaData,
            this.cSep3,
            this.cOpenFolder,
            this.cSep4,
            this.UpdateFIlmInfo,
            this.cSep5,
            this.ShowChart});
            this.TabMenu.Name = "contextMenuStrip1";
            this.TabMenu.Size = new System.Drawing.Size(208, 210);
            this.TabMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // cFind
            // 
            this.cFind.Image = global::FilmCollection.Properties.Resources.find;
            this.cFind.Name = "cFind";
            this.cFind.Size = new System.Drawing.Size(207, 22);
            this.cFind.Text = "Найти";
            this.cFind.Click += new System.EventHandler(this.cFind_Click);
            // 
            // cSep1
            // 
            this.cSep1.Name = "cSep1";
            this.cSep1.Size = new System.Drawing.Size(204, 6);
            // 
            // cAdd
            // 
            this.cAdd.Image = global::FilmCollection.Properties.Resources.add;
            this.cAdd.Name = "cAdd";
            this.cAdd.Size = new System.Drawing.Size(207, 22);
            this.cAdd.Text = "Добавить";
            this.cAdd.Click += new System.EventHandler(this.AddRec_Click);
            // 
            // cChange
            // 
            this.cChange.Image = global::FilmCollection.Properties.Resources.change;
            this.cChange.Name = "cChange";
            this.cChange.Size = new System.Drawing.Size(207, 22);
            this.cChange.Text = "Изменить";
            this.cChange.Click += new System.EventHandler(this.EditRec_Click);
            // 
            // cDelete
            // 
            this.cDelete.Image = global::FilmCollection.Properties.Resources.del;
            this.cDelete.Name = "cDelete";
            this.cDelete.Size = new System.Drawing.Size(207, 22);
            this.cDelete.Text = "Удалить";
            this.cDelete.Click += new System.EventHandler(this.DeleteRec_Click);
            // 
            // cSep2
            // 
            this.cSep2.Name = "cSep2";
            this.cSep2.Size = new System.Drawing.Size(204, 6);
            // 
            // cClearMetaData
            // 
            this.cClearMetaData.Image = global::FilmCollection.Properties.Resources.MetaClear;
            this.cClearMetaData.Name = "cClearMetaData";
            this.cClearMetaData.Size = new System.Drawing.Size(207, 22);
            this.cClearMetaData.Text = "Очистка информации";
            this.cClearMetaData.Click += new System.EventHandler(this.cClearMetaData_Click);
            // 
            // cSep3
            // 
            this.cSep3.Name = "cSep3";
            this.cSep3.Size = new System.Drawing.Size(204, 6);
            // 
            // cOpenFolder
            // 
            this.cOpenFolder.Image = global::FilmCollection.Properties.Resources.Folder;
            this.cOpenFolder.Name = "cOpenFolder";
            this.cOpenFolder.Size = new System.Drawing.Size(207, 22);
            this.cOpenFolder.Text = "Открыть папку";
            this.cOpenFolder.Click += new System.EventHandler(this.cOpenFolder_Click);
            // 
            // cSep4
            // 
            this.cSep4.Name = "cSep4";
            this.cSep4.Size = new System.Drawing.Size(204, 6);
            // 
            // UpdateFIlmInfo
            // 
            this.UpdateFIlmInfo.Image = global::FilmCollection.Properties.Resources.grabber;
            this.UpdateFIlmInfo.Name = "UpdateFIlmInfo";
            this.UpdateFIlmInfo.Size = new System.Drawing.Size(207, 22);
            this.UpdateFIlmInfo.Text = "Обновить информацию";
            this.UpdateFIlmInfo.Click += new System.EventHandler(this.UpdateInfo_Click);
            // 
            // cSep5
            // 
            this.cSep5.Name = "cSep5";
            this.cSep5.Size = new System.Drawing.Size(204, 6);
            // 
            // ShowChart
            // 
            this.ShowChart.Name = "ShowChart";
            this.ShowChart.Size = new System.Drawing.Size(207, 22);
            this.ShowChart.Text = "Показать связи";
            this.ShowChart.Click += new System.EventHandler(this.ShowChart_Click);
            // 
            // statusLine
            // 
            this.statusLine.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabel,
            this.tsProgressBar,
            this.FindStatusLabel,
            this.tssDayTime,
            this.tssWorkTime});
            this.statusLine.Location = new System.Drawing.Point(0, 689);
            this.statusLine.Name = "statusLine";
            this.statusLine.Size = new System.Drawing.Size(1175, 22);
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
            this.tsProgressBar.BackColor = System.Drawing.SystemColors.Control;
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
            this.FindStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssDayTime
            // 
            this.tssDayTime.AutoSize = false;
            this.tssDayTime.Name = "tssDayTime";
            this.tssDayTime.Size = new System.Drawing.Size(120, 17);
            this.tssDayTime.Text = "dayTime";
            // 
            // tssWorkTime
            // 
            this.tssWorkTime.AutoSize = false;
            this.tssWorkTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tssWorkTime.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tssWorkTime.Name = "tssWorkTime";
            this.tssWorkTime.Size = new System.Drawing.Size(150, 17);
            this.tssWorkTime.Text = "WorkTime";
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuChange,
            this.настройкаToolStripMenuItem,
            this.MenuHelp});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1175, 24);
            this.mainMenu.TabIndex = 10;
            this.mainMenu.Text = "menuStrip1";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCreateBase,
            this.btnUpdateBase,
            this.ts1,
            this.btnBackupBase,
            this.btnRecoveryBase,
            this.ts2,
            this.btnExportHTML,
            this.btnReport,
            this.ts3,
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
            // ts1
            // 
            this.ts1.Name = "ts1";
            this.ts1.Size = new System.Drawing.Size(184, 6);
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
            this.btnRecoveryBase.Click += new System.EventHandler(this.RecoveryBase_Click);
            // 
            // ts2
            // 
            this.ts2.Name = "ts2";
            this.ts2.Size = new System.Drawing.Size(184, 6);
            this.ts2.Visible = false;
            // 
            // btnExportHTML
            // 
            this.btnExportHTML.Name = "btnExportHTML";
            this.btnExportHTML.Size = new System.Drawing.Size(187, 22);
            this.btnExportHTML.Text = "Экспорт в HTML";
            this.btnExportHTML.Click += new System.EventHandler(this.btnExportHTML_Click);
            // 
            // btnReport
            // 
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(187, 22);
            this.btnReport.Text = "Экспорт в CSV(Excel)";
            this.btnReport.Click += new System.EventHandler(this.btnReportCSV_Click);
            // 
            // ts3
            // 
            this.ts3.Name = "ts3";
            this.ts3.Size = new System.Drawing.Size(184, 6);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::FilmCollection.Properties.Resources.ExitV2;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(187, 22);
            this.btnExit.Text = "Выход";
            this.btnExit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // MenuChange
            // 
            this.MenuChange.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnChange,
            this.btnDelete,
            this.ts4,
            this.поискToolStripMenuItem});
            this.MenuChange.Name = "MenuChange";
            this.MenuChange.Size = new System.Drawing.Size(59, 20);
            this.MenuChange.Text = "Правка";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::FilmCollection.Properties.Resources.add;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.btnAdd.Size = new System.Drawing.Size(149, 22);
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Click += new System.EventHandler(this.tsAdd_Click);
            // 
            // btnChange
            // 
            this.btnChange.Image = global::FilmCollection.Properties.Resources.change;
            this.btnChange.Name = "btnChange";
            this.btnChange.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.btnChange.Size = new System.Drawing.Size(149, 22);
            this.btnChange.Text = "Изменить";
            this.btnChange.Click += new System.EventHandler(this.tsChange_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::FilmCollection.Properties.Resources.del;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.btnDelete.Size = new System.Drawing.Size(149, 22);
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Click += new System.EventHandler(this.tsRemove_Click);
            // 
            // ts4
            // 
            this.ts4.Name = "ts4";
            this.ts4.Size = new System.Drawing.Size(146, 6);
            // 
            // поискToolStripMenuItem
            // 
            this.поискToolStripMenuItem.Image = global::FilmCollection.Properties.Resources.find;
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.поискToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.поискToolStripMenuItem.Text = "Поиск";
            this.поискToolStripMenuItem.Click += new System.EventHandler(this.tsFind_Click);
            // 
            // настройкаToolStripMenuItem
            // 
            this.настройкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOptions,
            this.btnActors,
            this.ts5,
            this.btnCleanDB,
            this.btnOpenCatalogDB,
            this.ts6,
            this.btnOpenReportForm,
            this.toolStripSeparator1,
            this.btnReindexerForm});
            this.настройкаToolStripMenuItem.Name = "настройкаToolStripMenuItem";
            this.настройкаToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.настройкаToolStripMenuItem.Text = "Настройка";
            // 
            // btnOptions
            // 
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(196, 22);
            this.btnOptions.Text = "Параметры";
            this.btnOptions.Visible = false;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnActors
            // 
            this.btnActors.Name = "btnActors";
            this.btnActors.Size = new System.Drawing.Size(196, 22);
            this.btnActors.Text = "Актеры";
            this.btnActors.Visible = false;
            // 
            // ts5
            // 
            this.ts5.Name = "ts5";
            this.ts5.Size = new System.Drawing.Size(193, 6);
            // 
            // btnCleanDB
            // 
            this.btnCleanDB.Image = global::FilmCollection.Properties.Resources.dbClear;
            this.btnCleanDB.Name = "btnCleanDB";
            this.btnCleanDB.Size = new System.Drawing.Size(196, 22);
            this.btnCleanDB.Text = "Очистка базы";
            this.btnCleanDB.Click += new System.EventHandler(this.CleanBase_Click);
            // 
            // btnOpenCatalogDB
            // 
            this.btnOpenCatalogDB.Image = global::FilmCollection.Properties.Resources.Folder;
            this.btnOpenCatalogDB.Name = "btnOpenCatalogDB";
            this.btnOpenCatalogDB.Size = new System.Drawing.Size(196, 22);
            this.btnOpenCatalogDB.Text = "Открыть каталог базы";
            this.btnOpenCatalogDB.Click += new System.EventHandler(this.btnOpenCatalogDB_Click);
            // 
            // ts6
            // 
            this.ts6.Name = "ts6";
            this.ts6.Size = new System.Drawing.Size(193, 6);
            // 
            // btnOpenReportForm
            // 
            this.btnOpenReportForm.Image = global::FilmCollection.Properties.Resources.Report;
            this.btnOpenReportForm.Name = "btnOpenReportForm";
            this.btnOpenReportForm.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.btnOpenReportForm.Size = new System.Drawing.Size(196, 22);
            this.btnOpenReportForm.Text = "Отчет";
            this.btnOpenReportForm.Click += new System.EventHandler(this.btnOpenReportForm_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // btnReindexerForm
            // 
            this.btnReindexerForm.Name = "btnReindexerForm";
            this.btnReindexerForm.Size = new System.Drawing.Size(196, 22);
            this.btnReindexerForm.Text = "Проверка индексов";
            this.btnReindexerForm.Click += new System.EventHandler(this.btnReindexerForm_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHelp,
            this.btnHistory,
            this.ts7,
            this.btnCheckUpdate,
            this.ts8,
            this.btnAbout});
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Size = new System.Drawing.Size(65, 20);
            this.MenuHelp.Text = "Справка";
            // 
            // btnHelp
            // 
            this.btnHelp.Image = global::FilmCollection.Properties.Resources.help_run;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.btnHelp.Size = new System.Drawing.Size(204, 22);
            this.btnHelp.Text = "Справка";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(204, 22);
            this.btnHistory.Text = "История изменений";
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // ts7
            // 
            this.ts7.Name = "ts7";
            this.ts7.Size = new System.Drawing.Size(201, 6);
            // 
            // btnCheckUpdate
            // 
            this.btnCheckUpdate.Name = "btnCheckUpdate";
            this.btnCheckUpdate.Size = new System.Drawing.Size(204, 22);
            this.btnCheckUpdate.Text = "Проверить обновления";
            this.btnCheckUpdate.Click += new System.EventHandler(this.btnCheckUpdate_Click);
            // 
            // ts8
            // 
            this.ts8.Name = "ts8";
            this.ts8.Size = new System.Drawing.Size(201, 6);
            // 
            // btnAbout
            // 
            this.btnAbout.Image = global::FilmCollection.Properties.Resources.help;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(204, 22);
            this.btnAbout.Text = "О программе";
            this.btnAbout.Click += new System.EventHandler(this.About_Click);
            // 
            // treeFolder
            // 
            this.treeFolder.AllowDrop = true;
            this.treeFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFolder.ImageIndex = 1;
            this.treeFolder.ImageList = this.imageLst;
            this.treeFolder.Location = new System.Drawing.Point(0, 0);
            this.treeFolder.Name = "treeFolder";
            this.treeFolder.SelectedImageIndex = 0;
            this.treeFolder.Size = new System.Drawing.Size(191, 640);
            this.treeFolder.TabIndex = 22;
            this.treeFolder.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeFolder_ItemDrag);
            this.treeFolder.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeFolder_NodeMouseClick);
            this.treeFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeFolder_DragDrop);
            this.treeFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeFolder_DragEnter);
            // 
            // imageLst
            // 
            this.imageLst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageLst.ImageStream")));
            this.imageLst.TransparentColor = System.Drawing.Color.Transparent;
            this.imageLst.Images.SetKeyName(0, "stock_folder-move.png");
            this.imageLst.Images.SetKeyName(1, "folder.png");
            this.imageLst.Images.SetKeyName(2, "Folder Music.png");
            this.imageLst.Images.SetKeyName(3, "blue-folder-horizontal.png");
            this.imageLst.Images.SetKeyName(4, "stock_folder-move_2.png");
            this.imageLst.Images.SetKeyName(5, "folder2.png");
            this.imageLst.Images.SetKeyName(6, "folder_page.png");
            this.imageLst.Images.SetKeyName(7, "Folder.gif");
            this.imageLst.Images.SetKeyName(8, "tree_folder_closed.png");
            this.imageLst.Images.SetKeyName(9, "tree_folder_open.gif");
            // 
            // TreeMenu
            // 
            this.TreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сCollapseAll,
            this.сExpandAll,
            this.tcSep1,
            this.cExpandSelectNode,
            this.tcSep2,
            this.cShowSelcetNodeAllFiles,
            this.tcSep3,
            this.cRenameFolder,
            this.tcSep4,
            this.cOpenCurrentFolder,
            this.tcSep5,
            this.UpdateCatalogInfo,
            this.tcSep6,
            this.ChangeCatalogTypeVideo,
            this.ChangeCatalogTypeVideo2});
            this.TreeMenu.Name = "contextTreeMenu";
            this.TreeMenu.Size = new System.Drawing.Size(370, 238);
            // 
            // сCollapseAll
            // 
            this.сCollapseAll.Image = global::FilmCollection.Properties.Resources.collapse;
            this.сCollapseAll.Name = "сCollapseAll";
            this.сCollapseAll.Size = new System.Drawing.Size(369, 22);
            this.сCollapseAll.Text = "Свернуть все";
            this.сCollapseAll.Click += new System.EventHandler(this.сCollapseAll_Click);
            // 
            // сExpandAll
            // 
            this.сExpandAll.Image = global::FilmCollection.Properties.Resources.expand;
            this.сExpandAll.Name = "сExpandAll";
            this.сExpandAll.Size = new System.Drawing.Size(369, 22);
            this.сExpandAll.Text = "Развернуть все";
            this.сExpandAll.Click += new System.EventHandler(this.сExpandAll_Click);
            // 
            // tcSep1
            // 
            this.tcSep1.Name = "tcSep1";
            this.tcSep1.Size = new System.Drawing.Size(366, 6);
            // 
            // cExpandSelectNode
            // 
            this.cExpandSelectNode.Image = global::FilmCollection.Properties.Resources.expandNode;
            this.cExpandSelectNode.Name = "cExpandSelectNode";
            this.cExpandSelectNode.Size = new System.Drawing.Size(369, 22);
            this.cExpandSelectNode.Text = "Развернуть ветку";
            this.cExpandSelectNode.Click += new System.EventHandler(this.cExpandSelectNode_Click);
            // 
            // tcSep2
            // 
            this.tcSep2.Name = "tcSep2";
            this.tcSep2.Size = new System.Drawing.Size(366, 6);
            // 
            // cShowSelcetNodeAllFiles
            // 
            this.cShowSelcetNodeAllFiles.Image = global::FilmCollection.Properties.Resources.viewfiles;
            this.cShowSelcetNodeAllFiles.Name = "cShowSelcetNodeAllFiles";
            this.cShowSelcetNodeAllFiles.Size = new System.Drawing.Size(369, 22);
            this.cShowSelcetNodeAllFiles.Text = "Отобразить все вложенные файлы";
            this.cShowSelcetNodeAllFiles.Click += new System.EventHandler(this.cShowSelcetNodeAllFiles_Click);
            // 
            // tcSep3
            // 
            this.tcSep3.Name = "tcSep3";
            this.tcSep3.Size = new System.Drawing.Size(366, 6);
            // 
            // cRenameFolder
            // 
            this.cRenameFolder.Image = global::FilmCollection.Properties.Resources.FolderEdit;
            this.cRenameFolder.Name = "cRenameFolder";
            this.cRenameFolder.Size = new System.Drawing.Size(369, 22);
            this.cRenameFolder.Text = "Переименовать папку";
            this.cRenameFolder.Click += new System.EventHandler(this.cRenameFolder_Click);
            // 
            // tcSep4
            // 
            this.tcSep4.Name = "tcSep4";
            this.tcSep4.Size = new System.Drawing.Size(366, 6);
            // 
            // cOpenCurrentFolder
            // 
            this.cOpenCurrentFolder.Image = global::FilmCollection.Properties.Resources.Folder;
            this.cOpenCurrentFolder.Name = "cOpenCurrentFolder";
            this.cOpenCurrentFolder.Size = new System.Drawing.Size(369, 22);
            this.cOpenCurrentFolder.Text = "Открыть папку";
            this.cOpenCurrentFolder.Click += new System.EventHandler(this.cOpenCurrentFolder_Click);
            // 
            // tcSep5
            // 
            this.tcSep5.Name = "tcSep5";
            this.tcSep5.Size = new System.Drawing.Size(366, 6);
            // 
            // UpdateCatalogInfo
            // 
            this.UpdateCatalogInfo.Image = global::FilmCollection.Properties.Resources.grabber;
            this.UpdateCatalogInfo.Name = "UpdateCatalogInfo";
            this.UpdateCatalogInfo.Size = new System.Drawing.Size(369, 22);
            this.UpdateCatalogInfo.Text = "Обновить информацию в каталоге";
            this.UpdateCatalogInfo.Click += new System.EventHandler(this.UpdateCatalogInfo_Click);
            // 
            // tcSep6
            // 
            this.tcSep6.Name = "tcSep6";
            this.tcSep6.Size = new System.Drawing.Size(366, 6);
            // 
            // ChangeCatalogTypeVideo
            // 
            this.ChangeCatalogTypeVideo.Image = global::FilmCollection.Properties.Resources.fileSelect;
            this.ChangeCatalogTypeVideo.Name = "ChangeCatalogTypeVideo";
            this.ChangeCatalogTypeVideo.Size = new System.Drawing.Size(369, 22);
            this.ChangeCatalogTypeVideo.Text = "Сделать каталог сериалом на основе выбранного";
            this.ChangeCatalogTypeVideo.Click += new System.EventHandler(this.ChangeCatalogTypeVideo_Click);
            // 
            // ChangeCatalogTypeVideo2
            // 
            this.ChangeCatalogTypeVideo2.Image = global::FilmCollection.Properties.Resources.folderSelect;
            this.ChangeCatalogTypeVideo2.Name = "ChangeCatalogTypeVideo2";
            this.ChangeCatalogTypeVideo2.Size = new System.Drawing.Size(369, 22);
            this.ChangeCatalogTypeVideo2.Text = "Сделать каталог сериалом на основе имени каталога";
            this.ChangeCatalogTypeVideo2.Click += new System.EventHandler(this.ChangeCatalogTypeVideo2_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabFilm);
            this.tabControl2.Controls.Add(this.tabActors);
            this.tabControl2.Controls.Add(this.tabImage);
            this.tabControl2.Controls.Add(this.tabDiagram);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(980, 640);
            this.tabControl2.TabIndex = 11;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.SelectActor_Info);
            this.tabControl2.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl2_Selecting);
            this.tabControl2.Click += new System.EventHandler(this.tabControl_ChangeTab_Click);
            // 
            // tabFilm
            // 
            this.tabFilm.Controls.Add(this.scTabFilm);
            this.tabFilm.Location = new System.Drawing.Point(4, 22);
            this.tabFilm.Name = "tabFilm";
            this.tabFilm.Padding = new System.Windows.Forms.Padding(3);
            this.tabFilm.Size = new System.Drawing.Size(972, 614);
            this.tabFilm.TabIndex = 0;
            this.tabFilm.Text = "Фильмотека";
            this.tabFilm.UseVisualStyleBackColor = true;
            // 
            // scTabFilm
            // 
            this.scTabFilm.BackColor = System.Drawing.SystemColors.Control;
            this.scTabFilm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scTabFilm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scTabFilm.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scTabFilm.IsSplitterFixed = true;
            this.scTabFilm.Location = new System.Drawing.Point(3, 3);
            this.scTabFilm.Name = "scTabFilm";
            // 
            // scTabFilm.Panel1
            // 
            this.scTabFilm.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.scTabFilm.Panel1.Controls.Add(this.cbIsVisible);
            this.scTabFilm.Panel1.Controls.Add(this.TableRec);
            this.scTabFilm.Panel1.Controls.Add(this.menuTableRec);
            this.scTabFilm.Panel1MinSize = 400;
            // 
            // scTabFilm.Panel2
            // 
            this.scTabFilm.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.scTabFilm.Panel2.Controls.Add(this.panelEdit);
            this.scTabFilm.Panel2.Controls.Add(this.panelView);
            this.scTabFilm.Panel2.Controls.Add(this.panelFolder);
            this.scTabFilm.Panel2.Controls.Add(this.panelScheme);
            this.scTabFilm.Panel2.Controls.Add(this.panelFind);
            this.scTabFilm.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.scTabFilm.Panel2MinSize = 200;
            this.scTabFilm.Size = new System.Drawing.Size(966, 608);
            this.scTabFilm.SplitterDistance = 592;
            this.scTabFilm.TabIndex = 17;
            // 
            // cbIsVisible
            // 
            this.cbIsVisible.AutoSize = true;
            this.cbIsVisible.Location = new System.Drawing.Point(129, 6);
            this.cbIsVisible.Name = "cbIsVisible";
            this.cbIsVisible.Size = new System.Drawing.Size(171, 17);
            this.cbIsVisible.TabIndex = 24;
            this.cbIsVisible.Text = "Показать только удаленные";
            this.cbIsVisible.UseVisualStyleBackColor = true;
            this.cbIsVisible.CheckStateChanged += new System.EventHandler(this.Filter);
            // 
            // menuTableRec
            // 
            this.menuTableRec.BackColor = System.Drawing.SystemColors.Control;
            this.menuTableRec.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnResetFilterRec,
            this.tscbTypeFilter,
            this.tscbSort});
            this.menuTableRec.Location = new System.Drawing.Point(0, 0);
            this.menuTableRec.Name = "menuTableRec";
            this.menuTableRec.Size = new System.Drawing.Size(590, 27);
            this.menuTableRec.TabIndex = 23;
            this.menuTableRec.Text = "menuStrip1";
            // 
            // btnResetFilterRec
            // 
            this.btnResetFilterRec.Image = global::FilmCollection.Properties.Resources.resetFiltr;
            this.btnResetFilterRec.Name = "btnResetFilterRec";
            this.btnResetFilterRec.Size = new System.Drawing.Size(120, 23);
            this.btnResetFilterRec.Text = "Сброс фильтра";
            this.btnResetFilterRec.Click += new System.EventHandler(this.ResetFilter_Click);
            // 
            // tscbTypeFilter
            // 
            this.tscbTypeFilter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tscbTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbTypeFilter.Items.AddRange(new object[] {
            "Все",
            "Фильмы",
            "Сериалы",
            "Мульты"});
            this.tscbTypeFilter.Name = "tscbTypeFilter";
            this.tscbTypeFilter.Size = new System.Drawing.Size(121, 23);
            this.tscbTypeFilter.SelectedIndexChanged += new System.EventHandler(this.Filter);
            // 
            // tscbSort
            // 
            this.tscbSort.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tscbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbSort.Items.AddRange(new object[] {
            "По названию",
            "По году",
            "По стране",
            "По жанру",
            "По категории",
            "По времени",
            "По файлу"});
            this.tscbSort.Name = "tscbSort";
            this.tscbSort.Size = new System.Drawing.Size(121, 23);
            this.tscbSort.SelectedIndexChanged += new System.EventHandler(this.Filter);
            // 
            // panelEdit
            // 
            this.panelEdit.Controls.Add(this.gMedia);
            this.panelEdit.Controls.Add(this.panelEditTitle);
            this.panelEdit.Controls.Add(this.btnSave);
            this.panelEdit.Controls.Add(this.btnCancel);
            this.panelEdit.Controls.Add(this.gRecord);
            this.panelEdit.Controls.Add(this.btnNew);
            this.panelEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEdit.Location = new System.Drawing.Point(0, 0);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(368, 606);
            this.panelEdit.TabIndex = 10;
            // 
            // gMedia
            // 
            this.gMedia.Controls.Add(this.rtDescription);
            this.gMedia.Controls.Add(this.checkNewRecord);
            this.gMedia.Controls.Add(this.cbNameMedia);
            this.gMedia.Controls.Add(this.cBoxTypeVideo);
            this.gMedia.Controls.Add(this.cBoxGenre);
            this.gMedia.Controls.Add(this.cBoxCountry);
            this.gMedia.Controls.Add(this.mtbYear);
            this.gMedia.Controls.Add(this.lblDescription);
            this.gMedia.Controls.Add(this.lblName);
            this.gMedia.Controls.Add(this.lblCountry);
            this.gMedia.Controls.Add(this.lblGenre);
            this.gMedia.Controls.Add(this.lblTypeVideo);
            this.gMedia.Controls.Add(this.lblYear);
            this.gMedia.Controls.Add(this.btnAddGroup);
            this.gMedia.Controls.Add(this.btnRemoveAllGroup);
            this.gMedia.Controls.Add(this.btnRemoveGroup);
            this.gMedia.Controls.Add(this.lblActorsAll);
            this.gMedia.Controls.Add(this.lblActorsSelect);
            this.gMedia.Controls.Add(this.chkActorSelect);
            this.gMedia.Controls.Add(this.chkActorList);
            this.gMedia.Location = new System.Drawing.Point(8, 27);
            this.gMedia.Name = "gMedia";
            this.gMedia.Size = new System.Drawing.Size(353, 363);
            this.gMedia.TabIndex = 60;
            this.gMedia.TabStop = false;
            this.gMedia.Text = "Общая информация";
            // 
            // rtDescription
            // 
            this.rtDescription.Location = new System.Drawing.Point(67, 113);
            this.rtDescription.Name = "rtDescription";
            this.rtDescription.Size = new System.Drawing.Size(275, 102);
            this.rtDescription.TabIndex = 61;
            this.rtDescription.Text = "";
            this.rtDescription.ModifiedChanged += new System.EventHandler(this.UserModifiedChanged);
            // 
            // checkNewRecord
            // 
            this.checkNewRecord.AutoSize = true;
            this.checkNewRecord.Checked = true;
            this.checkNewRecord.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkNewRecord.Location = new System.Drawing.Point(273, 27);
            this.checkNewRecord.Name = "checkNewRecord";
            this.checkNewRecord.Size = new System.Drawing.Size(74, 17);
            this.checkNewRecord.TabIndex = 60;
            this.checkNewRecord.Text = "привязка";
            this.checkNewRecord.UseVisualStyleBackColor = true;
            this.checkNewRecord.CheckedChanged += new System.EventHandler(this.checkNewRecord_CheckedChanged);
            // 
            // cbNameMedia
            // 
            this.cbNameMedia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbNameMedia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbNameMedia.Enabled = false;
            this.cbNameMedia.FormattingEnabled = true;
            this.cbNameMedia.Location = new System.Drawing.Point(67, 24);
            this.cbNameMedia.Name = "cbNameMedia";
            this.cbNameMedia.Size = new System.Drawing.Size(202, 21);
            this.cbNameMedia.TabIndex = 59;
            this.cbNameMedia.SelectedIndexChanged += new System.EventHandler(this.cBoxNameMedia_SelectedIndexChanged);
            this.cbNameMedia.SelectionChangeCommitted += new System.EventHandler(this.UserModifiedChanged);
            this.cbNameMedia.TextUpdate += new System.EventHandler(this.UserModifiedChanged);
            // 
            // cBoxTypeVideo
            // 
            this.cBoxTypeVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxTypeVideo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxTypeVideo.FormattingEnabled = true;
            this.cBoxTypeVideo.Location = new System.Drawing.Point(242, 84);
            this.cBoxTypeVideo.Name = "cBoxTypeVideo";
            this.cBoxTypeVideo.Size = new System.Drawing.Size(100, 21);
            this.cBoxTypeVideo.TabIndex = 42;
            this.cBoxTypeVideo.SelectionChangeCommitted += new System.EventHandler(this.UserModifiedChanged);
            // 
            // cBoxGenre
            // 
            this.cBoxGenre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxGenre.FormattingEnabled = true;
            this.cBoxGenre.Location = new System.Drawing.Point(67, 84);
            this.cBoxGenre.Name = "cBoxGenre";
            this.cBoxGenre.Size = new System.Drawing.Size(121, 21);
            this.cBoxGenre.TabIndex = 31;
            this.cBoxGenre.SelectionChangeCommitted += new System.EventHandler(this.UserModifiedChanged);
            // 
            // cBoxCountry
            // 
            this.cBoxCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCountry.FormattingEnabled = true;
            this.cBoxCountry.Location = new System.Drawing.Point(188, 54);
            this.cBoxCountry.Name = "cBoxCountry";
            this.cBoxCountry.Size = new System.Drawing.Size(154, 21);
            this.cBoxCountry.TabIndex = 50;
            this.cBoxCountry.SelectionChangeCommitted += new System.EventHandler(this.UserModifiedChanged);
            // 
            // mtbYear
            // 
            this.mtbYear.Location = new System.Drawing.Point(67, 54);
            this.mtbYear.Mask = "0000";
            this.mtbYear.Name = "mtbYear";
            this.mtbYear.Size = new System.Drawing.Size(57, 20);
            this.mtbYear.TabIndex = 49;
            this.mtbYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtbYear.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.mtbYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbYear_KeyDown);
            this.mtbYear.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtbYear_KeyUp);
            this.mtbYear.Validating += new System.ComponentModel.CancelEventHandler(this.mtbYear_Validating);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(9, 116);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(57, 13);
            this.lblDescription.TabIndex = 25;
            this.lblDescription.Text = "Описание";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(4, 28);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 13);
            this.lblName.TabIndex = 19;
            this.lblName.Text = " Название";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(143, 57);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(43, 13);
            this.lblCountry.TabIndex = 21;
            this.lblCountry.Text = "Страна";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(27, 88);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(36, 13);
            this.lblGenre.TabIndex = 22;
            this.lblGenre.Text = "Жанр";
            // 
            // lblTypeVideo
            // 
            this.lblTypeVideo.AutoSize = true;
            this.lblTypeVideo.Location = new System.Drawing.Point(212, 87);
            this.lblTypeVideo.Name = "lblTypeVideo";
            this.lblTypeVideo.Size = new System.Drawing.Size(26, 13);
            this.lblTypeVideo.TabIndex = 23;
            this.lblTypeVideo.Text = "Тип";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(35, 57);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(25, 13);
            this.lblYear.TabIndex = 20;
            this.lblYear.Text = "Год";
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.BackColor = System.Drawing.Color.LightGray;
            this.btnAddGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddGroup.Location = new System.Drawing.Point(197, 241);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(24, 24);
            this.btnAddGroup.TabIndex = 52;
            this.btnAddGroup.Text = ">";
            this.btnAddGroup.UseVisualStyleBackColor = false;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAdd_SelectActor_Click);
            // 
            // btnRemoveAllGroup
            // 
            this.btnRemoveAllGroup.BackColor = System.Drawing.Color.LightGray;
            this.btnRemoveAllGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRemoveAllGroup.Location = new System.Drawing.Point(197, 314);
            this.btnRemoveAllGroup.Name = "btnRemoveAllGroup";
            this.btnRemoveAllGroup.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveAllGroup.TabIndex = 53;
            this.btnRemoveAllGroup.Text = "<<";
            this.btnRemoveAllGroup.UseVisualStyleBackColor = false;
            this.btnRemoveAllGroup.Click += new System.EventHandler(this.btnRemoveAllGroup_Click);
            // 
            // btnRemoveGroup
            // 
            this.btnRemoveGroup.BackColor = System.Drawing.Color.LightGray;
            this.btnRemoveGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRemoveGroup.Location = new System.Drawing.Point(197, 284);
            this.btnRemoveGroup.Name = "btnRemoveGroup";
            this.btnRemoveGroup.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveGroup.TabIndex = 53;
            this.btnRemoveGroup.Text = "<";
            this.btnRemoveGroup.UseVisualStyleBackColor = false;
            this.btnRemoveGroup.Click += new System.EventHandler(this.btnRemove_SelectActor_Click);
            // 
            // lblActorsAll
            // 
            this.lblActorsAll.Location = new System.Drawing.Point(70, 218);
            this.lblActorsAll.Name = "lblActorsAll";
            this.lblActorsAll.Size = new System.Drawing.Size(100, 22);
            this.lblActorsAll.TabIndex = 54;
            this.lblActorsAll.Text = "Список актеров:";
            this.lblActorsAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblActorsSelect
            // 
            this.lblActorsSelect.Location = new System.Drawing.Point(224, 218);
            this.lblActorsSelect.Name = "lblActorsSelect";
            this.lblActorsSelect.Size = new System.Drawing.Size(124, 23);
            this.lblActorsSelect.TabIndex = 56;
            this.lblActorsSelect.Text = "Снимались в фильме:";
            this.lblActorsSelect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkActorSelect
            // 
            this.chkActorSelect.Location = new System.Drawing.Point(227, 241);
            this.chkActorSelect.Name = "chkActorSelect";
            this.chkActorSelect.Size = new System.Drawing.Size(115, 108);
            this.chkActorSelect.TabIndex = 55;
            // 
            // chkActorList
            // 
            this.chkActorList.CheckOnClick = true;
            this.chkActorList.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.chkActorList.Location = new System.Drawing.Point(67, 241);
            this.chkActorList.MultiColumn = true;
            this.chkActorList.Name = "chkActorList";
            this.chkActorList.Size = new System.Drawing.Size(124, 109);
            this.chkActorList.TabIndex = 51;
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
            this.btnSave.Location = new System.Drawing.Point(265, 544);
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
            this.btnCancel.Location = new System.Drawing.Point(265, 573);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 23);
            this.btnCancel.TabIndex = 46;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gRecord
            // 
            this.gRecord.Controls.Add(this.lblFilePath);
            this.gRecord.Controls.Add(this.lblNameR);
            this.gRecord.Controls.Add(this.lblTime);
            this.gRecord.Controls.Add(this.lblFileName);
            this.gRecord.Controls.Add(this.mtbTime);
            this.gRecord.Controls.Add(this.tbFileName);
            this.gRecord.Controls.Add(this.btnFileNameEdit);
            this.gRecord.Controls.Add(this.tbFilePath);
            this.gRecord.Controls.Add(this.tbNameRecord);
            this.gRecord.Controls.Add(this.btnGetTime);
            this.gRecord.Location = new System.Drawing.Point(8, 396);
            this.gRecord.Name = "gRecord";
            this.gRecord.Size = new System.Drawing.Size(353, 139);
            this.gRecord.TabIndex = 61;
            this.gRecord.TabStop = false;
            this.gRecord.Text = "Информация о файле";
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(33, 108);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(31, 13);
            this.lblFilePath.TabIndex = 19;
            this.lblFilePath.Text = "Путь";
            // 
            // lblNameR
            // 
            this.lblNameR.AutoSize = true;
            this.lblNameR.Location = new System.Drawing.Point(6, 22);
            this.lblNameR.Name = "lblNameR";
            this.lblNameR.Size = new System.Drawing.Size(60, 13);
            this.lblNameR.TabIndex = 19;
            this.lblNameR.Text = " Название";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(22, 51);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(40, 13);
            this.lblTime.TabIndex = 24;
            this.lblTime.Text = "Время";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(3, 79);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(64, 13);
            this.lblFileName.TabIndex = 26;
            this.lblFileName.Text = "Имя файла";
            // 
            // mtbTime
            // 
            this.mtbTime.Location = new System.Drawing.Point(67, 48);
            this.mtbTime.Mask = "00:00:00";
            this.mtbTime.Name = "mtbTime";
            this.mtbTime.Size = new System.Drawing.Size(75, 20);
            this.mtbTime.TabIndex = 49;
            this.mtbTime.Text = "000000";
            this.mtbTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtbTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbTime_KeyDown);
            this.mtbTime.Validating += new System.ComponentModel.CancelEventHandler(this.mtbTime_Validating);
            // 
            // tbFileName
            // 
            this.tbFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFileName.Enabled = false;
            this.tbFileName.Location = new System.Drawing.Point(67, 76);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(246, 20);
            this.tbFileName.TabIndex = 44;
            this.tbFileName.ModifiedChanged += new System.EventHandler(this.UserModifiedChanged);
            this.tbFileName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbYear_KeyDown);
            // 
            // btnFileNameEdit
            // 
            this.btnFileNameEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileNameEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileNameEdit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnFileNameEdit.Image = global::FilmCollection.Properties.Resources._lock;
            this.btnFileNameEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFileNameEdit.Location = new System.Drawing.Point(319, 73);
            this.btnFileNameEdit.Name = "btnFileNameEdit";
            this.btnFileNameEdit.Size = new System.Drawing.Size(24, 25);
            this.btnFileNameEdit.TabIndex = 43;
            this.btnFileNameEdit.UseVisualStyleBackColor = true;
            this.btnFileNameEdit.Click += new System.EventHandler(this.FileNameEdit_Unlock);
            // 
            // tbFilePath
            // 
            this.tbFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilePath.Location = new System.Drawing.Point(67, 105);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.ReadOnly = true;
            this.tbFilePath.Size = new System.Drawing.Size(279, 20);
            this.tbFilePath.TabIndex = 27;
            this.tbFilePath.ModifiedChanged += new System.EventHandler(this.UserModifiedChanged);
            // 
            // tbNameRecord
            // 
            this.tbNameRecord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNameRecord.Location = new System.Drawing.Point(67, 19);
            this.tbNameRecord.Name = "tbNameRecord";
            this.tbNameRecord.Size = new System.Drawing.Size(279, 20);
            this.tbNameRecord.TabIndex = 27;
            this.tbNameRecord.ModifiedChanged += new System.EventHandler(this.UserModifiedChanged);
            this.tbNameRecord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbYear_KeyDown);
            // 
            // btnGetTime
            // 
            this.btnGetTime.Location = new System.Drawing.Point(151, 47);
            this.btnGetTime.Name = "btnGetTime";
            this.btnGetTime.Size = new System.Drawing.Size(196, 23);
            this.btnGetTime.TabIndex = 59;
            this.btnGetTime.Text = "Получить время из файла";
            this.btnGetTime.UseVisualStyleBackColor = true;
            this.btnGetTime.Click += new System.EventHandler(this.btnGetTime_Click);
            // 
            // btnNew
            // 
            this.btnNew.Image = global::FilmCollection.Properties.Resources.add;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(19, 544);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(81, 23);
            this.btnNew.TabIndex = 18;
            this.btnNew.Text = "Добавить";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // panelView
            // 
            this.panelView.Controls.Add(this.ucView);
            this.panelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelView.Location = new System.Drawing.Point(0, 0);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(368, 606);
            this.panelView.TabIndex = 57;
            // 
            // panelFolder
            // 
            this.panelFolder.Controls.Add(this.btnSaveFolder);
            this.panelFolder.Controls.Add(this.button2);
            this.panelFolder.Controls.Add(this.button3);
            this.panelFolder.Controls.Add(this.label17);
            this.panelFolder.Controls.Add(this.label16);
            this.panelFolder.Controls.Add(this.textBox4);
            this.panelFolder.Controls.Add(this.textBox3);
            this.panelFolder.Controls.Add(this.label7);
            this.panelFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFolder.Location = new System.Drawing.Point(0, 0);
            this.panelFolder.Name = "panelFolder";
            this.panelFolder.Size = new System.Drawing.Size(368, 606);
            this.panelFolder.TabIndex = 59;
            // 
            // btnSaveFolder
            // 
            this.btnSaveFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveFolder.Image = global::FilmCollection.Properties.Resources.save;
            this.btnSaveFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveFolder.Location = new System.Drawing.Point(253, 165);
            this.btnSaveFolder.Name = "btnSaveFolder";
            this.btnSaveFolder.Size = new System.Drawing.Size(86, 23);
            this.btnSaveFolder.TabIndex = 60;
            this.btnSaveFolder.Text = "Сохранить";
            this.btnSaveFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveFolder.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(253, 194);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 23);
            this.button2.TabIndex = 59;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // button3
            // 
            this.button3.Image = global::FilmCollection.Properties.Resources.add;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(28, 165);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(81, 23);
            this.button3.TabIndex = 58;
            this.button3.Text = "Добавить";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(29, 43);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(98, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "Текущий каталог:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(29, 88);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(188, 13);
            this.label16.TabIndex = 4;
            this.label16.Text = "Укажите новое название каталога:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(28, 62);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(311, 20);
            this.textBox4.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(28, 107);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(311, 20);
            this.textBox3.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(368, 27);
            this.label7.TabIndex = 1;
            this.label7.Text = "Панель изменения каталога";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelScheme
            // 
            this.panelScheme.Controls.Add(this.ucScheme);
            this.panelScheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScheme.Location = new System.Drawing.Point(0, 0);
            this.panelScheme.Name = "panelScheme";
            this.panelScheme.Size = new System.Drawing.Size(368, 606);
            this.panelScheme.TabIndex = 1;
            // 
            // panelFind
            // 
            this.panelFind.Controls.Add(this.cbFullFind);
            this.panelFind.Controls.Add(this.btnHidePanel);
            this.panelFind.Controls.Add(this.btnFindReset);
            this.panelFind.Controls.Add(this.lCritery);
            this.panelFind.Controls.Add(this.lFindText);
            this.panelFind.Controls.Add(this.panelFindTitle);
            this.panelFind.Controls.Add(this.tbFind);
            this.panelFind.Controls.Add(this.btnFindNext);
            this.panelFind.Controls.Add(this.btnFind);
            this.panelFind.Controls.Add(this.cbTypeFind);
            this.panelFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFind.Location = new System.Drawing.Point(0, 0);
            this.panelFind.Name = "panelFind";
            this.panelFind.Size = new System.Drawing.Size(368, 606);
            this.panelFind.TabIndex = 0;
            // 
            // cbFullFind
            // 
            this.cbFullFind.AutoSize = true;
            this.cbFullFind.Location = new System.Drawing.Point(40, 184);
            this.cbFullFind.Name = "cbFullFind";
            this.cbFullFind.Size = new System.Drawing.Size(108, 17);
            this.cbFullFind.TabIndex = 20;
            this.cbFullFind.Text = "Сквозной поиск";
            this.cbFullFind.UseVisualStyleBackColor = true;
            this.cbFullFind.Visible = false;
            // 
            // btnHidePanel
            // 
            this.btnHidePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHidePanel.Location = new System.Drawing.Point(154, 544);
            this.btnHidePanel.Name = "btnHidePanel";
            this.btnHidePanel.Size = new System.Drawing.Size(75, 23);
            this.btnHidePanel.TabIndex = 19;
            this.btnHidePanel.Text = "Скрыть";
            this.btnHidePanel.UseVisualStyleBackColor = true;
            this.btnHidePanel.Click += new System.EventHandler(this.btnHidePanel_Click);
            // 
            // btnFindReset
            // 
            this.btnFindReset.Location = new System.Drawing.Point(58, 143);
            this.btnFindReset.Name = "btnFindReset";
            this.btnFindReset.Size = new System.Drawing.Size(69, 23);
            this.btnFindReset.TabIndex = 18;
            this.btnFindReset.Text = "Сброс";
            this.btnFindReset.UseVisualStyleBackColor = true;
            this.btnFindReset.Click += new System.EventHandler(this.btnFindReset_Click);
            // 
            // lCritery
            // 
            this.lCritery.AutoSize = true;
            this.lCritery.Location = new System.Drawing.Point(22, 91);
            this.lCritery.Name = "lCritery";
            this.lCritery.Size = new System.Drawing.Size(94, 13);
            this.lCritery.TabIndex = 17;
            this.lCritery.Text = "Критерий поиска";
            // 
            // lFindText
            // 
            this.lFindText.AutoSize = true;
            this.lFindText.Location = new System.Drawing.Point(23, 43);
            this.lFindText.Name = "lFindText";
            this.lFindText.Size = new System.Drawing.Size(82, 13);
            this.lFindText.TabIndex = 17;
            this.lFindText.Text = "Строка поиска";
            // 
            // panelFindTitle
            // 
            this.panelFindTitle.Controls.Add(this.lblFindTitle);
            this.panelFindTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFindTitle.Location = new System.Drawing.Point(0, 0);
            this.panelFindTitle.Name = "panelFindTitle";
            this.panelFindTitle.Size = new System.Drawing.Size(368, 27);
            this.panelFindTitle.TabIndex = 16;
            // 
            // lblFindTitle
            // 
            this.lblFindTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFindTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFindTitle.Location = new System.Drawing.Point(0, 0);
            this.lblFindTitle.Name = "lblFindTitle";
            this.lblFindTitle.Size = new System.Drawing.Size(368, 27);
            this.lblFindTitle.TabIndex = 0;
            this.lblFindTitle.Text = "Панель поиска";
            this.lblFindTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbFind
            // 
            this.tbFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFind.Location = new System.Drawing.Point(22, 59);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(328, 20);
            this.tbFind.TabIndex = 15;
            this.tbFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFind_KeyDown);
            this.tbFind.MouseEnter += new System.EventHandler(this.tbFind_MouseEnter);
            this.tbFind.MouseLeave += new System.EventHandler(this.tbFind_MouseLeave);
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
            this.cbTypeFind.Location = new System.Drawing.Point(22, 109);
            this.cbTypeFind.Name = "cbTypeFind";
            this.cbTypeFind.Size = new System.Drawing.Size(138, 21);
            this.cbTypeFind.TabIndex = 13;
            this.cbTypeFind.SelectedIndexChanged += new System.EventHandler(this.cbTypeFind_SelectedIndexChanged);
            // 
            // tabActors
            // 
            this.tabActors.Controls.Add(this.scTabActors);
            this.tabActors.Location = new System.Drawing.Point(4, 22);
            this.tabActors.Name = "tabActors";
            this.tabActors.Padding = new System.Windows.Forms.Padding(3);
            this.tabActors.Size = new System.Drawing.Size(972, 614);
            this.tabActors.TabIndex = 3;
            this.tabActors.Text = "Актеры";
            this.tabActors.UseVisualStyleBackColor = true;
            // 
            // scTabActors
            // 
            this.scTabActors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scTabActors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scTabActors.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scTabActors.IsSplitterFixed = true;
            this.scTabActors.Location = new System.Drawing.Point(3, 3);
            this.scTabActors.Name = "scTabActors";
            // 
            // scTabActors.Panel1
            // 
            this.scTabActors.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.scTabActors.Panel1.Controls.Add(this.dgvTableActors);
            this.scTabActors.Panel1.Controls.Add(this.menuTableAct);
            // 
            // scTabActors.Panel2
            // 
            this.scTabActors.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.scTabActors.Panel2.Controls.Add(this.panelEditAct);
            this.scTabActors.Panel2.Controls.Add(this.panelViewAct);
            this.scTabActors.Size = new System.Drawing.Size(966, 608);
            this.scTabActors.SplitterDistance = 537;
            this.scTabActors.TabIndex = 1;
            // 
            // dgvTableActors
            // 
            this.dgvTableActors.AllowUserToAddRows = false;
            this.dgvTableActors.AllowUserToDeleteRows = false;
            this.dgvTableActors.AllowUserToResizeRows = false;
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
            this.dgvTableActors.Size = new System.Drawing.Size(535, 579);
            this.dgvTableActors.TabIndex = 0;
            this.dgvTableActors.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTableActors_CellMouseDown);
            this.dgvTableActors.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTableActors_ColumnHeaderMouseClick);
            this.dgvTableActors.SelectionChanged += new System.EventHandler(this.SelectActor_Info);
            this.dgvTableActors.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvTableActors_KeyDown);
            this.dgvTableActors.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TableAct_MouseClick);
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
            // menuTableAct
            // 
            this.menuTableAct.BackColor = System.Drawing.SystemColors.Control;
            this.menuTableAct.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnResetFilterAct,
            this.tsActCountryFilter,
            this.tsActSort});
            this.menuTableAct.Location = new System.Drawing.Point(0, 0);
            this.menuTableAct.Name = "menuTableAct";
            this.menuTableAct.Size = new System.Drawing.Size(535, 27);
            this.menuTableAct.TabIndex = 25;
            this.menuTableAct.Text = "menuStrip1";
            // 
            // btnResetFilterAct
            // 
            this.btnResetFilterAct.Image = global::FilmCollection.Properties.Resources.resetFiltr;
            this.btnResetFilterAct.Name = "btnResetFilterAct";
            this.btnResetFilterAct.Size = new System.Drawing.Size(120, 23);
            this.btnResetFilterAct.Text = "Сброс фильтра";
            this.btnResetFilterAct.Click += new System.EventHandler(this.ResetFilter_Click);
            // 
            // tsActCountryFilter
            // 
            this.tsActCountryFilter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsActCountryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsActCountryFilter.Name = "tsActCountryFilter";
            this.tsActCountryFilter.Size = new System.Drawing.Size(121, 23);
            this.tsActCountryFilter.SelectedIndexChanged += new System.EventHandler(this.Filter);
            // 
            // tsActSort
            // 
            this.tsActSort.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsActSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsActSort.Items.AddRange(new object[] {
            "По Ф.И.О.",
            "По дате рождения",
            "По дате смерти",
            "По стране"});
            this.tsActSort.Name = "tsActSort";
            this.tsActSort.Size = new System.Drawing.Size(121, 23);
            this.tsActSort.SelectedIndexChanged += new System.EventHandler(this.Filter);
            // 
            // panelEditAct
            // 
            this.panelEditAct.Controls.Add(this.groupBox1);
            this.panelEditAct.Controls.Add(this.gActAbout);
            this.panelEditAct.Controls.Add(this.btnSaveActor);
            this.panelEditAct.Controls.Add(this.btnCancelActor);
            this.panelEditAct.Controls.Add(this.btnNewActor);
            this.panelEditAct.Controls.Add(this.label8);
            this.panelEditAct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEditAct.Location = new System.Drawing.Point(0, 0);
            this.panelEditAct.Name = "panelEditAct";
            this.panelEditAct.Size = new System.Drawing.Size(423, 606);
            this.panelEditAct.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listViewFilm);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lvSelectRecord);
            this.groupBox1.Controls.Add(this.tbFilmFind);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(20, 198);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 302);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильмография";
            // 
            // listViewFilm
            // 
            this.listViewFilm.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colYear});
            this.listViewFilm.FullRowSelect = true;
            this.listViewFilm.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewFilm.Location = new System.Drawing.Point(15, 19);
            this.listViewFilm.MultiSelect = false;
            this.listViewFilm.Name = "listViewFilm";
            this.listViewFilm.ShowGroups = false;
            this.listViewFilm.Size = new System.Drawing.Size(364, 137);
            this.listViewFilm.TabIndex = 62;
            this.listViewFilm.UseCompatibleStateImageBehavior = false;
            this.listViewFilm.View = System.Windows.Forms.View.Details;
            this.listViewFilm.DoubleClick += new System.EventHandler(this.listViewFilm_DoubleClick);
            // 
            // colName
            // 
            this.colName.Text = "";
            this.colName.Width = 275;
            // 
            // colYear
            // 
            this.colYear.Text = "";
            this.colYear.Width = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(116, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(160, 13);
            this.label10.TabIndex = 53;
            this.label10.Text = "Введите названия для поиска";
            // 
            // lvSelectRecord
            // 
            this.lvSelectRecord.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSelectName,
            this.colSelectYear});
            this.lvSelectRecord.FullRowSelect = true;
            this.lvSelectRecord.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvSelectRecord.Location = new System.Drawing.Point(15, 214);
            this.lvSelectRecord.MultiSelect = false;
            this.lvSelectRecord.Name = "lvSelectRecord";
            this.lvSelectRecord.ShowGroups = false;
            this.lvSelectRecord.Size = new System.Drawing.Size(364, 75);
            this.lvSelectRecord.TabIndex = 62;
            this.lvSelectRecord.UseCompatibleStateImageBehavior = false;
            this.lvSelectRecord.View = System.Windows.Forms.View.Details;
            this.lvSelectRecord.DoubleClick += new System.EventHandler(this.lvSelectRecord_DoubleClick);
            // 
            // colSelectName
            // 
            this.colSelectName.Text = "";
            this.colSelectName.Width = 275;
            // 
            // colSelectYear
            // 
            this.colSelectYear.Text = "";
            this.colSelectYear.Width = 45;
            // 
            // tbFilmFind
            // 
            this.tbFilmFind.Location = new System.Drawing.Point(15, 175);
            this.tbFilmFind.Name = "tbFilmFind";
            this.tbFilmFind.Size = new System.Drawing.Size(364, 20);
            this.tbFilmFind.TabIndex = 55;
            this.tbFilmFind.TextChanged += new System.EventHandler(this.tbFilmFind_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 198);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(137, 13);
            this.label14.TabIndex = 53;
            this.label14.Text = "Кликом выберите записи";
            // 
            // gActAbout
            // 
            this.gActAbout.Controls.Add(this.chLifeState);
            this.gActAbout.Controls.Add(this.cBoxCountryActor);
            this.gActAbout.Controls.Add(this.tbBIO);
            this.gActAbout.Controls.Add(this.tbFIO);
            this.gActAbout.Controls.Add(this.maskDateOfBirth);
            this.gActAbout.Controls.Add(this.label9);
            this.gActAbout.Controls.Add(this.label15);
            this.gActAbout.Controls.Add(this.maskDateOfDeath);
            this.gActAbout.Controls.Add(this.label6);
            this.gActAbout.Controls.Add(this.label11);
            this.gActAbout.Controls.Add(this.label12);
            this.gActAbout.Controls.Add(this.label13);
            this.gActAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gActAbout.Location = new System.Drawing.Point(20, 30);
            this.gActAbout.Name = "gActAbout";
            this.gActAbout.Size = new System.Drawing.Size(391, 157);
            this.gActAbout.TabIndex = 63;
            this.gActAbout.TabStop = false;
            this.gActAbout.Text = "Информация об актере";
            // 
            // chLifeState
            // 
            this.chLifeState.AutoSize = true;
            this.chLifeState.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chLifeState.Location = new System.Drawing.Point(327, 59);
            this.chLifeState.Name = "chLifeState";
            this.chLifeState.Size = new System.Drawing.Size(49, 17);
            this.chLifeState.TabIndex = 61;
            this.chLifeState.Text = "Жив";
            this.chLifeState.UseVisualStyleBackColor = true;
            this.chLifeState.CheckedChanged += new System.EventHandler(this.checkLive_CheckedChanged);
            // 
            // cBoxCountryActor
            // 
            this.cBoxCountryActor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCountryActor.FormattingEnabled = true;
            this.cBoxCountryActor.Location = new System.Drawing.Point(98, 90);
            this.cBoxCountryActor.Name = "cBoxCountryActor";
            this.cBoxCountryActor.Size = new System.Drawing.Size(281, 21);
            this.cBoxCountryActor.TabIndex = 59;
            // 
            // tbBIO
            // 
            this.tbBIO.Location = new System.Drawing.Point(98, 123);
            this.tbBIO.Name = "tbBIO";
            this.tbBIO.Size = new System.Drawing.Size(281, 20);
            this.tbBIO.TabIndex = 55;
            // 
            // tbFIO
            // 
            this.tbFIO.BackColor = System.Drawing.SystemColors.Window;
            this.tbFIO.Location = new System.Drawing.Point(98, 23);
            this.tbFIO.Name = "tbFIO";
            this.tbFIO.Size = new System.Drawing.Size(279, 20);
            this.tbFIO.TabIndex = 55;
            // 
            // maskDateOfBirth
            // 
            this.maskDateOfBirth.Location = new System.Drawing.Point(98, 56);
            this.maskDateOfBirth.Mask = "00/00/0000";
            this.maskDateOfBirth.Name = "maskDateOfBirth";
            this.maskDateOfBirth.Size = new System.Drawing.Size(74, 20);
            this.maskDateOfBirth.TabIndex = 58;
            this.maskDateOfBirth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 52;
            this.label9.Text = "Ф.И.О.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(32, 127);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 13);
            this.label15.TabIndex = 54;
            this.label15.Text = "Биография";
            // 
            // maskDateOfDeath
            // 
            this.maskDateOfDeath.Location = new System.Drawing.Point(201, 57);
            this.maskDateOfDeath.Mask = "00/00/0000";
            this.maskDateOfDeath.Name = "maskDateOfDeath";
            this.maskDateOfDeath.Size = new System.Drawing.Size(121, 20);
            this.maskDateOfDeath.TabIndex = 58;
            this.maskDateOfDeath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 54;
            this.label6.Text = "Страна";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 53;
            this.label11.Text = "Годы жизни:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(85, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 13);
            this.label12.TabIndex = 53;
            this.label12.Text = "с";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(177, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 13);
            this.label13.TabIndex = 53;
            this.label13.Text = "по";
            // 
            // btnSaveActor
            // 
            this.btnSaveActor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveActor.Image = global::FilmCollection.Properties.Resources.save;
            this.btnSaveActor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveActor.Location = new System.Drawing.Point(294, 514);
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
            this.btnCancelActor.Location = new System.Drawing.Point(294, 543);
            this.btnCancelActor.Name = "btnCancelActor";
            this.btnCancelActor.Size = new System.Drawing.Size(86, 23);
            this.btnCancelActor.TabIndex = 56;
            this.btnCancelActor.Text = "Отмена";
            this.btnCancelActor.UseVisualStyleBackColor = true;
            this.btnCancelActor.Click += new System.EventHandler(this.btnCancelActor_Click);
            // 
            // btnNewActor
            // 
            this.btnNewActor.Image = global::FilmCollection.Properties.Resources.add;
            this.btnNewActor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewActor.Location = new System.Drawing.Point(47, 514);
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
            this.label8.Size = new System.Drawing.Size(423, 27);
            this.label8.TabIndex = 1;
            this.label8.Text = "Панель редактирования";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelViewAct
            // 
            this.panelViewAct.Controls.Add(this.groupBox2);
            this.panelViewAct.Controls.Add(this.groupBox3);
            this.panelViewAct.Controls.Add(this.label26);
            this.panelViewAct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelViewAct.Location = new System.Drawing.Point(0, 0);
            this.panelViewAct.Name = "panelViewAct";
            this.panelViewAct.Size = new System.Drawing.Size(423, 606);
            this.panelViewAct.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listViewFilmV);
            this.groupBox2.Location = new System.Drawing.Point(20, 198);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(391, 302);
            this.groupBox2.TabIndex = 64;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Фильмография";
            // 
            // listViewFilmV
            // 
            this.listViewFilmV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column1,
            this.column2,
            this.column3});
            this.listViewFilmV.FullRowSelect = true;
            this.listViewFilmV.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewFilmV.Location = new System.Drawing.Point(15, 19);
            this.listViewFilmV.MultiSelect = false;
            this.listViewFilmV.Name = "listViewFilmV";
            this.listViewFilmV.ShowGroups = false;
            this.listViewFilmV.Size = new System.Drawing.Size(364, 261);
            this.listViewFilmV.TabIndex = 62;
            this.listViewFilmV.UseCompatibleStateImageBehavior = false;
            this.listViewFilmV.View = System.Windows.Forms.View.Details;
            this.listViewFilmV.DoubleClick += new System.EventHandler(this.listViewFilmV_DoubleClick);
            // 
            // column1
            // 
            this.column1.Text = "";
            this.column1.Width = 200;
            // 
            // column2
            // 
            this.column2.Text = "";
            this.column2.Width = 100;
            // 
            // column3
            // 
            this.column3.Text = "";
            this.column3.Width = 45;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbFIOv);
            this.groupBox3.Controls.Add(this.tbCountryAv);
            this.groupBox3.Controls.Add(this.linkBIOv);
            this.groupBox3.Controls.Add(this.maskDateOfBirthV);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.maskDateOfDeathV);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(20, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(391, 157);
            this.groupBox3.TabIndex = 63;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Информация об актере";
            // 
            // tbFIOv
            // 
            this.tbFIOv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFIOv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbFIOv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbFIOv.Location = new System.Drawing.Point(98, 24);
            this.tbFIOv.Name = "tbFIOv";
            this.tbFIOv.ReadOnly = true;
            this.tbFIOv.Size = new System.Drawing.Size(278, 16);
            this.tbFIOv.TabIndex = 66;
            // 
            // tbCountryAv
            // 
            this.tbCountryAv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCountryAv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCountryAv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCountryAv.Location = new System.Drawing.Point(98, 92);
            this.tbCountryAv.Name = "tbCountryAv";
            this.tbCountryAv.ReadOnly = true;
            this.tbCountryAv.Size = new System.Drawing.Size(278, 16);
            this.tbCountryAv.TabIndex = 66;
            // 
            // linkBIOv
            // 
            this.linkBIOv.Location = new System.Drawing.Point(98, 123);
            this.linkBIOv.Name = "linkBIOv";
            this.linkBIOv.Padding = new System.Windows.Forms.Padding(3);
            this.linkBIOv.Size = new System.Drawing.Size(281, 23);
            this.linkBIOv.TabIndex = 65;
            this.linkBIOv.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBIOv_LinkClicked);
            // 
            // maskDateOfBirthV
            // 
            this.maskDateOfBirthV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maskDateOfBirthV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskDateOfBirthV.Location = new System.Drawing.Point(108, 57);
            this.maskDateOfBirthV.Mask = "00/00/0000";
            this.maskDateOfBirthV.Name = "maskDateOfBirthV";
            this.maskDateOfBirthV.ReadOnly = true;
            this.maskDateOfBirthV.Size = new System.Drawing.Size(87, 16);
            this.maskDateOfBirthV.TabIndex = 58;
            this.maskDateOfBirthV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(49, 26);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(46, 13);
            this.label20.TabIndex = 52;
            this.label20.Text = "Ф.И.О.:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(32, 127);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(66, 13);
            this.label21.TabIndex = 54;
            this.label21.Text = "Биография:";
            // 
            // maskDateOfDeathV
            // 
            this.maskDateOfDeathV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maskDateOfDeathV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskDateOfDeathV.Location = new System.Drawing.Point(227, 56);
            this.maskDateOfDeathV.Mask = "00/00/0000";
            this.maskDateOfDeathV.Name = "maskDateOfDeathV";
            this.maskDateOfDeathV.ReadOnly = true;
            this.maskDateOfDeathV.Size = new System.Drawing.Size(156, 16);
            this.maskDateOfDeathV.TabIndex = 58;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(49, 93);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(46, 13);
            this.label22.TabIndex = 54;
            this.label22.Text = "Страна:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(22, 59);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(71, 13);
            this.label23.TabIndex = 53;
            this.label23.Text = "Годы жизни:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(96, 59);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(13, 13);
            this.label24.TabIndex = 53;
            this.label24.Text = "с";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(200, 59);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(19, 13);
            this.label25.TabIndex = 53;
            this.label25.Text = "по";
            // 
            // label26
            // 
            this.label26.Dock = System.Windows.Forms.DockStyle.Top;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label26.Location = new System.Drawing.Point(0, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(423, 27);
            this.label26.TabIndex = 1;
            this.label26.Text = "Информация об актере";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabImage
            // 
            this.tabImage.BackColor = System.Drawing.SystemColors.Control;
            this.tabImage.Controls.Add(this.panelMain);
            this.tabImage.Controls.Add(this.panel2);
            this.tabImage.Location = new System.Drawing.Point(4, 22);
            this.tabImage.Name = "tabImage";
            this.tabImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabImage.Size = new System.Drawing.Size(972, 614);
            this.tabImage.TabIndex = 4;
            this.tabImage.Text = "Постеры";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.flowLayoutPanelMain);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(3, 32);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(966, 579);
            this.panelMain.TabIndex = 7;
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanelMain.CausesValidation = false;
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(966, 579);
            this.flowLayoutPanelMain.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.buttonCancel);
            this.panel2.Controls.Add(this.trackBarSize);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(966, 29);
            this.panel2.TabIndex = 10;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(6, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(146, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel Scan Directory";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // trackBarSize
            // 
            this.trackBarSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarSize.AutoSize = false;
            this.trackBarSize.LargeChange = 1;
            this.trackBarSize.Location = new System.Drawing.Point(834, 6);
            this.trackBarSize.Maximum = 2;
            this.trackBarSize.Name = "trackBarSize";
            this.trackBarSize.Size = new System.Drawing.Size(124, 23);
            this.trackBarSize.TabIndex = 6;
            this.trackBarSize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarSize.Value = 2;
            this.trackBarSize.ValueChanged += new System.EventHandler(this.trackBarSize_ValueChanged);
            // 
            // tabDiagram
            // 
            this.tabDiagram.BackColor = System.Drawing.SystemColors.Control;
            this.tabDiagram.Controls.Add(this.ucDiagr);
            this.tabDiagram.Location = new System.Drawing.Point(4, 22);
            this.tabDiagram.Name = "tabDiagram";
            this.tabDiagram.Size = new System.Drawing.Size(972, 614);
            this.tabDiagram.TabIndex = 5;
            this.tabDiagram.Text = "Диаграмма";
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
            this.scMain.Size = new System.Drawing.Size(1175, 640);
            this.scMain.SplitterDistance = 191;
            this.scMain.TabIndex = 24;
            // 
            // mainMenuIcon
            // 
            this.mainMenuIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCreateDB,
            this.tsUpdateDB,
            this.toolStripSeparator4,
            this.tsBackupDB,
            this.tsRecoveryDB,
            this.toolStripSeparator6,
            this.tsAdd,
            this.tsChange,
            this.tsRemove,
            this.toolStripSeparator5,
            this.tsFind,
            this.tsFindbyName,
            this.tsHidePanel});
            this.mainMenuIcon.Location = new System.Drawing.Point(0, 24);
            this.mainMenuIcon.Name = "mainMenuIcon";
            this.mainMenuIcon.Size = new System.Drawing.Size(1175, 25);
            this.mainMenuIcon.TabIndex = 26;
            this.mainMenuIcon.Text = "toolStrip1";
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
            this.tsRecoveryDB.Click += new System.EventHandler(this.RecoveryBase_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tsAdd
            // 
            this.tsAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAdd.Image = global::FilmCollection.Properties.Resources.add;
            this.tsAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAdd.Name = "tsAdd";
            this.tsAdd.Size = new System.Drawing.Size(23, 22);
            this.tsAdd.Text = "Добавить";
            this.tsAdd.Click += new System.EventHandler(this.tsAdd_Click);
            // 
            // tsChange
            // 
            this.tsChange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsChange.Image = global::FilmCollection.Properties.Resources.change;
            this.tsChange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsChange.Name = "tsChange";
            this.tsChange.Size = new System.Drawing.Size(23, 22);
            this.tsChange.Text = "Изменить";
            this.tsChange.Click += new System.EventHandler(this.tsChange_Click);
            // 
            // tsRemove
            // 
            this.tsRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsRemove.Image = global::FilmCollection.Properties.Resources.del;
            this.tsRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRemove.Name = "tsRemove";
            this.tsRemove.Size = new System.Drawing.Size(23, 22);
            this.tsRemove.Text = "Удалить";
            this.tsRemove.Click += new System.EventHandler(this.tsRemove_Click);
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
            this.tsFind.Click += new System.EventHandler(this.tsFind_Click);
            // 
            // tsFindbyName
            // 
            this.tsFindbyName.AutoSize = false;
            this.tsFindbyName.BackColor = System.Drawing.SystemColors.Window;
            this.tsFindbyName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tsFindbyName.MaxLength = 150;
            this.tsFindbyName.Name = "tsFindbyName";
            this.tsFindbyName.Padding = new System.Windows.Forms.Padding(5);
            this.tsFindbyName.Size = new System.Drawing.Size(150, 20);
            this.tsFindbyName.ToolTipText = "Панель быстрого поиска по названию";
            this.tsFindbyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tsFindbyName_KeyDown);
            this.tsFindbyName.MouseEnter += new System.EventHandler(this.tsFindbyName_MouseEnter);
            this.tsFindbyName.MouseLeave += new System.EventHandler(this.tsFindbyName_MouseLeave);
            this.tsFindbyName.Paint += new System.Windows.Forms.PaintEventHandler(this.tsFindbyName_Paint);
            // 
            // tsHidePanel
            // 
            this.tsHidePanel.CheckOnClick = true;
            this.tsHidePanel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsHidePanel.Image = global::FilmCollection.Properties.Resources.hide;
            this.tsHidePanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsHidePanel.Name = "tsHidePanel";
            this.tsHidePanel.Size = new System.Drawing.Size(23, 22);
            this.tsHidePanel.Text = "Скрыть панель";
            this.tsHidePanel.ToolTipText = "Скрыть панель";
            this.tsHidePanel.CheckedChanged += new System.EventHandler(this.tsHidePanel_CheckedChanged);
            // 
            // toolinfo
            // 
            this.toolinfo.AutoPopDelay = 5000;
            this.toolinfo.InitialDelay = 300;
            this.toolinfo.ReshowDelay = 100;
            // 
            // Tray
            // 
            this.Tray.Text = "Фильмотека";
            this.Tray.Visible = true;
            this.Tray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Tray_MouseDoubleClick);
            // 
            // TrayMenu
            // 
            this.TrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowWindow,
            this.About,
            this.separator1,
            this.Exit});
            this.TrayMenu.Name = "TrayMenu";
            this.TrayMenu.Size = new System.Drawing.Size(155, 76);
            // 
            // ShowWindow
            // 
            this.ShowWindow.Name = "ShowWindow";
            this.ShowWindow.Size = new System.Drawing.Size(154, 22);
            this.ShowWindow.Text = "Показать окно";
            this.ShowWindow.Click += new System.EventHandler(this.ShowWindow_Click);
            // 
            // About
            // 
            this.About.Image = global::FilmCollection.Properties.Resources.help;
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(154, 22);
            this.About.Text = "О программе";
            this.About.Click += new System.EventHandler(this.About_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(151, 6);
            // 
            // Exit
            // 
            this.Exit.Image = global::FilmCollection.Properties.Resources.ExitV2;
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(154, 22);
            this.Exit.Text = "Выход";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // timerForDateTime
            // 
            this.timerForDateTime.Enabled = true;
            this.timerForDateTime.Tick += new System.EventHandler(this.timerForDateTime_Tick);
            // 
            // ucView
            // 
            this.ucView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucView.Location = new System.Drawing.Point(0, 0);
            this.ucView.Name = "ucView";
            this.ucView.Size = new System.Drawing.Size(368, 606);
            this.ucView.TabIndex = 0;
            // 
            // ucScheme
            // 
            this.ucScheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucScheme.Location = new System.Drawing.Point(0, 0);
            this.ucScheme.Name = "ucScheme";
            this.ucScheme.Size = new System.Drawing.Size(368, 606);
            this.ucScheme.TabIndex = 0;
            // 
            // ucDiagr
            // 
            this.ucDiagr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDiagr.Location = new System.Drawing.Point(0, 0);
            this.ucDiagr.Name = "ucDiagr";
            this.ucDiagr.Size = new System.Drawing.Size(972, 614);
            this.ucDiagr.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 711);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.statusLine);
            this.Controls.Add(this.mainMenuIcon);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.menuTableRec;
            this.Name = "MainForm";
            this.Text = "Фильмотека";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_Close);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.TableRec)).EndInit();
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
            this.menuTableRec.ResumeLayout(false);
            this.menuTableRec.PerformLayout();
            this.panelEdit.ResumeLayout(false);
            this.gMedia.ResumeLayout(false);
            this.gMedia.PerformLayout();
            this.panelEditTitle.ResumeLayout(false);
            this.gRecord.ResumeLayout(false);
            this.gRecord.PerformLayout();
            this.panelView.ResumeLayout(false);
            this.panelFolder.ResumeLayout(false);
            this.panelFolder.PerformLayout();
            this.panelScheme.ResumeLayout(false);
            this.panelFind.ResumeLayout(false);
            this.panelFind.PerformLayout();
            this.panelFindTitle.ResumeLayout(false);
            this.tabActors.ResumeLayout(false);
            this.scTabActors.Panel1.ResumeLayout(false);
            this.scTabActors.Panel1.PerformLayout();
            this.scTabActors.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scTabActors)).EndInit();
            this.scTabActors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableActors)).EndInit();
            this.menuTableAct.ResumeLayout(false);
            this.menuTableAct.PerformLayout();
            this.panelEditAct.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gActAbout.ResumeLayout(false);
            this.gActAbout.PerformLayout();
            this.panelViewAct.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabImage.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize)).EndInit();
            this.tabDiagram.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.mainMenuIcon.ResumeLayout(false);
            this.mainMenuIcon.PerformLayout();
            this.TrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip TabMenu;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabFilm;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem btnCreateBase;
        private System.Windows.Forms.ToolStripMenuItem MenuHelp;
        private System.Windows.Forms.ToolStripMenuItem cAdd;
        private System.Windows.Forms.ToolStripMenuItem cDelete;
        private System.Windows.Forms.ToolStripMenuItem cChange;
        private System.Windows.Forms.ToolStripMenuItem btnAbout;
        private System.Windows.Forms.ToolStripMenuItem btnHistory;
        private System.Windows.Forms.ToolStripMenuItem cFind;
        private System.Windows.Forms.ToolStripSeparator cSep1;
        private System.Windows.Forms.ToolStripMenuItem btnExportHTML;
        private System.Windows.Forms.ToolStripSeparator ts3;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripMenuItem btnReport;
        private System.Windows.Forms.Timer timerLoad;
        private System.Windows.Forms.ToolStripMenuItem btnUpdateBase;
        private System.Windows.Forms.ToolStripSeparator ts1;
        private System.Windows.Forms.ToolStripMenuItem btnBackupBase;
        private System.Windows.Forms.ToolStripSeparator ts2;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.SplitContainer scTabFilm;
        private System.Windows.Forms.Panel panelFind;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Button btnFileNameEdit;
        private System.Windows.Forms.ComboBox cBoxTypeVideo;
        private System.Windows.Forms.ComboBox cBoxGenre;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblTypeVideo;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ComboBox cbTypeFind;
        private System.Windows.Forms.MenuStrip menuTableRec;
        private System.Windows.Forms.ToolStripMenuItem btnResetFilterRec;
        private System.Windows.Forms.ToolStripComboBox tscbTypeFilter;
        private System.Windows.Forms.ToolStripComboBox tscbSort;
        private System.Windows.Forms.ToolStripStatusLabel tssLabel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panelEditTitle;
        private System.Windows.Forms.Label lblEditTitle;
        private System.Windows.Forms.Panel panelFindTitle;
        private System.Windows.Forms.Label lblFindTitle;
        private System.Windows.Forms.Label lCritery;
        private System.Windows.Forms.Label lFindText;
        private System.Windows.Forms.StatusStrip statusLine;
        private System.Windows.Forms.ToolStripMenuItem btnRecoveryBase;
        private System.Windows.Forms.ToolStripMenuItem настройкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnOptions;
        private System.Windows.Forms.ToolStripMenuItem btnActors;
        private System.Windows.Forms.Button btnFindNext;
        private System.Windows.Forms.Button btnFindReset;
        private System.Windows.Forms.ContextMenuStrip TreeMenu;
        private System.Windows.Forms.ToolStripMenuItem сCollapseAll;
        private System.Windows.Forms.ToolStripMenuItem сExpandAll;
        private System.Windows.Forms.ToolStripSeparator tcSep1;
        private System.Windows.Forms.ToolStripMenuItem cExpandSelectNode;
        private System.Windows.Forms.ToolStripSeparator tcSep2;
        private System.Windows.Forms.ToolStripMenuItem cShowSelcetNodeAllFiles;
        private System.Windows.Forms.ToolStripMenuItem MenuChange;
        private System.Windows.Forms.ToolStrip mainMenuIcon;
        private System.Windows.Forms.ToolStripButton tsCreateDB;
        private System.Windows.Forms.ToolStripButton tsUpdateDB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsAdd;
        private System.Windows.Forms.ToolStripButton tsChange;
        private System.Windows.Forms.ToolStripButton tsRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsFind;
        private System.Windows.Forms.ToolTip toolinfo;
        private System.Windows.Forms.MaskedTextBox mtbYear;
        private System.Windows.Forms.ComboBox cBoxCountry;
        private System.Windows.Forms.ToolStripButton tsBackupDB;
        private System.Windows.Forms.ToolStripButton tsRecoveryDB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.TabPage tabActors;
        private System.Windows.Forms.SplitContainer scTabActors;
        private System.Windows.Forms.DataGridView dgvTableActors;
        private System.Windows.Forms.Button btnRemoveGroup;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Label lblActorsSelect;
        /// <summary>Снимались в фильме</summary>
        private System.Windows.Forms.ListBox chkActorSelect;
        private System.Windows.Forms.Label lblActorsAll;
        /// <summary>Список актеров</summary>
        private System.Windows.Forms.CheckedListBox chkActorList;
        private System.Windows.Forms.Panel panelEditAct;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MenuStrip menuTableAct;
        private System.Windows.Forms.ToolStripMenuItem btnResetFilterAct;
        private System.Windows.Forms.ToolStripComboBox tsActCountryFilter;
        private System.Windows.Forms.ToolStripComboBox tsActSort;
        private System.Windows.Forms.ComboBox cBoxCountryActor;
        private System.Windows.Forms.Button btnSaveActor;
        private System.Windows.Forms.Button btnCancelActor;
        private System.Windows.Forms.TextBox tbFilmFind;
        private System.Windows.Forms.TextBox tbFIO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnNewActor;
        private System.Windows.Forms.MaskedTextBox maskDateOfDeath;
        private System.Windows.Forms.CheckBox chLifeState;
        private System.Windows.Forms.MaskedTextBox maskDateOfBirth;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActFIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateOfDeath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCountry;
        private System.Windows.Forms.ListView lvSelectRecord;
        private System.Windows.Forms.ColumnHeader colSelectName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListView listViewFilm;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.GroupBox gActAbout;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader colSelectYear;
        private System.Windows.Forms.ColumnHeader colYear;
        private System.Windows.Forms.TabPage tabImage;
        private System.Windows.Forms.ToolStripTextBox tsFindbyName;
        private System.Windows.Forms.ToolStripSeparator tcSep3;
        private System.Windows.Forms.ToolStripMenuItem cRenameFolder;
        private System.Windows.Forms.Panel panelFolder;
        private System.Windows.Forms.Button btnSaveFolder;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem cOpenFolder;
        private System.Windows.Forms.ToolStripSeparator cSep3;
        private System.Windows.Forms.CheckBox cbIsVisible;
        private System.Windows.Forms.ToolStripSeparator ts5;
        private System.Windows.Forms.ToolStripMenuItem btnCleanDB;
        private System.Windows.Forms.ToolStripMenuItem UpdateFIlmInfo;
        private System.Windows.Forms.ToolStripSeparator cSep4;
        private System.Windows.Forms.ToolStripSeparator tcSep4;
        private System.Windows.Forms.ToolStripMenuItem UpdateCatalogInfo;
        private System.Windows.Forms.Button btnGetTime;
        private System.Windows.Forms.MaskedTextBox mtbTime;
        private System.Windows.Forms.GroupBox gMedia;
        private System.Windows.Forms.TextBox tbNameRecord;
        private System.Windows.Forms.GroupBox gRecord;
        private System.Windows.Forms.Label lblNameR;
        private System.Windows.Forms.ToolStripSeparator tcSep5;
        private System.Windows.Forms.ToolStripMenuItem ChangeCatalogTypeVideo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panelViewAct;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listViewFilmV;
        private System.Windows.Forms.ColumnHeader column1;
        private System.Windows.Forms.ColumnHeader column3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.LinkLabel linkBIOv;
        private System.Windows.Forms.MaskedTextBox maskDateOfBirthV;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.MaskedTextBox maskDateOfDeathV;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox tbBIO;
        private System.Windows.Forms.TextBox tbFIOv;
        private System.Windows.Forms.TextBox tbCountryAv;
        private System.Windows.Forms.ComboBox cbNameMedia;
        private System.Windows.Forms.CheckBox checkNewRecord;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TrackBar trackBarSize;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem ChangeCatalogTypeVideo2;
        private System.Windows.Forms.Button btnRemoveAllGroup;
        private System.Windows.Forms.ToolStripMenuItem btnOpenCatalogDB;
        private System.Windows.Forms.ColumnHeader column2;
        private System.Windows.Forms.ToolStripSeparator ts6;
        private System.Windows.Forms.ToolStripMenuItem btnOpenReportForm;
        private System.Windows.Forms.Button btnHidePanel;
        private System.Windows.Forms.NotifyIcon Tray;
        private System.Windows.Forms.ToolStripMenuItem btnHelp;
        private System.Windows.Forms.ToolStripSeparator ts7;
        private System.Windows.Forms.ToolStripMenuItem btnAdd;
        private System.Windows.Forms.ToolStripMenuItem btnChange;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private System.Windows.Forms.ToolStripSeparator ts4;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip TrayMenu;
        private System.Windows.Forms.ToolStripMenuItem About;
        private System.Windows.Forms.ToolStripMenuItem ShowWindow;
        private System.Windows.Forms.ToolStripSeparator separator1;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem btnCheckUpdate;
        private System.Windows.Forms.ToolStripSeparator ts8;
        private System.Windows.Forms.ToolStripButton tsHidePanel;
        private System.Windows.Forms.CheckBox cbFullFind;
        private System.Windows.Forms.Panel panelView;
        private ucMediaInfo ucView;
        private System.Windows.Forms.RichTextBox rtDescription;
        private System.Windows.Forms.ToolStripSeparator cSep2;
        private System.Windows.Forms.ToolStripMenuItem cClearMetaData;
        public System.Windows.Forms.ToolStripStatusLabel FindStatusLabel;
        public System.Windows.Forms.ToolStripProgressBar tsProgressBar;
        public System.Windows.Forms.DataGridView TableRec;
        public System.Windows.Forms.TreeView treeFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnReindexerForm;
        private System.Windows.Forms.ToolStripSeparator cSep5;
        private System.Windows.Forms.ToolStripMenuItem ShowChart;
        private System.Windows.Forms.Panel panelScheme;
        private ucChart ucScheme;
        private System.Windows.Forms.ToolStripMenuItem cOpenCurrentFolder;
        private System.Windows.Forms.ToolStripSeparator tcSep6;
        private System.Windows.Forms.TabPage tabDiagram;
        private ucChart ucDiagr;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCountryString;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnGenreString;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCategoryString;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnFileName;
        private System.Windows.Forms.ImageList imageLst;
        private System.Windows.Forms.ToolStripStatusLabel tssDayTime;
        private System.Windows.Forms.ToolStripStatusLabel tssWorkTime;
        private System.Windows.Forms.Timer timerForDateTime;
    }
}

