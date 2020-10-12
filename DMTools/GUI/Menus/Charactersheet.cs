using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiegoG.DnDTDesktop.GUI.Elements;
using DiegoG.DnDTDesktop.Characters;

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
