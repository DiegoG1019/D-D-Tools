using DiegoG.WPF;
using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace DiegoG.DnDTools.Desktop.GUI
{
    public static class Extensions
    {
        /// <summary>
        /// Not recommended for all controls.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="theme"></param>
        public static void PaintControlTheme(this Control control, Theme theme)
        {
            control.Background = new SolidColorBrush(theme.CommonElementBackgroundColor);
            control.Foreground = new SolidColorBrush(theme.CommonTextColor);
            control.FontSize = theme.CommonFontSize1;
            var (left, top, right, bottom) = control.BorderThickness;
            left = left == 0 ? 0 : theme.BorderThickness1;
            top = top == 0 ? 0 : theme.BorderThickness1;
            right = right == 0 ? 0 : theme.BorderThickness1;
            bottom = bottom == 0 ? 0 : theme.BorderThickness1;
            control.BorderThickness = new System.Windows.Thickness(left, top, right, bottom);
            if (control.BorderBrush is not null)
                control.BorderBrush = new SolidColorBrush(theme.BorderColor1);
        }
    }
}
