namespace DiegoG.DnDTDesktop.GUI.Elements
{
    partial class SavingThrowsDisplay
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
            this.characterGUIFlowPanel1 = new DiegoG.DnDTDesktop.GUI.Elements.Components.CharacterGUIFlowPanel();
            this.FortitudeCard = new DiegoG.DnDTDesktop.GUI.Elements.SavingThrowTab();
            this.ReflexesCard = new DiegoG.DnDTDesktop.GUI.Elements.SavingThrowTab();
            this.WillpowerCard = new DiegoG.DnDTDesktop.GUI.Elements.SavingThrowTab();
            this.characterGUIFlowPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // characterGUIFlowPanel1
            // 
            this.characterGUIFlowPanel1.Controls.Add(this.FortitudeCard);
            this.characterGUIFlowPanel1.Controls.Add(this.ReflexesCard);
            this.characterGUIFlowPanel1.Controls.Add(this.WillpowerCard);
            this.characterGUIFlowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.characterGUIFlowPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.characterGUIFlowPanel1.Location = new System.Drawing.Point(0, 0);
            this.characterGUIFlowPanel1.Name = "characterGUIFlowPanel1";
            this.characterGUIFlowPanel1.Size = new System.Drawing.Size(612, 159);
            this.characterGUIFlowPanel1.TabIndex = 0;
            // 
            // FortitudeCard
            // 
            this.FortitudeCard.Location = new System.Drawing.Point(3, 3);
            this.FortitudeCard.Name = "FortitudeCard";
            this.FortitudeCard.SelectedStat = DiegoG.DnDTDesktop.Enums.SavingThrows.Fortitude;
            this.FortitudeCard.Size = new System.Drawing.Size(198, 185);
            this.FortitudeCard.TabIndex = 0;
            // 
            // ReflexesCard
            // 
            this.ReflexesCard.Location = new System.Drawing.Point(207, 3);
            this.ReflexesCard.Name = "ReflexesCard";
            this.ReflexesCard.SelectedStat = DiegoG.DnDTDesktop.Enums.SavingThrows.Reflexes;
            this.ReflexesCard.Size = new System.Drawing.Size(198, 185);
            this.ReflexesCard.TabIndex = 1;
            // 
            // WillpowerCard
            // 
            this.WillpowerCard.Location = new System.Drawing.Point(411, 3);
            this.WillpowerCard.Name = "WillpowerCard";
            this.WillpowerCard.SelectedStat = DiegoG.DnDTDesktop.Enums.SavingThrows.Willpower;
            this.WillpowerCard.Size = new System.Drawing.Size(198, 185);
            this.WillpowerCard.TabIndex = 2;
            // 
            // SavingThrowsDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.characterGUIFlowPanel1);
            this.Name = "SavingThrowsDisplay";
            this.Size = new System.Drawing.Size(612, 159);
            this.characterGUIFlowPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Components.CharacterGUIFlowPanel characterGUIFlowPanel1;
        private SavingThrowTab FortitudeCard;
        private SavingThrowTab ReflexesCard;
        private SavingThrowTab WillpowerCard;
    }
}
