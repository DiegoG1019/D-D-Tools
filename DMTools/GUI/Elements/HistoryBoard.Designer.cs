namespace DiegoG.DnDTDesktop.GUI.Elements
{
    partial class HistoryBoard
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
            this.Board = new System.Windows.Forms.TableLayoutPanel();
            this.HistoryNameLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.CurrentValueLabeledTextBox = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledTextbox();
            this.LabeledNumericAddition = new DiegoG.DnDTDesktop.GUI.Elements.Components.LabeledNumericBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Board, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.HistoryNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(254, 435);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // Board
            // 
            this.Board.AutoScroll = true;
            this.Board.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Board.ColumnCount = 2;
            this.Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Board.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Board.Location = new System.Drawing.Point(3, 23);
            this.Board.Name = "Board";
            this.Board.RowCount = 1;
            this.Board.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Board.Size = new System.Drawing.Size(248, 289);
            this.Board.TabIndex = 0;
            this.Board.Paint += new System.Windows.Forms.PaintEventHandler(this.Board_Paint);
            // 
            // HistoryNameLabel
            // 
            this.HistoryNameLabel.AutoSize = true;
            this.HistoryNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HistoryNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HistoryNameLabel.Location = new System.Drawing.Point(3, 0);
            this.HistoryNameLabel.Name = "HistoryNameLabel";
            this.HistoryNameLabel.Size = new System.Drawing.Size(248, 20);
            this.HistoryNameLabel.TabIndex = 1;
            this.HistoryNameLabel.Text = "Title";
            this.HistoryNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.CurrentValueLabeledTextBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.LabeledNumericAddition, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 318);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(248, 114);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // CurrentValueLabeledTextBox
            // 
            this.CurrentValueLabeledTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentValueLabeledTextBox.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentValueLabeledTextBox.LabelOnTop = true;
            this.CurrentValueLabeledTextBox.LabelText = "Value";
            this.CurrentValueLabeledTextBox.Location = new System.Drawing.Point(3, 63);
            this.CurrentValueLabeledTextBox.Name = "CurrentValueLabeledTextBox";
            this.CurrentValueLabeledTextBox.Size = new System.Drawing.Size(242, 54);
            this.CurrentValueLabeledTextBox.TabIndex = 2;
            this.CurrentValueLabeledTextBox.TextBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentValueLabeledTextBox.TextBoxReadOnly = true;
            this.CurrentValueLabeledTextBox.TextBoxText = "";
            this.CurrentValueLabeledTextBox.TextBoxTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LabeledNumericAddition
            // 
            this.LabeledNumericAddition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabeledNumericAddition.LabelText = "Add";
            this.LabeledNumericAddition.Location = new System.Drawing.Point(3, 3);
            this.LabeledNumericAddition.Name = "LabeledNumericAddition";
            this.LabeledNumericAddition.NumericTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.LabeledNumericAddition.NumericValue = 0;
            this.LabeledNumericAddition.Size = new System.Drawing.Size(242, 54);
            this.LabeledNumericAddition.TabIndex = 1;
            this.LabeledNumericAddition.Load += new System.EventHandler(this.LabeledNumericAddition_Load);
            // 
            // HistoryBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "HistoryBoard";
            this.Size = new System.Drawing.Size(254, 435);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;

        public System.Windows.Forms.TableLayoutPanel Board;
        public System.Windows.Forms.Label HistoryNameLabel;
        public Components.LabeledTextbox CurrentValueLabeledTextBox;
        public Components.LabeledNumericBox LabeledNumericAddition;
    }
}
