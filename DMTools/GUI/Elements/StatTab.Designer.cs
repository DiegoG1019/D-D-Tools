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
            this.StatNameLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.BaseModifierLabeledTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.ExtraPointsLabeledTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.BasePointsLabeledTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.labeledTextbox1 = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.labeledTextbox2 = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.FullModifierLabeledTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
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
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.BasePointsLabeledTextBox, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.ExtraPointsLabeledTextBox, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.BaseModifierLabeledTextBox, 0, 0);
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
            // BaseModifierLabeledTextBox
            // 
            this.BaseModifierLabeledTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseModifierLabeledTextBox.LabelText = "Base Modifier";
            this.BaseModifierLabeledTextBox.Location = new System.Drawing.Point(3, 3);
            this.BaseModifierLabeledTextBox.Name = "BaseModifierLabeledTextBox";
            this.BaseModifierLabeledTextBox.Size = new System.Drawing.Size(84, 40);
            this.BaseModifierLabeledTextBox.TabIndex = 0;
            this.BaseModifierLabeledTextBox.TextBoxReadOnly = false;
            this.BaseModifierLabeledTextBox.TextBoxText = "";
            this.BaseModifierLabeledTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ExtraPointsLabeledTextBox
            // 
            this.ExtraPointsLabeledTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExtraPointsLabeledTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExtraPointsLabeledTextBox.LabelText = "Extra Points";
            this.ExtraPointsLabeledTextBox.Location = new System.Drawing.Point(2, 48);
            this.ExtraPointsLabeledTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ExtraPointsLabeledTextBox.Name = "ExtraPointsLabeledTextBox";
            this.ExtraPointsLabeledTextBox.Size = new System.Drawing.Size(86, 34);
            this.ExtraPointsLabeledTextBox.TabIndex = 1;
            this.ExtraPointsLabeledTextBox.TextBoxReadOnly = false;
            this.ExtraPointsLabeledTextBox.TextBoxText = "";
            this.ExtraPointsLabeledTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BasePointsLabeledTextBox
            // 
            this.BasePointsLabeledTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BasePointsLabeledTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BasePointsLabeledTextBox.LabelText = "Base Points";
            this.BasePointsLabeledTextBox.Location = new System.Drawing.Point(4, 88);
            this.BasePointsLabeledTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BasePointsLabeledTextBox.Name = "BasePointsLabeledTextBox";
            this.BasePointsLabeledTextBox.Size = new System.Drawing.Size(82, 59);
            this.BasePointsLabeledTextBox.TabIndex = 2;
            this.BasePointsLabeledTextBox.TextBoxReadOnly = false;
            this.BasePointsLabeledTextBox.TextBoxText = "";
            this.BasePointsLabeledTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.labeledTextbox1, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.labeledTextbox2, 0, 1);
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
            // labeledTextbox1
            // 
            this.labeledTextbox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labeledTextbox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeledTextbox1.LabelText = "Total Points";
            this.labeledTextbox1.Location = new System.Drawing.Point(4, 88);
            this.labeledTextbox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labeledTextbox1.Name = "labeledTextbox1";
            this.labeledTextbox1.Size = new System.Drawing.Size(82, 59);
            this.labeledTextbox1.TabIndex = 2;
            this.labeledTextbox1.TextBoxReadOnly = false;
            this.labeledTextbox1.TextBoxText = "";
            this.labeledTextbox1.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labeledTextbox2
            // 
            this.labeledTextbox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labeledTextbox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeledTextbox2.LabelText = "Effect Points";
            this.labeledTextbox2.Location = new System.Drawing.Point(2, 48);
            this.labeledTextbox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.labeledTextbox2.Name = "labeledTextbox2";
            this.labeledTextbox2.Size = new System.Drawing.Size(86, 34);
            this.labeledTextbox2.TabIndex = 1;
            this.labeledTextbox2.TextBoxReadOnly = false;
            this.labeledTextbox2.TextBoxText = "";
            this.labeledTextbox2.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FullModifierLabeledTextBox
            // 
            this.FullModifierLabeledTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FullModifierLabeledTextBox.LabelText = "Full Modifier";
            this.FullModifierLabeledTextBox.Location = new System.Drawing.Point(3, 3);
            this.FullModifierLabeledTextBox.Name = "FullModifierLabeledTextBox";
            this.FullModifierLabeledTextBox.Size = new System.Drawing.Size(84, 40);
            this.FullModifierLabeledTextBox.TabIndex = 0;
            this.FullModifierLabeledTextBox.TextBoxReadOnly = false;
            this.FullModifierLabeledTextBox.TextBoxText = "";
            this.FullModifierLabeledTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label StatNameLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Components.LabeledTextbox BaseModifierLabeledTextBox;
        private Components.LabeledTextbox BasePointsLabeledTextBox;
        private Components.LabeledTextbox ExtraPointsLabeledTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Components.LabeledTextbox labeledTextbox1;
        private Components.LabeledTextbox labeledTextbox2;
        private Components.LabeledTextbox FullModifierLabeledTextBox;
    }
}
