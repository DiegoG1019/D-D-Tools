using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.Base.Characters.Complements
{
    [Serializable]
    public class CharacterSavingThrowProperty : CharacterTrait<CharacterSavingThrowProperty>, ICharacterProperty
    {
        public Stats BaseStat { get => BaseStatField; set { BaseStatField = value; NotifyPropertyChanged(); } }
        private Stats BaseStatField;
        public int BasePoints { get => BasePointsField; set { BasePointsField = value; NotifyPropertyChanged(); } }
        private int BasePointsField;
        public int Bonus { get => BonusField; set {BonusField = value;
                NotifyPropertyChanged();
            } }
        private int BonusField;
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int EffectPoints { get => EffectPointsField; set {EffectPointsField = value;
                NotifyPropertyChanged();
            } }
        private int EffectPointsField;
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int BaseTotal => BasePoints + Parent.Stats[BaseStat].Total + Bonus;
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int Total => BaseTotal + EffectPoints;
    }
}
