using DiegoG.DnDTools.Base.Items.Info;
using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities;

namespace DiegoG.DnDTools.Base.Items.Weapons
{
    public class Ammo : Weapon // As of now, it's really just a Melee weapon
    {
        public CriticalHit Critical { get; set; }
        public Length ExtraRange { get; set; }
        public Ammo() { }
        public Ammo(NameDesc nameDesc) : base(nameDesc) { }
    }
}
