using DiegoG.DnDTools.Base.Items.Weapons;
using DiegoG.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.DnDTools.Base.Cache.Items.Weapons
{
    public static class RangedWeapons
    {
        public static IEnumerable<Ranged> All { get; } = ReflectionCollectionMethods.GetAllMatchingTypeStaticPropertyValues<Ranged>(typeof(RangedWeapons));

    }
}
