namespace DiegoG.DnDTDesktop.GUI.Elements
{
    partial class JobTab
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
            this.characterGUITableLayoutPanel1 = new DiegoG.DnDTDesktop.GUI.Elements.Components.CharacterGUITableLayoutPanel();
            this.JobColumnTable = new DiegoG.DnDTDesktop.GUI.Elements.Components.CharacterGUITableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.characterGUITableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // characterGUITableLayoutPanel1
            // 
            this.characterGUITableLayoutPanel1.ColumnCount = 1;
            this.characterGUITableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.characterGUITableLayoutPanel1.Controls.Add(this.JobColumnTable, 0, 1);
            this.characterGUITableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.characterGUITableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.characterGUITableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.characterGUITableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.characterGUITableLayoutPanel1.Name = "characterGUITableLayoutPanel1";
            this.characterGUITableLayoutPanel1.RowCount = 2;
            this.characterGUITableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.444445F));
            this.characterGUITableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.55556F));
            this.characterGUITableLayoutPanel1.Size = new System.Drawing.Size(278, 225);
            this.characterGUITableLayoutPanel1.TabIndex = 0;
            // 
            // JobColumnTable
            // 
            this.JobColumnTable.AutoScroll = true;
            this.JobColumnTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.JobColumnTable.ColumnCount = 1;
            this.JobColumnTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.JobColumnTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JobColumnTable.Location = new System.Drawing.Point(3, 22);
            this.JobColumnTable.Name = "JobColumnTable";
            this.JobColumnTable.RowCount = 1;
            this.JobColumnTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.JobColumnTable.Size = new System.Drawing.Size(272, 200);
            this.JobColumnTable.TabIndex = 0;
            this.JobColumnTable.Paint += new System.Windows.Forms.PaintEventHandler(this.characterGUITableLayoutPanel2_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Character Jobs";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // JobTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.characterGUITableLayoutPanel1);
            this.Name = "JobTab";
            this.Size = new System.Drawing.Size(278, 225);
            this.characterGUITableLayoutPanel1.ResumeLayout(false);
            this.characterGUITableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Components.CharacterGUITableLayoutPanel characterGUITableLayoutPanel1;
        private Components.CharacterGUITableLayoutPanel JobColumnTable;
        private System.Windows.Forms.Label label1;
    }
}
