using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities;
using DiegoG.Utilities.Measures;

namespace DiegoG.DnDTools.Base.Items.Weapons
{

    public class Ranged : Weapon
    {
        public Length Range { get => RangeField; set { RangeField = value; NotifyPropertyChanged(); } }
        private Length RangeField = new(30, Length.Units.Foot);
        public Ranged() : base() { }
        public Ranged(NameDesc nameDesc) : base(nameDesc) { }
    }
}
