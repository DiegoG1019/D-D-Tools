using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DiegoG.DnDTools.Base.Characters.Complements
{
    [Serializable]
    public class CharacterStatProperty : CharacterTrait<CharacterStatProperty>, ICharacterProperty
    {
        public int BasePoints { get => BasePointsField; set { BasePointsField = value; NotifyPropertyChanged(); } }
        private int BasePointsField;
        public int Bonus { get => BonusField; set { BonusField = value; NotifyPropertyChanged(); } }
        private int BonusField;

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int EffectPoints { get => EffectPointsField; set { EffectPointsField = value; NotifyPropertyChanged(); } }
        private int EffectPointsField;
        
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int BaseTotal => BasePoints + Bonus;
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int BaseModifier => (BaseTotal / 2) - 5;
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int Total => BaseTotal + EffectPoints;
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int Modifier => (Total / 2) - 5;
    }
}
