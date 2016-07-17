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
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.сRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cResetTreeFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.cSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cFind = new System.Windows.Forms.ToolStripMenuItem();
            this.cSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cChange = new System.Windows.Forms.ToolStripMenuItem();
            this.cDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.browserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuScan = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpdateBase = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTree = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.экспортВHTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.версииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeFolder = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabFilm = new System.Windows.Forms.TabPage();
            this.tabWriter = new System.Windows.Forms.TabPage();
            this.timerLoad = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabFilm.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTable
            // 
            this.dgvTable.AllowUserToAddRows = false;
            this.dgvTable.AllowUserToDeleteRows = false;
            this.dgvTable.AllowUserToOrderColumns = true;
            this.dgvTable.AllowUserToResizeRows = false;
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column9,
            this.Column2,
            this.Column6,
            this.Column5,
            this.Column3,
            this.Column8,
            this.Column4});
            this.dgvTable.ContextMenuStrip = this.contextMenu;
            this.dgvTable.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvTable.Location = new System.Drawing.Point(3, 3);
            this.dgvTable.MultiSelect = false;
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.ReadOnly = true;
            this.dgvTable.RowHeadersVisible = false;
            this.dgvTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTable.Size = new System.Drawing.Size(693, 411);
            this.dgvTable.TabIndex = 9;
            this.dgvTable.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Name";
            this.Column1.HeaderText = "Название фильма";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "DirName";
            this.Column9.HeaderText = "Расположение";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Year";
            this.Column2.HeaderText = "Год";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 50;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Country";
            this.Column6.HeaderText = "Страна";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 80;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "GenreString";
            this.Column5.HeaderText = "Жанр";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 80;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "CategoryString";
            this.Column3.HeaderText = "Категория";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 80;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Time";
            this.Column8.HeaderText = "Время";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 50;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Файл";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сRefresh,
            this.cSeparator1,
            this.cResetTreeFilter,
            this.cSeparator2,
            this.cFind,
            this.cSeparator3,
            this.cAdd,
            this.cChange,
            this.cDelete});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(160, 154);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // сRefresh
            // 
            this.сRefresh.Name = "сRefresh";
            this.сRefresh.Size = new System.Drawing.Size(159, 22);
            this.сRefresh.Text = "Обновить";
            // 
            // cSeparator1
            // 
            this.cSeparator1.Name = "cSeparator1";
            this.cSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // cResetTreeFilter
            // 
            this.cResetTreeFilter.Name = "cResetTreeFilter";
            this.cResetTreeFilter.Size = new System.Drawing.Size(159, 22);
            this.cResetTreeFilter.Text = "Сброс фильтра";
            this.cResetTreeFilter.Click += new System.EventHandler(this.cResetTreeFilter_Click);
            // 
            // cSeparator2
            // 
            this.cSeparator2.Name = "cSeparator2";
            this.cSeparator2.Size = new System.Drawing.Size(156, 6);
            // 
            // cFind
            // 
            this.cFind.Name = "cFind";
            this.cFind.Size = new System.Drawing.Size(159, 22);
            this.cFind.Text = "Найти (F3)";
            // 
            // cSeparator3
            // 
            this.cSeparator3.Name = "cSeparator3";
            this.cSeparator3.Size = new System.Drawing.Size(156, 6);
            // 
            // cAdd
            // 
            this.cAdd.Name = "cAdd";
            this.cAdd.Size = new System.Drawing.Size(159, 22);
            this.cAdd.Text = "Добавить";
            this.cAdd.Click += new System.EventHandler(this.cAdd_Click);
            // 
            // cChange
            // 
            this.cChange.Name = "cChange";
            this.cChange.Size = new System.Drawing.Size(159, 22);
            this.cChange.Text = "Изменить";
            this.cChange.Click += new System.EventHandler(this.cMenuChange_Click);
            // 
            // cDelete
            // 
            this.cDelete.Name = "cDelete";
            this.cDelete.Size = new System.Drawing.Size(159, 22);
            this.cDelete.Text = "Удалить";
            // 
            // browserDialog
            // 
            this.browserDialog.ShowNewFolderButton = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 467);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1154, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.справкаToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1154, 24);
            this.mainMenu.TabIndex = 21;
            this.mainMenu.Text = "menuStrip1";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuScan,
            this.btnUpdateBase,
            this.toolStripSeparator3,
            this.MenuLoad,
            this.MenuTree,
            this.toolStripSeparator1,
            this.экспортВHTMLToolStripMenuItem,
            this.отчетToolStripMenuItem,
            this.toolStripSeparator2,
            this.выходToolStripMenuItem});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(48, 20);
            this.MenuFile.Text = "Файл";
            // 
            // MenuScan
            // 
            this.MenuScan.Name = "MenuScan";
            this.MenuScan.Size = new System.Drawing.Size(164, 22);
            this.MenuScan.Text = "Создать базу";
            this.MenuScan.Click += new System.EventHandler(this.btnCreateBase_Click);
            // 
            // btnUpdateBase
            // 
            this.btnUpdateBase.Name = "btnUpdateBase";
            this.btnUpdateBase.Size = new System.Drawing.Size(164, 22);
            this.btnUpdateBase.Text = "Обновить базу";
            this.btnUpdateBase.Click += new System.EventHandler(this.btnUpdateBase_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(161, 6);
            // 
            // MenuLoad
            // 
            this.MenuLoad.Name = "MenuLoad";
            this.MenuLoad.Size = new System.Drawing.Size(164, 22);
            this.MenuLoad.Text = "Загрузить";
            this.MenuLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // MenuTree
            // 
            this.MenuTree.Name = "MenuTree";
            this.MenuTree.Size = new System.Drawing.Size(164, 22);
            this.MenuTree.Text = "Дерево";
            this.MenuTree.Click += new System.EventHandler(this.btnTree_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // экспортВHTMLToolStripMenuItem
            // 
            this.экспортВHTMLToolStripMenuItem.Name = "экспортВHTMLToolStripMenuItem";
            this.экспортВHTMLToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.экспортВHTMLToolStripMenuItem.Text = "Экспорт в HTML";
            // 
            // отчетToolStripMenuItem
            // 
            this.отчетToolStripMenuItem.Name = "отчетToolStripMenuItem";
            this.отчетToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.отчетToolStripMenuItem.Text = "Отчет";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(161, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem,
            this.версииToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // версииToolStripMenuItem
            // 
            this.версииToolStripMenuItem.Name = "версииToolStripMenuItem";
            this.версииToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.версииToolStripMenuItem.Text = "Версии";
            // 
            // treeFolder
            // 
            this.treeFolder.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeFolder.Location = new System.Drawing.Point(0, 24);
            this.treeFolder.Name = "treeFolder";
            this.treeFolder.Size = new System.Drawing.Size(228, 443);
            this.treeFolder.TabIndex = 22;
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Location = new System.Drawing.Point(228, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 443);
            this.splitter1.TabIndex = 23;
            this.splitter1.TabStop = false;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabFilm);
            this.tabControl2.Controls.Add(this.tabWriter);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(231, 24);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(923, 443);
            this.tabControl2.TabIndex = 24;
            // 
            // tabFilm
            // 
            this.tabFilm.Controls.Add(this.dgvTable);
            this.tabFilm.Location = new System.Drawing.Point(4, 22);
            this.tabFilm.Name = "tabFilm";
            this.tabFilm.Padding = new System.Windows.Forms.Padding(3);
            this.tabFilm.Size = new System.Drawing.Size(915, 417);
            this.tabFilm.TabIndex = 0;
            this.tabFilm.Text = "Фильмотека";
            this.tabFilm.UseVisualStyleBackColor = true;
            // 
            // tabWriter
            // 
            this.tabWriter.Location = new System.Drawing.Point(4, 22);
            this.tabWriter.Name = "tabWriter";
            this.tabWriter.Padding = new System.Windows.Forms.Padding(3);
            this.tabWriter.Size = new System.Drawing.Size(915, 417);
            this.tabWriter.TabIndex = 1;
            this.tabWriter.Text = "Редактор";
            this.tabWriter.UseVisualStyleBackColor = true;
            // 
            // timerLoad
            // 
            this.timerLoad.Tick += new System.EventHandler(this.T_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 489);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.treeFolder);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainMenu);
            this.Name = "MainForm";
            this.Text = "Фильмотека";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabFilm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.FolderBrowserDialog browserDialog;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.TreeView treeFolder;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabFilm;
        private System.Windows.Forms.TabPage tabWriter;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuScan;
        private System.Windows.Forms.ToolStripMenuItem MenuLoad;
        private System.Windows.Forms.ToolStripMenuItem MenuTree;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сRefresh;
        private System.Windows.Forms.ToolStripSeparator cSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cAdd;
        private System.Windows.Forms.ToolStripMenuItem cDelete;
        private System.Windows.Forms.ToolStripMenuItem cChange;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem версииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cFind;
        private System.Windows.Forms.ToolStripSeparator cSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem экспортВHTMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cResetTreeFilter;
        private System.Windows.Forms.ToolStripSeparator cSeparator2;
        private System.Windows.Forms.ToolStripMenuItem отчетToolStripMenuItem;
        private System.Windows.Forms.Timer timerLoad;
        private System.Windows.Forms.ToolStripMenuItem btnUpdateBase;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}

