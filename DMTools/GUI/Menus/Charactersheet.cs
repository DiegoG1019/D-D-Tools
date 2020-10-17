using DiegoG.DnDTDesktop.Characters;
using DiegoG.DnDTDesktop.GUI.Elements.Interfaces;
using System;
using System.Windows.Forms;

namespace DiegoG.DnDTDesktop.GUI.Menus
{
    public partial class Charactersheet : UserControl, ICharacterGUI
    {
        public Charactersheet()
        {
            InitializeComponent();
            HeldCharacterChanged += Charactersheet_HeldCharacterChanged;
        }

        private void Charactersheet_HeldCharacterChanged()
        {
            throw new NotImplementedException();
        }

        public Character HeldCharacter => throw new NotImplementedException();

        public event Action HeldCharacterChanged;
    }
}
