using System;

namespace DiegoG.DnDTDesktop.Other
{
    public interface IFlagged<T> where T : Enum
    {
        FlagsArray<T> Flags { get; set; }
    }
}
