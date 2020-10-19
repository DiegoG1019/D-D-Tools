using System;
using System.Windows.Forms;

namespace DiegoG.DnDTDesktop.GUI.Elements.Components
{
    public partial class LabeledNumericBox : UserControl
    {

        public HorizontalAlignment NumericTextAlignment
        {
            get => Numeric.TextAlign;
            set => Numeric.TextAlign = value;
        }
        public string LabelText
        {
            get => Label.Text;
            set => Label.Text = value;
        }
        public int NumericValue
        {
            get => (int)Numeric.Value;
            set => Numeric.Value = value;
        }
        public LabeledNumericBox()
        {
            InitializeComponent();
            Numeric.Maximum = int.MaxValue;
            CommitButton.Click += (sender,e) => CommitButtonClicked(sender, new LabeledNumericBoxEventArgs(NumericValue));
        }
        private bool _lot;
        public bool LabelOnTop
        {
            get => _lot;
            set
            {
                _lot = value;
                LayoutPanel.Controls.Clear();
                if (LabelOnTop)
                {
                    LayoutPanel.Controls.Add(Label, 0, 0);
                    LayoutPanel.Controls.Add(NumericButtonTable, 0, 1);
                }
                else
                {
                    LayoutPanel.Controls.Add(NumericButtonTable, 0, 0);
                    LayoutPanel.Controls.Add(Label, 0, 1);
                }
            }
        }

        public event Action<object, LabeledNumericBoxEventArgs> CommitButtonClicked;
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    public class LabeledNumericBoxEventArgs : EventArgs
    {
        public int HeldValue { get; private set; }
        public LabeledNumericBoxEventArgs(int val) => HeldValue = val;
    }

}
