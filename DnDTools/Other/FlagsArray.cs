using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DiegoG.DnDNetCore.Other
{
    [Serializable]
    public class FlagsArray<T> : IEnumerable<(T Flag, bool Value)> where T : Enum
    {
        public IEnumerable<T> Flags => Enum.GetValues(typeof(T)).Cast<T>();
        public int Size = Enum.GetNames(typeof(T)).Length;
        public bool[] array;
        public bool this[T ind]
        {
            get => array[Convert.ToInt32(ind)];
            set => array[Convert.ToInt32(ind)] = value;
        }
        public FlagsArray() => array = new bool[Size];
        public FlagsArray(bool[] a)
        {
            if (a.Length != Size)
                throw new InvalidOperationException("array is a different size than its associated Enum");
            array = a;
        }
        public FlagsArray(FlagsArray<T> Other) : this(Other.array) { }
        public IEnumerator<(T Flag, bool Value)> GetEnumerator()
        {
            foreach (var i in Flags)
                yield return (i, this[i]);
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
