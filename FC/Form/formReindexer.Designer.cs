namespace FilmCollection
{
    partial class formReindexer
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
            this.btnParse = new System.Windows.Forms.Button();
            this.btnFix = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelErrorCount = new System.Windows.Forms.Label();
            this.groupBoxCheck = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBoxCheck.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(15, 23);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(143, 23);
            this.btnParse.TabIndex = 0;
            this.btnParse.Text = "Выполнить проверку";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // btnFix
            // 
            this.btnFix.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnFix.Enabled = false;
            this.btnFix.Image = global::FilmCollection.Properties.Resources.check;
            this.btnFix.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFix.Location = new System.Drawing.Point(320, 369);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(104, 23);
            this.btnFix.TabIndex = 1;
            this.btnFix.Text = "Исправить";
            this.btnFix.UseVisualStyleBackColor = true;
            this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowDrop = true;
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView2.Location = new System.Drawing.Point(15, 61);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(397, 240);
            this.dataGridView2.TabIndex = 8;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "value";
            this.Column1.HeaderText = "Индекс";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "key";
            this.Column2.HeaderText = "Название";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // labelErrorCount
            // 
            this.labelErrorCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelErrorCount.Location = new System.Drawing.Point(13, 308);
            this.labelErrorCount.Name = "labelErrorCount";
            this.labelErrorCount.Size = new System.Drawing.Size(395, 20);
            this.labelErrorCount.TabIndex = 10;
            this.labelErrorCount.Text = "Найдено ошибочных элементов";
            // 
            // groupBoxCheck
            // 
            this.groupBoxCheck.Controls.Add(this.dataGridView2);
            this.groupBoxCheck.Controls.Add(this.labelErrorCount);
            this.groupBoxCheck.Controls.Add(this.btnParse);
            this.groupBoxCheck.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCheck.Name = "groupBoxCheck";
            this.groupBoxCheck.Size = new System.Drawing.Size(428, 337);
            this.groupBoxCheck.TabIndex = 11;
            this.groupBoxCheck.TabStop = false;
            this.groupBoxCheck.Text = "Проверка базы";
            // 
            // formReindexer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 404);
            this.Controls.Add(this.groupBoxCheck);
            this.Controls.Add(this.btnFix);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formReindexer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reindexer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBoxCheck.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.Button btnFix;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label labelErrorCount;
        private System.Windows.Forms.GroupBox groupBoxCheck;
    }
}