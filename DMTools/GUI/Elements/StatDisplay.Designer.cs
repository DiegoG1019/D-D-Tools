namespace DiegoG.DnDTDesktop.GUI.Elements
{
    partial class StatDisplay
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
            this.StrengthStatCard = new DiegoG.DnDTDesktop.GUI.Elements.StatCard();
            this.ConstitutionStatCard = new DiegoG.DnDTDesktop.GUI.Elements.StatCard();
            this.DexterityStatCard = new DiegoG.DnDTDesktop.GUI.Elements.StatCard();
            this.WisdomStatCard = new DiegoG.DnDTDesktop.GUI.Elements.StatCard();
            this.IntelligenceStatCard = new DiegoG.DnDTDesktop.GUI.Elements.StatCard();
            this.CharismaStatCard = new DiegoG.DnDTDesktop.GUI.Elements.StatCard();
            this.characterGUITableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // characterGUITableLayoutPanel1
            // 
            this.characterGUITableLayoutPanel1.ColumnCount = 3;
            this.characterGUITableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.characterGUITableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.characterGUITableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.characterGUITableLayoutPanel1.Controls.Add(this.StrengthStatCard, 0, 0);
            this.characterGUITableLayoutPanel1.Controls.Add(this.ConstitutionStatCard, 1, 0);
            this.characterGUITableLayoutPanel1.Controls.Add(this.DexterityStatCard, 2, 0);
            this.characterGUITableLayoutPanel1.Controls.Add(this.WisdomStatCard, 0, 1);
            this.characterGUITableLayoutPanel1.Controls.Add(this.IntelligenceStatCard, 1, 1);
            this.characterGUITableLayoutPanel1.Controls.Add(this.CharismaStatCard, 2, 1);
            this.characterGUITableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.characterGUITableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.characterGUITableLayoutPanel1.Name = "characterGUITableLayoutPanel1";
            this.characterGUITableLayoutPanel1.RowCount = 2;
            this.characterGUITableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.characterGUITableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.characterGUITableLayoutPanel1.Size = new System.Drawing.Size(866, 512);
            this.characterGUITableLayoutPanel1.TabIndex = 0;
            // 
            // StrengthStatCard
            // 
            this.StrengthStatCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StrengthStatCard.Location = new System.Drawing.Point(3, 3);
            this.StrengthStatCard.Name = "StrengthStatCard";
            this.StrengthStatCard.SelectedStat = DiegoG.DnDTDesktop.Enums.Stats.Strength;
            this.StrengthStatCard.Size = new System.Drawing.Size(282, 250);
            this.StrengthStatCard.TabIndex = 6;
            // 
            // ConstitutionStatCard
            // 
            this.ConstitutionStatCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConstitutionStatCard.Location = new System.Drawing.Point(291, 3);
            this.ConstitutionStatCard.Name = "ConstitutionStatCard";
            this.ConstitutionStatCard.SelectedStat = DiegoG.DnDTDesktop.Enums.Stats.Constitution;
            this.ConstitutionStatCard.Size = new System.Drawing.Size(282, 250);
            this.ConstitutionStatCard.TabIndex = 7;
            // 
            // DexterityStatCard
            // 
            this.DexterityStatCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DexterityStatCard.Location = new System.Drawing.Point(579, 3);
            this.DexterityStatCard.Name = "DexterityStatCard";
            this.DexterityStatCard.SelectedStat = DiegoG.DnDTDesktop.Enums.Stats.Dexterity;
            this.DexterityStatCard.Size = new System.Drawing.Size(284, 250);
            this.DexterityStatCard.TabIndex = 8;
            // 
            // WisdomStatCard
            // 
            this.WisdomStatCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WisdomStatCard.Location = new System.Drawing.Point(3, 259);
            this.WisdomStatCard.Name = "WisdomStatCard";
            this.WisdomStatCard.SelectedStat = DiegoG.DnDTDesktop.Enums.Stats.Wisdom;
            this.WisdomStatCard.Size = new System.Drawing.Size(282, 250);
            this.WisdomStatCard.TabIndex = 9;
            // 
            // IntelligenceStatCard
            // 
            this.IntelligenceStatCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IntelligenceStatCard.Location = new System.Drawing.Point(291, 259);
            this.IntelligenceStatCard.Name = "IntelligenceStatCard";
            this.IntelligenceStatCard.SelectedStat = DiegoG.DnDTDesktop.Enums.Stats.Intelligence;
            this.IntelligenceStatCard.Size = new System.Drawing.Size(282, 250);
            this.IntelligenceStatCard.TabIndex = 10;
            // 
            // CharismaStatCard
            // 
            this.CharismaStatCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CharismaStatCard.Location = new System.Drawing.Point(579, 259);
            this.CharismaStatCard.Name = "CharismaStatCard";
            this.CharismaStatCard.SelectedStat = DiegoG.DnDTDesktop.Enums.Stats.Charisma;
            this.CharismaStatCard.Size = new System.Drawing.Size(284, 250);
            this.CharismaStatCard.TabIndex = 11;
            // 
            // StatDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.characterGUITableLayoutPanel1);
            this.Name = "StatDisplay";
            this.Size = new System.Drawing.Size(866, 512);
            this.characterGUITableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Components.CharacterGUITableLayoutPanel characterGUITableLayoutPanel1;
        private StatCard StrengthStatCard;
        private StatCard ConstitutionStatCard;
        private StatCard DexterityStatCard;
        private StatCard WisdomStatCard;
        private StatCard IntelligenceStatCard;
        private StatCard CharismaStatCard;
    }
}
