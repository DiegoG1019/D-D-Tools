using DiegoG.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiegoG.DnDNetCore.GUI.Components
{
    /// <summary>
    /// Interaction logic for LabeledNumericBox.xaml
    /// </summary>
    public partial class LabeledNumericBox
    {
        public delegate void NumericBoxTextChangedEventHandler(object sender, TextChangedEventArgs e, double newnumber);
        public event NumericBoxTextChangedEventHandler NumericBoxChanged;

        public LabeledNumericBox()
        {
            InitializeComponent();
            _Item.Text = "0";
            Identify(_Label, _Item, _BorderRectangle, _BorderRow);
            _Item.TextChanged += (s, a) => NumericBoxChanged(s, a, ItemNumericBoxNumber);
            NumericBoxChanged += (s, a, t) => { };
        }

        private void ItemNumericBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(_Item.Text, out double result))
                NumericBoxChanged(sender, e, result);
        }

        public bool ReadOnly
        {
            get => _Item.IsReadOnly;
            set => _Item.IsReadOnly = value;
        }
        public double ItemNumericBoxNumber
        {
            get => double.Parse(_Item.Text);
            set => _Item.Text = value.ToString();
        }
        public double ItemTextBoxFontSize
        {
            get => _Item.FontSize;
            set => _Item.FontSize = value;
        }
        public override void PaintTheme(Theme theme)
        {
            base.PaintTheme(theme);
            ItemTextBoxFontSize = theme.CommonFontSize1;
        }
    }
}
