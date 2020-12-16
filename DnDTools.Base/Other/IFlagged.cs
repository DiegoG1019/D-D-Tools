using System;

namespace DiegoG.DnDTools.Base.Other
{
    public interface IFlagged<T> where T : Enum
    {
        FlagsArray<T> Flags { get; set; }
    }
}
