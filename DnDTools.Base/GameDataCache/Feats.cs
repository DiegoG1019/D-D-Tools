using DiegoG.DnDTools.Base.Characters;
using DiegoG.Utilities.Collections;
using DiegoG.Utilities.Settings;
using System.Collections.Generic;
using static DiegoG.DnDTools.Base.Enumerations;
using static DiegoG.DnDTools.Base.Lang;

namespace DiegoG.DnDTools.Base.Cache
{
    public static class Feats
    {
        public static IEnumerable<Ability> All { get; } = ReflectionCollectionMethods.GetAllMatchingTypeStaticPropertyValues<Ability>(typeof(Feats));
        private static FeatsAndAbilitiesLang FeatLang => Settings<Lang>.Current.FeatsAndAbilities;
        private static Lang Lang => Settings<Lang>.Current;
        public static Ability WeaponFinesse => new Ability()
        {
            Name = FeatLang.WeaponFinesse.Name,
            Description = FeatLang.WeaponFinesse.Description,
            Requirements = $"{Lang.Other.BaseAttackBonusText} +1.",
        };
        public static Ability EfficientStrike => new Ability()
        {
            Name = FeatLang.EfficientStrike.Name,
            Description = FeatLang.EfficientStrike.Description,
            Requirements = $"{Lang.ShortStatsStrings[Stats.Dexterity]}. 20",
        };
    }
}
