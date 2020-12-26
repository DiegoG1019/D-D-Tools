using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities;

namespace DiegoG.DnDTools.Base.Items
{
    public class Armor : Item
    {
        public int Protection { get => ProtectionField; set { ProtectionField = value; NotifyPropertyChanged(); } }
        private int ProtectionField;
        public ushort MaximumDeterity { get => MaximumDeterityField; set { MaximumDeterityField = value; NotifyPropertyChanged(); } }
        private ushort MaximumDeterityField;
        public int Penalty { get => PenaltyField; set { PenaltyField = value; NotifyPropertyChanged(); } }
        private int PenaltyField;
        public Percentage SpellFailure { get => SpellFailureField; set { SpellFailureField = value; NotifyPropertyChanged(); } }
        private Percentage SpellFailureField = new Percentage(0);
        public int SpeedModifier { get => SpeedPenaltyField; set { SpeedPenaltyField = value; NotifyPropertyChanged(); } }
        private int SpeedPenaltyField;
        public Armor() : base() { }
        public Armor(NameDesc nameDesc) : base(nameDesc) { }
    }
}
