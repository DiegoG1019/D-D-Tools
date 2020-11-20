using System;

namespace DiegoG.DnDNetCore.Other
{
    public interface IFlagged<T> where T : Enum
    {
        FlagsArray<T> Flags { get; set; }
    }
}
