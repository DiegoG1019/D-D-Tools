﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.DnDNetCore.Cache.Items.Weapons
{
    public static class Ranged
    {
        public static IEnumerable<Ra> All { get; } = ReflectionCollectionMethods.GetAllMatchingTypeStaticPropertyValues<Ability>(typeof(Abilities));

    }
}