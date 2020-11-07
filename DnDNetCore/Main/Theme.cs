using DiegoG.Utilities.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.DnDNetCore
{
    public class Theme : ISettings
    {
        public Color InfoBoxColor { get; set; } = Color.White;
        public Color TextColor { get; set; } = Color.Black;
        public Color BackgroundColor { get; set; } = Color.Black;
        public Color BackgroundText { get; set; } = Color.LightGray;
        public Color ModifierBoxColor1 { get; set; } = Color.White;
        public Color ModifierBoxColor2 { get; set; } = Color.LightGray;
        public Color TemporaryModifierBoxColor1 { get; set; } = Color.LightBlue;
        public Color TemporaryModifierBoxColor2 { get; set; } = Color.PowderBlue;
        public Color TemporaryModifierBoxColor3 { get; set; } = Color.DeepSkyBlue;
        public Color AlternateinfoBoxColor { get; set; } = Color.Silver;
        public Color SavingThrowBoxColor1 { get; set; } = Color.IndianRed;
        public Color SavingThrowBoxColor2 { get; set; } = Color.Firebrick;
        public Color InfoBoxColor2 { get; set; } = Color.DarkGray;
        public Color HeaderBoxColor { get; set; } = Color.DimGray;
    }
}
