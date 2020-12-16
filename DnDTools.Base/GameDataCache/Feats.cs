using DiegoG.DnDTools.Base.Characters.Complements;
using static DiegoG.DnDTools.Base.Enumerations;
using DiegoG.DnDTools.Base.Other;
using System.Collections.Generic;
using DiegoG.DnDTools.Base.Characters;
using DiegoG.Utilities;
using DiegoG.Utilities.Settings;
using DiegoG.Utilities.Collections;

namespace DiegoG.DnDTools.Base.Cache
{
    public static class Feats
    {
        public static IEnumerable<Ability> All { get; } = ReflectionCollectionMethods.GetAllMatchingTypeStaticPropertyValues<Ability>(typeof(Feats));
        private static Lang SetLang => Settings<Lang>.Current;
        public static Ability WeaponFinesse => new Ability()
        {
            Name = SetLang.WeaponFinesse.Name,
            Description = SetLang.WeaponFinesse.Description,
            Requirements = $"{SetLang.BaseAttackBonusText} +1.",
        };
        public static Ability EfficientStrike => new Ability()
        {
            Name = SetLang.EfficientStrike.Name,
            Description = SetLang.EfficientStrike.Description,
            Requirements = $"{SetLang.ShortStatsStrings[Stats.Dexterity]}. 20",
        };
    }
}
