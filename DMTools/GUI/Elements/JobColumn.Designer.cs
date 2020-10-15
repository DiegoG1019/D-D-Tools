namespace DiegoG.DnDTDesktop.GUI.Elements
{
    partial class JobColumn
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
            this.JobNameTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.JobLevelNumeric = new System.Windows.Forms.NumericUpDown();
            this.LevelLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JobLevelNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // JobNameTextBox
            // 
            this.JobNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JobNameTextBox.Location = new System.Drawing.Point(3, 3);
            this.JobNameTextBox.Name = "JobNameTextBox";
            this.JobNameTextBox.Size = new System.Drawing.Size(222, 20);
            this.JobNameTextBox.TabIndex = 1;
            this.JobNameTextBox.TextChanged += new System.EventHandler(this.JobNameTextBox_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Controls.Add(this.JobLevelNumeric, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.JobNameTextBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LevelLabel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(328, 25);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // JobLevelNumeric
            // 
            this.JobLevelNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JobLevelNumeric.Location = new System.Drawing.Point(281, 3);
            this.JobLevelNumeric.Name = "JobLevelNumeric";
            this.JobLevelNumeric.Size = new System.Drawing.Size(44, 20);
            this.JobLevelNumeric.TabIndex = 5;
            this.JobLevelNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LevelLabel
            // 
            this.LevelLabel.AutoSize = true;
            this.LevelLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LevelLabel.Location = new System.Drawing.Point(231, 0);
            this.LevelLabel.Name = "LevelLabel";
            this.LevelLabel.Size = new System.Drawing.Size(44, 25);
            this.LevelLabel.TabIndex = 4;
            this.LevelLabel.Text = "Lv.";
            this.LevelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // JobColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "JobColumn";
            this.Size = new System.Drawing.Size(328, 25);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JobLevelNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox JobNameTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown JobLevelNumeric;
        private System.Windows.Forms.Label LevelLabel;
    }
}
