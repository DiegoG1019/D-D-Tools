using static DiegoG.DnDTDesktop.Enumerations;
using DiegoG.Utilities;

namespace DiegoG.DnDTDesktop.Properties
{
    public sealed partial class Settings
    {
        public Verbosity Verbosity
        {
            get => (Verbosity)___Vb;
            set => ___Vb = (int)value;
        }
        public Length.Units PreferredLengthUnit
        {
            get => (Length.Units)_PreferredLengthUnit;
            set => _PreferredLengthUnit = (int)value;
        }
        public Mass.Units PreferredMassUnit
        {
            get => (Mass.Units)_PreferredMassUnit;
            set => _PreferredMassUnit = (int)value;
        }
    }
}
