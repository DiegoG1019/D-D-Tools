using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DiegoG.DnDTools.Base.Characters.Complements
{
    [Serializable]
    public class CharacterStat<TStat, TProperty> : CharacterTrait<CharacterStat<TStat, TProperty>> where TStat : Enum where TProperty : CharacterTrait<TProperty>, ICharacterProperty, new()
    {
        public Dictionary<TStat, TProperty> Stats { get; set; } = new Dictionary<TStat, TProperty>();

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public TProperty this[TStat ind]
        {
            get => Stats[ind];
            set => Stats[ind] = value;
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
        public event Action DictionaryChanged;
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
                DictionaryChanged();
            }
        }

        public SecondaryCharacterStats() => DictionaryChanged += SecondaryCharacterStat_DictionaryChanged;
        private void SecondaryCharacterStat_DictionaryChanged() { }
        /// <summary>
        /// Case Insensitive
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, SecondaryCharacterStatProperty value)
        {
            Stats.Add(key.ToLower(), value);
            DictionaryChanged();
        }
    }
}
