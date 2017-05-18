namespace FilmCollection
{
    partial class ucMediaInfo
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbActors = new System.Windows.Forms.ListBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.lblRecDescription = new System.Windows.Forms.Label();
            this.lblRecRole = new System.Windows.Forms.Label();
            this.lblRecCountry = new System.Windows.Forms.Label();
            this.lblRecYear = new System.Windows.Forms.Label();
            this.lblRecName = new System.Windows.Forms.Label();
            this.tbfDesc = new System.Windows.Forms.TextBox();
            this.tbfCountry = new System.Windows.Forms.TextBox();
            this.tbfYear = new System.Windows.Forms.TextBox();
            this.tbfName = new System.Windows.Forms.TextBox();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lblRecTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.panelTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbActors
            // 
            this.lbActors.BackColor = System.Drawing.SystemColors.Control;
            this.lbActors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbActors.Location = new System.Drawing.Point(26, 117);
            this.lbActors.Name = "lbActors";
            this.lbActors.Size = new System.Drawing.Size(134, 169);
            this.lbActors.TabIndex = 69;
            // 
            // pbImage
            // 
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Location = new System.Drawing.Point(166, 41);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(202, 301);
            this.pbImage.TabIndex = 68;
            this.pbImage.TabStop = false;
            // 
            // btnPlay
            // 
            this.btnPlay.Enabled = false;
            this.btnPlay.Image = global::FilmCollection.Properties.Resources.play;
            this.btnPlay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlay.Location = new System.Drawing.Point(24, 293);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(111, 23);
            this.btnPlay.TabIndex = 62;
            this.btnPlay.Text = "Воспроизвести";
            this.btnPlay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // lblRecDescription
            // 
            this.lblRecDescription.AutoSize = true;
            this.lblRecDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRecDescription.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRecDescription.Location = new System.Drawing.Point(20, 322);
            this.lblRecDescription.Name = "lblRecDescription";
            this.lblRecDescription.Size = new System.Drawing.Size(82, 17);
            this.lblRecDescription.TabIndex = 61;
            this.lblRecDescription.Text = " Описание:";
            // 
            // lblRecRole
            // 
            this.lblRecRole.AutoSize = true;
            this.lblRecRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRecRole.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRecRole.Location = new System.Drawing.Point(23, 98);
            this.lblRecRole.Name = "lblRecRole";
            this.lblRecRole.Size = new System.Drawing.Size(121, 17);
            this.lblRecRole.TabIndex = 57;
            this.lblRecRole.Text = "Роли исполняют:";
            // 
            // lblRecCountry
            // 
            this.lblRecCountry.AutoSize = true;
            this.lblRecCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRecCountry.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRecCountry.Location = new System.Drawing.Point(22, 58);
            this.lblRecCountry.Name = "lblRecCountry";
            this.lblRecCountry.Size = new System.Drawing.Size(60, 17);
            this.lblRecCountry.TabIndex = 58;
            this.lblRecCountry.Text = "Страна:";
            // 
            // lblRecYear
            // 
            this.lblRecYear.AutoSize = true;
            this.lblRecYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRecYear.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRecYear.Location = new System.Drawing.Point(21, 36);
            this.lblRecYear.Name = "lblRecYear";
            this.lblRecYear.Size = new System.Drawing.Size(36, 17);
            this.lblRecYear.TabIndex = 59;
            this.lblRecYear.Text = "Год:";
            // 
            // lblRecName
            // 
            this.lblRecName.AutoSize = true;
            this.lblRecName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRecName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRecName.Location = new System.Drawing.Point(16, 17);
            this.lblRecName.Name = "lblRecName";
            this.lblRecName.Size = new System.Drawing.Size(80, 17);
            this.lblRecName.TabIndex = 60;
            this.lblRecName.Text = " Название:";
            // 
            // tbfDesc
            // 
            this.tbfDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbfDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbfDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbfDesc.Location = new System.Drawing.Point(19, 348);
            this.tbfDesc.Multiline = true;
            this.tbfDesc.Name = "tbfDesc";
            this.tbfDesc.ReadOnly = true;
            this.tbfDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbfDesc.Size = new System.Drawing.Size(349, 239);
            this.tbfDesc.TabIndex = 67;
            // 
            // tbfCountry
            // 
            this.tbfCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbfCountry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbfCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbfCountry.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbfCountry.Location = new System.Drawing.Point(26, 79);
            this.tbfCountry.Name = "tbfCountry";
            this.tbfCountry.ReadOnly = true;
            this.tbfCountry.Size = new System.Drawing.Size(118, 16);
            this.tbfCountry.TabIndex = 63;
            // 
            // tbfYear
            // 
            this.tbfYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbfYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbfYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbfYear.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbfYear.Location = new System.Drawing.Point(59, 39);
            this.tbfYear.Name = "tbfYear";
            this.tbfYear.ReadOnly = true;
            this.tbfYear.Size = new System.Drawing.Size(82, 16);
            this.tbfYear.TabIndex = 64;
            // 
            // tbfName
            // 
            this.tbfName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbfName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbfName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbfName.Location = new System.Drawing.Point(97, 19);
            this.tbfName.Name = "tbfName";
            this.tbfName.ReadOnly = true;
            this.tbfName.Size = new System.Drawing.Size(271, 16);
            this.tbfName.TabIndex = 65;
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.lblRecTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(386, 27);
            this.panelTitle.TabIndex = 66;
            // 
            // lblRecTitle
            // 
            this.lblRecTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRecTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRecTitle.Location = new System.Drawing.Point(0, 0);
            this.lblRecTitle.Name = "lblRecTitle";
            this.lblRecTitle.Size = new System.Drawing.Size(386, 27);
            this.lblRecTitle.TabIndex = 0;
            this.lblRecTitle.Text = "Общие сведения";
            this.lblRecTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbfCountry);
            this.panel1.Controls.Add(this.lblRecName);
            this.panel1.Controls.Add(this.tbfYear);
            this.panel1.Controls.Add(this.lbActors);
            this.panel1.Controls.Add(this.tbfName);
            this.panel1.Controls.Add(this.tbfDesc);
            this.panel1.Controls.Add(this.pbImage);
            this.panel1.Controls.Add(this.lblRecYear);
            this.panel1.Controls.Add(this.btnPlay);
            this.panel1.Controls.Add(this.lblRecCountry);
            this.panel1.Controls.Add(this.lblRecDescription);
            this.panel1.Controls.Add(this.lblRecRole);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 599);
            this.panel1.TabIndex = 70;
            // 
            // ucMediaInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTitle);
            this.Name = "ucMediaInfo";
            this.Size = new System.Drawing.Size(386, 626);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbActors;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblRecDescription;
        private System.Windows.Forms.Label lblRecRole;
        private System.Windows.Forms.Label lblRecCountry;
        private System.Windows.Forms.Label lblRecYear;
        private System.Windows.Forms.Label lblRecName;
        private System.Windows.Forms.TextBox tbfDesc;
        private System.Windows.Forms.TextBox tbfCountry;
        private System.Windows.Forms.TextBox tbfYear;
        private System.Windows.Forms.TextBox tbfName;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label lblRecTitle;
        private System.Windows.Forms.Panel panel1;
    }
}
