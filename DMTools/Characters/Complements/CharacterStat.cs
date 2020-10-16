using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DiegoG.DnDTDesktop.Characters.Complements
{
    [Serializable]
    public class CharacterStat<TStat, TProperty> : CharacterTrait<CharacterStat<TStat, TProperty>>, IEnumerable<TProperty> where TStat : Enum where TProperty : CharacterTrait<TProperty>, ICharacterProperty, new()
    {
        public TProperty[] StatsArray { get; set; }

        public TProperty this[TStat ind]
        {
            get => StatsArray[Convert.ToInt32(ind)];
            set => StatsArray[Convert.ToInt32(ind)] = value;
        }
        public IEnumerator<TProperty> GetEnumerator()
        {
            foreach (var i in StatsArray)
            {
                yield return i;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public CharacterStat()
        {
            var count = Enum.GetNames(typeof(TStat)).Length;
            StatsArray = new TProperty[count];
            for(int i = 0; i < count; i++)
            {
                StatsArray[i] = new TProperty() { ParentName = ParentName };
            }
        }
    }
}
