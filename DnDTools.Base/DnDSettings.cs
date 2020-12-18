using DiegoG.Utilities.Measures;
using DiegoG.Utilities.Settings;

namespace DiegoG.DnDTools.Base
{
    public class DnDSettings : ISettings
    {
        public ulong Version { get; } = 0;

        public Mass CoinWeight { get; set; } = new Mass(20, Mass.Units.Gram);
        public int SquareSize { get; set; } = 5;
        public int IncapacitatedHP { get; set; } = 0;
        public int BleedingOutHP { get; set; } = -5;
        public int DeceasedHP { get; set; } = -10;
        public Length.Units PreferredLengthUnit { get; set; } = Length.Units.Meter;
        public Mass.Units PreferredMassUnit { get; set; } = Mass.Units.Kilogram;
        ///Just like the previous one, the purpose of this is to initialize some of the members to different defaults if 
#if DEBUG
        public DnDSettings()
        {
        }
#endif
    }
}
