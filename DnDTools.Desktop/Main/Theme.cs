using DiegoG.Utilities.Settings;
using DiegoG.WPF;
using System.Windows.Media;

namespace DiegoG.DnDTools.Desktop
{
    public class Theme : ISettings
    {
        public ulong Version { get; } = 3;

        /// <summary>
        /// Defaults to Black
        /// </summary>
        public Color CommonTextColor { get; set; } = Colors.Black;
        /// <summary>
        /// Defaults to light gray (0xFFE6E6E6)
        /// </summary>
        public Color CommonWidgetBackgroundColor { get; set; } = ColorExtensions.FromArgbUInt32(0xFFE6E6E6);
        /// <summary>
        /// Defaults to Transparent
        /// </summary>
        public Color CommonElementBackgroundColor { get; set; } = Colors.Transparent;
        /// <summary>
        /// Defaults to lightblue (0xFF729FCF)
        /// </summary>
        public Color HighlightedElementBackgroundColor1 { get; set; } = ColorExtensions.FromArgbUInt32(0xFF729FCF);
        /// <summary>
        /// Defaults to medium red (0xFFB40E16)
        /// </summary>
        public Color HighlightedElementBackgroundColor2 { get; set; } = ColorExtensions.FromArgbUInt32(0xFFB40E16);
        /// <summary>
        /// Commonly used for textboxes and other elements, defaults to 12
        /// </summary>
        public double CommonFontSize1 { get; set; } = 12;
        /// <summary>
        /// Commonly used for labels, defaults to 12
        /// </summary>
        public double CommonFontSize2 { get; set; } = 12;
        /// <summary>
        /// Commonly used for multiline labels, defaults to 8
        /// </summary>
        public double CommonFontSize3 { get; set; } = 8;
        /// <summary>
        /// For large controls, defaults to 16;
        /// </summary>
        public double BigFontSize1 { get; set; } = 16;
        /// <summary>
        /// Defaults to Black
        /// </summary>
        public Color CommonButtonTextColor { get; set; } = Colors.Black;
        /// <summary>
        /// Defaults to gray (0xFFDDDDDD)
        /// </summary>
        public Color CommonButtonBackgroundColor { get; set; } = ColorExtensions.FromArgbUInt32(0xFFDDDDDD);
        /// <summary>
        /// Defaults to gray (0xFF707070)
        /// </summary>
        public Color CommonButtonBorderColor { get; set; } = ColorExtensions.FromArgbUInt32(0xFF707070);
        /// <summary>
        /// Defaults to 1
        /// </summary>
        public double CommonButtonBorderThickness { get; set; } = 1;
        /// <summary>
        /// Defaults to Black
        /// </summary>
        public Color BorderColor1 { get; set; } = Colors.Black;
        /// <summary>
        /// Defaults to .5
        /// </summary>
        public double BorderThickness1 { get; set; } = .5;
        /// <summary>
        /// Defaults to White
        /// </summary>
        public Color BorderColor2 { get; set; } = Colors.White;
        /// <summary>
        /// Defaults to .5
        /// </summary>
        public double BorderThickness2 { get; set; } = .5;

#if DEBUG
        public Theme()
        {

        }
#endif
    }
}
