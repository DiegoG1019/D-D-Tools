using DiegoG.DnDTools.Base.Characters.Complements;
using DiegoG.DnDTools.Base.Other;
using System;
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
        private int BaseACField;
        public int Size { get => SizeField; set { SizeField = value; NotifyPropertyChanged(); } }
        private int SizeField;
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

    }
}
