namespace DiegoG.DnDTDesktop.GUI.Elements
{
    partial class SmallHealthCard
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
            this.BaseHPTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.EffectHealthTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.RemainingHPTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.LethalDamageTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.NonLethalHPTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.NonLethalDamageTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.HPLabel = new System.Windows.Forms.Label();
            this.StatusTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.HPLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.StatusTextBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(247, 231);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.BaseHPTextBox, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.EffectHealthTextBox, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.RemainingHPTextBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.LethalDamageTextBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.NonLethalHPTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.NonLethalDamageTextBox, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(241, 159);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // BaseHPTextBox
            // 
            this.BaseHPTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseHPTextBox.LabelText = "Base Health";
            this.BaseHPTextBox.Location = new System.Drawing.Point(123, 109);
            this.BaseHPTextBox.Name = "BaseHPTextBox";
            this.BaseHPTextBox.Size = new System.Drawing.Size(115, 47);
            this.BaseHPTextBox.TabIndex = 10;
            this.BaseHPTextBox.TextBoxReadOnly = true;
            this.BaseHPTextBox.TextBoxText = "";
            this.BaseHPTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EffectHealthTextBox
            // 
            this.EffectHealthTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EffectHealthTextBox.LabelText = "Effect Health";
            this.EffectHealthTextBox.Location = new System.Drawing.Point(3, 109);
            this.EffectHealthTextBox.Name = "EffectHealthTextBox";
            this.EffectHealthTextBox.Size = new System.Drawing.Size(114, 47);
            this.EffectHealthTextBox.TabIndex = 9;
            this.EffectHealthTextBox.TextBoxReadOnly = true;
            this.EffectHealthTextBox.TextBoxText = "";
            this.EffectHealthTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RemainingHPTextBox
            // 
            this.RemainingHPTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemainingHPTextBox.LabelText = "Remaining HP";
            this.RemainingHPTextBox.Location = new System.Drawing.Point(123, 56);
            this.RemainingHPTextBox.Name = "RemainingHPTextBox";
            this.RemainingHPTextBox.Size = new System.Drawing.Size(115, 47);
            this.RemainingHPTextBox.TabIndex = 8;
            this.RemainingHPTextBox.TextBoxReadOnly = true;
            this.RemainingHPTextBox.TextBoxText = "";
            this.RemainingHPTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LethalDamageTextBox
            // 
            this.LethalDamageTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LethalDamageTextBox.LabelText = "Lethal Damage";
            this.LethalDamageTextBox.Location = new System.Drawing.Point(3, 56);
            this.LethalDamageTextBox.Name = "LethalDamageTextBox";
            this.LethalDamageTextBox.Size = new System.Drawing.Size(114, 47);
            this.LethalDamageTextBox.TabIndex = 7;
            this.LethalDamageTextBox.TextBoxReadOnly = true;
            this.LethalDamageTextBox.TextBoxText = "";
            this.LethalDamageTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NonLethalHPTextBox
            // 
            this.NonLethalHPTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NonLethalHPTextBox.LabelText = "Non-Lethal HP";
            this.NonLethalHPTextBox.Location = new System.Drawing.Point(123, 3);
            this.NonLethalHPTextBox.Name = "NonLethalHPTextBox";
            this.NonLethalHPTextBox.Size = new System.Drawing.Size(115, 47);
            this.NonLethalHPTextBox.TabIndex = 6;
            this.NonLethalHPTextBox.TextBoxReadOnly = true;
            this.NonLethalHPTextBox.TextBoxText = "";
            this.NonLethalHPTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NonLethalDamageTextBox
            // 
            this.NonLethalDamageTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NonLethalDamageTextBox.LabelText = "Non-Lethal Damage";
            this.NonLethalDamageTextBox.Location = new System.Drawing.Point(3, 3);
            this.NonLethalDamageTextBox.Name = "NonLethalDamageTextBox";
            this.NonLethalDamageTextBox.Size = new System.Drawing.Size(114, 47);
            this.NonLethalDamageTextBox.TabIndex = 5;
            this.NonLethalDamageTextBox.TextBoxReadOnly = true;
            this.NonLethalDamageTextBox.TextBoxText = "";
            this.NonLethalDamageTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // HPLabel
            // 
            this.HPLabel.AutoSize = true;
            this.HPLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HPLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HPLabel.Location = new System.Drawing.Point(3, 211);
            this.HPLabel.Name = "HPLabel";
            this.HPLabel.Size = new System.Drawing.Size(241, 20);
            this.HPLabel.TabIndex = 2;
            this.HPLabel.Text = "Health Display";
            this.HPLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatusTextBox
            // 
            this.StatusTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusTextBox.LabelText = "Status";
            this.StatusTextBox.Location = new System.Drawing.Point(3, 168);
            this.StatusTextBox.Name = "StatusTextBox";
            this.StatusTextBox.Size = new System.Drawing.Size(241, 40);
            this.StatusTextBox.TabIndex = 3;
            this.StatusTextBox.TextBoxReadOnly = true;
            this.StatusTextBox.TextBoxText = "";
            this.StatusTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SmallHealthCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SmallHealthCard";
            this.Size = new System.Drawing.Size(247, 231);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Components.LabeledTextbox BaseHPTextBox;
        private Components.LabeledTextbox EffectHealthTextBox;
        private Components.LabeledTextbox RemainingHPTextBox;
        private Components.LabeledTextbox LethalDamageTextBox;
        private Components.LabeledTextbox NonLethalHPTextBox;
        private Components.LabeledTextbox NonLethalDamageTextBox;
        private System.Windows.Forms.Label HPLabel;
        private Components.LabeledTextbox StatusTextBox;
    }
}
