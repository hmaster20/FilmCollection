namespace FilmCollection
{
    partial class RecoveryForm
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
            this.btnEditCancel = new System.Windows.Forms.Button();
            this.btnEditOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.cbBadBase = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnEditCancel
            // 
            this.btnEditCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEditCancel.Location = new System.Drawing.Point(205, 270);
            this.btnEditCancel.Name = "btnEditCancel";
            this.btnEditCancel.Size = new System.Drawing.Size(75, 23);
            this.btnEditCancel.TabIndex = 3;
            this.btnEditCancel.Text = "Отмена";
            this.btnEditCancel.UseVisualStyleBackColor = true;
            // 
            // btnEditOk
            // 
            this.btnEditOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnEditOk.Image = global::FilmCollection.Properties.Resources.attention;
            this.btnEditOk.Location = new System.Drawing.Point(12, 270);
            this.btnEditOk.Name = "btnEditOk";
            this.btnEditOk.Size = new System.Drawing.Size(92, 23);
            this.btnEditOk.TabIndex = 2;
            this.btnEditOk.Text = "Применить";
            this.btnEditOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditOk.UseVisualStyleBackColor = true;
            this.btnEditOk.Click += new System.EventHandler(this.btnEditOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Список доступных баз:";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(15, 25);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(265, 212);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // cbBadBase
            // 
            this.cbBadBase.AutoSize = true;
            this.cbBadBase.Location = new System.Drawing.Point(15, 243);
            this.cbBadBase.Name = "cbBadBase";
            this.cbBadBase.Size = new System.Drawing.Size(179, 17);
            this.cbBadBase.TabIndex = 6;
            this.cbBadBase.Text = "Отобразить испорченые базы";
            this.cbBadBase.UseVisualStyleBackColor = true;
            // 
            // RecoveryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 305);
            this.Controls.Add(this.cbBadBase);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEditCancel);
            this.Controls.Add(this.btnEditOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecoveryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Форма восстановления";
            this.Load += new System.EventHandler(this.RecoveryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEditCancel;
        private System.Windows.Forms.Button btnEditOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.CheckBox cbBadBase;
    }
}