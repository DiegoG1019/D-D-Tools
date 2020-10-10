using System;
using static DiegoG.DnDTDesktop.Enums;

namespace DiegoG.DnDTDesktop.Characters
{
    [Serializable]
    public class Character
    {
        public int GetModifier(Stats stat) => throw new NotImplementedException();
        public Experience Experience { get; set; }
    }
}
