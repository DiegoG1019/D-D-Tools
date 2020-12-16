using System;
using System.Collections;
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
using static DiegoG.DnDTools.Base.Enumerations;

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
            set =>_Item.ItemsSource = value;
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
