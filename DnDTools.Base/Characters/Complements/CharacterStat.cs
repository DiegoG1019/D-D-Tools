using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DiegoG.DnDTools.Base.Characters.Complements
{
    [Serializable]
    public class CharacterStat<TStat, TProperty> : CharacterTrait<CharacterStat<TStat, TProperty>> where TStat : Enum where TProperty : CharacterTrait<TProperty>, ICharacterProperty, new()
    {
        public Dictionary<TStat, TProperty> Stats { get => StatsField; set { StatsField = value; NotifyPropertyChanged(); } }
        private Dictionary<TStat, TProperty> StatsField = new Dictionary<TStat, TProperty>();

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public TProperty this[TStat ind]
        {
            get => Stats[ind];
            set { Stats[ind] = value; NotifyPropertyChanged(); }
        }
        public CharacterStat() { }
        public CharacterStat(string parentName)
        {
            ParentName = parentName;
            var count = Enum.GetValues(typeof(TStat));
            foreach (var v in count)
                Stats[(TStat)v] = new TProperty() { ParentName = parentName };
        }
    }
    [Serializable]
    public class SecondaryCharacterStats : CharacterTrait<SecondaryCharacterStats>
    {
        public Dictionary<string, SecondaryCharacterStatProperty> Stats { get; set; } = new Dictionary<string, SecondaryCharacterStatProperty>();
        /// <summary>
        /// Case Insensitive
        /// </summary>
        /// <param name="ind"></param>
        /// <returns></returns>
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public SecondaryCharacterStatProperty this[string ind]
        {
            get => Stats[ind.ToLower()];
            set
            {
                Stats[ind.ToLower()] = value;
                NotifyPropertyChanged();
            }
        }
        /// <summary>
        /// Case Insensitive
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, SecondaryCharacterStatProperty value)
        {
            Stats.Add(key.ToLower(), value);
            NotifyPropertyChanged();
        }
    }
}
