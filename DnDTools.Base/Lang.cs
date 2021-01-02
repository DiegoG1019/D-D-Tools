using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities.Measures;
using DiegoG.Utilities.Settings;
using System.Collections.Generic;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.Base
{
    public class Lang : ISettings
    {
        public ulong Version { get; } = 6;

        public UILang UI { get; set; } = new();
        public class UILang
        {
            public string CharacterBasicDataFormatText { get; set; } = "Character Basic Data: {0} ({1})";
            public string CharacterStatsFormatText { get; set; } = "Character Stats: {0} ({1})";
            public string CharacterDataFormatText { get; set; } = "Character Data: {0} ({1})";
            public string ViewNotesText { get; set; } = "View Notes";
            public string ViewIntroText { get; set; } = "Intro";
            public string ViewBioText { get; set; } = "Biography";
            public string RemainingText { get; set; } = "Remaining";
        }

        public OtherLang Other { get; set; } = new();
        public class OtherLang
        {
            public string Currency { get; set; } = " coins";
            public string BaseAttackBonusText { get; set; } = "Base Attack Bonus";
            public string SimpleText { get; set; } = "Simple";
            public string AverageText { get; set; } = "Average";
            public string GoodText { get; set; } = "Good";
            public string SuperiorText { get; set; } = "Superior";
            public string MasterWorkText { get; set; } = "Masterwork";
            public string BaseText { get; set; } = "Base";
            public string CurrentText { get; set; } = "Current";
            public string EffectText { get; set; } = "Effect";
            public string StateText { get; set; } = "State";
            public string NaturalText { get; set; } = "Natural";
            public string DeflectionText { get; set; } = "Deflection";
            public string BagText { get; set; } = "Bag";
            public string BagPluralText { get; set; } = "Bags";
            public string EquippedText { get; set; } = "Equipment";
        }

        public CharacterDataLang CharacterData { get; set; } = new();
        public class CharacterDataLang
        {
            public string ClassText { get; set; } = "Class";
            public string ClassPluralText { get; set; } = "Classes";
            public string SecondaryStatsText { get; set; } = "Secondary Stats";
            public string SavingThrowsText { get; set; } = "Saving Throws";
            public string StatsText { get; set; } = "Stats";
            public string HealthText { get; set; } = "Health";
            public string ArmorClassText { get; set; } = "Armor Class";
            public string ShortArmorClassText { get; set; } = "AC";
            public string TouchArmorClassText { get; set; } = "Touch";
            public string UnawareArmorClassText { get; set; } = "Unaware";
            public string InitiativeText { get; set; } = "Initiative";
            public string SpeedText { get; set; } = "Speed";
            public string ExperienceText { get; set; } = "Experience";
            public string LevelText { get; set; } = "Level";
            public string ExpLevelText { get; set; } = "Exp. Level";
            public string LethalDamageText { get; set; } = "Lethal Damage";
            public string NonLethalDamageText { get; set; } = "Non Lethal Damage";
        }

        public CharacterDescriptionLang CharacterDescription { get; set; } = new();
        public class CharacterDescriptionLang
        {
            public string DescriptionText { get; set; } = "Description";
            public string GenderText { get; set; } = "Gender";
            public string PersonalityText { get; set; } = "Personality";
            public string FullNameText { get; set; } = "Full Name";
            public string RaceText { get; set; } = "Race";
            public string AlignmentText { get; set; } = "Alignment";
            public string DeityText { get; set; } = "Deity";
            public string BodyTypeText { get; set; } = "Body Type";
            public string SizeText { get; set; } = "Size";
            public string AgeText { get; set; } = "Age";
            public string HeightText { get; set; } = "Height";
            public string WeightText { get; set; } = "Weight";
            public string EyeColorText { get; set; } = "Eye Color";
            public string HairColorText { get; set; } = "Hair Color";
            public string SkinColorText { get; set; } = "Skin Color";
        }

        public CharacterSkillsLang CharacterSkills { get; set; } = new();
        public class CharacterSkillsLang
        {
            public string SkillText { get; set; } = "Skill";
            public string SkillPluralText { get; set; } = "Skills";
            public string SkillNameText { get; set; } = "Skill Name";
            public string KeyStatText { get; set; } = "Key Ability";
            public string SkillModifierText { get; set; } = "Skill Modifier";
            public string RanksText { get; set; } = "Rank";
            public string MiscRanksText { get; set; } = "Misc. Rank";
            public string OtherRanksText { get; set; } = "Extra Rank";
            public string ArmorPenalizerText { get; set; } = "Armor Penalizer";
            public string SkillFlagsText { get; set; } = "Skill Flags";
        }

        public CharacterAbilitiesLang CharacterAbilities { get; set; } = new();
        public class CharacterAbilitiesLang
        {
            public string AbilityText { get; set; } = "Ability";
            public string AbilityPluralText { get; set; } = "Abilities";
            public string FeatText { get; set; } = "Feat";
            public string FeatPluralText { get; set; } = "Feats";
        }

        //Enumerations
        public Dictionary<Alignments, string> AlignmentStrings { get; set; } = new Dictionary<Alignments, string>()
        {
            { Alignments.ChaoticEvil, "Chaotic Evil" },
            { Alignments.ChaoticGood, "Chaotic Good" },
            { Alignments.ChaoticNeutral, "Chaotic Neutral" },

            { Alignments.LawfulEvil, "Lawful Evil" },
            { Alignments.LawfulGood, "Lawful Good" },
            { Alignments.LawfulNeutral, "Lawful Neutral" },

            { Alignments.NeutralEvil, "Neutral Evil" },
            { Alignments.NeutralGood, "Neutral Good" },
            { Alignments.TrueNeutral, "True Neutral" },
        };
        public Dictionary<BodyTypes, string> BodyTypeStrings { get; set; } = new Dictionary<BodyTypes, string>()
        {
            { BodyTypes.Aberration, "Aberration" },
            { BodyTypes.Animal, "Animal" },
            { BodyTypes.Construct, "Construct" },
            { BodyTypes.Dragon, "Dragon" },
            { BodyTypes.Elemental, "Elemental" },
            { BodyTypes.Fey, "Fey" },
            { BodyTypes.Giant, "Giant" },
            { BodyTypes.Humanoid, "Humanoid" },
            { BodyTypes.MagicalBeast, "Magical Beast" },
            { BodyTypes.MonstrousHumanoid, "Monstrous Humanoid" },
            { BodyTypes.Ooze, "Ooze" },
            { BodyTypes.Outsider, "Outsider" },
            { BodyTypes.Plant, "Plant" },
            { BodyTypes.Undead, "Undead" },
            { BodyTypes.Vermin, "Vermin" },
        };
        public Dictionary<Sizes, string> SizeStrings { get; set; } = new Dictionary<Sizes, string>()
        {
            { Sizes.Fine, "Fine" },
            { Sizes.Diminutive, "Diminutive" },
            { Sizes.Tiny, "Tiny" },
            { Sizes.Small, "Small" },
            { Sizes.Medium, "Medium" },
            { Sizes.Large, "Large" },
            { Sizes.Huge, "Huge" },
            { Sizes.Gargantuan, "Gargantuan" },
            { Sizes.Colossal, "Colossal" },
        };
        public Dictionary<Stats, string> StatsStrings { get; set; } = new Dictionary<Stats, string>()
        {
            { Stats.Strength, "Strength" },
            { Stats.Constitution, "Constitution" },
            { Stats.Dexterity, "Dexterity" },
            { Stats.Wisdom, "Wisdom" },
            { Stats.Intelligence, "Intelligence" },
            { Stats.Charisma, "Charisma" },
        };
        public Dictionary<Stats, string> ShortStatsStrings { get; set; } = new Dictionary<Stats, string>()
        {
            { Stats.Strength, "Str" },
            { Stats.Constitution, "Con" },
            { Stats.Dexterity, "Dex" },
            { Stats.Wisdom, "Wis" },
            { Stats.Intelligence, "Int" },
            { Stats.Charisma, "Char" },
        };
        public Dictionary<SecondaryStats, string> SecondaryStatsStrings { get; set; } = new Dictionary<SecondaryStats, string>()
        {
            { SecondaryStats.Initiative, "Initiative" },
            { SecondaryStats.Speed, "Speed" },
        };
        public Dictionary<SavingThrow, string> SavingThrowStrings { get; set; } = new Dictionary<SavingThrow, string>()
        {
            { SavingThrow.Fortitude, "Fortitude" },
            { SavingThrow.Reflexes, "Reflexes" },
            { SavingThrow.Willpower, "Willpower" },
        };
        public Dictionary<CombatAction, string> CombatActionStrings { get; set; } = new Dictionary<CombatAction, string>()
        {
            { CombatAction.Free, "Free Action" },
            { CombatAction.FullRound, "Full Round Action" },
            { CombatAction.Immediate, "Immediate Action" },
            { CombatAction.Move, "Move Action" },
            { CombatAction.NotAnAction, "Not an Action" },
            { CombatAction.Standard, "Standard Action" },
            { CombatAction.Swift, "Swift Action" }
        };
        public Dictionary<MagicSchool, string> MagicSchoolStrings { get; set; } = new Dictionary<MagicSchool, string>()
        {
            { MagicSchool.Abjuration, "Abjuration" },
            { MagicSchool.Conjuration, "Conjuration" },
            { MagicSchool.Divination, "Divination" },
            { MagicSchool.Enchantment, "Enchantment" },
            { MagicSchool.Evocation, "Evocation" },
            { MagicSchool.Illusion, "Illusion" },
            { MagicSchool.Necromancy, "Necromancy" },
            { MagicSchool.Transmutation, "Transmutation" }
        };
        public Dictionary<WeaponCategory, string> WeaponCategoryStrings { get; set; } = new Dictionary<WeaponCategory, string>()
        {
            { WeaponCategory.Simple, "Simple" },
            { WeaponCategory.Martial, "Martial" },
            { WeaponCategory.Exotic, "Exotic" },
            { WeaponCategory.Improvised, "Improvised" },
        };
        public Dictionary<ImpactType, string> ImpactTypeStrings { get; set; } = new Dictionary<ImpactType, string>()
        {
            { ImpactType.Bludgeoning, "Bludgeoning" },
            { ImpactType.Piercing, "Piercing" },
            { ImpactType.Slashing, "Slashing" },
        };
        public Dictionary<ItemEncumbrance, string> ItemEncumbranceStrings { get; set; } = new Dictionary<ItemEncumbrance, string>()
        {
            { ItemEncumbrance.Light, "Light" },
            { ItemEncumbrance.OneHand, "One Handed" },
            { ItemEncumbrance.TwoHand, "Two Handed" },
        };
        public Dictionary<CombatState, string> CombatStateStrings { get; set; } = new Dictionary<CombatState, string>()
        {
            { CombatState.Active, "Active" },
            { CombatState.Incapacitated, "Incapacitated" },
            { CombatState.BleedingOut, "Bleeding Out" },
            { CombatState.Deceased, "Deceased" },
        };
    }
}
