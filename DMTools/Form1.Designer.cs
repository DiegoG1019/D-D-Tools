namespace DnDTDesktop
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.versionLabel = new System.Windows.Forms.Label();
            this.jobListFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.jobListMainLabel = new System.Windows.Forms.Label();
            this.jobListFlowLayoutLevel = new System.Windows.Forms.FlowLayoutPanel();
            this.jobListLevelLabel = new System.Windows.Forms.Label();
            this.jobListFlowLayout.SuspendLayout();
            this.jobListFlowLayoutLevel.SuspendLayout();
            this.SuspendLayout();
            // 
            // versionLabel
            // 
            resources.ApplyResources(this.versionLabel, "versionLabel");
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // jobListFlowLayout
            // 
            this.jobListFlowLayout.Controls.Add(this.jobListMainLabel);
            resources.ApplyResources(this.jobListFlowLayout, "jobListFlowLayout");
            this.jobListFlowLayout.Name = "jobListFlowLayout";
            // 
            // jobListMainLabel
            // 
            resources.ApplyResources(this.jobListMainLabel, "jobListMainLabel");
            this.jobListMainLabel.Name = "jobListMainLabel";
            this.jobListMainLabel.Click += new System.EventHandler(this.jobListMainLabel_Click);
            // 
            // jobListFlowLayoutLevel
            // 
            this.jobListFlowLayoutLevel.Controls.Add(this.jobListLevelLabel);
            resources.ApplyResources(this.jobListFlowLayoutLevel, "jobListFlowLayoutLevel");
            this.jobListFlowLayoutLevel.Name = "jobListFlowLayoutLevel";
            // 
            // jobListLevelLabel
            // 
            resources.ApplyResources(this.jobListLevelLabel, "label1");
            this.jobListLevelLabel.Name = "label1";
            // 
            // MainMenu
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.jobListFlowLayout);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.jobListFlowLayoutLevel);
            this.Name = "MainMenu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.jobListFlowLayout.ResumeLayout(false);
            this.jobListFlowLayoutLevel.ResumeLayout(false);
            this.jobListFlowLayoutLevel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.FlowLayoutPanel jobListFlowLayout;
        private System.Windows.Forms.Label jobListMainLabel;
        private System.Windows.Forms.FlowLayoutPanel jobListFlowLayoutLevel;
        private System.Windows.Forms.Label jobListLevelLabel;
    }
}

