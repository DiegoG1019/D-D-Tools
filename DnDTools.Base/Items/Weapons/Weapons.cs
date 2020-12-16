using DiegoG.DnDTools.Base.Items.Info;
using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities;
using static DiegoG.DnDTools.Base.Enumerations;
using static DiegoG.DnDTools.Base.Lang;

namespace DiegoG.DnDTools.Base.Items.Weapons
{
    public class Weapon : Item
    {
        public AttackDamage Damage { get; set; }
        public AttackThrow AttackThrow { get; set; }
        public WeaponCategory Category { get; set; }
        public ImpactType Impact { get; set; }
        public Length Reach { get; set; }

        public Weapon() { }
        public Weapon(NameDesc nameDesc) : base(nameDesc) { }
    }
}
