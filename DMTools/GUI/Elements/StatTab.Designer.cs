namespace DiegoG.DnDTDesktop.GUI.Elements
{
    partial class StatCard
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.TotalPointsLabeledTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.EffectPointsLabeledTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.FullModifierLabeledTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.BaseTotalNumericBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledNumericBox();
            this.BaseModifierLabeledTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.ExtraPointsLabeledNumeric = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledNumericBox();
            this.StatNameLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.StatNameLabel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.MaximumSize = new System.Drawing.Size(198, 205);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(198, 205);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.80769F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.19231F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(198, 205);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(192, 157);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.TotalPointsLabeledTextBox, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.EffectPointsLabeledTextBox, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.FullModifierLabeledTextBox, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(99, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(90, 151);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // TotalPointsLabeledTextBox
            // 
            this.TotalPointsLabeledTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TotalPointsLabeledTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalPointsLabeledTextBox.LabelText = "Total Points";
            this.TotalPointsLabeledTextBox.Location = new System.Drawing.Point(4, 88);
            this.TotalPointsLabeledTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TotalPointsLabeledTextBox.Name = "TotalPointsLabeledTextBox";
            this.TotalPointsLabeledTextBox.Size = new System.Drawing.Size(82, 59);
            this.TotalPointsLabeledTextBox.TabIndex = 2;
            this.TotalPointsLabeledTextBox.TextBoxReadOnly = true;
            this.TotalPointsLabeledTextBox.TextBoxText = "";
            this.TotalPointsLabeledTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EffectPointsLabeledTextBox
            // 
            this.EffectPointsLabeledTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EffectPointsLabeledTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EffectPointsLabeledTextBox.LabelText = "Effect Points";
            this.EffectPointsLabeledTextBox.Location = new System.Drawing.Point(2, 48);
            this.EffectPointsLabeledTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.EffectPointsLabeledTextBox.Name = "EffectPointsLabeledTextBox";
            this.EffectPointsLabeledTextBox.Size = new System.Drawing.Size(86, 34);
            this.EffectPointsLabeledTextBox.TabIndex = 1;
            this.EffectPointsLabeledTextBox.TextBoxReadOnly = true;
            this.EffectPointsLabeledTextBox.TextBoxText = "";
            this.EffectPointsLabeledTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FullModifierLabeledTextBox
            // 
            this.FullModifierLabeledTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FullModifierLabeledTextBox.LabelText = "Full Modifier";
            this.FullModifierLabeledTextBox.Location = new System.Drawing.Point(3, 3);
            this.FullModifierLabeledTextBox.Name = "FullModifierLabeledTextBox";
            this.FullModifierLabeledTextBox.Size = new System.Drawing.Size(84, 40);
            this.FullModifierLabeledTextBox.TabIndex = 0;
            this.FullModifierLabeledTextBox.TextBoxReadOnly = true;
            this.FullModifierLabeledTextBox.TextBoxText = "";
            this.FullModifierLabeledTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.BaseTotalNumericBox, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.BaseModifierLabeledTextBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.ExtraPointsLabeledNumeric, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(90, 151);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // BaseTotalNumericBox
            // 
            this.BaseTotalNumericBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseTotalNumericBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseTotalNumericBox.LabelText = "Base Total Points";
            this.BaseTotalNumericBox.Location = new System.Drawing.Point(4, 88);
            this.BaseTotalNumericBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BaseTotalNumericBox.Name = "BaseTotalNumericBox";
            this.BaseTotalNumericBox.NumericTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.BaseTotalNumericBox.NumericValue = 0;
            this.BaseTotalNumericBox.Size = new System.Drawing.Size(82, 59);
            this.BaseTotalNumericBox.TabIndex = 4;
            // 
            // BaseModifierLabeledTextBox
            // 
            this.BaseModifierLabeledTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseModifierLabeledTextBox.LabelText = "Base Modifier";
            this.BaseModifierLabeledTextBox.Location = new System.Drawing.Point(3, 3);
            this.BaseModifierLabeledTextBox.Name = "BaseModifierLabeledTextBox";
            this.BaseModifierLabeledTextBox.Size = new System.Drawing.Size(84, 40);
            this.BaseModifierLabeledTextBox.TabIndex = 0;
            this.BaseModifierLabeledTextBox.TextBoxReadOnly = true;
            this.BaseModifierLabeledTextBox.TextBoxText = "";
            this.BaseModifierLabeledTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ExtraPointsLabeledNumeric
            // 
            this.ExtraPointsLabeledNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExtraPointsLabeledNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExtraPointsLabeledNumeric.LabelText = "Extra Points";
            this.ExtraPointsLabeledNumeric.Location = new System.Drawing.Point(2, 48);
            this.ExtraPointsLabeledNumeric.Margin = new System.Windows.Forms.Padding(2);
            this.ExtraPointsLabeledNumeric.Name = "ExtraPointsLabeledNumeric";
            this.ExtraPointsLabeledNumeric.NumericTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.ExtraPointsLabeledNumeric.NumericValue = 0;
            this.ExtraPointsLabeledNumeric.Size = new System.Drawing.Size(86, 34);
            this.ExtraPointsLabeledNumeric.TabIndex = 3;
            // 
            // StatNameLabel
            // 
            this.StatNameLabel.AutoSize = true;
            this.StatNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatNameLabel.Location = new System.Drawing.Point(3, 163);
            this.StatNameLabel.Name = "StatNameLabel";
            this.StatNameLabel.Size = new System.Drawing.Size(192, 42);
            this.StatNameLabel.TabIndex = 2;
            this.StatNameLabel.Text = "StatName";
            this.StatNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // StatCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StatCard";
            this.Size = new System.Drawing.Size(198, 185);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label StatNameLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Components.LabeledTextbox BaseModifierLabeledTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Components.LabeledTextbox TotalPointsLabeledTextBox;
        private Components.LabeledTextbox EffectPointsLabeledTextBox;
        private Components.LabeledTextbox FullModifierLabeledTextBox;
        private Components.LabeledNumericBox ExtraPointsLabeledNumeric;
        private Components.LabeledNumericBox BaseTotalNumericBox;
    }
}
