using System.Drawing;
using System.Windows.Forms;

namespace DiegoG.DnDTDesktop.GUI.Elements.Components
{
    public partial class LabeledTextbox : UserControl
    {
        public HorizontalAlignment TextBoxTextAlignment
        {
            get => TextBox.TextAlign;
            set => TextBox.TextAlign = value;
        }
        public bool TextBoxReadOnly
        {
            get => TextBox.ReadOnly;
            set => TextBox.ReadOnly = value;
        }
        public string LabelText
        {
            get => Label.Text;
            set => Label.Text = value;
        }
        public string TextBoxText
        {
            get => TextBox.Text;
            set => TextBox.Text = value;
        }
        public Font TextBoxFont
        {
            get => TextBox.Font;
            set => TextBox.Font = value;
        }
        public Font LabelFont
        {
            get => Label.Font;
            set => Label.Font = value;
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
                    LayoutPanel.Controls.Add(TextBox, 0, 1);
                }
                else
                {
                    LayoutPanel.Controls.Add(TextBox, 0, 0);
                    LayoutPanel.Controls.Add(Label, 0, 1);
                }
            }
        }
        public LabeledTextbox()
        {
            InitializeComponent();
            LayoutPanel.Controls.Clear();
            LabelOnTop = LabelOnTop;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {

        }
    }
}
