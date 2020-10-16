using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.DnDTDesktop.Characters.Complements
{
    public interface ICharacterProperty
    {
        int BasePoints { get; }
        int Bonus { get; }
        int EffectPoints { get; }
        int BaseTotal { get; }
        int Total { get; }
    }
}
