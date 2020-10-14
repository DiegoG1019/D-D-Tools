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
            Numeric.Maximum = int.MaxValue;
            InitializeComponent();
        }
    }
}
