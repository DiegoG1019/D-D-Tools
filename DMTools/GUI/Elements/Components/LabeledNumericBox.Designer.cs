namespace DiegoG.DnDTDesktop.GUI.Elements.Components
{
    partial class LabeledNumericBox
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
            this.LayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.Label = new System.Windows.Forms.Label();
            this.NumericButtonTable = new System.Windows.Forms.TableLayoutPanel();
            this.Numeric = new System.Windows.Forms.NumericUpDown();
            this.CommitButton = new System.Windows.Forms.Button();
            this.LayoutPanel.SuspendLayout();
            this.NumericButtonTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.ColumnCount = 1;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.Controls.Add(this.Label, 0, 1);
            this.LayoutPanel.Controls.Add(this.NumericButtonTable, 0, 0);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 2;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LayoutPanel.Size = new System.Drawing.Size(150, 150);
            this.LayoutPanel.TabIndex = 1;
            this.LayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label.Location = new System.Drawing.Point(3, 35);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(144, 115);
            this.Label.TabIndex = 2;
            this.Label.Text = "label1";
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NumericButtonTable
            // 
            this.NumericButtonTable.ColumnCount = 2;
            this.NumericButtonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.NumericButtonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.NumericButtonTable.Controls.Add(this.Numeric, 0, 0);
            this.NumericButtonTable.Controls.Add(this.CommitButton, 1, 0);
            this.NumericButtonTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NumericButtonTable.Location = new System.Drawing.Point(3, 3);
            this.NumericButtonTable.Name = "NumericButtonTable";
            this.NumericButtonTable.RowCount = 1;
            this.NumericButtonTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.NumericButtonTable.Size = new System.Drawing.Size(144, 29);
            this.NumericButtonTable.TabIndex = 1;
            // 
            // Numeric
            // 
            this.Numeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Numeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Numeric.Location = new System.Drawing.Point(3, 3);
            this.Numeric.Name = "Numeric";
            this.Numeric.Size = new System.Drawing.Size(103, 22);
            this.Numeric.TabIndex = 2;
            // 
            // CommitButton
            // 
            this.CommitButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommitButton.Location = new System.Drawing.Point(112, 3);
            this.CommitButton.Name = "CommitButton";
            this.CommitButton.Size = new System.Drawing.Size(29, 23);
            this.CommitButton.TabIndex = 3;
            this.CommitButton.Text = ">";
            this.CommitButton.UseVisualStyleBackColor = true;
            // 
            // LabeledNumericBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LayoutPanel);
            this.Name = "LabeledNumericBox";
            this.LayoutPanel.ResumeLayout(false);
            this.LayoutPanel.PerformLayout();
            this.NumericButtonTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Numeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel LayoutPanel;
        private System.Windows.Forms.TableLayoutPanel NumericButtonTable;
        public System.Windows.Forms.NumericUpDown Numeric;
        public System.Windows.Forms.Button CommitButton;
        public System.Windows.Forms.Label Label;
    }
}
