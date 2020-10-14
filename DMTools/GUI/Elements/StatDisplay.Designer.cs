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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.StrengthStatCard = new DiegoG.DnDTDesktop.GUI.Elements.StatCard();
            this.ConstitutionStatCard = new DiegoG.DnDTDesktop.GUI.Elements.StatCard();
            this.DexterityStatCard = new DiegoG.DnDTDesktop.GUI.Elements.StatCard();
            this.WisdomStatCard = new DiegoG.DnDTDesktop.GUI.Elements.StatCard();
            this.IntelligenceStatCard = new DiegoG.DnDTDesktop.GUI.Elements.StatCard();
            this.CharismaStatCard = new DiegoG.DnDTDesktop.GUI.Elements.StatCard();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.StrengthStatCard);
            this.flowLayoutPanel1.Controls.Add(this.ConstitutionStatCard);
            this.flowLayoutPanel1.Controls.Add(this.DexterityStatCard);
            this.flowLayoutPanel1.Controls.Add(this.WisdomStatCard);
            this.flowLayoutPanel1.Controls.Add(this.IntelligenceStatCard);
            this.flowLayoutPanel1.Controls.Add(this.CharismaStatCard);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(612, 382);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // StrengthStatCard
            // 
            this.StrengthStatCard.Location = new System.Drawing.Point(3, 3);
            this.StrengthStatCard.Name = "StrengthStatCard";
            this.StrengthStatCard.Size = new System.Drawing.Size(198, 185);
            this.StrengthStatCard.TabIndex = 0;
            // 
            // ConstitutionStatCard
            // 
            this.ConstitutionStatCard.Location = new System.Drawing.Point(207, 3);
            this.ConstitutionStatCard.Name = "ConstitutionStatCard";
            this.ConstitutionStatCard.Size = new System.Drawing.Size(198, 185);
            this.ConstitutionStatCard.TabIndex = 1;
            // 
            // DexterityStatCard
            // 
            this.DexterityStatCard.Location = new System.Drawing.Point(411, 3);
            this.DexterityStatCard.Name = "DexterityStatCard";
            this.DexterityStatCard.Size = new System.Drawing.Size(198, 185);
            this.DexterityStatCard.TabIndex = 2;
            // 
            // WisdomStatCard
            // 
            this.WisdomStatCard.Location = new System.Drawing.Point(3, 194);
            this.WisdomStatCard.Name = "WisdomStatCard";
            this.WisdomStatCard.Size = new System.Drawing.Size(198, 185);
            this.WisdomStatCard.TabIndex = 3;
            // 
            // IntelligenceStatCard
            // 
            this.IntelligenceStatCard.Location = new System.Drawing.Point(207, 194);
            this.IntelligenceStatCard.Name = "IntelligenceStatCard";
            this.IntelligenceStatCard.Size = new System.Drawing.Size(198, 185);
            this.IntelligenceStatCard.TabIndex = 4;
            // 
            // CharismaStatCard
            // 
            this.CharismaStatCard.Location = new System.Drawing.Point(411, 194);
            this.CharismaStatCard.Name = "CharismaStatCard";
            this.CharismaStatCard.Size = new System.Drawing.Size(198, 185);
            this.CharismaStatCard.TabIndex = 5;
            // 
            // StatDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "StatDisplay";
            this.Size = new System.Drawing.Size(612, 382);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private StatCard StrengthStatCard;
        private StatCard ConstitutionStatCard;
        private StatCard DexterityStatCard;
        private StatCard WisdomStatCard;
        private StatCard IntelligenceStatCard;
        private StatCard CharismaStatCard;
    }
}
