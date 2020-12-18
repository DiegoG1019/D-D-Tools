using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities;
using DiegoG.Utilities.Measures;

namespace DiegoG.DnDTools.Base.Items.Weapons
{

    public class Ranged : Weapon
    {
        public Length Range { get; set; }
        public Ranged() { }
        public Ranged(NameDesc nameDesc) : base(nameDesc) { }
    }
}
