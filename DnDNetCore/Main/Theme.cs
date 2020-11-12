using DiegoG.Utilities.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using DiegoG.Utilities.Exceptions;

namespace DiegoG.DnDNetCore
{
    public class Theme : ISettings
    {
        public ulong Version { get; } = 1;

        public Color CommonTextColor { get; set; } = Colors.Black;
        public Color CommonWidgetBackgroundColor { get; set; } = Color.FromArgb(0xFF, 0xE6, 0xE6, 0xE6);
        public Color CommonElementBackgroundColor { get; set; } = Colors.Transparent;
        public double CommonFontSize1 { get; set; } = 12;
        public double CommonFontSize2 { get; set; } = 12;

        public Color CommonButtonTextColor { get; set; } = Colors.Black;
        public Color CommonButtonBackgroundColor { get; set; } = Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD);
        public Color CommonButtonBorderColor { get; set; } = Color.FromArgb(0xFF, 0x70, 0x70, 0x70);
        public double CommonButtonBorderThickness { get; set; } = 1;

        public Color BorderColor1 { get; set; } = Colors.Black;
        public double BorderThickness1 { get; set; } = .5;
        public Color BorderColor2 { get; set; } = Colors.White;
        public double BorderThickness2 { get; set; } = .5;

#if DEBUG
        public Theme()
        {

        }
#endif
    }
}
