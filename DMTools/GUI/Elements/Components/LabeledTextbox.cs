using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiegoG.DnDTDesktop.GUI.Elements.Components
{
    public partial class LabeledTextbox : UserControl
    {
        public HorizontalAlignment TextBoxTextAlignment
        {
            get => textBox1.TextAlign;
            set => textBox1.TextAlign = value;
        }
        public bool TextBoxReadOnly
        {
            get => textBox1.ReadOnly;
            set => textBox1.ReadOnly = value;
        }
        public string LabelText
        {
            get => label1.Text;
            set => label1.Text = value;
        }
        public string TextBoxText
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }
        public LabeledTextbox()
        {
            InitializeComponent();
        }
    }
}
