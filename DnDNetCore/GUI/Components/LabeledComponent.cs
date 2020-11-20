using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DiegoG.DnDNetCore.GUI.Components
{
    public abstract class LabeledComponent : UserControl, IThemeable
    {
        public Label Label { get; private set; }
        public Control Item { get; private set; }
        public Rectangle Separator { get; private set; }
        public RowDefinition BorderRow { get; private set; }
        public void Identify(Label label, Control item, Rectangle separator, RowDefinition borderrow)
        { Label = label; Item = item; Separator = separator; BorderRow = borderrow; }

        public virtual void PaintTheme(Theme theme)
        {
            BackgroundColor = theme.CommonElementBackgroundColor;
            ForegroundColor = theme.CommonTextColor;
            LabelFontSize = theme.CommonFontSize2;
        }

        public int TopOfGrid => 0;
        public int BottomOfGrid => 2;

        private Color _ilbc;
        public Color LabelBackColor
        {
            get => _ilbc;
            set { Label.Background = new SolidColorBrush(value); _ilbc = value; }
        }

        private Color _itbbc;
        public Color ItemBackColor
        {
            get => _itbbc;
            set { Item.Background = new SolidColorBrush(value); _itbbc = value; }
        }

        private Color _iltc;
        public Color LabelTextColor
        {
            get => _iltc;
            set { Label.Foreground = new SolidColorBrush(value); _iltc = value; }
        }

        private Color _itbtc;
        public Color ItemForeColor
        {
            get => _itbtc;
            set { Item.Foreground = new SolidColorBrush(value); _itbtc = value; }
        }
        public Color BackgroundColor
        {
            set
            {
                ItemBackColor = value;
                LabelBackColor = value;
            }
        }
        public Color ForegroundColor
        {
            set
            {
                ItemForeColor = value;
                LabelTextColor = value;
            }
        }
        public string LabelText
        {
            get => (string)Label.Content;
            set => Label.Content = value;
        }
        public double LabelFontSize
        {
            get => Label.FontSize;
            set => Label.FontSize = value;
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
                    Grid.SetRow(Label, TopOfGrid);
                    Grid.SetRow(Item, BottomOfGrid);
                    return;
                }
                Grid.SetRow(Label, BottomOfGrid);
                Grid.SetRow(Item, TopOfGrid);
            }
        }
        private Color _sbc = Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF);
        public Color SeparatorBorderColor
        {
            get => _sbc;
            set
            {
                _sbc = value;
                Separator.Fill = new SolidColorBrush(value);
            }
        }

        public double SeparatorBorderThickness
        {
            get => BorderRow.Height.Value;
            set => BorderRow.Height = new System.Windows.GridLength(value, System.Windows.GridUnitType.Pixel);
        }
    }
}
