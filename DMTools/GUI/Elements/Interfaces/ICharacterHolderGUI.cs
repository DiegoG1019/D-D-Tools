using DiegoG.DnDTDesktop.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.DnDTDesktop.GUI.Elements.Interfaces
{
    public interface ICharacterHolderGUI
    {
        Character HeldCharacter { get; }
    }
}
