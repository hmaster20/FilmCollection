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
            this.clBoxColumn = new System.Windows.Forms.CheckedListBox();
            this.lBoxColumnSelected = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.gBoxOptions.SuspendLayout();
            this.gBoxRecColumn.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxOptions
            // 
            this.gBoxOptions.Controls.Add(this.lCatalogPath);
            this.gBoxOptions.Controls.Add(this.lBasePath);
            this.gBoxOptions.Controls.Add(this.lCatalog);
            this.gBoxOptions.Controls.Add(this.lBase);
            this.gBoxOptions.Location = new System.Drawing.Point(12, 231);
            this.gBoxOptions.Name = "gBoxOptions";
            this.gBoxOptions.Size = new System.Drawing.Size(494, 76);
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
            this.button1.Location = new System.Drawing.Point(129, 326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Location = new System.Drawing.Point(311, 326);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Отмена";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // gBoxRecColumn
            // 
            this.gBoxRecColumn.Controls.Add(this.button2);
            this.gBoxRecColumn.Controls.Add(this.clBoxColumn);
            this.gBoxRecColumn.Controls.Add(this.lBoxColumnSelected);
            this.gBoxRecColumn.Location = new System.Drawing.Point(15, 12);
            this.gBoxRecColumn.Name = "gBoxRecColumn";
            this.gBoxRecColumn.Size = new System.Drawing.Size(491, 213);
            this.gBoxRecColumn.TabIndex = 5;
            this.gBoxRecColumn.TabStop = false;
            this.gBoxRecColumn.Text = "Настройка столбцов фильмотеки";
            // 
            // clBoxColumn
            // 
            this.clBoxColumn.BackColor = System.Drawing.SystemColors.Control;
            this.clBoxColumn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clBoxColumn.FormattingEnabled = true;
            this.clBoxColumn.Location = new System.Drawing.Point(16, 23);
            this.clBoxColumn.Name = "clBoxColumn";
            this.clBoxColumn.Size = new System.Drawing.Size(120, 165);
            this.clBoxColumn.TabIndex = 6;
            // 
            // lBoxColumnSelected
            // 
            this.lBoxColumnSelected.BackColor = System.Drawing.SystemColors.Control;
            this.lBoxColumnSelected.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lBoxColumnSelected.FormattingEnabled = true;
            this.lBoxColumnSelected.Location = new System.Drawing.Point(169, 23);
            this.lBoxColumnSelected.Name = "lBoxColumnSelected";
            this.lBoxColumnSelected.Size = new System.Drawing.Size(120, 169);
            this.lBoxColumnSelected.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(363, 169);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 361);
            this.Controls.Add(this.gBoxRecColumn);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gBoxOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Параметры";
            this.gBoxOptions.ResumeLayout(false);
            this.gBoxOptions.PerformLayout();
            this.gBoxRecColumn.ResumeLayout(false);
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
        private System.Windows.Forms.ListBox lBoxColumnSelected;
        private System.Windows.Forms.Label lCatalogPath;
        private System.Windows.Forms.Label lBasePath;
        private System.Windows.Forms.Button button2;
    }
}