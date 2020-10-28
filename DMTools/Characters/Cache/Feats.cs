﻿using DiegoG.DnDTDesktop.Characters.Complements;
using static DiegoG.DnDTDesktop.Enumerations;
using DiegoG.DnDTDesktop.Other;
using System.Collections.Generic;
using DiegoG.Utilities;
using DiegoG.DnDTDesktop.Properties;

namespace DiegoG.DnDTDesktop.Characters.Cache
{
    public static class Feats
    {
        public static Ability WeaponFinesse => new Ability()
        {
            Name = "Weapon Finesse",
            Description = "With a light weapon, rapier, whip, or spiked chain made for a creature of your size category, you may use your Dexterity modifier instead of your Strength modifier on attack rolls. If you carry a shield, its armor check penalty applies to your attack rolls.",
            Requirements = "Base attack bonus +1.",
        };
        public static Ability EfficientStrike => new Ability()
        {
            Name = "Efficient Strike",
            Description = "Able to stack Sneak Attack to Critical Hits",
            Requirements = "Dex. 20",
        };
    }
}
