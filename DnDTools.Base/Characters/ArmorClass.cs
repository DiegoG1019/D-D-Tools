using DiegoG.DnDTools.Base.Characters.Complements;
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.Base.Characters
{
    [Serializable]
    public sealed class ArmorClass : CharacterTrait<ArmorClass>
    {
        public int BaseAC { get => BaseACField; set { BaseACField = value; NotifyPropertyChanged(); } }
        private int BaseACField = 10;
        public int Natural { get => NaturalField; set { NaturalField = value; NotifyPropertyChanged(); } }
        private int NaturalField;
        public int Deflection { get => DeflectionField; set { DeflectionField = value; NotifyPropertyChanged(); } }
        private int DeflectionField;
        /// <summary>
        /// Whether or not to use Dexterity when calculating UnawareAC
        /// </summary>
        public bool UnawareDex { get => UnawareDexField; set { UnawareDexField = value; NotifyPropertyChanged(); } }
        private bool UnawareDexField;
        public int Bonus { get => BonusField; set { BonusField = value; NotifyPropertyChanged(); } }
        private int BonusField;
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int Effect { get => EffectField; set { EffectField = value; NotifyPropertyChanged(); } }
        private int EffectField;
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int Armor => Parent.Equipped.ArmorAC;

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int AC => BaseAC + Armor + Size + Natural + Deflection + Bonus + Effect + Parent.Stats[Stats.Dexterity].Modifier;

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int TouchAC => BaseAC + Size + Effect + Deflection + Parent.Stats[Stats.Dexterity].Modifier;

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int UnawareAC => BaseAC + Armor + Size + Natural + Effect + (UnawareDex ? Parent.Stats[Stats.Dexterity].Modifier : 0);

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int Size => GetSizeACComparison(Parent.Description.Size);

        public int ACSizeCompare(Sizes otherSize)
            => GetSizeACComparison(Parent.Description.Size, otherSize);
        public static int GetSizeACComparison(Sizes thisSize, Sizes otherSize = Sizes.Medium)
            => GetSizeAC(thisSize) - GetSizeAC(otherSize);
        public static int GetSizeAC(Sizes size)
            => size switch
            {
                Sizes.Fine => 4,
                Sizes.Diminutive => 3,
                Sizes.Tiny => 2,
                Sizes.Small => 1,
                Sizes.Medium => 0,
                Sizes.Large => -1,
                Sizes.Huge => -2,
                Sizes.Gargantuan => -3,
                Sizes.Colossal => -4,
                _ => throw new NotSupportedException("Unknown Size enum value"),
            };
    }
}
