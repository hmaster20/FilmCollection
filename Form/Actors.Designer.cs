namespace FilmCollection
{
    partial class Actors
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
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnRemoveGroup = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.chkRightFelds = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkLeftFelds = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.BackColor = System.Drawing.Color.LightGray;
            this.btnMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMoveDown.Location = new System.Drawing.Point(103, 368);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(68, 24);
            this.btnMoveDown.TabIndex = 30;
            this.btnMoveDown.Text = "Down";
            this.btnMoveDown.UseVisualStyleBackColor = false;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.BackColor = System.Drawing.Color.LightGray;
            this.btnMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMoveUp.Location = new System.Drawing.Point(31, 368);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(68, 24);
            this.btnMoveUp.TabIndex = 29;
            this.btnMoveUp.Text = "Up";
            this.btnMoveUp.UseVisualStyleBackColor = false;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnRemoveGroup
            // 
            this.btnRemoveGroup.BackColor = System.Drawing.Color.LightGray;
            this.btnRemoveGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRemoveGroup.Location = new System.Drawing.Point(179, 135);
            this.btnRemoveGroup.Name = "btnRemoveGroup";
            this.btnRemoveGroup.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveGroup.TabIndex = 23;
            this.btnRemoveGroup.Text = "<";
            this.btnRemoveGroup.UseVisualStyleBackColor = false;
            this.btnRemoveGroup.Click += new System.EventHandler(this.btnRemoveGroup_Click);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.BackColor = System.Drawing.Color.LightGray;
            this.btnAddGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddGroup.Location = new System.Drawing.Point(179, 107);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(24, 24);
            this.btnAddGroup.TabIndex = 22;
            this.btnAddGroup.Text = ">";
            this.btnAddGroup.UseVisualStyleBackColor = false;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(206, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 26;
            this.label4.Text = "Section(Group By):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkRightFelds
            // 
            this.chkRightFelds.Location = new System.Drawing.Point(210, 74);
            this.chkRightFelds.Name = "chkRightFelds";
            this.chkRightFelds.Size = new System.Drawing.Size(122, 121);
            this.chkRightFelds.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(30, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 24;
            this.label3.Text = "Report Fields:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkLeftFelds
            // 
            this.chkLeftFelds.CheckOnClick = true;
            this.chkLeftFelds.Items.AddRange(new object[] {
            "123",
            "44",
            "555"});
            this.chkLeftFelds.Location = new System.Drawing.Point(30, 74);
            this.chkLeftFelds.Name = "chkLeftFelds";
            this.chkLeftFelds.Size = new System.Drawing.Size(141, 289);
            this.chkLeftFelds.TabIndex = 21;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(424, 101);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 94);
            this.checkedListBox1.TabIndex = 31;
            // 
            // Actors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 421);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btnRemoveGroup);
            this.Controls.Add(this.btnAddGroup);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkRightFelds);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkLeftFelds);
            this.Name = "Actors";
            this.Text = "Actors";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnRemoveGroup;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox chkRightFelds;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox chkLeftFelds;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}