using DiegoG.DnDTools.Base.Items.Weapons;
using DiegoG.Utilities.Collections;
using System.Collections.Generic;

namespace DiegoG.DnDTools.Base.Cache.Items.Weapons
{
    public static class RangedWeapons
    {
        public static IEnumerable<Ranged> All { get; } = ReflectionCollectionMethods.GetAllMatchingTypeStaticPropertyValues<Ranged>(typeof(RangedWeapons));

    }
}
