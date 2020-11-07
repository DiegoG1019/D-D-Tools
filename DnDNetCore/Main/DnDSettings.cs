using DiegoG.Utilities;
using DiegoG.Utilities.Collections;
using DiegoG.Utilities.Enumerations;
using DiegoG.Utilities.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DiegoG.DnDNetCore
{
    public class DnDSettings : ApplicationSettings
    {
        public Mass CoinWeight { get; set; } = new Mass(20, Mass.Units.Gram);
        public int SquareSize { get; set; } = 5;
        public int IncapacitatedHP { get; set; } = 0;
        public int BleedingOutHP { get; set; } = -5;
        public int DeceasedHP { get; set; } = -10;
        public Length.Units PreferredLengthUnit { get; set; } = Length.Units.Meter;
        public Mass.Units PreferredMassUnit { get; set; } = Mass.Units.Kilogram;
        public bool GUIOnStartup { get; set; } = true;
        public string Lang { get; set; } = "eng";
        public string Theme { get; set; } = "default";
        public string DataDirectory { get; set; } = null;
        ///Just like the previous one, the purpose of this is to initialize some of the members to different defaults if 
#if DEBUG
        public DnDSettings()
        {
        }
#endif
    }
}
