using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DiegoG.DnDTDesktop.Characters.Complements
{
    [Serializable]
    public class CharacterStat<TStat> : IEnumerable<CharacterStatProperty<TStat>> where TStat : Enum
    {
        public CharacterStatProperty<TStat>[] StatsArray { get; set; }

        public CharacterStatProperty<TStat> this[TStat ind]
        {
            get => StatsArray[Convert.ToInt32(ind)];
            set => StatsArray[Convert.ToInt32(ind)] = value;
        }
        public IEnumerator<CharacterStatProperty<TStat>> GetEnumerator()
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
            StatsArray = new CharacterStatProperty<TStat>[count];
            for(int i = 0; i < count; i++)
            {
                StatsArray[i] = new CharacterStatProperty<TStat>();
            }
        }
    }
}
