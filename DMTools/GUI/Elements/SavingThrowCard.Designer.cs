namespace DiegoG.DnDTDesktop.GUI.Elements
{
    partial class SavingThrowCard
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
            this.BaseStatModifierTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.BaseTotalTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.TotalPointsLabeledTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.EffectPointsLabeledTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.BonusPointsNumeric = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledNumericBox();
            this.StatNameLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.StatNameLabel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(213, 258);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.BaseStatModifierTextBox, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.BaseTotalTextBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.TotalPointsLabeledTextBox, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.EffectPointsLabeledTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.BonusPointsNumeric, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(207, 232);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // BaseStatModifierTextBox
            // 
            this.BaseStatModifierTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseStatModifierTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseStatModifierTextBox.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseStatModifierTextBox.LabelOnTop = false;
            this.BaseStatModifierTextBox.LabelText = "Base Stat Modifier";
            this.BaseStatModifierTextBox.Location = new System.Drawing.Point(105, 156);
            this.BaseStatModifierTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.BaseStatModifierTextBox.Name = "BaseStatModifierTextBox";
            this.BaseStatModifierTextBox.Size = new System.Drawing.Size(100, 74);
            this.BaseStatModifierTextBox.TabIndex = 19;
            this.BaseStatModifierTextBox.TextBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseStatModifierTextBox.TextBoxReadOnly = true;
            this.BaseStatModifierTextBox.TextBoxText = "";
            this.BaseStatModifierTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BaseTotalTextBox
            // 
            this.BaseTotalTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseTotalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseTotalTextBox.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseTotalTextBox.LabelOnTop = false;
            this.BaseTotalTextBox.LabelText = "Base Total Points";
            this.BaseTotalTextBox.Location = new System.Drawing.Point(105, 79);
            this.BaseTotalTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.BaseTotalTextBox.Name = "BaseTotalTextBox";
            this.BaseTotalTextBox.Size = new System.Drawing.Size(100, 73);
            this.BaseTotalTextBox.TabIndex = 18;
            this.BaseTotalTextBox.TextBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseTotalTextBox.TextBoxReadOnly = true;
            this.BaseTotalTextBox.TextBoxText = "";
            this.BaseTotalTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.BaseTotalTextBox.Load += new System.EventHandler(this.BaseTotalTextBox_Load);
            // 
            // TotalPointsLabeledTextBox
            // 
            this.TotalPointsLabeledTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TotalPointsLabeledTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalPointsLabeledTextBox.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalPointsLabeledTextBox.LabelOnTop = false;
            this.TotalPointsLabeledTextBox.LabelText = "Total Points";
            this.TotalPointsLabeledTextBox.Location = new System.Drawing.Point(4, 158);
            this.TotalPointsLabeledTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TotalPointsLabeledTextBox.Name = "TotalPointsLabeledTextBox";
            this.TotalPointsLabeledTextBox.Size = new System.Drawing.Size(95, 70);
            this.TotalPointsLabeledTextBox.TabIndex = 17;
            this.TotalPointsLabeledTextBox.TextBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalPointsLabeledTextBox.TextBoxReadOnly = true;
            this.TotalPointsLabeledTextBox.TextBoxText = "";
            this.TotalPointsLabeledTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EffectPointsLabeledTextBox
            // 
            this.EffectPointsLabeledTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EffectPointsLabeledTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EffectPointsLabeledTextBox.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EffectPointsLabeledTextBox.LabelOnTop = false;
            this.EffectPointsLabeledTextBox.LabelText = "Effect Points";
            this.EffectPointsLabeledTextBox.Location = new System.Drawing.Point(105, 2);
            this.EffectPointsLabeledTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.EffectPointsLabeledTextBox.Name = "EffectPointsLabeledTextBox";
            this.EffectPointsLabeledTextBox.Size = new System.Drawing.Size(100, 73);
            this.EffectPointsLabeledTextBox.TabIndex = 16;
            this.EffectPointsLabeledTextBox.TextBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EffectPointsLabeledTextBox.TextBoxReadOnly = true;
            this.EffectPointsLabeledTextBox.TextBoxText = "";
            this.EffectPointsLabeledTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BonusPointsNumeric
            // 
            this.BonusPointsNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BonusPointsNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BonusPointsNumeric.LabelOnTop = false;
            this.BonusPointsNumeric.LabelText = "Bonus Points";
            this.BonusPointsNumeric.Location = new System.Drawing.Point(4, 4);
            this.BonusPointsNumeric.Margin = new System.Windows.Forms.Padding(4);
            this.BonusPointsNumeric.Name = "BonusPointsNumeric";
            this.BonusPointsNumeric.NumericTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.BonusPointsNumeric.NumericValue = 0;
            this.BonusPointsNumeric.Size = new System.Drawing.Size(95, 69);
            this.BonusPointsNumeric.TabIndex = 15;
            // 
            // StatNameLabel
            // 
            this.StatNameLabel.AutoSize = true;
            this.StatNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatNameLabel.Location = new System.Drawing.Point(3, 238);
            this.StatNameLabel.Name = "StatNameLabel";
            this.StatNameLabel.Size = new System.Drawing.Size(207, 20);
            this.StatNameLabel.TabIndex = 1;
            this.StatNameLabel.Text = "StatName";
            this.StatNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.StatNameLabel.Click += new System.EventHandler(this.StatNameLabel_Click);
            // 
            // SavingThrowCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SavingThrowCard";
            this.Size = new System.Drawing.Size(213, 258);
            this.Load += new System.EventHandler(this.SavingThrowCard_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label StatNameLabel;
        private Components.LabeledTextbox EffectPointsLabeledTextBox;
        private Components.LabeledNumericBox BonusPointsNumeric;
        private Components.LabeledTextbox TotalPointsLabeledTextBox;
        private Components.LabeledTextbox BaseStatModifierTextBox;
        private Components.LabeledTextbox BaseTotalTextBox;
    }
}
