namespace FC.Provider
{
    partial class ucChart
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
            this.components = new System.ComponentModel.Container();
            this.ChartMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.redoLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChartMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChartMenu
            // 
            this.ChartMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDetails,
            this.redoLayoutToolStripMenuItem});
            this.ChartMenu.Name = "ChartMenu";
            this.ChartMenu.Size = new System.Drawing.Size(163, 70);
            // 
            // tsDetails
            // 
            this.tsDetails.Name = "tsDetails";
            this.tsDetails.Size = new System.Drawing.Size(162, 22);
            this.tsDetails.Text = "Детализировать";
            this.tsDetails.Click += new System.EventHandler(this.tsDetails_Click);
            // 
            // redoLayoutToolStripMenuItem
            // 
            this.redoLayoutToolStripMenuItem.Name = "redoLayoutToolStripMenuItem";
            this.redoLayoutToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.redoLayoutToolStripMenuItem.Text = "Redo layout";
            this.redoLayoutToolStripMenuItem.Click += new System.EventHandler(this.redoLayout_Click);
            // 
            // ucChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucChart";
            this.Size = new System.Drawing.Size(295, 349);
            this.ChartMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ChartMenu;
        private System.Windows.Forms.ToolStripMenuItem tsDetails;
        private System.Windows.Forms.ToolStripMenuItem redoLayoutToolStripMenuItem;
    }
}
