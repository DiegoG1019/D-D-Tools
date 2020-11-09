﻿using DiegoG.DnDNetCore.Items.Info;
using DiegoG.Utilities;
using static DiegoG.DnDNetCore.Enumerations;

namespace DiegoG.DnDNetCore.Items.Weapons
{
    public class Weapon : Item
    {
        public AttackDamage Damage { get; set; }
        public AttackThrow AttackThrow { get; set; }
        public string Type { get; set; }
        public string Impact { get; set; }
        public Length Reach { get; set; }
    }
}