using DiegoG.Utilities.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiegoG.DnDNetCore.Enumerations;

namespace DiegoG.DnDNetCore
{
    public class Lang : ISettings
    {
        public ulong Version { get; } = 1;

        //Other
        public string Currency { get; set; } = " coins";

        //CharacterDescription
        public string GenderText { get; set; } = "Gender";
        public string PersonalityText { get; set; } = "Personality";
        public string ViewIntroButton { get; set; } = "Intro";
        public string ViewBioButton { get; set; } = "Biography";
        public string FullNameText { get; set; } = "Full Name";
        public string ExpLevelText { get; set; } = "Exp. Level";
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
        public string ViewNotesButton { get; set; } = "View Notes";

        //CharacterSkills
        public string SkillNameText { get; set; } = "Skill Name";
        public string KeyStatText { get; set; } = "Key Stat";
        public string SkillModifierText { get; set; } = "Skill Modifier";
        public string RanksText { get; set; } = "Rank";
        public string MiscRanksText { get; set; } = "Misc. Rank";
        public string OtherRanksText { get; set; } = "Extra Rank";
        public string ArmorPenalizerText { get; set; } = "Armor Penalizer";
        public string SkillFlagsText { get; set; } = "Skill Flags";

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
    }
}
