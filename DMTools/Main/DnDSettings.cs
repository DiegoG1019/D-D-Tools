using DiegoG.Utilities;
using DiegoG.Utilities.Enumerations;
using DiegoG.Utilities.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.DnDTDesktop
{
    public class DnDSettings : SettingsClass
    {
        public Mass CoinWeight { get; set; } = new Mass(20, Mass.Units.Gram);
        public int SquareSize { get; set; } = 5;
        public int IncapacitatedHP { get; set; } = 0;
        public int BleedingOutHP { get; set; } = -5;
        public int DeceasedHP { get; set; } = -10;
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
        public bool JsonWriteIndented { get; set; } = true;
        public Length.Units PreferredLengthUnit { get; set; } = Length.Units.Meter;
        public Mass.Units PreferredMassUnit { get; set; } = Mass.Units.Kilogram;
        public bool GUIOnStartup { get; set; } = true;
        ///Just like the previous one, the purpose of this is to initialize some of the members to different defaults if 
#if DEBUG
        public DnDSettings()
        {
        }
#endif
    }
}
