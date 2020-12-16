using DiegoG.DnDTools.Base.Items.Info;
using DiegoG.DnDTools.Base.Other;

namespace DiegoG.DnDTools.Base.Items.Weapons
{

    public class Melee : Weapon
    {
        public CriticalHit Critical { get; set; }
        public Melee() { }
        public Melee(NameDesc nameDesc) : base(nameDesc) { }
    }
}
