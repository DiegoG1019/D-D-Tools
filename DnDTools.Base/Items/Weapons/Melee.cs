using DiegoG.DnDTools.Base.Items.Info;
using DiegoG.DnDTools.Base.Other;

namespace DiegoG.DnDTools.Base.Items.Weapons
{

    public class Melee : Weapon
    {
        public CriticalHit Critical { get => CriticalField; set { CriticalField = value; NotifyPropertyChanged(); } }
        private CriticalHit CriticalField;
        public Melee() : base() { }
        public Melee(NameDesc nameDesc) : base(nameDesc) { }
    }
}
