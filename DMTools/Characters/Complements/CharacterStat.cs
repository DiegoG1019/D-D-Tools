using System;
using System.Collections;
using System.Collections.Generic;

namespace DiegoG.DnDTDesktop.Characters.Complements
{
    [Serializable]
    public class CharacterStat<TStat, TProperty> : CharacterTrait<CharacterStat<TStat, TProperty>>, IEnumerable<KeyValuePair<TStat, TProperty>> where TStat : Enum where TProperty : CharacterTrait<TProperty>, ICharacterProperty, new()
    {
        public TProperty[] StatsArray { get; set; }
        public TStat[] KeyArray { get; set; }

        public TProperty this[TStat ind]
        {
            get => StatsArray[Convert.ToInt32(ind)];
            set => StatsArray[Convert.ToInt32(ind)] = value;
        }
        public IEnumerator<KeyValuePair<TStat, TProperty>> GetEnumerator()
        {
            for (int i = 0; i < StatsArray.Length; i++)
                yield return new KeyValuePair<TStat, TProperty>((TStat)Enum.ToObject(typeof(TStat), i), StatsArray[i]);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public CharacterStat()
        {
            var count = Enum.GetNames(typeof(TStat)).Length;
            StatsArray = new TProperty[count];
            KeyArray = new TStat[count];
            for (int i = 0; i < count; i++)
                StatsArray[i] = new TProperty() { ParentName = ParentName };
        }
    }
    [Serializable]
    public class SecondaryCharacterStat : CharacterTrait<SecondaryCharacterStat>
    {
        public Dictionary<string, SecondaryCharacterStatProperty> StatsDict { get; set; }
        public event Action DictionaryChanged;

        public SecondaryCharacterStatProperty this[string ind]
        {
            get => StatsDict[ind];
            set
            {
                StatsDict[ind] = value;
                DictionaryChanged();
            }
        }

        public SecondaryCharacterStat() => DictionaryChanged += SecondaryCharacterStat_DictionaryChanged;

        private void SecondaryCharacterStat_DictionaryChanged()
        { }

        public Dictionary<string, SecondaryCharacterStatProperty>.KeyCollection Keys => StatsDict.Keys;
        public Dictionary<string, SecondaryCharacterStatProperty>.ValueCollection Values => StatsDict.Values;
        public void Add(string key, SecondaryCharacterStatProperty value)
        {
            StatsDict.Add(key, value);
            DictionaryChanged();
        }
    }
}
