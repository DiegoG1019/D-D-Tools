using DiegoG.DnDTDesktop.Characters;
using DiegoG.DnDTDesktop.GUI.Elements.Interfaces;
using System;
using System.Windows.Forms;

namespace DiegoG.DnDTDesktop.GUI.Elements.Components
{
    public class CharacterGUIFlowPanel : FlowLayoutPanel, ICharacterGUI, ICharacterGUIElement
    {
        public ICharacterGUI ParentCharacterGUI => (ICharacterGUI)Parent;
        public Character HeldCharacter => ParentCharacterGUI.HeldCharacter;
        public event Action HeldCharacterChanged
        {
            add => ParentCharacterGUI.HeldCharacterChanged += value;
            remove => ParentCharacterGUI.HeldCharacterChanged -= value;
        }
    }
}
