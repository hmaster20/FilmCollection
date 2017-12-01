namespace FilmCollection
{
    partial class ucSelectCatalog
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBase = new System.Windows.Forms.ListBox();
            this.btnAddSource = new System.Windows.Forms.Button();
            this.btnDelSource = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBase
            // 
            this.listBase.FormattingEnabled = true;
            this.listBase.Location = new System.Drawing.Point(13, 14);
            this.listBase.Name = "listBase";
            this.listBase.Size = new System.Drawing.Size(416, 173);
            this.listBase.TabIndex = 19;
            // 
            // btnAddSource
            // 
            this.btnAddSource.Location = new System.Drawing.Point(445, 14);
            this.btnAddSource.Name = "btnAddSource";
            this.btnAddSource.Size = new System.Drawing.Size(75, 23);
            this.btnAddSource.TabIndex = 17;
            this.btnAddSource.Text = "Добавить";
            this.btnAddSource.UseVisualStyleBackColor = true;
            this.btnAddSource.Click += new System.EventHandler(this.btnAddSource_Click);
            // 
            // btnDelSource
            // 
            this.btnDelSource.Location = new System.Drawing.Point(445, 43);
            this.btnDelSource.Name = "btnDelSource";
            this.btnDelSource.Size = new System.Drawing.Size(75, 23);
            this.btnDelSource.TabIndex = 18;
            this.btnDelSource.Text = "Удалить";
            this.btnDelSource.UseVisualStyleBackColor = true;
            this.btnDelSource.Click += new System.EventHandler(this.btnDelSource_Click);
            // 
            // ucSelectCatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBase);
            this.Controls.Add(this.btnAddSource);
            this.Controls.Add(this.btnDelSource);
            this.Name = "ucSelectCatalog";
            this.Size = new System.Drawing.Size(534, 207);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBase;
        private System.Windows.Forms.Button btnAddSource;
        private System.Windows.Forms.Button btnDelSource;
    }
}
