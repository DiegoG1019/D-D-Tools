namespace DiegoG.DnDTDesktop.GUI.Elements
{
    partial class SkillColumn
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
            this.Label1 = new System.Windows.Forms.Label();
            this.KeyStatListBox = new System.Windows.Forms.ListBox();
            this.JobSkillCheckBox = new System.Windows.Forms.CheckBox();
            this.SkillNameTextBox = new System.Windows.Forms.TextBox();
            this.TrainedOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.SkillModifierTextBox = new System.Windows.Forms.TextBox();
            this.StatModifierTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.MiscRanksNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ArmorPenaltyTextBox = new System.Windows.Forms.TextBox();
            this.ArmorPenalizerCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RanksNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MiscRanksNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RanksNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label1.Location = new System.Drawing.Point(470, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(9, 25);
            this.Label1.TabIndex = 16;
            this.Label1.Text = "=";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KeyStatListBox
            // 
            this.KeyStatListBox.FormattingEnabled = true;
            this.KeyStatListBox.Location = new System.Drawing.Point(358, 3);
            this.KeyStatListBox.Name = "KeyStatListBox";
            this.KeyStatListBox.Size = new System.Drawing.Size(46, 17);
            this.KeyStatListBox.TabIndex = 15;
            this.KeyStatListBox.SelectedIndexChanged += new System.EventHandler(this.KeyStat_SelectedIndexChanged);
            // 
            // JobSkillCheckBox
            // 
            this.JobSkillCheckBox.AutoSize = true;
            this.JobSkillCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JobSkillCheckBox.Location = new System.Drawing.Point(3, 3);
            this.JobSkillCheckBox.Name = "JobSkillCheckBox";
            this.JobSkillCheckBox.Size = new System.Drawing.Size(34, 19);
            this.JobSkillCheckBox.TabIndex = 3;
            this.JobSkillCheckBox.UseVisualStyleBackColor = true;
            this.JobSkillCheckBox.CheckedChanged += new System.EventHandler(this.JobSkillCheckBox_CheckedChanged);
            // 
            // SkillNameTextBox
            // 
            this.SkillNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SkillNameTextBox.Location = new System.Drawing.Point(83, 3);
            this.SkillNameTextBox.Name = "SkillNameTextBox";
            this.SkillNameTextBox.Size = new System.Drawing.Size(269, 20);
            this.SkillNameTextBox.TabIndex = 5;
            this.SkillNameTextBox.TextChanged += new System.EventHandler(this.SkillNameTextBox_TextChanged);
            // 
            // TrainedOnlyCheckBox
            // 
            this.TrainedOnlyCheckBox.AutoSize = true;
            this.TrainedOnlyCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrainedOnlyCheckBox.Location = new System.Drawing.Point(43, 3);
            this.TrainedOnlyCheckBox.Name = "TrainedOnlyCheckBox";
            this.TrainedOnlyCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TrainedOnlyCheckBox.Size = new System.Drawing.Size(34, 19);
            this.TrainedOnlyCheckBox.TabIndex = 6;
            this.TrainedOnlyCheckBox.UseVisualStyleBackColor = true;
            this.TrainedOnlyCheckBox.CheckedChanged += new System.EventHandler(this.TrainedOnlyCheckBox_CheckedChanged);
            // 
            // SkillModifierTextBox
            // 
            this.SkillModifierTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SkillModifierTextBox.Location = new System.Drawing.Point(410, 3);
            this.SkillModifierTextBox.Name = "SkillModifierTextBox";
            this.SkillModifierTextBox.ReadOnly = true;
            this.SkillModifierTextBox.Size = new System.Drawing.Size(54, 20);
            this.SkillModifierTextBox.TabIndex = 14;
            // 
            // StatModifierTextBox
            // 
            this.StatModifierTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatModifierTextBox.Location = new System.Drawing.Point(485, 3);
            this.StatModifierTextBox.Name = "StatModifierTextBox";
            this.StatModifierTextBox.ReadOnly = true;
            this.StatModifierTextBox.Size = new System.Drawing.Size(54, 20);
            this.StatModifierTextBox.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(545, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(9, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "+";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(620, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(9, 25);
            this.label3.TabIndex = 21;
            this.label3.Text = "+";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainLayout
            // 
            this.MainLayout.ColumnCount = 14;
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 275F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.MainLayout.Controls.Add(this.MiscRanksNumericUpDown, 10, 0);
            this.MainLayout.Controls.Add(this.ArmorPenaltyTextBox, 12, 0);
            this.MainLayout.Controls.Add(this.ArmorPenalizerCheckBox, 13, 0);
            this.MainLayout.Controls.Add(this.label4, 11, 0);
            this.MainLayout.Controls.Add(this.label3, 9, 0);
            this.MainLayout.Controls.Add(this.label2, 7, 0);
            this.MainLayout.Controls.Add(this.StatModifierTextBox, 6, 0);
            this.MainLayout.Controls.Add(this.SkillModifierTextBox, 4, 0);
            this.MainLayout.Controls.Add(this.TrainedOnlyCheckBox, 1, 0);
            this.MainLayout.Controls.Add(this.SkillNameTextBox, 2, 0);
            this.MainLayout.Controls.Add(this.JobSkillCheckBox, 0, 0);
            this.MainLayout.Controls.Add(this.KeyStatListBox, 3, 0);
            this.MainLayout.Controls.Add(this.Label1, 5, 0);
            this.MainLayout.Controls.Add(this.RanksNumericUpDown, 8, 0);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.MainLayout.Location = new System.Drawing.Point(0, 0);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.RowCount = 1;
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.Size = new System.Drawing.Size(790, 25);
            this.MainLayout.TabIndex = 2;
            // 
            // MiscRanksNumericUpDown
            // 
            this.MiscRanksNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MiscRanksNumericUpDown.Location = new System.Drawing.Point(635, 3);
            this.MiscRanksNumericUpDown.Maximum = new decimal(new int[] {
            2147483640,
            0,
            0,
            0});
            this.MiscRanksNumericUpDown.Name = "MiscRanksNumericUpDown";
            this.MiscRanksNumericUpDown.Size = new System.Drawing.Size(54, 20);
            this.MiscRanksNumericUpDown.TabIndex = 32;
            this.MiscRanksNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MiscRanksNumericUpDown.ValueChanged += new System.EventHandler(this.MiscRanksNumericUpDown_ValueChanged);
            // 
            // ArmorPenaltyTextBox
            // 
            this.ArmorPenaltyTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArmorPenaltyTextBox.Location = new System.Drawing.Point(710, 3);
            this.ArmorPenaltyTextBox.Name = "ArmorPenaltyTextBox";
            this.ArmorPenaltyTextBox.ReadOnly = true;
            this.ArmorPenaltyTextBox.Size = new System.Drawing.Size(54, 20);
            this.ArmorPenaltyTextBox.TabIndex = 30;
            // 
            // ArmorPenalizerCheckBox
            // 
            this.ArmorPenalizerCheckBox.AutoSize = true;
            this.ArmorPenalizerCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArmorPenalizerCheckBox.Location = new System.Drawing.Point(770, 3);
            this.ArmorPenalizerCheckBox.Name = "ArmorPenalizerCheckBox";
            this.ArmorPenalizerCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ArmorPenalizerCheckBox.Size = new System.Drawing.Size(17, 19);
            this.ArmorPenalizerCheckBox.TabIndex = 29;
            this.ArmorPenalizerCheckBox.UseVisualStyleBackColor = true;
            this.ArmorPenalizerCheckBox.CheckedChanged += new System.EventHandler(this.ArmorPenalizerCheckBox_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(695, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(9, 25);
            this.label4.TabIndex = 28;
            this.label4.Text = "+";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RanksNumericUpDown
            // 
            this.RanksNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RanksNumericUpDown.Location = new System.Drawing.Point(560, 3);
            this.RanksNumericUpDown.Maximum = new decimal(new int[] {
            2147483640,
            0,
            0,
            0});
            this.RanksNumericUpDown.Name = "RanksNumericUpDown";
            this.RanksNumericUpDown.Size = new System.Drawing.Size(54, 20);
            this.RanksNumericUpDown.TabIndex = 31;
            this.RanksNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RanksNumericUpDown.ValueChanged += new System.EventHandler(this.RanksNumericUpDown_ValueChanged);
            // 
            // SkillColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainLayout);
            this.MaximumSize = new System.Drawing.Size(790, 25);
            this.MinimumSize = new System.Drawing.Size(790, 25);
            this.Name = "SkillColumn";
            this.Size = new System.Drawing.Size(790, 25);
            this.MainLayout.ResumeLayout(false);
            this.MainLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MiscRanksNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RanksNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ListBox KeyStatListBox;
        private System.Windows.Forms.CheckBox JobSkillCheckBox;
        private System.Windows.Forms.TextBox SkillNameTextBox;
        private System.Windows.Forms.CheckBox TrainedOnlyCheckBox;
        private System.Windows.Forms.TextBox SkillModifierTextBox;
        private System.Windows.Forms.TextBox StatModifierTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel MainLayout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ArmorPenaltyTextBox;
        private System.Windows.Forms.CheckBox ArmorPenalizerCheckBox;
        private System.Windows.Forms.NumericUpDown RanksNumericUpDown;
        private System.Windows.Forms.NumericUpDown MiscRanksNumericUpDown;
    }
}
