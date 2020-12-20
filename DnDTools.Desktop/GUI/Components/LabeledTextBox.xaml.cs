using System.Windows.Controls;

namespace DiegoG.DnDTools.Desktop.GUI.Components
{
    /// <summary>
    /// Interaction logic for LabeledTextBox.xaml
    /// </summary>
    public partial class LabeledTextBox
    {
        public delegate void LabeledTextBoxTextChangedEventHandler(object sender, TextChangedEventArgs e, string newtext);
        public event LabeledTextBoxTextChangedEventHandler TextBoxChanged;
        public LabeledTextBox()
        {
            InitializeComponent();
            Identify(_Label, _Item, _BorderRectangle, _BorderRow);
            _Item.TextChanged += (s, a) => TextBoxChanged(s, a, ItemTextBoxText);
            TextBoxChanged += (s, a, t) => { };
        }
        public bool ReadOnly
        {
            get => _Item.IsReadOnly;
            set => _Item.IsReadOnly = value;
        }
        public string ItemTextBoxText
        {
            get => _Item.Text;
            set => _Item.Text = value;
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
