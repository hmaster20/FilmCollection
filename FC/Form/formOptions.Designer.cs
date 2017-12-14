namespace FilmCollection
{
    partial class Options
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
            this.gBoxOptions = new System.Windows.Forms.GroupBox();
            this.lCatalogPath = new System.Windows.Forms.Label();
            this.lCatalog = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.gBoxRecColumn = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clBoxColumnCurrent = new System.Windows.Forms.CheckedListBox();
            this.clBoxColumn = new System.Windows.Forms.CheckedListBox();
            this.ColRemove = new System.Windows.Forms.Button();
            this.ColAdd = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clBoxFormats = new System.Windows.Forms.CheckedListBox();
            this.btnAddSource = new System.Windows.Forms.Button();
            this.btnChangeSource = new System.Windows.Forms.Button();
            this.listBase = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnDelSource = new System.Windows.Forms.Button();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tpCountry = new System.Windows.Forms.TabPage();
            this.lbtpCountry = new System.Windows.Forms.ListBox();
            this.tpGenre = new System.Windows.Forms.TabPage();
            this.lbtpGenre = new System.Windows.Forms.ListBox();
            this.tpCategory = new System.Windows.Forms.TabPage();
            this.lbtpCategory = new System.Windows.Forms.ListBox();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.gBoxOptions.SuspendLayout();
            this.gBoxRecColumn.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tpCountry.SuspendLayout();
            this.tpGenre.SuspendLayout();
            this.tpCategory.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxOptions
            // 
            this.gBoxOptions.Controls.Add(this.lCatalogPath);
            this.gBoxOptions.Controls.Add(this.lCatalog);
            this.gBoxOptions.Location = new System.Drawing.Point(13, 175);
            this.gBoxOptions.Name = "gBoxOptions";
            this.gBoxOptions.Size = new System.Drawing.Size(520, 92);
            this.gBoxOptions.TabIndex = 0;
            this.gBoxOptions.TabStop = false;
            this.gBoxOptions.Text = "Параметры";
            // 
            // lCatalogPath
            // 
            this.lCatalogPath.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lCatalogPath.Location = new System.Drawing.Point(11, 42);
            this.lCatalogPath.Name = "lCatalogPath";
            this.lCatalogPath.Size = new System.Drawing.Size(383, 13);
            this.lCatalogPath.TabIndex = 1;
            this.lCatalogPath.Text = "Путь к каталогу фильмотеки";
            // 
            // lCatalog
            // 
            this.lCatalog.AutoSize = true;
            this.lCatalog.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lCatalog.Location = new System.Drawing.Point(11, 27);
            this.lCatalog.Name = "lCatalog";
            this.lCatalog.Size = new System.Drawing.Size(149, 13);
            this.lCatalog.TabIndex = 2;
            this.lCatalog.Text = "Расположение файла базы:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(20, 24);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(191, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Разрешить сворачивнаие в трей";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(213, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Location = new System.Drawing.Point(316, 352);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Отмена";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // gBoxRecColumn
            // 
            this.gBoxRecColumn.Controls.Add(this.label2);
            this.gBoxRecColumn.Controls.Add(this.label1);
            this.gBoxRecColumn.Controls.Add(this.clBoxColumnCurrent);
            this.gBoxRecColumn.Controls.Add(this.clBoxColumn);
            this.gBoxRecColumn.Controls.Add(this.ColRemove);
            this.gBoxRecColumn.Controls.Add(this.ColAdd);
            this.gBoxRecColumn.Location = new System.Drawing.Point(13, 9);
            this.gBoxRecColumn.Name = "gBoxRecColumn";
            this.gBoxRecColumn.Size = new System.Drawing.Size(336, 264);
            this.gBoxRecColumn.TabIndex = 5;
            this.gBoxRecColumn.TabStop = false;
            this.gBoxRecColumn.Text = "Настройка столбцов фильмотеки";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Активные столбцы";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Все столбцы";
            // 
            // clBoxColumnCurrent
            // 
            this.clBoxColumnCurrent.BackColor = System.Drawing.SystemColors.Control;
            this.clBoxColumnCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clBoxColumnCurrent.FormattingEnabled = true;
            this.clBoxColumnCurrent.Location = new System.Drawing.Point(191, 46);
            this.clBoxColumnCurrent.Name = "clBoxColumnCurrent";
            this.clBoxColumnCurrent.Size = new System.Drawing.Size(120, 197);
            this.clBoxColumnCurrent.TabIndex = 6;
            // 
            // clBoxColumn
            // 
            this.clBoxColumn.BackColor = System.Drawing.SystemColors.Control;
            this.clBoxColumn.FormattingEnabled = true;
            this.clBoxColumn.Location = new System.Drawing.Point(24, 46);
            this.clBoxColumn.Name = "clBoxColumn";
            this.clBoxColumn.Size = new System.Drawing.Size(120, 199);
            this.clBoxColumn.TabIndex = 6;
            // 
            // ColRemove
            // 
            this.ColRemove.Location = new System.Drawing.Point(150, 124);
            this.ColRemove.Name = "ColRemove";
            this.ColRemove.Size = new System.Drawing.Size(35, 23);
            this.ColRemove.TabIndex = 8;
            this.ColRemove.Text = "<<";
            this.ColRemove.UseVisualStyleBackColor = true;
            this.ColRemove.Click += new System.EventHandler(this.ColRemove_Click);
            // 
            // ColAdd
            // 
            this.ColAdd.Location = new System.Drawing.Point(150, 95);
            this.ColAdd.Name = "ColAdd";
            this.ColAdd.Size = new System.Drawing.Size(35, 23);
            this.ColAdd.TabIndex = 8;
            this.ColAdd.Text = ">>";
            this.ColAdd.UseVisualStyleBackColor = true;
            this.ColAdd.Click += new System.EventHandler(this.ColAdd_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 10;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(136, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Добавить";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(136, 49);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "Удалить";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.clBoxFormats);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 270);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление новых форматов";
            // 
            // clBoxFormats
            // 
            this.clBoxFormats.BackColor = System.Drawing.SystemColors.Control;
            this.clBoxFormats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clBoxFormats.FormattingEnabled = true;
            this.clBoxFormats.Location = new System.Drawing.Point(10, 45);
            this.clBoxFormats.Name = "clBoxFormats";
            this.clBoxFormats.Size = new System.Drawing.Size(120, 212);
            this.clBoxFormats.TabIndex = 6;
            // 
            // btnAddSource
            // 
            this.btnAddSource.Location = new System.Drawing.Point(452, 17);
            this.btnAddSource.Name = "btnAddSource";
            this.btnAddSource.Size = new System.Drawing.Size(75, 23);
            this.btnAddSource.TabIndex = 15;
            this.btnAddSource.Text = "Добавить";
            this.btnAddSource.UseVisualStyleBackColor = true;
            this.btnAddSource.Click += new System.EventHandler(this.btnAddSource_Click);
            // 
            // btnChangeSource
            // 
            this.btnChangeSource.Location = new System.Drawing.Point(452, 46);
            this.btnChangeSource.Name = "btnChangeSource";
            this.btnChangeSource.Size = new System.Drawing.Size(75, 23);
            this.btnChangeSource.TabIndex = 15;
            this.btnChangeSource.Text = "Изменить";
            this.btnChangeSource.UseVisualStyleBackColor = true;
            this.btnChangeSource.Click += new System.EventHandler(this.btnChangeSource_Click);
            // 
            // listBase
            // 
            this.listBase.FormattingEnabled = true;
            this.listBase.Location = new System.Drawing.Point(20, 17);
            this.listBase.Name = "listBase";
            this.listBase.Size = new System.Drawing.Size(416, 225);
            this.listBase.TabIndex = 16;
            this.listBase.SelectedValueChanged += new System.EventHandler(this.listBase_SelectedValueChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(553, 319);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.listBase);
            this.tabPage1.Controls.Add(this.btnAddSource);
            this.tabPage1.Controls.Add(this.btnDelSource);
            this.tabPage1.Controls.Add(this.btnChangeSource);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(545, 293);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Источник файлов";
            // 
            // btnDelSource
            // 
            this.btnDelSource.Location = new System.Drawing.Point(452, 75);
            this.btnDelSource.Name = "btnDelSource";
            this.btnDelSource.Size = new System.Drawing.Size(75, 23);
            this.btnDelSource.TabIndex = 15;
            this.btnDelSource.Text = "Удалить";
            this.btnDelSource.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage8.Controls.Add(this.gBoxOptions);
            this.tabPage8.Controls.Add(this.groupBox2);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(545, 293);
            this.tabPage8.TabIndex = 4;
            this.tabPage8.Text = "Резервное копирование";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.numericUpDown2);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Location = new System.Drawing.Point(13, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(520, 147);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Резервное копирование";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(471, 110);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 23);
            this.button2.TabIndex = 14;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(187, 112);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(278, 20);
            this.textBox2.TabIndex = 13;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(167, 81);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(54, 20);
            this.numericUpDown2.TabIndex = 12;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(167, 49);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(54, 20);
            this.numericUpDown1.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Каталог для резервных копий";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Интервал между копиями";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Хранить число копий";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(20, 28);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(323, 17);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "Разрешить автоматическое резервное копирование базы";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.gBoxRecColumn);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(545, 293);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Столбцы";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(545, 293);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Форматы файлов";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tabControl2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(545, 293);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Справочники";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl2.Controls.Add(this.tpCountry);
            this.tabControl2.Controls.Add(this.tpGenre);
            this.tabControl2.Controls.Add(this.tpCategory);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl2.ItemSize = new System.Drawing.Size(25, 120);
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(545, 293);
            this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl2.TabIndex = 0;
            this.tabControl2.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl2_DrawItem);
            // 
            // tpCountry
            // 
            this.tpCountry.Controls.Add(this.lbtpCountry);
            this.tpCountry.Location = new System.Drawing.Point(124, 4);
            this.tpCountry.Name = "tpCountry";
            this.tpCountry.Padding = new System.Windows.Forms.Padding(3);
            this.tpCountry.Size = new System.Drawing.Size(417, 285);
            this.tpCountry.TabIndex = 0;
            this.tpCountry.Text = "Страны";
            // 
            // lbtpCountry
            // 
            this.lbtpCountry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbtpCountry.FormattingEnabled = true;
            this.lbtpCountry.Location = new System.Drawing.Point(3, 3);
            this.lbtpCountry.Name = "lbtpCountry";
            this.lbtpCountry.Size = new System.Drawing.Size(411, 279);
            this.lbtpCountry.TabIndex = 0;
            // 
            // tpGenre
            // 
            this.tpGenre.BackColor = System.Drawing.SystemColors.Control;
            this.tpGenre.Controls.Add(this.lbtpGenre);
            this.tpGenre.Location = new System.Drawing.Point(124, 4);
            this.tpGenre.Name = "tpGenre";
            this.tpGenre.Padding = new System.Windows.Forms.Padding(3);
            this.tpGenre.Size = new System.Drawing.Size(417, 285);
            this.tpGenre.TabIndex = 1;
            this.tpGenre.Text = "Жанры";
            // 
            // lbtpGenre
            // 
            this.lbtpGenre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbtpGenre.FormattingEnabled = true;
            this.lbtpGenre.Location = new System.Drawing.Point(3, 3);
            this.lbtpGenre.Name = "lbtpGenre";
            this.lbtpGenre.Size = new System.Drawing.Size(411, 279);
            this.lbtpGenre.TabIndex = 0;
            // 
            // tpCategory
            // 
            this.tpCategory.BackColor = System.Drawing.SystemColors.Control;
            this.tpCategory.Controls.Add(this.lbtpCategory);
            this.tpCategory.Location = new System.Drawing.Point(124, 4);
            this.tpCategory.Name = "tpCategory";
            this.tpCategory.Size = new System.Drawing.Size(417, 285);
            this.tpCategory.TabIndex = 2;
            this.tpCategory.Text = "Категории";
            // 
            // lbtpCategory
            // 
            this.lbtpCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbtpCategory.FormattingEnabled = true;
            this.lbtpCategory.Location = new System.Drawing.Point(0, 0);
            this.lbtpCategory.Name = "lbtpCategory";
            this.lbtpCategory.Size = new System.Drawing.Size(417, 285);
            this.lbtpCategory.TabIndex = 0;
            // 
            // tabPage9
            // 
            this.tabPage9.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage9.Controls.Add(this.checkBox1);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(545, 293);
            this.tabPage9.TabIndex = 5;
            this.tabPage9.Text = "Прочие";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 394);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Options_FormClosing);
            this.gBoxOptions.ResumeLayout(false);
            this.gBoxOptions.PerformLayout();
            this.gBoxRecColumn.ResumeLayout(false);
            this.gBoxRecColumn.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tpCountry.ResumeLayout(false);
            this.tpGenre.ResumeLayout(false);
            this.tpCategory.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxOptions;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lCatalog;
        private System.Windows.Forms.GroupBox gBoxRecColumn;
        private System.Windows.Forms.CheckedListBox clBoxColumn;
        private System.Windows.Forms.Label lCatalogPath;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox clBoxFormats;
        private System.Windows.Forms.CheckedListBox clBoxColumnCurrent;
        private System.Windows.Forms.Button ColRemove;
        private System.Windows.Forms.Button ColAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddSource;
        private System.Windows.Forms.Button btnChangeSource;
        private System.Windows.Forms.ListBox listBase;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tpCountry;
        private System.Windows.Forms.TabPage tpGenre;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tpCategory;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.ListBox lbtpCountry;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.ListBox lbtpGenre;
        private System.Windows.Forms.ListBox lbtpCategory;
        private System.Windows.Forms.Button btnDelSource;
    }
}