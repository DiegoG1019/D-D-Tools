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
            this.TotalPointsLabeledTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.BaseTotalNumericBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledNumericBox();
            this.EffectPointsLabeledTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.ExtraPointsLabeledNumeric = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledNumericBox();
            this.FullModifierLabeledTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.BaseModifierLabeledTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(305, 218);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.TotalPointsLabeledTextBox, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.BaseTotalNumericBox, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.EffectPointsLabeledTextBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.ExtraPointsLabeledNumeric, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.FullModifierLabeledTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.BaseModifierLabeledTextBox, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(299, 192);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // TotalPointsLabeledTextBox
            // 
            this.TotalPointsLabeledTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TotalPointsLabeledTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalPointsLabeledTextBox.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalPointsLabeledTextBox.LabelOnTop = false;
            this.TotalPointsLabeledTextBox.LabelText = "Total Points";
            this.TotalPointsLabeledTextBox.Location = new System.Drawing.Point(153, 130);
            this.TotalPointsLabeledTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TotalPointsLabeledTextBox.Name = "TotalPointsLabeledTextBox";
            this.TotalPointsLabeledTextBox.Size = new System.Drawing.Size(142, 58);
            this.TotalPointsLabeledTextBox.TabIndex = 7;
            this.TotalPointsLabeledTextBox.TextBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalPointsLabeledTextBox.TextBoxReadOnly = true;
            this.TotalPointsLabeledTextBox.TextBoxText = "";
            this.TotalPointsLabeledTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BaseTotalNumericBox
            // 
            this.BaseTotalNumericBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseTotalNumericBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseTotalNumericBox.LabelOnTop = false;
            this.BaseTotalNumericBox.LabelText = "Base Total Points";
            this.BaseTotalNumericBox.Location = new System.Drawing.Point(4, 130);
            this.BaseTotalNumericBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BaseTotalNumericBox.Name = "BaseTotalNumericBox";
            this.BaseTotalNumericBox.NumericTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.BaseTotalNumericBox.NumericValue = 0;
            this.BaseTotalNumericBox.Size = new System.Drawing.Size(141, 58);
            this.BaseTotalNumericBox.TabIndex = 6;
            // 
            // EffectPointsLabeledTextBox
            // 
            this.EffectPointsLabeledTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EffectPointsLabeledTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EffectPointsLabeledTextBox.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EffectPointsLabeledTextBox.LabelOnTop = false;
            this.EffectPointsLabeledTextBox.LabelText = "Effect Points";
            this.EffectPointsLabeledTextBox.Location = new System.Drawing.Point(151, 65);
            this.EffectPointsLabeledTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.EffectPointsLabeledTextBox.Name = "EffectPointsLabeledTextBox";
            this.EffectPointsLabeledTextBox.Size = new System.Drawing.Size(146, 59);
            this.EffectPointsLabeledTextBox.TabIndex = 5;
            this.EffectPointsLabeledTextBox.TextBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EffectPointsLabeledTextBox.TextBoxReadOnly = true;
            this.EffectPointsLabeledTextBox.TextBoxText = "";
            this.EffectPointsLabeledTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.EffectPointsLabeledTextBox.Load += new System.EventHandler(this.EffectPointsLabeledTextBox_Load);
            // 
            // ExtraPointsLabeledNumeric
            // 
            this.ExtraPointsLabeledNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExtraPointsLabeledNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExtraPointsLabeledNumeric.LabelOnTop = false;
            this.ExtraPointsLabeledNumeric.LabelText = "Extra Points";
            this.ExtraPointsLabeledNumeric.Location = new System.Drawing.Point(2, 65);
            this.ExtraPointsLabeledNumeric.Margin = new System.Windows.Forms.Padding(2);
            this.ExtraPointsLabeledNumeric.Name = "ExtraPointsLabeledNumeric";
            this.ExtraPointsLabeledNumeric.NumericTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.ExtraPointsLabeledNumeric.NumericValue = 0;
            this.ExtraPointsLabeledNumeric.Size = new System.Drawing.Size(145, 59);
            this.ExtraPointsLabeledNumeric.TabIndex = 4;
            // 
            // FullModifierLabeledTextBox
            // 
            this.FullModifierLabeledTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FullModifierLabeledTextBox.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullModifierLabeledTextBox.LabelOnTop = false;
            this.FullModifierLabeledTextBox.LabelText = "Full Modifier";
            this.FullModifierLabeledTextBox.Location = new System.Drawing.Point(152, 3);
            this.FullModifierLabeledTextBox.Name = "FullModifierLabeledTextBox";
            this.FullModifierLabeledTextBox.Size = new System.Drawing.Size(144, 57);
            this.FullModifierLabeledTextBox.TabIndex = 2;
            this.FullModifierLabeledTextBox.TextBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullModifierLabeledTextBox.TextBoxReadOnly = true;
            this.FullModifierLabeledTextBox.TextBoxText = "";
            this.FullModifierLabeledTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BaseModifierLabeledTextBox
            // 
            this.BaseModifierLabeledTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseModifierLabeledTextBox.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseModifierLabeledTextBox.LabelOnTop = false;
            this.BaseModifierLabeledTextBox.LabelText = "Base Modifier";
            this.BaseModifierLabeledTextBox.Location = new System.Drawing.Point(3, 3);
            this.BaseModifierLabeledTextBox.Name = "BaseModifierLabeledTextBox";
            this.BaseModifierLabeledTextBox.Size = new System.Drawing.Size(143, 57);
            this.BaseModifierLabeledTextBox.TabIndex = 1;
            this.BaseModifierLabeledTextBox.TextBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseModifierLabeledTextBox.TextBoxReadOnly = true;
            this.BaseModifierLabeledTextBox.TextBoxText = "";
            this.BaseModifierLabeledTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StatNameLabel
            // 
            this.StatNameLabel.AutoSize = true;
            this.StatNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatNameLabel.Location = new System.Drawing.Point(3, 198);
            this.StatNameLabel.Name = "StatNameLabel";
            this.StatNameLabel.Size = new System.Drawing.Size(299, 20);
            this.StatNameLabel.TabIndex = 1;
            this.StatNameLabel.Text = "StatName";
            this.StatNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StatCard";
            this.Size = new System.Drawing.Size(305, 218);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label StatNameLabel;
        private Components.LabeledTextbox BaseModifierLabeledTextBox;
        private Components.LabeledTextbox FullModifierLabeledTextBox;
        private Components.LabeledNumericBox ExtraPointsLabeledNumeric;
        private Components.LabeledTextbox EffectPointsLabeledTextBox;
        private Components.LabeledNumericBox BaseTotalNumericBox;
        private Components.LabeledTextbox TotalPointsLabeledTextBox;
    }
}
