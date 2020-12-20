using System.Collections;
using System.Windows.Controls;

namespace DiegoG.DnDTools.Desktop.GUI.Components
{
    /// <summary>
    /// Interaction logic for LabeledDropDown.xaml
    /// </summary>
    public partial class LabeledDropDown : LabeledComponent
    {
        public delegate void LabeledDropDownSelectionChangedEventHandler(object sender, SelectionChangedEventArgs e, int newindex);
        public event LabeledDropDownSelectionChangedEventHandler SelectionChanged;

        public LabeledDropDown()
        {
            InitializeComponent();
            Identify(_Label, _Item, _BorderRectangle, _BorderRow);
            _Item.SelectionChanged += (s, a) => SelectionChanged(s, a, _Item.SelectedIndex);
            SelectionChanged += (s, a, t) => { };
        }

        public IEnumerable ItemDropDownSource
        {
            get => _Item.ItemsSource;
            set => _Item.ItemsSource = value;
        }
        public bool IsReadOnly
        {
            get => _Item.IsReadOnly;
            set => _Item.IsReadOnly = value;
        }
        public bool IsEditable
        {
            get => _Item.IsEditable;
            set => _Item.IsEditable = value;
        }
        public int ItemDropDownIndex
        {
            get => _Item.SelectedIndex;
            set => _Item.SelectedIndex = value;
        }
        public object ItemDropDownSelectedItem => _Item.SelectedItem;
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
