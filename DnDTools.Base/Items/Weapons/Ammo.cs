using DiegoG.DnDTools.Base.Items.Info;
using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities.Measures;

namespace DiegoG.DnDTools.Base.Items.Weapons
{
    public class Ammo : Weapon // As of now, it's really just a Melee weapon
    {
        public CriticalHit Critical { get => CriticalField; set { CriticalField = value; NotifyPropertyChanged(); } }
        private CriticalHit CriticalField;
        public Length ExtraRange { get => ExtraRangeField; set { ExtraRangeField = value; NotifyPropertyChanged(); } }
        private Length ExtraRangeField = Length.Zero;
        public Ammo() : base() { }
        public Ammo(NameDesc nameDesc) : base(nameDesc) { }
    }
}
