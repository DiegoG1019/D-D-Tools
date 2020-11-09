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
    public partial class LabeledNumericBox : UserControl
    {
        public delegate void NumericBoxTextChangedEventHandler(object sender, TextChangedEventArgs e, decimal newnumber);
        public LabeledNumericBox()
        {
            InitializeComponent();
            LabelOnTop = false;
            _bt = _borderItemLabel.BorderThickness.Top * 2;
            ItemTextBox.TextChanged += ItemTextBox_TextChanged;
        }

        private void ItemTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (decimal.TryParse(ItemTextBox.Text, out decimal result))
            {
                TextBoxTextChanged(sender, e, result);
                return;
            }
            ItemTextBox.Text = "0";
        }

        public event NumericBoxTextChangedEventHandler TextBoxTextChanged;

        private Color _ilbc;
        public Color ItemLabelBackColor
        {
            get => _ilbc;
            set { ItemLabel.Background = new SolidColorBrush(value); _ilbc = value; }
        }

        private Color _itbbc;
        public Color ItemTextBoxBackColor
        {
            get => _itbbc;
            set { ItemTextBox.Background = new SolidColorBrush(value); _itbbc = value; }
        }

        private Color _iltc;
        public Color ItemLabelTextColor
        {
            get => _iltc;
            set { ItemLabel.Foreground = new SolidColorBrush(value); _iltc = value; }
        }

        private Color _itbtc;
        public Color ItemTextBoxTextColor
        {
            get => _itbtc;
            set { ItemTextBox.Foreground = new SolidColorBrush(value); _itbtc = value; }
        }
        public Color BackgroundColor
        {
            set
            {
                ItemTextBoxBackColor = value;
                ItemLabelBackColor = value;
            }
        }
        public Color ForegroundColor
        {
            set
            {
                ItemTextBoxTextColor = value;
                ItemLabelTextColor = value;
            }
        }
        public bool ReadOnly
        {
            get => ItemTextBox.IsReadOnly;
            set => ItemTextBox.IsReadOnly = value;
        }
        public string ItemLabelText
        {
            get => (string)ItemLabel.Content;
            set => ItemLabel.Content = value;
        }
        public decimal ItemTextBoxText
        {
            get => decimal.Parse(ItemTextBox.Text);
            set => ItemTextBox.Text = value.ToString();
        }
        public double ItemLabelFontSize
        {
            get => ItemLabel.FontSize;
            set => ItemLabel.FontSize = value;
        }
        public double ItemTextBoxFontSize
        {
            get => ItemTextBox.FontSize;
            set => ItemTextBox.FontSize = value;
        }
        private bool _lot;
        public bool LabelOnTop
        {
            get => _lot;
            set
            {
                _lot = value;
                if (_lot)
                {
                    Grid.SetRow(_borderItemLabel, 0);
                    Grid.SetRow(_borderItemTextBox, 1);
                    goto FlipBorders;
                }
                Grid.SetRow(_borderItemLabel, 1);
                Grid.SetRow(_borderItemTextBox, 0);

                FlipBorders:;
                var (leftA, topA, rightA, bottomA) = _borderItemLabel.BorderThickness;
                var (leftB, topB, rightB, bottomB) = _borderItemTextBox.BorderThickness;
                _borderItemLabel.BorderThickness = new Thickness(leftB, topB, rightB, bottomB);
                _borderItemTextBox.BorderThickness = new Thickness(leftA, topA, rightA, bottomA);
                return;
            }
        }
        private Color _sbc = Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF);
        public Color SeparatorBorderColor
        {
            get => _sbc;
            set
            {
                _sbc = value;
                _borderItemTextBox.BorderBrush = new SolidColorBrush(value);
                _borderItemLabel.BorderBrush = new SolidColorBrush(value);
            }
        }
        private double _bt;
        public double SeparatorBorderThickness
        {
            get => _bt;
            set
            {
                _bt = value;
                var (leftItb, _, rightItb, bottomItb) = _borderItemTextBox.BorderThickness;
                var (leftIl, topIl, rightIl, _) = _borderItemLabel.BorderThickness;
                if (_lot)
                {
                    _borderItemLabel.BorderThickness = new Thickness(leftIl, topIl, rightIl, _bt / 2);
                    _borderItemTextBox.BorderThickness = new Thickness(leftItb, _bt / 2, rightItb, bottomItb);
                }
            }
        }
        public Label ItemLabel => _itemLabel;
        public TextBox ItemTextBox => _itemTextBox;
    }
}
