using DiegoG.DnDTDesktop.Characters;
using DiegoG.DnDTDesktop.GUI.Elements.Interfaces;
using System;
using System.Windows.Forms;

namespace DiegoG.DnDTDesktop.GUI.Elements.Components
{
    public class CharacterUserControl : UserControl, ICharacterGUI, ICharacterGUIElement
    {
        public ICharacterGUI ParentCharacterGUI => (ICharacterGUI)Parent;
        public Character HeldCharacter => ParentCharacterGUI.HeldCharacter;
        public event Action HeldCharacterChanged
        {
            add => ParentCharacterGUI.HeldCharacterChanged += value;
            remove => ParentCharacterGUI.HeldCharacterChanged -= value;
        }
        public virtual void Init()
        {
            if (!(Parent is ICharacterGUI) && !(Parent is ICharacterGUIElement))
                throw new Exception("Parent must be implement ICharacterGUI");
            ParentCharacterGUI.HeldCharacterChanged += CharacterUserControl_HeldCharacterChanged;
            CharacterUserControl_HeldCharacterChanged();
        }
        protected virtual void CharacterUserControl_HeldCharacterChanged() { }
    }
}
