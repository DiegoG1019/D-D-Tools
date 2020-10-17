using System;

namespace DiegoG.DnDTDesktop.GUI.Elements.Interfaces
{
    public interface ICharacterGUI : ICharacterHolderGUI
    {
        event Action HeldCharacterChanged;
    }
}
