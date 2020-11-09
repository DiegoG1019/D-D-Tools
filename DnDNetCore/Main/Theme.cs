using DiegoG.Utilities.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DiegoG.DnDNetCore
{
    public class Theme : ISettings
    {
        public ulong Version { get; } = 0;

        public Color CommonTextColor { get; set; } = Color.FromArgb(0xFF, 0x00, 0x00, 0x00);
        public Color CommonButtonTextColor { get; set; } = Color.FromArgb(0xFF, 0x00, 0x00, 0x00);
        public Color CommonButtonBackgroundColor { get; set; } = Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD);
        public Color CommonButtonBorderColor { get; set; } = Color.FromArgb(0xFF, 0x70, 0x70, 0x70);
        public double CommonButtonBorderThickness { get; set; } = 1;
        public Color CommonBackgroundColor { get; set; } = Color.FromArgb(0xFF, 0xE6, 0xE6, 0xE6);
        public Color BorderColor1 { get; set; } = Color.FromArgb(0xFF, 0x00, 0x00, 0x00);
        public double BorderThickness1 { get; set; } = .5;
        public Color BorderColor2 { get; set; } = Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF);
        public double BorderThickness2 { get; set; } = .5;

#if DEBUG
        public Theme()
        {

        }
#endif
    }
}
