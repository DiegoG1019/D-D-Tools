using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using DiegoG.DnDTools.Base.Scripting;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DiegoG.DnDTools.Base.Characters.Complements
{
    public class SecondaryCharacterStatProperty : CharacterTrait<SecondaryCharacterStatProperty>, ICharacterProperty, INotifyPropertyChanged
    {
        public int BasePoints { get => BasePointsField; set {BasePointsField = value;
                NotifyPropertyChanged();
            } }
        private int BasePointsField;
        public int Bonus { get => BonusField; set {BonusField = value;
                NotifyPropertyChanged();
            } }
        private int BonusField;
        public int EffectPoints { get => EffectPointsField; set {EffectPointsField = value;
                NotifyPropertyChanged();
            } }
        private int EffectPointsField;
        public CharacterPropertyScript ScriptData { get; set; }

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int BaseTotal => BasePoints + Bonus + DependentValue;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int Total => BaseTotal + EffectPoints;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int Modifier => (Total / 2) - 5;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int BaseModifier => (BaseTotal / 2) - 5;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public bool HasScript => ScriptData != null;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int DependentValue => (HasScript ? ScriptData.DependentValue(Parent, this) : 0);
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int OtherValue => (HasScript ? ScriptData.OtherValue(Parent, this) : 0);
    }
}
