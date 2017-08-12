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
            this.lBasePath = new System.Windows.Forms.Label();
            this.lCatalog = new System.Windows.Forms.Label();
            this.lBase = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.gBoxRecColumn = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.clBoxColumn = new System.Windows.Forms.CheckedListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clBoxFormats = new System.Windows.Forms.CheckedListBox();
            this.ColAdd = new System.Windows.Forms.Button();
            this.ColRemove = new System.Windows.Forms.Button();
            this.clBoxColumnCurrent = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gBoxOptions.SuspendLayout();
            this.gBoxRecColumn.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxOptions
            // 
            this.gBoxOptions.Controls.Add(this.checkBox1);
            this.gBoxOptions.Controls.Add(this.lCatalogPath);
            this.gBoxOptions.Controls.Add(this.lBasePath);
            this.gBoxOptions.Controls.Add(this.lCatalog);
            this.gBoxOptions.Controls.Add(this.lBase);
            this.gBoxOptions.Location = new System.Drawing.Point(12, 282);
            this.gBoxOptions.Name = "gBoxOptions";
            this.gBoxOptions.Size = new System.Drawing.Size(549, 100);
            this.gBoxOptions.TabIndex = 0;
            this.gBoxOptions.TabStop = false;
            this.gBoxOptions.Text = "Параметры";
            // 
            // lCatalogPath
            // 
            this.lCatalogPath.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lCatalogPath.Location = new System.Drawing.Point(70, 50);
            this.lCatalogPath.Name = "lCatalogPath";
            this.lCatalogPath.Size = new System.Drawing.Size(418, 13);
            this.lCatalogPath.TabIndex = 1;
            this.lCatalogPath.Text = "Путь к каталогу фильмотеки";
            // 
            // lBasePath
            // 
            this.lBasePath.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lBasePath.Location = new System.Drawing.Point(70, 24);
            this.lBasePath.Name = "lBasePath";
            this.lBasePath.Size = new System.Drawing.Size(418, 13);
            this.lBasePath.TabIndex = 1;
            this.lBasePath.Text = "Путь к файлу базы";
            // 
            // lCatalog
            // 
            this.lCatalog.AutoSize = true;
            this.lCatalog.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lCatalog.Location = new System.Drawing.Point(16, 50);
            this.lCatalog.Name = "lCatalog";
            this.lCatalog.Size = new System.Drawing.Size(51, 13);
            this.lCatalog.TabIndex = 2;
            this.lCatalog.Text = "Каталог:";
            // 
            // lBase
            // 
            this.lBase.AutoSize = true;
            this.lBase.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lBase.Location = new System.Drawing.Point(16, 24);
            this.lBase.Name = "lBase";
            this.lBase.Size = new System.Drawing.Size(35, 13);
            this.lBase.TabIndex = 1;
            this.lBase.Text = "База:";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(196, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Location = new System.Drawing.Point(295, 395);
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
            this.gBoxRecColumn.Location = new System.Drawing.Point(239, 12);
            this.gBoxRecColumn.Name = "gBoxRecColumn";
            this.gBoxRecColumn.Size = new System.Drawing.Size(322, 264);
            this.gBoxRecColumn.TabIndex = 5;
            this.gBoxRecColumn.TabStop = false;
            this.gBoxRecColumn.Text = "Настройка столбцов фильмотеки";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(19, 77);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(191, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Разрешить сворачивнаие в трей";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // clBoxColumn
            // 
            this.clBoxColumn.BackColor = System.Drawing.SystemColors.Control;
            this.clBoxColumn.FormattingEnabled = true;
            this.clBoxColumn.Location = new System.Drawing.Point(24, 45);
            this.clBoxColumn.Name = "clBoxColumn";
            this.clBoxColumn.Size = new System.Drawing.Size(120, 184);
            this.clBoxColumn.TabIndex = 6;
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
            this.button5.Location = new System.Drawing.Point(10, 233);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(120, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "Удалить выбранные";
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
            this.groupBox1.Size = new System.Drawing.Size(221, 264);
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
            this.clBoxFormats.Size = new System.Drawing.Size(120, 182);
            this.clBoxFormats.TabIndex = 6;
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
            // clBoxColumnCurrent
            // 
            this.clBoxColumnCurrent.BackColor = System.Drawing.SystemColors.Control;
            this.clBoxColumnCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clBoxColumnCurrent.FormattingEnabled = true;
            this.clBoxColumnCurrent.Location = new System.Drawing.Point(191, 46);
            this.clBoxColumnCurrent.Name = "clBoxColumnCurrent";
            this.clBoxColumnCurrent.Size = new System.Drawing.Size(120, 182);
            this.clBoxColumnCurrent.TabIndex = 6;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Активные столбцы";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 428);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gBoxRecColumn);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gBoxOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Параметры";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Options_FormClosing);
            this.gBoxOptions.ResumeLayout(false);
            this.gBoxOptions.PerformLayout();
            this.gBoxRecColumn.ResumeLayout(false);
            this.gBoxRecColumn.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxOptions;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lCatalog;
        private System.Windows.Forms.Label lBase;
        private System.Windows.Forms.GroupBox gBoxRecColumn;
        private System.Windows.Forms.CheckedListBox clBoxColumn;
        private System.Windows.Forms.Label lCatalogPath;
        private System.Windows.Forms.Label lBasePath;
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
    }
}