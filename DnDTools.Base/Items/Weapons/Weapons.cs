using DiegoG.DnDTools.Base.Items.Info;
using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities.Measures;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.Base.Items.Weapons
{
    public class Weapon : Item
    {
        public AttackDamage Damage { get => DamageField; set { DamageField = value; NotifyPropertyChanged(); } }
        private AttackDamage DamageField;
        public AttackThrow AttackThrow { get => AttackThrowField; set { AttackThrowField = value; NotifyPropertyChanged(); } }
        private AttackThrow AttackThrowField;
        public WeaponCategory Category { get => CategoryField; set { CategoryField = value; NotifyPropertyChanged(); } }
        private WeaponCategory CategoryField;
        public ImpactType Impact { get => ImpactField; set { ImpactField = value; NotifyPropertyChanged(); } }
        private ImpactType ImpactField;
        public Length Reach { get => ReachField; set { ReachField = value; NotifyPropertyChanged(); } }
        private Length ReachField;

        public Weapon() : base() { }
        public Weapon(NameDesc nameDesc) : base(nameDesc) { }
    }
}
