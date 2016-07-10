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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnScanDir = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.treeFolder = new System.Windows.Forms.TreeView();
            this.btnTree = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(362, 49);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(403, 150);
            this.dataGridView1.TabIndex = 9;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Name";
            this.Column1.HeaderText = "Название";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Year";
            this.Column2.HeaderText = "Год";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Type";
            this.Column3.HeaderText = "Тип";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Path";
            this.Column4.HeaderText = "Путь";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // btnScanDir
            // 
            this.btnScanDir.Location = new System.Drawing.Point(362, 218);
            this.btnScanDir.Name = "btnScanDir";
            this.btnScanDir.Size = new System.Drawing.Size(86, 46);
            this.btnScanDir.TabIndex = 10;
            this.btnScanDir.Text = "Сканировать папку";
            this.btnScanDir.UseVisualStyleBackColor = true;
            this.btnScanDir.Click += new System.EventHandler(this.btnScanDir_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(476, 220);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(80, 44);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "Загрузить конфиг";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // treeFolder
            // 
            this.treeFolder.Location = new System.Drawing.Point(16, 49);
            this.treeFolder.Name = "treeFolder";
            this.treeFolder.Size = new System.Drawing.Size(308, 150);
            this.treeFolder.TabIndex = 12;
            // 
            // btnTree
            // 
            this.btnTree.Location = new System.Drawing.Point(150, 231);
            this.btnTree.Name = "btnTree";
            this.btnTree.Size = new System.Drawing.Size(75, 23);
            this.btnTree.TabIndex = 13;
            this.btnTree.Text = "btnTree";
            this.btnTree.UseVisualStyleBackColor = true;
            this.btnTree.Click += new System.EventHandler(this.btnTree_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 604);
            this.Controls.Add(this.btnTree);
            this.Controls.Add(this.treeFolder);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnScanDir);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnScanDir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TreeView treeFolder;
        private System.Windows.Forms.Button btnTree;
    }
}

