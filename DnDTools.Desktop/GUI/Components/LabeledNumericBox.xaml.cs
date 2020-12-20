using System.Windows.Controls;

namespace DiegoG.DnDTools.Desktop.GUI.Components
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
