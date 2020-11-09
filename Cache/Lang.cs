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
        public ulong Version { get; } = 0;

        public string Currency { get; set; } = " coins";
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
        }; public Dictionary<Sizes, string> SizeStrings { get; set; } = new Dictionary<Sizes, string>()
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
    }
}
