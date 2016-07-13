namespace FilmCollection
{
    partial class EditForm
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
            this.btnEditOk = new System.Windows.Forms.Button();
            this.btnEditCancel = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.tbCountry = new System.Windows.Forms.TextBox();
            this.cBoxGenre = new System.Windows.Forms.ComboBox();
            this.lblGenre = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.dynamicRichTextBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnUpSize = new System.Windows.Forms.Button();
            this.btnDownSize = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.cBoxTypeVideo = new System.Windows.Forms.ComboBox();
            this.labelTypeVideo = new System.Windows.Forms.Label();
            this.toolTipEditForm = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditOk
            // 
            this.btnEditOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnEditOk.Location = new System.Drawing.Point(138, 430);
            this.btnEditOk.Name = "btnEditOk";
            this.btnEditOk.Size = new System.Drawing.Size(75, 23);
            this.btnEditOk.TabIndex = 0;
            this.btnEditOk.Text = "Ok";
            this.btnEditOk.UseVisualStyleBackColor = true;
            // 
            // btnEditCancel
            // 
            this.btnEditCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEditCancel.Location = new System.Drawing.Point(313, 430);
            this.btnEditCancel.Name = "btnEditCancel";
            this.btnEditCancel.Size = new System.Drawing.Size(75, 23);
            this.btnEditCancel.TabIndex = 1;
            this.btnEditCancel.Text = "Отмена";
            this.btnEditCancel.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(43, 28);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = " Название";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(46, 57);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(25, 13);
            this.lblYear.TabIndex = 3;
            this.lblYear.Text = "Год";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(46, 86);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(43, 13);
            this.lblCountry.TabIndex = 4;
            this.lblCountry.Text = "Страна";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(129, 25);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(259, 20);
            this.tbName.TabIndex = 5;
            // 
            // tbYear
            // 
            this.tbYear.Location = new System.Drawing.Point(129, 54);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(259, 20);
            this.tbYear.TabIndex = 5;
            // 
            // tbCountry
            // 
            this.tbCountry.Location = new System.Drawing.Point(129, 83);
            this.tbCountry.Name = "tbCountry";
            this.tbCountry.Size = new System.Drawing.Size(259, 20);
            this.tbCountry.TabIndex = 5;
            // 
            // cBoxGenre
            // 
            this.cBoxGenre.FormattingEnabled = true;
            this.cBoxGenre.Location = new System.Drawing.Point(129, 112);
            this.cBoxGenre.Name = "cBoxGenre";
            this.cBoxGenre.Size = new System.Drawing.Size(259, 21);
            this.cBoxGenre.TabIndex = 6;
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(46, 115);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(36, 13);
            this.lblGenre.TabIndex = 4;
            this.lblGenre.Text = "Жанр";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(129, 172);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(259, 20);
            this.numericUpDown1.TabIndex = 7;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(46, 174);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(40, 13);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "Время";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(46, 205);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(57, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Описание";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(129, 202);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(259, 47);
            this.tbDescription.TabIndex = 5;
            // 
            // dynamicRichTextBox
            // 
            this.dynamicRichTextBox.Location = new System.Drawing.Point(149, 326);
            this.dynamicRichTextBox.Name = "dynamicRichTextBox";
            this.dynamicRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.dynamicRichTextBox.Size = new System.Drawing.Size(359, 87);
            this.dynamicRichTextBox.TabIndex = 8;
            this.dynamicRichTextBox.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(37, 377);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(149, 297);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(44, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Bold";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnBold_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(199, 297);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(44, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "italy";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnItalic_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(249, 297);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(44, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "Under";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnUnderline_Click);
            // 
            // btnUpSize
            // 
            this.btnUpSize.Location = new System.Drawing.Point(299, 297);
            this.btnUpSize.Name = "btnUpSize";
            this.btnUpSize.Size = new System.Drawing.Size(54, 23);
            this.btnUpSize.TabIndex = 12;
            this.btnUpSize.Text = "UpSize";
            this.btnUpSize.UseVisualStyleBackColor = true;
            this.btnUpSize.Click += new System.EventHandler(this.btnSizePlus_Click);
            // 
            // btnDownSize
            // 
            this.btnDownSize.Location = new System.Drawing.Point(359, 297);
            this.btnDownSize.Name = "btnDownSize";
            this.btnDownSize.Size = new System.Drawing.Size(68, 23);
            this.btnDownSize.TabIndex = 12;
            this.btnDownSize.Text = "DownSize";
            this.btnDownSize.UseVisualStyleBackColor = true;
            this.btnDownSize.Click += new System.EventHandler(this.btnSizeMinus_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(433, 297);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 13;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // cBoxTypeVideo
            // 
            this.cBoxTypeVideo.FormattingEnabled = true;
            this.cBoxTypeVideo.Items.AddRange(new object[] {
            "Фильм",
            "Сериал",
            "Мультфильм"});
            this.cBoxTypeVideo.Location = new System.Drawing.Point(129, 142);
            this.cBoxTypeVideo.Name = "cBoxTypeVideo";
            this.cBoxTypeVideo.Size = new System.Drawing.Size(259, 21);
            this.cBoxTypeVideo.TabIndex = 14;
            // 
            // labelTypeVideo
            // 
            this.labelTypeVideo.AutoSize = true;
            this.labelTypeVideo.Location = new System.Drawing.Point(46, 145);
            this.labelTypeVideo.Name = "labelTypeVideo";
            this.labelTypeVideo.Size = new System.Drawing.Size(26, 13);
            this.labelTypeVideo.TabIndex = 4;
            this.labelTypeVideo.Text = "Тип";
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 478);
            this.Controls.Add(this.cBoxTypeVideo);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btnDownSize);
            this.Controls.Add(this.btnUpSize);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dynamicRichTextBox);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.cBoxGenre);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbCountry);
            this.Controls.Add(this.tbYear);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.labelTypeVideo);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnEditCancel);
            this.Controls.Add(this.btnEditOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditForm";
            this.Load += new System.EventHandler(this.EditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEditOk;
        private System.Windows.Forms.Button btnEditCancel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.TextBox tbCountry;
        private System.Windows.Forms.ComboBox cBoxGenre;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox dynamicRichTextBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnUpSize;
        private System.Windows.Forms.Button btnDownSize;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox cBoxTypeVideo;
        private System.Windows.Forms.Label labelTypeVideo;
        private System.Windows.Forms.ToolTip toolTipEditForm;
    }
}