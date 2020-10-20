namespace DiegoG.DnDTDesktop.GUI.Elements
{
    partial class BigHealthCard
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
            this.NonLethalDamageHistory = new DiegoG.DnDTDesktop.GUI.Elements.HistoryBoard();
            this.LethalDamageHistory = new DiegoG.DnDTDesktop.GUI.Elements.HistoryBoard();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.NonLethalHPTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.RemainingHPTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.BaseHealthTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.TouchACTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.ACTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.EffectHealthTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.UnawareACTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.StatusTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.HpThrowsBoard = new System.Windows.Forms.TableLayoutPanel();
            this.HpThrowsLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(658, 478);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.NonLethalDamageHistory, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.LethalDamageHistory, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(652, 374);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // NonLethalDamageHistory
            // 
            this.NonLethalDamageHistory.AutoAddToHistory = false;
            this.NonLethalDamageHistory.AutoRefreshValue = true;
            this.NonLethalDamageHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NonLethalDamageHistory.HeldHistory = null;
            this.NonLethalDamageHistory.Location = new System.Drawing.Point(437, 3);
            this.NonLethalDamageHistory.Name = "NonLethalDamageHistory";
            this.NonLethalDamageHistory.NumericLabelText = "Add";
            this.NonLethalDamageHistory.Size = new System.Drawing.Size(212, 368);
            this.NonLethalDamageHistory.TabIndex = 2;
            this.NonLethalDamageHistory.TextBoxLabelText = "Total Non Lethal Damage";
            this.NonLethalDamageHistory.Title = "Non Lethal Damage";
            this.NonLethalDamageHistory.Load += new System.EventHandler(this.NonLethalDamageHistory_Load);
            // 
            // LethalDamageHistory
            // 
            this.LethalDamageHistory.AutoAddToHistory = false;
            this.LethalDamageHistory.AutoRefreshValue = true;
            this.LethalDamageHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LethalDamageHistory.HeldHistory = null;
            this.LethalDamageHistory.Location = new System.Drawing.Point(220, 3);
            this.LethalDamageHistory.Name = "LethalDamageHistory";
            this.LethalDamageHistory.NumericLabelText = "Add";
            this.LethalDamageHistory.Size = new System.Drawing.Size(211, 368);
            this.LethalDamageHistory.TabIndex = 0;
            this.LethalDamageHistory.TextBoxLabelText = "Total Lethal Damage";
            this.LethalDamageHistory.Title = "Lethal Damage";
            this.LethalDamageHistory.Load += new System.EventHandler(this.LethalDamageHistory_Load);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 4;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel7.Controls.Add(this.StatusTextBox, 3, 1);
            this.tableLayoutPanel7.Controls.Add(this.UnawareACTextBox, 2, 1);
            this.tableLayoutPanel7.Controls.Add(this.EffectHealthTextBox, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.ACTextBox, 3, 0);
            this.tableLayoutPanel7.Controls.Add(this.TouchACTextBox, 2, 0);
            this.tableLayoutPanel7.Controls.Add(this.BaseHealthTextBox, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.RemainingHPTextBox, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.NonLethalHPTextBox, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 383);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(652, 92);
            this.tableLayoutPanel7.TabIndex = 5;
            // 
            // NonLethalHPTextBox
            // 
            this.NonLethalHPTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NonLethalHPTextBox.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NonLethalHPTextBox.LabelOnTop = false;
            this.NonLethalHPTextBox.LabelText = "Non-Lethal HP";
            this.NonLethalHPTextBox.Location = new System.Drawing.Point(3, 3);
            this.NonLethalHPTextBox.Name = "NonLethalHPTextBox";
            this.NonLethalHPTextBox.Size = new System.Drawing.Size(157, 40);
            this.NonLethalHPTextBox.TabIndex = 18;
            this.NonLethalHPTextBox.TextBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NonLethalHPTextBox.TextBoxReadOnly = true;
            this.NonLethalHPTextBox.TextBoxText = "";
            this.NonLethalHPTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RemainingHPTextBox
            // 
            this.RemainingHPTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemainingHPTextBox.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemainingHPTextBox.LabelOnTop = true;
            this.RemainingHPTextBox.LabelText = "Remaining HP";
            this.RemainingHPTextBox.Location = new System.Drawing.Point(3, 49);
            this.RemainingHPTextBox.Name = "RemainingHPTextBox";
            this.RemainingHPTextBox.Size = new System.Drawing.Size(157, 40);
            this.RemainingHPTextBox.TabIndex = 20;
            this.RemainingHPTextBox.TextBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemainingHPTextBox.TextBoxReadOnly = true;
            this.RemainingHPTextBox.TextBoxText = "";
            this.RemainingHPTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BaseHealthTextBox
            // 
            this.BaseHealthTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseHealthTextBox.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseHealthTextBox.LabelOnTop = false;
            this.BaseHealthTextBox.LabelText = "Base Health";
            this.BaseHealthTextBox.Location = new System.Drawing.Point(166, 3);
            this.BaseHealthTextBox.Name = "BaseHealthTextBox";
            this.BaseHealthTextBox.Size = new System.Drawing.Size(157, 40);
            this.BaseHealthTextBox.TabIndex = 22;
            this.BaseHealthTextBox.TextBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseHealthTextBox.TextBoxReadOnly = true;
            this.BaseHealthTextBox.TextBoxText = "";
            this.BaseHealthTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TouchACTextBox
            // 
            this.TouchACTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TouchACTextBox.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TouchACTextBox.LabelOnTop = false;
            this.TouchACTextBox.LabelText = "Touch AC";
            this.TouchACTextBox.Location = new System.Drawing.Point(329, 3);
            this.TouchACTextBox.Name = "TouchACTextBox";
            this.TouchACTextBox.Size = new System.Drawing.Size(157, 40);
            this.TouchACTextBox.TabIndex = 26;
            this.TouchACTextBox.TextBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TouchACTextBox.TextBoxReadOnly = true;
            this.TouchACTextBox.TextBoxText = "";
            this.TouchACTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ACTextBox
            // 
            this.ACTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ACTextBox.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ACTextBox.LabelOnTop = false;
            this.ACTextBox.LabelText = "AC";
            this.ACTextBox.Location = new System.Drawing.Point(492, 3);
            this.ACTextBox.Name = "ACTextBox";
            this.ACTextBox.Size = new System.Drawing.Size(157, 40);
            this.ACTextBox.TabIndex = 28;
            this.ACTextBox.TextBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ACTextBox.TextBoxReadOnly = true;
            this.ACTextBox.TextBoxText = "";
            this.ACTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EffectHealthTextBox
            // 
            this.EffectHealthTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EffectHealthTextBox.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EffectHealthTextBox.LabelOnTop = true;
            this.EffectHealthTextBox.LabelText = "Effect Health";
            this.EffectHealthTextBox.Location = new System.Drawing.Point(166, 49);
            this.EffectHealthTextBox.Name = "EffectHealthTextBox";
            this.EffectHealthTextBox.Size = new System.Drawing.Size(157, 40);
            this.EffectHealthTextBox.TabIndex = 30;
            this.EffectHealthTextBox.TextBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EffectHealthTextBox.TextBoxReadOnly = true;
            this.EffectHealthTextBox.TextBoxText = "";
            this.EffectHealthTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UnawareACTextBox
            // 
            this.UnawareACTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UnawareACTextBox.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnawareACTextBox.LabelOnTop = true;
            this.UnawareACTextBox.LabelText = "Unaware AC";
            this.UnawareACTextBox.Location = new System.Drawing.Point(329, 49);
            this.UnawareACTextBox.Name = "UnawareACTextBox";
            this.UnawareACTextBox.Size = new System.Drawing.Size(157, 40);
            this.UnawareACTextBox.TabIndex = 34;
            this.UnawareACTextBox.TextBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnawareACTextBox.TextBoxReadOnly = true;
            this.UnawareACTextBox.TextBoxText = "";
            this.UnawareACTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StatusTextBox
            // 
            this.StatusTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusTextBox.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusTextBox.LabelOnTop = true;
            this.StatusTextBox.LabelText = "Status";
            this.StatusTextBox.Location = new System.Drawing.Point(492, 49);
            this.StatusTextBox.Name = "StatusTextBox";
            this.StatusTextBox.Size = new System.Drawing.Size(157, 40);
            this.StatusTextBox.TabIndex = 35;
            this.StatusTextBox.TextBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusTextBox.TextBoxReadOnly = true;
            this.StatusTextBox.TextBoxText = "";
            this.StatusTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.HpThrowsBoard, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.HpThrowsLabel, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(211, 368);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // HpThrowsBoard
            // 
            this.HpThrowsBoard.AutoScroll = true;
            this.HpThrowsBoard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.HpThrowsBoard.ColumnCount = 1;
            this.HpThrowsBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.HpThrowsBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HpThrowsBoard.Location = new System.Drawing.Point(3, 3);
            this.HpThrowsBoard.Name = "HpThrowsBoard";
            this.HpThrowsBoard.RowCount = 1;
            this.HpThrowsBoard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.HpThrowsBoard.Size = new System.Drawing.Size(205, 349);
            this.HpThrowsBoard.TabIndex = 4;
            this.HpThrowsBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.HpThrowsBoard_Paint);
            // 
            // HpThrowsLabel
            // 
            this.HpThrowsLabel.AutoSize = true;
            this.HpThrowsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HpThrowsLabel.Location = new System.Drawing.Point(3, 355);
            this.HpThrowsLabel.Name = "HpThrowsLabel";
            this.HpThrowsLabel.Size = new System.Drawing.Size(205, 13);
            this.HpThrowsLabel.TabIndex = 5;
            this.HpThrowsLabel.Text = "HP Throws";
            this.HpThrowsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BigHealthCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BigHealthCard";
            this.Size = new System.Drawing.Size(658, 478);
            this.Load += new System.EventHandler(this.BigHealthCard_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public HistoryBoard LethalDamageHistory;
        public HistoryBoard NonLethalDamageHistory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private Components.LabeledTextbox RemainingHPTextBox;
        private Components.LabeledTextbox NonLethalHPTextBox;
        private Components.LabeledTextbox ACTextBox;
        private Components.LabeledTextbox TouchACTextBox;
        private Components.LabeledTextbox BaseHealthTextBox;
        private Components.LabeledTextbox EffectHealthTextBox;
        private Components.LabeledTextbox StatusTextBox;
        private Components.LabeledTextbox UnawareACTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel HpThrowsBoard;
        private System.Windows.Forms.Label HpThrowsLabel;
    }
}
