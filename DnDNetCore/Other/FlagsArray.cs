using System;

namespace DiegoG.DnDNetCore.Other
{
    [Serializable]
    public class FlagsArray<T> where T : Enum
    {
        public int Size = Enum.GetNames(typeof(T)).Length;
        public bool[] array;
        public bool this[T ind]
        {
            get
            {
                return array[Convert.ToInt32(ind)];
            }
            set
            {
                array[Convert.ToInt32(ind)] = value;
            }
        }
        public FlagsArray()
        {
            array = new bool[Size];
        }
        public FlagsArray(bool[] a)
        {
            if (a.Length != Size)
            {
                throw new InvalidOperationException("array is a different size than its associated Enum");
            }
            array = a;
        }
        public FlagsArray(FlagsArray<T> Other) : this(Other.array) { }
    }
}
