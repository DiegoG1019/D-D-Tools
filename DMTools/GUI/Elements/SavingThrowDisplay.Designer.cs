namespace DiegoG.DnDTDesktop.GUI.Elements
{
    partial class SavingThrowDisplay
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
            this.WillpowerCard = new DiegoG.DnDTDesktop.GUI.Elements.SavingThrowCard();
            this.ReflexesCard = new DiegoG.DnDTDesktop.GUI.Elements.SavingThrowCard();
            this.FortitudeCard = new DiegoG.DnDTDesktop.GUI.Elements.SavingThrowCard();
            this.characterGUITableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // characterGUITableLayoutPanel1
            // 
            this.characterGUITableLayoutPanel1.ColumnCount = 1;
            this.characterGUITableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.characterGUITableLayoutPanel1.Controls.Add(this.WillpowerCard, 0, 2);
            this.characterGUITableLayoutPanel1.Controls.Add(this.ReflexesCard, 0, 1);
            this.characterGUITableLayoutPanel1.Controls.Add(this.FortitudeCard, 0, 0);
            this.characterGUITableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.characterGUITableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.characterGUITableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.characterGUITableLayoutPanel1.Name = "characterGUITableLayoutPanel1";
            this.characterGUITableLayoutPanel1.RowCount = 3;
            this.characterGUITableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.characterGUITableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.characterGUITableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.characterGUITableLayoutPanel1.Size = new System.Drawing.Size(245, 590);
            this.characterGUITableLayoutPanel1.TabIndex = 0;
            // 
            // WillpowerCard
            // 
            this.WillpowerCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WillpowerCard.Location = new System.Drawing.Point(3, 395);
            this.WillpowerCard.Name = "WillpowerCard";
            this.WillpowerCard.SelectedStat = DiegoG.DnDTDesktop.Enums.SavingThrows.Willpower;
            this.WillpowerCard.Size = new System.Drawing.Size(239, 192);
            this.WillpowerCard.TabIndex = 3;
            // 
            // ReflexesCard
            // 
            this.ReflexesCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReflexesCard.Location = new System.Drawing.Point(3, 199);
            this.ReflexesCard.Name = "ReflexesCard";
            this.ReflexesCard.SelectedStat = DiegoG.DnDTDesktop.Enums.SavingThrows.Reflexes;
            this.ReflexesCard.Size = new System.Drawing.Size(239, 190);
            this.ReflexesCard.TabIndex = 2;
            // 
            // FortitudeCard
            // 
            this.FortitudeCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FortitudeCard.Location = new System.Drawing.Point(3, 3);
            this.FortitudeCard.Name = "FortitudeCard";
            this.FortitudeCard.SelectedStat = DiegoG.DnDTDesktop.Enums.SavingThrows.Fortitude;
            this.FortitudeCard.Size = new System.Drawing.Size(239, 190);
            this.FortitudeCard.TabIndex = 1;
            // 
            // SavingThrowDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.characterGUITableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(245, 590);
            this.Name = "SavingThrowDisplay";
            this.Size = new System.Drawing.Size(245, 590);
            this.Load += new System.EventHandler(this.SavingThrowDisplay_Load);
            this.characterGUITableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Components.CharacterGUITableLayoutPanel characterGUITableLayoutPanel1;
        private SavingThrowCard FortitudeCard;
        private SavingThrowCard WillpowerCard;
        private SavingThrowCard ReflexesCard;
    }
}
