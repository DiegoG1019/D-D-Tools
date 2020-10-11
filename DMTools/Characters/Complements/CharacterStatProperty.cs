using System;
using System.Collections;
using System.Collections.Generic;

namespace DiegoG.DnDTDesktop.Characters.Complements
{
    [Serializable]
    public class CharacterStatProperty<TStat> : IEnumerable<int> where TStat : Enum
    {
        public int[] StatsArray { get; set; }

        public int this[TStat ind]
        {
            get => StatsArray[Convert.ToInt32(ind)];
            set => StatsArray[Convert.ToInt32(ind)] = value;
        }
        public IEnumerator<int> GetEnumerator()
        {
            foreach (var i in StatsArray)
            {
                yield return i;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Don't use this one
        /// </summary>
        public CharacterStatProperty() : this(1) { }
        public CharacterStatProperty(int count)
        {
            StatsArray = new int[count];
        }

        public static CharacterStatProperty<TStat> operator +(CharacterStatProperty<TStat> a, CharacterStatProperty<TStat> b)
        {
            var newcsp = new CharacterStatProperty<TStat>(a.StatsArray.Length);
            for (int i = 0; i < a.StatsArray.Length; i++)
            {
                newcsp.StatsArray[i] = a.StatsArray[i] + b.StatsArray[i];
            }

            return newcsp;
        }
        public static CharacterStatProperty<TStat> operator +(CharacterStatProperty<TStat> a, int b)
        {
            var newcsp = new CharacterStatProperty<TStat>(a.StatsArray.Length);
            for (int i = 0; i < a.StatsArray.Length; i++)
            {
                newcsp.StatsArray[i] = a.StatsArray[i] + b;
            }

            return newcsp;
        }
        public static CharacterStatProperty<TStat> operator -(CharacterStatProperty<TStat> a, CharacterStatProperty<TStat> b)
        {
            var newcsp = new CharacterStatProperty<TStat>(a.StatsArray.Length);
            for (int i = 0; i < a.StatsArray.Length; i++)
            {
                newcsp.StatsArray[i] = a.StatsArray[i] - b.StatsArray[i];
            }

            return newcsp;
        }
        public static CharacterStatProperty<TStat> operator -(CharacterStatProperty<TStat> a, int b)
        {
            var newcsp = new CharacterStatProperty<TStat>(a.StatsArray.Length);
            for (int i = 0; i < a.StatsArray.Length; i++)
            {
                newcsp.StatsArray[i] = a.StatsArray[i] - b;
            }

            return newcsp;
        }
        public static CharacterStatProperty<TStat> operator /(CharacterStatProperty<TStat> a, int b)
        {
            var newcsp = new CharacterStatProperty<TStat>(a.StatsArray.Length);
            for (int i = 0; i < a.StatsArray.Length; i++)
            {
                newcsp.StatsArray[i] = a.StatsArray[i] / b;
            }

            return newcsp;
        }
        public static CharacterStatProperty<TStat> operator *(CharacterStatProperty<TStat> a, int b)
        {
            var newcsp = new CharacterStatProperty<TStat>(a.StatsArray.Length);
            for (int i = 0; i < a.StatsArray.Length; i++)
            {
                newcsp.StatsArray[i] = a.StatsArray[i] * b;
            }

            return newcsp;
        }
    }
}
